using System.Text;
using Commands;
using Spectre.Console;

namespace WinHealthCheckerCLI;

internal class Program
{
    private static readonly Markup WelcomeMessage = new Markup(
            "[bold underline green]Welcome to the Windows Health Checker CLI![/]")
        .Centered();

    private static readonly Dictionary<string, CommandRunner> CommandOptions = new()
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

    private static string[] _userSelectedOptions;
    private static bool _doFileLogging;
    private static string _logFilePath;

    private static async Task Main(string[] args)
    {
        foreach (var commandRunner in CommandOptions.Values)
            commandRunner.StandardOutputDataReceived += CommandRunnerOnStandardOutputDataReceived;

        var selectionConfirmed = false;

        while (!selectionConfirmed)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(WelcomeMessage);

            _userSelectedOptions = AnsiConsole.Prompt(commandOptionsPrompt).ToArray();

            LoggingPrompt();

            selectionConfirmed = OptionsSelectionConfirmed(selectionConfirmed);
        }

        AnsiConsole.MarkupLine("[bold green]Repair tool starting...[/]");
        foreach (var option in _userSelectedOptions)
        {
            AnsiConsole.MarkupLineInterpolated($"[bold green]Running {option}...[/]");
            var commandSuccessful = await CommandOptions[option].RunAsync();
            AnsiConsole.MarkupLineInterpolated(commandSuccessful
                ? $"[bold green]{option}: {option} completed![/]"
                : (FormattableString)$"[bold red]{option}: {option} Failed![/]");
        }
        
        AnsiConsole.MarkupLine("[bold green]\n\nRepairs and Scans Complete!\n" +
                               "Press any key to exit...[/]");
        Console.ReadLine();
    }

    private static bool OptionsSelectionConfirmed(bool selectionConfirmed)
    {
        AnsiConsole.Clear();
        var loggingTitle = new Markup("[bold underline green]Scan Options Overview...[/]\n").Centered();
        AnsiConsole.Write(loggingTitle);
        AnsiConsole.MarkupLine("[bold green]You selected:[/]");
        foreach (var option in _userSelectedOptions) AnsiConsole.MarkupLine($"- {option}");

        Console.WriteLine();
        var runCommands = AnsiConsole.Confirm("Are you sure you want to run the selected tools?", false);
        if (runCommands) selectionConfirmed = true;

        return selectionConfirmed;
    }

    private static void LoggingPrompt()
    {
        var loggingConfirmed = false;
        var loggingTitle = new Markup("[bold underline green]Logging Setup...[/]\n").Centered();

        while (!loggingConfirmed)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(loggingTitle);
            var doFileLogging = AnsiConsole.Confirm("Do you want to log the output to a file?", false);
            if (doFileLogging)
            {
                AnsiConsole.MarkupLine("[bold yellow]Notes:[/] \n" +
                                       "- If the file does not exist it will be created.\n" +
                                       "- [red]If the file already exists, it will be overwritten![/]\n");
                _logFilePath = AnsiConsole.Ask<string>("Enter the file path to save the log file:");
                _doFileLogging = true;
            }

            loggingConfirmed = AnsiConsole.Confirm("[bold underline yellow]Your logging file is set to:[/] \n" +
                                                   $"{_logFilePath}\n\n" +
                                                   "Are you sure you want to log to this file?", false);
            if (!SetupLogFile(_logFilePath))
            {
                loggingConfirmed = false;
                Console.WriteLine("Press a key to try again...");
                Console.ReadLine();
            }
        }
    }
    
    private static bool SetupLogFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            AnsiConsole.MarkupLine("[bold green]Log file exists...\n" +
                                   "Skipping file creation...[/]");
            return true;
        }
        
        try 
        {
            File.Create(filePath);
            AnsiConsole.MarkupLine("[bold green]Log file created successfully![/]");
            return true;
        } catch (Exception e)
        {
            AnsiConsole.MarkupLine($"[bold red]Error creating log file: {e.Message}[/]");
            return false;
        }
    }

    private static void WriteToLogFile(string filePath, string message)
    {
        using FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write);
        byte[] fileLine = Encoding.UTF8.GetBytes(message + Environment.NewLine);
        fileStream.Write(fileLine);
    }
    
    private static void CommandRunnerOnStandardOutputDataReceived(object? sender, OutputDataReceivedArgs e)
    {
        if (e.OutputLine == null) return;
        AnsiConsole.MarkupLineInterpolated($"[dim]{e.OutputLine}[/]");
        if (_doFileLogging) WriteToLogFile(_logFilePath, e.OutputLine);
    }
}