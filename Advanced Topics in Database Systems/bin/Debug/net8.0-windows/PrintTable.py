import json
import pandas as pd
import matplotlib.pyplot as plt

# Load JSON data
with open('Stats.json', 'r') as file:
    data = json.load(file)

# Prepare a dictionary to store data by isolation level
results = {
    'ReadUncommitted': {
        'Number of Type A Users': [],
        'Number of Type B Users': [],
        'Average Duration\nof Type A Threads (ms)': [],
        'Average Duration\nof Type B Threads (ms)': [],
        'Number of Deadlocks\nEncountered by\nType A Users': [],
        'Number of Deadlocks\nEncountered by\nType B Users': [],
        'Timeouts A (ms)': [],
        'Timeouts B (ms)': []
    },
    'ReadCommitted': {
        'Number of Type A Users': [],
        'Number of Type B Users': [],
        'Average Duration\nof Type A Threads (ms)': [],
        'Average Duration\nof Type B Threads (ms)': [],
        'Number of Deadlocks\nEncountered by\nType A Users': [],
        'Number of Deadlocks\nEncountered by\nType B Users': [],
        'Timeouts A (ms)': [],
        'Timeouts B (ms)': []
    },
    'RepeatableRead': {
        'Number of Type A Users': [],
        'Number of Type B Users': [],
        'Average Duration\nof Type A Threads (ms)': [],
        'Average Duration\nof Type B Threads (ms)': [],
        'Number of Deadlocks\nEncountered by\nType A Users': [],
        'Number of Deadlocks\nEncountered by\nType B Users': [],
        'Timeouts A (ms)': [],
        'Timeouts B (ms)': []
    },
    'Serializable': {
        'Number of Type A Users': [],
        'Number of Type B Users': [],
        'Average Duration\nof Type A Threads (ms)': [],
        'Average Duration\nof Type B Threads (ms)': [],
        'Number of Deadlocks\nEncountered by\nType A Users': [],
        'Number of Deadlocks\nEncountered by\nType B Users': [],
        'Timeouts A (ms)': [],
        'Timeouts B (ms)': []
    }
}

# Process each simulation dynamically
for simulation_key, simulation in data.items():
    for key, stats in simulation.items():
        if "ReadUncommitted" in key:
            isolation_level = 'ReadUncommitted'
        elif "ReadCommitted" in key:
            isolation_level = 'ReadCommitted'
        elif "RepeatableRead" in key:
            isolation_level = 'RepeatableRead'
        elif "Serializable" in key:
            isolation_level = 'Serializable'
        else:
            continue

        if "TypeA" in key:
            results[isolation_level]['Number of Type A Users'].append(stats['TotalRuns'])
            if stats['TotalRuns'] > 0:
                results[isolation_level]['Average Duration\nof Type A Threads (ms)'].append(stats['TotalDuration'] / stats['TotalRuns'])
            else:
                results[isolation_level]['Average Duration\nof Type A Threads (ms)'].append(0)
            results[isolation_level]['Number of Deadlocks\nEncountered by\nType A Users'].append(stats['TotalDeadlocks'])
            results[isolation_level]['Timeouts A (ms)'].append(stats.get('TotalTimeoutDuration', 0))
        elif "TypeB" in key:
            results[isolation_level]['Number of Type B Users'].append(stats['TotalRuns'])
            if stats['TotalRuns'] > 0:
                results[isolation_level]['Average Duration\nof Type B Threads (ms)'].append(stats['TotalDuration'] / stats['TotalRuns'])
            else:
                results[isolation_level]['Average Duration\nof Type B Threads (ms)'].append(0)
            results[isolation_level]['Number of Deadlocks\nEncountered by\nType B Users'].append(stats['TotalDeadlocks'])
            results[isolation_level]['Timeouts B (ms)'].append(stats.get('TotalTimeoutDuration', 0))

# Create a DataFrame and plot for each isolation level
for isolation_level, result in results.items():
    df = pd.DataFrame(result)

    # Plot the DataFrame as a table
    fig, ax = plt.subplots(figsize=(15, 6))
    ax.axis('tight')
    ax.axis('off')
    table = ax.table(cellText=df.values, colLabels=df.columns, cellLoc='center', loc='center', colWidths=[0.2]*len(df.columns),
                     cellColours=[['#f1f1f1']*len(df.columns)]*len(df),
                     bbox=[0, 0, 1, 1])

    # Adjust fontsize and scale for better display
    table.auto_set_font_size(False)
    table.set_fontsize(8)
    table.scale(1.5, 1.5)

    plt.title(f"Isolation Level: {isolation_level}")
    plt.show()
