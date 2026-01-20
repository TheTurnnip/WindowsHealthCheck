using Spectre.Console;

namespace WinHealthCheckerCLI.Prompts;

public class ToolOptionsPrompt : IPrompter
{
    public string[] UserSelectedOptions { get; set; }
    public IPrompter PreviousPrompter { get; set; }
    public IPrompter NextPrompter { get; set; }

    public async Task<string[]> DisplayPrompt()
    {
        AnsiConsole.Clear();
        AnsiConsole.Write(new Markup("[bold green underline]Welcome to WinHealthCheck![/]").Centered());
        while (UserSelectedOptions == null)
        {
            await Task.Delay(50);
        }
        
        return UserSelectedOptions;
    }

    public void ReturnToPreviousPrompt()
    {
        throw new NotImplementedException();
    }

    public void GoToNextPrompt()
    {
        throw new NotImplementedException();
    }
}