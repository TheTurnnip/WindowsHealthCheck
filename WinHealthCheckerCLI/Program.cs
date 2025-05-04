using Spectre.Console;
using System.Collections;
using Commands;

namespace WinHealthCheckerCLI;

class Program
{
    private static readonly Markup WelcomeMessage = new Markup(
        "[bold underline green]Welcome to the Windows Health Checker CLI![/]")
        .Centered();

    private static readonly Dictionary<string, CommandRunner> CommandOptions = new Dictionary<string, CommandRunner>()
    {
        { "Deployment Image Servicing and Management Health Restoration", new CommandRunner("ping 127.0.0.1") },
        { "Run System File Checker", new CommandRunner("ping 127.0.0.1") },
        { "Run A Disk Scan", new CommandRunner("ping 127.0.0.1") },
        { "Repair a Disk", new CommandRunner("ping 127.0.0.1") }
    };

    private static readonly MultiSelectionPrompt<string> commandOptionsPrompt = new MultiSelectionPrompt<string>()
        .Title("[bold yellow]Select the commands you want to run:[/]")
        .InstructionsText(
            "Note: If you select Repair a Disk, then the Disk Scan will run even if not selected \n" +
            "[grey](Press [blue]<space>[/] to toggle a fruit, " +
            "[green]<enter>[/] to accept)[/]")
        .AddChoices(CommandOptions.Keys.ToArray());
    
    private static Table logOutputTable = new Table()
        .Title("Logs")
        .AddColumn(new TableColumn("Command").Centered())
        .AddColumn(new TableColumn("Status").Centered())
        .AddColumn(new TableColumn("Output").Centered())
        .Border(TableBorder.Ascii2);
    
    private static string[] _userSelectedOptions;
    
    static async Task Main(string[] args)
    {
        foreach (CommandRunner commandRunner in CommandOptions.Values)
        {
            commandRunner.StandardOutputDataReceived += CommandRunnerOnStandardOutputDataReceived;
        }
        
        bool selectionConfirmed = false;
        
        while (!selectionConfirmed)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(WelcomeMessage);
            _userSelectedOptions = AnsiConsole.Prompt(commandOptionsPrompt).ToArray();
            AnsiConsole.MarkupLine("[bold green]You selected:[/]");
            foreach (var option in _userSelectedOptions)
            {
                AnsiConsole.MarkupLine($"- {option}");
            }
            bool runCommands = AnsiConsole.Confirm("Are you sure you want to run the selected commands?", false);
            if (runCommands)
            {
                selectionConfirmed = true;
            }
        }
        AnsiConsole.MarkupLine("[bold green]Repair tool starting...[/]");
        foreach (var option in _userSelectedOptions)
        {
            AnsiConsole.MarkupLineInterpolated($"Running {option}...");
            bool commandSuccessful = await CommandOptions[option].RunAsync();
            if (commandSuccessful)
            {
                AnsiConsole.MarkupLineInterpolated($"[bold green]{option}: {option} completed![/]");
            }
            else
            {
                AnsiConsole.MarkupLineInterpolated($"[bold red]{option}: {option} Failed![/]");
            }
        }
    }

    private static void CommandRunnerOnStandardOutputDataReceived(object? sender, OutputDataReceivedArgs e)
    {
        if (e.OutputLine != null)
        {
            AnsiConsole.MarkupLineInterpolated($"[dim]{e.OutputLine}[/]");
        }
    }
}