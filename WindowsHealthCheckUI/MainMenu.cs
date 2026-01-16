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
        private readonly Dictionary<string, CommandRunner> _commandLookup = new()
        {
            {
                "Run Deployment Image Servicing and Management Restore Health (DISM)",
                new CommandRunner("ping 8.8.8.8")
            },
            {
                "Run System File Checker (SFC)",
                new CommandRunner("ping 1.1.1.1")
            }
        };

        private readonly List<string> _selectedSystemCommands = new();
        private bool _diskCheckWithFixes;
        private bool _isScanning;
        private string? _lastScanOutput;
        private bool _isLastScanSaved = true;
        private string? _existingSaveFilePath;
        private const string DocumentationUrl = "";

        public MainMenu()
        {
            InitializeComponent();

            // Handle changes to the selection of system check commands. 
            chkWindowsSystemChecks.SelectedValueChanged += (_, _) =>
            {
                _selectedSystemCommands.Clear();
                foreach (var command in chkWindowsSystemChecks.CheckedItems)
                {
                    if (!_selectedSystemCommands.Contains(command.ToString() ?? "unknown"))
                    {
                        _selectedSystemCommands.Add(command.ToString() ?? "unknown");
                    }
                }
            };

            // Handle disk check command options.
            radScanDiskOnly.Click += (_, _) => _diskCheckWithFixes = false;
            radScanAndFixDisk.Click += (_, _) => _diskCheckWithFixes = true;

            // Handle the scan start button click event.
            btnStartScans.Click += async (_, _) =>
            {
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
                btnStartScans.Enabled = false;
                
                // Initialize the progress bar.
                progressBarScans.Minimum = 1;
                // +1 for disk check, +1 for initial progress
                progressBarScans.Maximum = _selectedSystemCommands.Count + 2;
                progressBarScans.Step = 1;
                var progress = new Progress<int>(percent =>
                {
                    // TODO: Implement more granular progress reporting using percent.
                    progressBarScans.PerformStep();
                });
                
                ScanOutput.ClearOutput();
                ScanOutput.AddNewLine("Starting selected scans...");
                ScanOutput.Show();

                // Run the selected system commands.
                foreach (var command in _selectedSystemCommands)
                {
                    var commandRunner = _commandLookup[command];
                    commandRunner.StandardOutputDataReceived += CommandRunnerOnStandardOutputDataReceived;
                    await commandRunner.RunAsync(progress);
                }

                // Run the disk check command based on user selection.
                if (_diskCheckWithFixes)
                {
                    var commandRunner = new CommandRunner("ping 127.0.0.1");
                    commandRunner.StandardOutputDataReceived += CommandRunnerOnStandardOutputDataReceived;
                    await commandRunner.RunAsync(progress);
                }
                else
                {
                    var commandRunner = new CommandRunner("ping 9.9.9.9");
                    commandRunner.StandardOutputDataReceived += CommandRunnerOnStandardOutputDataReceived;
                    await commandRunner.RunAsync(progress);
                }

                // Handle the completion of all scans.
                ScanOutput.AddNewLine("All selected scans completed.");
                _lastScanOutput = ScanOutput.GetOutput();
                _isLastScanSaved = false;
                _isScanning = false;
                btnStartScans.Enabled = true;
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
              // TODO: Show licence information in message box.
            };
            mnuAbout.Click += (_, _) =>
            {
                // TODO: Add about dialog.
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
        /// Handles the StandardOutputDataReceived event from CommandRunner instances.
        /// The line of output is added to the scan output text box.
        /// </summary>
        private static void CommandRunnerOnStandardOutputDataReceived(object? sender, OutputDataReceivedArgs e)
        {
            ScanOutput.AddNewLine(e.OutputLine ?? "");
        }
    }
}