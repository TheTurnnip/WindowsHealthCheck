using Spectre.Console;

namespace WinHealthCheckerCLI.Prompts;

public class HelpPrompt : IPrompter
{
    public string[] UserSelectedOptions { get; set; }
    public IPrompter PreviousPrompter { get; set; }
    public IPrompter NextPrompter { get; set; }
    
    private readonly string _title = "[bold underline green]Help Menu[/]";
    
    public async Task<string[]> DisplayPrompt()
    {
        AnsiConsole.MarkupLine(_title);
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