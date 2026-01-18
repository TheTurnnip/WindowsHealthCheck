using System.Diagnostics;
using Commands;
using WindowsHealthCheckUI;

namespace WinHealthCheckerUI
{
    public partial class MainMenu : Form
    {
        private static readonly ScanOutput ScanOutput = new();

        // Define a lookup dictionary for system commands where the key is the UI command name,
        // and the value is the CommandRunner instance for the respective command.
        private readonly Dictionary<string, CommandRunner> _commandLookup;

        private readonly List<string> _selectedSystemCommands = new();
        private string? _diskCheckCommand;
        private string? _selectedDisk;
        private CancellationTokenSource? _cancellationTokenSource;
        private bool _isScanning;
        private string? _lastScanOutput;
        private bool _isLastScanSaved = true;
        private string? _existingSaveFilePath;
        private bool _isDiskScanSelected;
        private const string DocumentationUrl = "";
        private const string LicenceUrl = "";

        public MainMenu()
        {
            InitializeComponent();
            
            _commandLookup = new Dictionary<string, CommandRunner>
            {
                {
                    "Run Deployment Image Servicing and Management Restore Health (DISM)",
                    new CommandRunner("ping 8.8.8.8")
                },
                {
                    "Run System File Checker (SFC)",
                    new CommandRunner("ping 1.1.1.1")
                },
            };

            _isDiskScanSelected = radNoScan.Checked;
            
            // Handle changes to the selection of system check commands. 
            chkWindowsSystemChecks.SelectedValueChanged += (_, _) =>
            {
                var previousCommandCount = _selectedSystemCommands.Count;
                _selectedSystemCommands.Clear();
                foreach (var command in chkWindowsSystemChecks.CheckedItems)
                {
                    if (!_selectedSystemCommands.Contains(command.ToString() ?? "unknown"))
                    {
                        _selectedSystemCommands.Add(command.ToString() ?? "unknown");
                    }
                }
                
                var currentCommandCount = _selectedSystemCommands.Count;
                if (currentCommandCount < previousCommandCount)
                {
                    DecrementSelectedCommands();
                }
                if (currentCommandCount > previousCommandCount)
                {
                    IncrementSelectedCommands();
                }
            };
            
            // Handle the disk radio button changes.
            radNoScan.CheckedChanged += RadScanCheckedChanged;
            radScanDiskOnly.CheckedChanged += RadScanCheckedChanged;
            radScanAndFixDisk.CheckedChanged += RadScanCheckedChanged;
            
            // Added the disks to the disk selection combo box.
            var drives = new Drives();
            foreach (var drive in drives.DriveNames)
            {
                cboDiskSelection.Items.Add(drive);
            }
            cboDiskSelection.SelectedIndex = 0;

            cboDiskSelection.SelectedIndexChanged += (_, _) =>
            {
                _selectedDisk = cboDiskSelection.SelectedItem?.ToString();
            };
            
            // Handle the scan start button click event.
            btnStartScans.Click += async (_, _) =>
            {
                Console.WriteLine(_selectedSystemCommands.Count);
                if (!_isLastScanSaved)
                {
                    var result = MessageBox.Show(
                        "There is unsaved scan output. Do you want to save it before starting a new scan?",
                        "Save Scan Output",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question
                    );

                    switch (result)
                    {
                        case DialogResult.Cancel:
                            return;
                        case DialogResult.Yes:
                            SaveScanAsFile();
                            if (!_isLastScanSaved)
                            {
                                return;
                            }
                            break;
                        case DialogResult.No:
                            break;
                    }
                }

                _isScanning = true;
                btnCancelScans.Enabled = true;
                btnStartScans.Enabled = false;
                
                // Initialize the progress bar.
                progressBarScans.Minimum = 0;
                progressBarScans.Maximum = _selectedSystemCommands.Count 
                                           + (_diskCheckCommand is not null ? 1 : 0);
                progressBarScans.Step = 1;
                var progress = new Progress<int>(percent =>
                {
                    // TODO: Implement more granular progress reporting using percent.
                    progressBarScans.PerformStep();
                });
                
                // Prepare the scan output window.
                ScanOutput.ClearOutput();
                ScanOutput.AddNewLine("Starting selected scans...");
                ScanOutput.Show();

                _cancellationTokenSource = new CancellationTokenSource();

                if (_selectedSystemCommands.Count == 0 && _diskCheckCommand is null)
                {
                    ScanOutput.AddNewLine("No scans selected. Please select at least one scan to run.");
                    _isScanning = false;
                    btnStartScans.Enabled = true;
                    btnCancelScans.Enabled = false;
                    return;
                }
                
                // Run the selected system commands.
                foreach (var command in _selectedSystemCommands)
                {
                    var commandRunner = _commandLookup[command];
                    lblCurrentScanValue.Text = command;
                    commandRunner.StandardOutputDataReceived += CommandRunnerOnStandardOutputDataReceived;
                    var exitStatus = await commandRunner.RunAsync(progress, _cancellationTokenSource.Token);
                    if (exitStatus == CommandRunnerExitStatus.Failure)
                    {
                        lblScanErrorsValue.Text = (int.Parse(lblScanErrorsValue.Text) + 1).ToString();
                    }
                    commandRunner.StandardOutputDataReceived -= CommandRunnerOnStandardOutputDataReceived;
                }

                // Run the disk check command based on user selection.
                if (_diskCheckCommand is not null)
                {
                    lblCurrentScanValue.Text = _diskCheckCommand;
                    // Make the disk check command runner.
                    var command = radScanAndFixDisk.Checked 
                        ? "dir " + _selectedDisk
                        : "ping 9.9.9.9";
                    var commandRunner = new CommandRunner(command);
                    commandRunner.StandardOutputDataReceived += CommandRunnerOnStandardOutputDataReceived;
                    var exitStatus = await commandRunner.RunAsync(progress, _cancellationTokenSource.Token);
                    if (exitStatus == CommandRunnerExitStatus.Failure)
                    {
                        lblScanErrorsValue.Text = (int.Parse(lblScanErrorsValue.Text) + 1).ToString();
                    }
                    commandRunner.StandardOutputDataReceived -= CommandRunnerOnStandardOutputDataReceived;
                }

                // Handle the completion of all scans.
                ScanOutput.AddNewLine("All selected scans completed.");
                _isScanning = false;
                _lastScanOutput = ScanOutput.GetOutput();
                _isLastScanSaved = false;
                lblCurrentScanValue.Text = "Completed all scans";
                btnStartScans.Enabled = true;
                btnCancelScans.Enabled = false;
            };

            btnCancelScans.Click += (_, _) =>
            {
                _cancellationTokenSource?.Cancel();
                progressBarScans.Value = 0;
            };

            // Handle showing the scan output window.
            btnShowScanOutput.Click += (_, _) =>
            {
                if (!ScanOutput.Visible)
                {
                    ScanOutput.Show();
                }
                else
                {
                    ScanOutput.BringToFront();
                }
            };

            // Handle the menu bar actions

            // File Menu
            mnuSave.Click += (_, _) =>
            {
                if (_existingSaveFilePath is null)
                {
                    SaveScanAsFile();
                }
                else
                {
                    SaveScanToFile(_existingSaveFilePath);
                }
            };

            mnuSaveAs.Click += (_, _) => SaveScanAsFile();

            mnuClose.Click += (_, _) =>
            {
                Close();
            };

            // View Menu
            mnuViewLastOutput.Click += (_, _) => ScanOutput.Show();

            // Help Menu 
            mnuDocumentation.Click += (_, _) =>
            {
                Process.Start("explorer", DocumentationUrl);
            };
            mnuLicence.Click += (_, _) =>
            {
                Process.Start("explorer", LicenceUrl);
            };
            mnuAbout.Click += (_, _) =>
            {
                // TODO: Implement about dialog.
            };

            // Ensure warnings before closing the main window.
            FormClosing += (sender, args) =>
            {
                args.Cancel = true;
                if (_isScanning)
                {
                    var result = MessageBox.Show(
                        "A scan is currently in progress. Are you sure you want to exit?",
                        "Confirm Exit",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );
                    args.Cancel = result == DialogResult.No;
                }

                if (!_isLastScanSaved)
                {
                    var result = MessageBox.Show(
                        "There is unsaved scan output. Do you want to save it before exiting?",
                        "Save Scan Output",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question
                    );

                    switch (result)
                    {
                        case DialogResult.Cancel:
                            args.Cancel = true;
                            break;
                        case DialogResult.Yes:
                            SaveScanAsFile();
                            args.Cancel = !_isLastScanSaved;
                            break;
                        case DialogResult.No:
                            args.Cancel = false;
                            break;
                    }
                }
                
                args.Cancel = false;
            };
        }

