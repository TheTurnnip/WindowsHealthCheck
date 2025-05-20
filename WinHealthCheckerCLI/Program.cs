using System.Text;
using Commands;
using Spectre.Console;
using WinHealthCheckerCLI.KeyPressHandler;
using WinHealthCheckerCLI.Prompts;

namespace WinHealthCheckerCLI;

internal class Program
{
    private static IPrompter _currentPrompter;
    private static Dictionary<IPrompter, int> _prompts = new Dictionary<IPrompter, int>()
    {
        { new HelpPrompt(), 0 },
    };
    
    private static async Task Main(string[] args)
    {
        var keyboardMonitor = new KeyboardMonitor(50);
        keyboardMonitor.KeyPressed += async (_, eventArgs) =>
        {
            switch (eventArgs.KeyInfo.Key)
            {
                case ConsoleKey.Q:
                    Console.WriteLine("Exiting the program...");
                    Environment.Exit(0);
                    break;
                case ConsoleKey.H:
                    _currentPrompter = new HelpPrompt();
                    await _currentPrompter.DisplayPrompt();
                    break;
                case ConsoleKey.B:
                    _currentPrompter.ReturnToPreviousPrompt();
                    break;
            }
        };
        
        // Start the event loop for the program.
        while (true)
        {
        }
    }
}