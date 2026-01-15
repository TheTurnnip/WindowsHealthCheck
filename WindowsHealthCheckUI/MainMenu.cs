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
        private Dictionary<string, CommandRunner> commandLookup = new Dictionary<string, CommandRunner>
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
        
        private List<string> selectedSystemCommands = new List<string>();
        
        public MainMenu()
        {
            InitializeComponent();
            chkWindowsSystemChecks.SelectedValueChanged += (sender, args) =>
            {
                selectedSystemCommands.Clear();
                foreach (var command in chkWindowsSystemChecks.CheckedItems)
                {
                    if (!selectedSystemCommands.Contains(command.ToString() ?? "unknown"))
                    {
                        selectedSystemCommands.Add(command.ToString() ?? "unknown");
                    }
                }
            };
            
            btnStartScans.Click += async (sender, args) =>
            {
                foreach (var command in selectedSystemCommands)
                {
                    var commandRunner = commandLookup[command];
                    commandRunner.StandardOutputDataReceived += CommandRunnerOnStandardOutputDataReceived;
                    await commandRunner.RunAsync();
                }
            };
        }

        private void CommandRunnerOnStandardOutputDataReceived(object? sender, OutputDataReceivedArgs e)
        {
            Console.WriteLine(e.OutputLine);
        }

        private void chkWindowsSystemChecks_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