        /// <summary>
        /// Handle the changes to the disk scan radio buttons.
        /// </summary>
        private void RadScanCheckedChanged(object? sender, EventArgs e)
        {
            if (radNoScan.Checked)
            {
                _diskCheckCommand = null;
                if (_isDiskScanSelected)
                {
                    DecrementSelectedCommands();
                }
                _isDiskScanSelected = false;
            }
            else if (radScanDiskOnly.Checked)
            {
                _diskCheckCommand = radScanDiskOnly.Text;
                if (!_isDiskScanSelected)
                {
                    IncrementSelectedCommands();
                }
                _isDiskScanSelected = true;
            }
            else if (radScanAndFixDisk.Checked)
            {
                _diskCheckCommand = radScanAndFixDisk.Text;
                if (!_isDiskScanSelected)
                {
                    IncrementSelectedCommands();
                }
                _isDiskScanSelected = true;
            }
        }

        /// <summary>
        /// Saves the last scan output to a new file chosen by the user.
        /// </summary>
        private void SaveScanAsFile()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "Save Scan Output"
            };
            var result = saveFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            SaveScanToFile(saveFileDialog.FileName);
        }

        /// <summary>
        /// Saves the last scan to the specified file path.
        /// </summary>
        /// <param name="path">The path to the file that the scan is saved to.</param>
        /// <exception cref="InvalidOperationException">Raised when no scan output is present.</exception>
        private void SaveScanToFile(string path)
        {
            try
            {
                using var fileStream = new StreamWriter(File.OpenWrite(path));
                if (_lastScanOutput is null)
                {
                    throw new InvalidOperationException("There is no scan output to save.");
                }
                fileStream.Write(_lastScanOutput);
                _existingSaveFilePath = path;
                _isLastScanSaved = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"There was an error saving the file: {ex.Message} ",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                _isLastScanSaved = false;
            }
        }

        /// <summary>
        /// Increments the value of selected commands by one.
        /// </summary>
        private void IncrementSelectedCommands()
        {
            lblSelectedScansValue.Text = (int.Parse(lblSelectedScansValue.Text) + 1).ToString();
        }
        
        /// <summary>
        /// Decrements the value of selected commands by one.
        /// </summary>
        private void DecrementSelectedCommands()
        {
            var decrement = int.Parse(lblSelectedScansValue.Text) - 1;
            lblSelectedScansValue.Text = decrement < 0 ? "0" : decrement.ToString();
        }

        /// <summary>
        /// Handles the StandardOutputDataReceived event from CommandRunner instances.
        /// The line of output is added to the scan output text box.
        /// </summary>
        private static void CommandRunnerOnStandardOutputDataReceived(object? sender, OutputDataReceivedArgs e)
        {
            ScanOutput.AddNewLine(e.OutputLine ?? "");
        }
    }
}
