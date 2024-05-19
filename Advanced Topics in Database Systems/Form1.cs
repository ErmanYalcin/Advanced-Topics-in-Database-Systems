using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Advanced_Topics_in_Database_Systems
{
    public partial class Form : System.Windows.Forms.Form
    {
        private const string CounterFilePath = @"SimulationCounter.txt";
        private ConcurrentDictionary<string, ThreadStats> cumulativeResults = new ConcurrentDictionary<string, ThreadStats>();

        public Form()
        {
            InitializeComponent();

            checkBox1TypeA.Checked = true;
            checkBox1TypeB.Checked = true;

            isolationLVL_comboBox.Items.AddRange(new object[]
            {
                IsolationLevel.ReadUncommitted,
                IsolationLevel.ReadCommitted,
                IsolationLevel.RepeatableRead,
                IsolationLevel.Serializable
            });
            isolationLVL_comboBox.SelectedIndex = 0;

            databaseVersion_comboBox.Items.AddRange(new object[]
            {
                "Part 1: Without indexes ✘",
                "Part 2: With indexes ✔"
            });
            databaseVersion_comboBox.SelectedIndex = 0;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            // Event handlers for type A checkboxes
            checkBox1TypeA.CheckedChanged += CheckBox_CheckedChanged_A;
            checkBox20TypeA.CheckedChanged += CheckBox_CheckedChanged_A;
            checkBox100TypeA.CheckedChanged += CheckBox_CheckedChanged_A;
            checkBox200TypeA.CheckedChanged += CheckBox_CheckedChanged_A;
            checkBox500TypeA.CheckedChanged += CheckBox_CheckedChanged_A;
            checkBox1000TypeA.CheckedChanged += CheckBox_CheckedChanged_A;

            // Event handlers for type B checkboxes
            checkBox1TypeB.CheckedChanged += CheckBox_CheckedChanged_B;
            checkBox20TypeB.CheckedChanged += CheckBox_CheckedChanged_B;
            checkBox100TypeB.CheckedChanged += CheckBox_CheckedChanged_B;
            checkBox200TypeB.CheckedChanged += CheckBox_CheckedChanged_B;
            checkBox500TypeB.CheckedChanged += CheckBox_CheckedChanged_B;
            checkBox1000TypeB.CheckedChanged += CheckBox_CheckedChanged_B;
        }

        private void CheckBox_CheckedChanged_A(object sender, EventArgs e)
        {
            CheckBox senderCheckBox = sender as CheckBox;

            if (senderCheckBox != null && senderCheckBox.Checked)
            {
                foreach (Control control in flowLayoutPanelTypeA.Controls)
                {
                    if (control is CheckBox checkBox && checkBox != senderCheckBox)
                    {
                        checkBox.Checked = false;
                    }
                }
            }
        }

        private void CheckBox_CheckedChanged_B(object sender, EventArgs e)
        {
            CheckBox senderCheckBox = sender as CheckBox;

            if (senderCheckBox != null && senderCheckBox.Checked)
            {
                foreach (Control control in flowLayoutPanelTypeB.Controls)
                {
                    if (control is CheckBox checkBox && checkBox != senderCheckBox)
                    {
                        checkBox.Checked = false;
                    }
                }
            }
        }

        private void StartThreads_Click(object sender, EventArgs e)
        {
            labelDurum.Text = "Durum: Başladı";
            labelDurum.ForeColor = Color.Yellow;

            int countTypeA = GetSelectedCount(flowLayoutPanelTypeA);
            int countTypeB = GetSelectedCount(flowLayoutPanelTypeB);

            IsolationLevel selectedIsolationLevel = (IsolationLevel)isolationLVL_comboBox.SelectedItem;
            string connectionString = GetConnectionString(databaseVersion_comboBox.SelectedItem.ToString());

            progressBar1.Value = 0; // ProgressBar'ı sıfırla
            int totalOperations = (countTypeA + countTypeB) * 100; // Toplam işlemi hesapla

            var threads = new List<Thread>();
            StartUserThreads(countTypeA, "TypeA", selectedIsolationLevel, connectionString, totalOperations, threads);
            StartUserThreads(countTypeB, "TypeB", selectedIsolationLevel, connectionString, totalOperations, threads);

            // Tüm thread'lerin bitmesini bekle
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            int simulationCounter = LoadSimulationCounter();
            SaveAllResultsToJson($"Simulation_{simulationCounter}_Isolation_{selectedIsolationLevel}_DB_{databaseVersion_comboBox.SelectedItem}");
            SaveSimulationCounter(simulationCounter + 1);

            labelDurum.Text = "Durum: Kaydedildi";
            labelDurum.ForeColor = Color.Green;

            RunPythonScript("PrintTable.py");
        }

        private int GetSelectedCount(FlowLayoutPanel panel)
        {
            foreach (CheckBox checkBox in panel.Controls)
            {
                if (checkBox.Checked)
                {
                    return int.Parse(checkBox.Text.ToString().Split(' ')[0]);
                }
            }
            return 0;
        }

        private string GetConnectionString(string selectedDatabaseVersion)
        {
            return selectedDatabaseVersion == "Part 1: Without indexes ✘"
                ? "Server=localhost;Database=AdventureWorks2022WithoutIndexes;Integrated Security=True;"
                : "Server=localhost;Database=AdventureWorks2022WithIndexes;Integrated Security=True;";
        }

        private void StartUserThreads(int userCount, string userType, IsolationLevel isolationLevel, string connectionString, int totalOperations, List<Thread> threads)
        {
            for (int i = 0; i < userCount; i++)
            {
                int threadIndex = i; // Local değişken
                Thread thread = new Thread(() => RunDatabaseOperations(userType, threadIndex, isolationLevel, connectionString, totalOperations));
                threads.Add(thread);
                thread.Start();
            }
        }

        private void RunDatabaseOperations(string type, int threadNumber, IsolationLevel isolationLevel, string connectionString, int totalOperations)
        {
            Debug.WriteLine($"{type} operation started for Thread Number {threadNumber} with {isolationLevel} isolation level on {connectionString}.");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int deadlocks = 0;
            long totalTimeoutDuration = 0; // Timeout sürelerini izlemek için yeni değişken
            int timeouts = 0; // Toplam timeout sayısını izlemek için yeni değişken

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Failed to open connection: {ex.Message}");
                    return; // Exit if connection fails
                }

                for (int i = 0; i < 100; i++)
                {
                    Debug.WriteLine($"{type} - Thread {threadNumber} - İşlem {i} başladı.");
                    using (SqlCommand command = new SqlCommand())
                    {
                        SqlTransaction transaction = null;
                        try
                        {
                            transaction = connection.BeginTransaction(isolationLevel);
                            command.Connection = connection;
                            command.Transaction = transaction;

                            if (type == "TypeA")
                            {
                                PerformUpdateOperations(command);
                            }
                            else if (type == "TypeB")
                            {
                                PerformSelectOperations(command);
                            }

                            transaction.Commit();
                        }
                        catch (SqlException ex) when (ex.Number == 1205)
                        {
                            deadlocks++;
                            transaction?.Rollback();
                            Debug.WriteLine("Deadlock encountered. Continuing gracefully.");
                        }
                        catch (SqlException ex) when (ex.Number == -2)
                        {
                            timeouts++;
                            i--;
                            totalTimeoutDuration += 5000; // Assuming 1 second (1000 milliseconds) for each timeout
                            transaction?.Rollback();
                            Debug.WriteLine("Timeout encountered. Continuing gracefully.");
                        }
                        catch (Exception ex)
                        {
                            transaction?.Rollback();
                            Debug.WriteLine($"An exception occurred: {ex.Message}");
                        }
                    }

                    Debug.WriteLine($"{type} - Thread {threadNumber} - İşlem {i} tamamlandı.");
                }
            }

            stopwatch.Stop();

            long adjustedTotalDuration = stopwatch.ElapsedMilliseconds - totalTimeoutDuration;

            cumulativeResults.AddOrUpdate($"{type}_{isolationLevel}_{connectionString}",
            new ThreadStats { TotalRuns = 1, TotalDuration = adjustedTotalDuration, TotalDeadlocks = deadlocks, TotalTimeoutDuration = totalTimeoutDuration },
            (key, existingVal) => new ThreadStats
            {
                TotalRuns = existingVal.TotalRuns + 1,
                TotalDuration = existingVal.TotalDuration + adjustedTotalDuration,
                TotalDeadlocks = existingVal.TotalDeadlocks + deadlocks,
                TotalTimeoutDuration = existingVal.TotalTimeoutDuration + totalTimeoutDuration,
                AverageDuration = (existingVal.TotalDuration + adjustedTotalDuration) / (existingVal.TotalRuns + 1)
            });

            Debug.WriteLine($"{type} operation completed with {isolationLevel} isolation level on {connectionString}. Total duration: {adjustedTotalDuration} ms. Total timeouts: {timeouts}. Total timeout duration: {totalTimeoutDuration} ms.");
        }


        private void PerformUpdateOperations(SqlCommand command)
        {
            string[] dates = { "20110101", "20120101", "20130101", "20140101", "20150101" };
            foreach (string date in dates)
            {
                if (new Random().NextDouble() < 0.5)
                {
                    command.CommandText = $@"
            UPDATE Sales.SalesOrderDetail
            SET UnitPrice = UnitPrice * 10.0 / 10.0
            WHERE UnitPrice > 100
            AND EXISTS (
                SELECT * FROM Sales.SalesOrderHeader
                WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID
                AND Sales.SalesOrderHeader.OrderDate BETWEEN '{date}' AND '{date.Substring(0, 4)}1231'
                AND Sales.SalesOrderHeader.OnlineOrderFlag = 1
            )";
                    command.CommandTimeout = 5;

                    command.ExecuteNonQuery();
                }
            }
        }

        private void PerformSelectOperations(SqlCommand command)
        {
            string[] dates = { "20110101", "20120101", "20130101", "20140101", "20150101" };
            foreach (string date in dates)
            {
                if (new Random().NextDouble() < 0.5)
                {
                    command.CommandText = $@"
            SELECT SUM(Sales.SalesOrderDetail.OrderQty)
            FROM Sales.SalesOrderDetail
            WHERE UnitPrice > 100
            AND EXISTS (
                SELECT * FROM Sales.SalesOrderHeader
                WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID
                AND Sales.SalesOrderHeader.OrderDate BETWEEN '{date}' AND '{date.Substring(0, 4)}1231'
                AND Sales.SalesOrderHeader.OnlineOrderFlag = 1
            )";
                    command.CommandTimeout = 5;
                    command.ExecuteScalar();
                }
            }
        }

        private int LoadSimulationCounter()
        {
            // Dosya varsa, içeriğini oku
            if (File.Exists(CounterFilePath))
            {
                string content = File.ReadAllText(CounterFilePath);
                if (int.TryParse(content, out int counter))
                {
                    return counter;
                }
            }
            return 0; // Dosya yoksa veya içerik geçersizse 0 dön
        }

        private void SaveSimulationCounter(int counter)
        {
            File.WriteAllText(CounterFilePath, counter.ToString());
        }

        private void SaveAllResultsToJson(string simulationId)
        {
            string jsonPath = @"Stats.json";
            Dictionary<string, Dictionary<string, ThreadStats>> simulations;

            if (File.Exists(jsonPath))
            {
                string existingJson = File.ReadAllText(jsonPath);
                simulations = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, ThreadStats>>>(existingJson) ?? new Dictionary<string, Dictionary<string, ThreadStats>>();
            }
            else
            {
                simulations = new Dictionary<string, Dictionary<string, ThreadStats>>();
            }

            Dictionary<string, ThreadStats> currentSimulationResults = new Dictionary<string, ThreadStats>();

            foreach (var entry in cumulativeResults)
            {
                string[] keys = entry.Key.Split('_');
                string type = keys[0];
                string isolationLevel = keys[1];
                string connectionString = keys[2];

                string formattedKey = $"{type}_{isolationLevel}_{connectionString}";
                currentSimulationResults[formattedKey] = entry.Value;
            }

            simulations[simulationId] = currentSimulationResults;

            var json = JsonConvert.SerializeObject(simulations, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonPath, json);
            cumulativeResults.Clear();
        }

        private void RunPythonScript(string scriptName)
        {
            Process pythonProcess = new Process();
            pythonProcess.StartInfo.FileName = "python";
            pythonProcess.StartInfo.Arguments = scriptName;
            pythonProcess.Start();
            //pythonProcess.WaitForExit();
        }
    }

    public class ThreadStats
    {
        public int TotalRuns { get; set; }
        public long TotalDuration { get; set; }
        public int TotalDeadlocks { get; set; }
        public double AverageDuration { get; set; }
        public long TotalTimeoutDuration { get; set; }
    }
}
