using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Commands;

namespace WindowsHealthCheckUI
{
    public partial class MainMenu : Form
    {
        private static ScanOutput _scanOutput = new ScanOutput();

        // Define a lookup dictionary for system commands where the key is the UI command name,
        // and the value is the CommandRunner instance for the respective command.
        private Dictionary<string, CommandRunner> _commandLookup = new()
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

        private readonly List<string> _selectedSystemCommands = new List<string>();
        private bool _diskCheckWithFixes;
        private bool _isScanning;
        private string? _lastScanOutput;

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
                if (_lastScanOutput is not null)
                {
                    // Show a re-run warning dialog with save option.
                }
                _isScanning = true;
                btnStartScans.Enabled = false;
                _scanOutput.ClearOutput();
                _scanOutput.AddNewLine("Starting selected scans...");
                _scanOutput.Show();
                
                // Run the selected system commands.
                foreach (var command in _selectedSystemCommands)
                {
                    var commandRunner = _commandLookup[command];
                    commandRunner.StandardOutputDataReceived += CommandRunnerOnStandardOutputDataReceived;
                    await commandRunner.RunAsync();
                }

                // Run the disk check command based on user selection.
                if (_diskCheckWithFixes)
                {
                    var commandRunner = new CommandRunner("ping 127.0.0.1");
                    commandRunner.StandardOutputDataReceived += CommandRunnerOnStandardOutputDataReceived;
                    await commandRunner.RunAsync();
                }
                else
                {
                    var commandRunner = new CommandRunner("ping 8.4.4.8");
                    commandRunner.StandardOutputDataReceived += CommandRunnerOnStandardOutputDataReceived;
                    await commandRunner.RunAsync();
                }
                
                // Handle the completion of all scans.
                _scanOutput.AddNewLine("All selected scans completed.");
                _lastScanOutput = _scanOutput.ToString();
                _isScanning = false;
                btnStartScans.Enabled = true;
            };

            // Handle showing the scan output window.
            btnShowScanOutput.Click += (_, _) => _scanOutput.Show();
            
            // Handle the menu bar actions
            
            // File Menu
            mnuSave.Click += (_, _) => { };
            mnuSaveAs.Click += (_, _) => { };
            mnuClose.Click += (_, _) => { Close(); };
            
            // View Menu
            mnuViewLastOutput.Click += (_, _) => _scanOutput.Show();
            
            // Help Menu 
            mnuDocumentation.Click += (_, _) => { };
            mnuLicence.Click += (_, _) => { };
            mnuAbout.Click += (_, _) => { };
        }

        /// <summary>
        /// Handles the StandardOutputDataReceived event from CommandRunner instances.
        /// The line of output is added to the scan output text box.
        /// </summary>
        private void CommandRunnerOnStandardOutputDataReceived(object? sender, OutputDataReceivedArgs e)
        {
            _scanOutput.AddNewLine(e.OutputLine ?? "");
        }
    }
}

