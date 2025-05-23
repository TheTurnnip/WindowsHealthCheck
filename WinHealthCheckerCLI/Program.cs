using System.Text;
using Commands;
using Spectre.Console;
using WinHealthCheckerCLI.KeyPressHandler;
using WinHealthCheckerCLI.Prompts;

namespace WinHealthCheckerCLI;

internal class Program
{
    private static IPrompter _currentPrompter;
    private static IPrompter _previousPrompter;
    
    private static async Task Main(string[] args)
    {
        var keyboardMonitor = new KeyboardMonitor(50);
        keyboardMonitor.KeyPressed += async (_, eventArgs) =>
        {
            switch (eventArgs.KeyInfo.Key)
            {
                case ConsoleKey.Q:
                    AnsiConsole.Clear();
                    Console.WriteLine("Exiting the program...");
                    Environment.Exit(0);
                    break;
                case ConsoleKey.H:
                    _previousPrompter = _currentPrompter;
                    _currentPrompter = new HelpPrompt();
                    await _currentPrompter.DisplayPrompt();
                    break;
                case ConsoleKey.B:
                    _currentPrompter = _previousPrompter;
                    AnsiConsole.WriteLine("Returning to the previous prompt...");;
                    await _currentPrompter.DisplayPrompt();
                    break;
            }
        };
        
        // Start the event loop for the program.
        while (true)
        {
            // Sets the prompt from where the app will start.
            _currentPrompter = new ToolOptionsPrompt();
            await _currentPrompter.DisplayPrompt();
            await Task.Delay(50);
        }
    }
}