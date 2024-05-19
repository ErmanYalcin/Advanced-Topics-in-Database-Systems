namespace Advanced_Topics_in_Database_Systems
{
    partial class Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            StartThreads = new Button();
            flowLayoutPanelTypeA = new FlowLayoutPanel();
            checkBox1TypeA = new CheckBox();
            checkBox20TypeA = new CheckBox();
            checkBox100TypeA = new CheckBox();
            checkBox200TypeA = new CheckBox();
            checkBox500TypeA = new CheckBox();
            checkBox1000TypeA = new CheckBox();
            flowLayoutPanelTypeB = new FlowLayoutPanel();
            checkBox1TypeB = new CheckBox();
            checkBox20TypeB = new CheckBox();
            checkBox100TypeB = new CheckBox();
            checkBox200TypeB = new CheckBox();
            checkBox500TypeB = new CheckBox();
            checkBox1000TypeB = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            labelDurum = new Label();
            progressBar1 = new ProgressBar();
            label3 = new Label();
            databaseVersion_comboBox = new ComboBox();
            isolationLVL_comboBox = new ComboBox();
            label4 = new Label();
            flowLayoutPanelTypeA.SuspendLayout();
            flowLayoutPanelTypeB.SuspendLayout();
            SuspendLayout();
            // 
            // StartThreads
            // 
            StartThreads.Location = new Point(216, 577);
            StartThreads.Name = "StartThreads";
            StartThreads.Size = new Size(158, 47);
            StartThreads.TabIndex = 0;
            StartThreads.Text = "Start Experiment";
            StartThreads.UseVisualStyleBackColor = true;
            StartThreads.Click += StartThreads_Click;
            // 
            // flowLayoutPanelTypeA
            // 
            flowLayoutPanelTypeA.Controls.Add(checkBox1TypeA);
            flowLayoutPanelTypeA.Controls.Add(checkBox20TypeA);
            flowLayoutPanelTypeA.Controls.Add(checkBox100TypeA);
            flowLayoutPanelTypeA.Controls.Add(checkBox200TypeA);
            flowLayoutPanelTypeA.Controls.Add(checkBox500TypeA);
            flowLayoutPanelTypeA.Controls.Add(checkBox1000TypeA);
            flowLayoutPanelTypeA.Location = new Point(14, 264);
            flowLayoutPanelTypeA.Name = "flowLayoutPanelTypeA";
            flowLayoutPanelTypeA.Size = new Size(580, 35);
            flowLayoutPanelTypeA.TabIndex = 1;
            // 
            // checkBox1TypeA
            // 
            checkBox1TypeA.AutoSize = true;
            checkBox1TypeA.Location = new Point(3, 3);
            checkBox1TypeA.Name = "checkBox1TypeA";
            checkBox1TypeA.Size = new Size(72, 24);
            checkBox1TypeA.TabIndex = 0;
            checkBox1TypeA.Text = "1 User";
            checkBox1TypeA.UseVisualStyleBackColor = true;
            // 
            // checkBox20TypeA
            // 
            checkBox20TypeA.AutoSize = true;
            checkBox20TypeA.Location = new Point(81, 3);
            checkBox20TypeA.Name = "checkBox20TypeA";
            checkBox20TypeA.Size = new Size(86, 24);
            checkBox20TypeA.TabIndex = 1;
            checkBox20TypeA.Text = "20 Users";
            checkBox20TypeA.UseVisualStyleBackColor = true;
            // 
            // checkBox100TypeA
            // 
            checkBox100TypeA.AutoSize = true;
            checkBox100TypeA.Location = new Point(173, 3);
            checkBox100TypeA.Name = "checkBox100TypeA";
            checkBox100TypeA.Size = new Size(94, 24);
            checkBox100TypeA.TabIndex = 2;
            checkBox100TypeA.Text = "100 Users";
            checkBox100TypeA.UseVisualStyleBackColor = true;
            // 
            // checkBox200TypeA
            // 
            checkBox200TypeA.AutoSize = true;
            checkBox200TypeA.Location = new Point(273, 3);
            checkBox200TypeA.Name = "checkBox200TypeA";
            checkBox200TypeA.Size = new Size(94, 24);
            checkBox200TypeA.TabIndex = 3;
            checkBox200TypeA.Text = "200 Users";
            checkBox200TypeA.UseVisualStyleBackColor = true;
            // 
            // checkBox500TypeA
            // 
            checkBox500TypeA.AutoSize = true;
            checkBox500TypeA.Location = new Point(373, 3);
            checkBox500TypeA.Name = "checkBox500TypeA";
            checkBox500TypeA.Size = new Size(94, 24);
            checkBox500TypeA.TabIndex = 4;
            checkBox500TypeA.Text = "500 Users";
            checkBox500TypeA.UseVisualStyleBackColor = true;
            // 
            // checkBox1000TypeA
            // 
            checkBox1000TypeA.AutoSize = true;
            checkBox1000TypeA.Location = new Point(473, 3);
            checkBox1000TypeA.Name = "checkBox1000TypeA";
            checkBox1000TypeA.Size = new Size(102, 24);
            checkBox1000TypeA.TabIndex = 5;
            checkBox1000TypeA.Text = "1000 Users";
            checkBox1000TypeA.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelTypeB
            // 
            flowLayoutPanelTypeB.Controls.Add(checkBox1TypeB);
            flowLayoutPanelTypeB.Controls.Add(checkBox20TypeB);
            flowLayoutPanelTypeB.Controls.Add(checkBox100TypeB);
            flowLayoutPanelTypeB.Controls.Add(checkBox200TypeB);
            flowLayoutPanelTypeB.Controls.Add(checkBox500TypeB);
            flowLayoutPanelTypeB.Controls.Add(checkBox1000TypeB);
            flowLayoutPanelTypeB.Location = new Point(9, 375);
            flowLayoutPanelTypeB.Name = "flowLayoutPanelTypeB";
            flowLayoutPanelTypeB.Size = new Size(580, 35);
            flowLayoutPanelTypeB.TabIndex = 6;
            // 
            // checkBox1TypeB
            // 
            checkBox1TypeB.AutoSize = true;
            checkBox1TypeB.Location = new Point(3, 3);
            checkBox1TypeB.Name = "checkBox1TypeB";
            checkBox1TypeB.Size = new Size(72, 24);
            checkBox1TypeB.TabIndex = 0;
            checkBox1TypeB.Text = "1 User";
            checkBox1TypeB.UseVisualStyleBackColor = true;
            // 
            // checkBox20TypeB
            // 
            checkBox20TypeB.AutoSize = true;
            checkBox20TypeB.Location = new Point(81, 3);
            checkBox20TypeB.Name = "checkBox20TypeB";
            checkBox20TypeB.Size = new Size(86, 24);
            checkBox20TypeB.TabIndex = 1;
            checkBox20TypeB.Text = "20 Users";
            checkBox20TypeB.UseVisualStyleBackColor = true;
            // 
            // checkBox100TypeB
            // 
            checkBox100TypeB.AutoSize = true;
            checkBox100TypeB.Location = new Point(173, 3);
            checkBox100TypeB.Name = "checkBox100TypeB";
            checkBox100TypeB.Size = new Size(94, 24);
            checkBox100TypeB.TabIndex = 2;
            checkBox100TypeB.Text = "100 Users";
            checkBox100TypeB.UseVisualStyleBackColor = true;
            // 
            // checkBox200TypeB
            // 
            checkBox200TypeB.AutoSize = true;
            checkBox200TypeB.Location = new Point(273, 3);
            checkBox200TypeB.Name = "checkBox200TypeB";
            checkBox200TypeB.Size = new Size(94, 24);
            checkBox200TypeB.TabIndex = 3;
            checkBox200TypeB.Text = "200 Users";
            checkBox200TypeB.UseVisualStyleBackColor = true;
            // 
            // checkBox500TypeB
            // 
            checkBox500TypeB.AutoSize = true;
            checkBox500TypeB.Location = new Point(373, 3);
            checkBox500TypeB.Name = "checkBox500TypeB";
            checkBox500TypeB.Size = new Size(94, 24);
            checkBox500TypeB.TabIndex = 4;
            checkBox500TypeB.Text = "500 Users";
            checkBox500TypeB.UseVisualStyleBackColor = true;
            // 
            // checkBox1000TypeB
            // 
            checkBox1000TypeB.AutoSize = true;
            checkBox1000TypeB.Location = new Point(473, 3);
            checkBox1000TypeB.Name = "checkBox1000TypeB";
            checkBox1000TypeB.Size = new Size(102, 24);
            checkBox1000TypeB.TabIndex = 5;
            checkBox1000TypeB.Text = "1000 Users";
            checkBox1000TypeB.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(164, 226);
            label1.Name = "label1";
            label1.Size = new Size(282, 20);
            label1.TabIndex = 7;
            label1.Text = "Please Select Number of Users for Type A";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(164, 340);
            label2.Name = "label2";
            label2.Size = new Size(281, 20);
            label2.TabIndex = 8;
            label2.Text = "Please Select Number of Users for Type B";
            // 
            // labelDurum
            // 
            labelDurum.AutoSize = true;
            labelDurum.ForeColor = Color.Red;
            labelDurum.Location = new Point(228, 525);
            labelDurum.Name = "labelDurum";
            labelDurum.Size = new Size(130, 20);
            labelDurum.TabIndex = 9;
            labelDurum.Text = "Durum: Başlamadı";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(233, 492);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(125, 16);
            progressBar1.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(216, 33);
            label3.Name = "label3";
            label3.Size = new Size(124, 20);
            label3.TabIndex = 11;
            label3.Text = "Database Version";
            // 
            // databaseVersion_comboBox
            // 
            databaseVersion_comboBox.FormattingEnabled = true;
            databaseVersion_comboBox.Location = new Point(216, 66);
            databaseVersion_comboBox.Name = "databaseVersion_comboBox";
            databaseVersion_comboBox.Size = new Size(183, 28);
            databaseVersion_comboBox.TabIndex = 12;
            // 
            // isolationLVL_comboBox
            // 
            isolationLVL_comboBox.FormattingEnabled = true;
            isolationLVL_comboBox.Location = new Point(216, 154);
            isolationLVL_comboBox.Name = "isolationLVL_comboBox";
            isolationLVL_comboBox.Size = new Size(183, 28);
            isolationLVL_comboBox.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(216, 117);
            label4.Name = "label4";
            label4.Size = new Size(183, 20);
            label4.TabIndex = 13;
            label4.Text = "Transaction Isolation Level";
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(608, 656);
            Controls.Add(isolationLVL_comboBox);
            Controls.Add(label4);
            Controls.Add(databaseVersion_comboBox);
            Controls.Add(label3);
            Controls.Add(progressBar1);
            Controls.Add(labelDurum);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanelTypeA);
            Controls.Add(StartThreads);
            Controls.Add(flowLayoutPanelTypeB);
            Name = "Form";
            Text = "Form1";
            flowLayoutPanelTypeA.ResumeLayout(false);
            flowLayoutPanelTypeA.PerformLayout();
            flowLayoutPanelTypeB.ResumeLayout(false);
            flowLayoutPanelTypeB.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Button StartThreads;
        private FlowLayoutPanel flowLayoutPanelTypeA;
        private CheckBox checkBox1TypeA;
        private CheckBox checkBox20TypeA;
        private CheckBox checkBox100TypeA;
        private CheckBox checkBox200TypeA;
        private CheckBox checkBox500TypeA;
        private CheckBox checkBox1000TypeA;
        private FlowLayoutPanel flowLayoutPanelTypeB;
        private CheckBox checkBox1TypeB;
        private CheckBox checkBox20TypeB;
        private CheckBox checkBox100TypeB;
        private CheckBox checkBox200TypeB;
        private CheckBox checkBox500TypeB;
        private CheckBox checkBox1000TypeB;
        private Label label1;
        private Label label2;
        private Label labelDurum;
        private DataGridView dataGridViewResults;
        private ProgressBar progressBar1;
        private Label label3;
        private ComboBox databaseVersion_comboBox;
        private ComboBox isolationLVL_comboBox;
        private Label label4;
    }
}
