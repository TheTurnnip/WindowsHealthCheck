namespace WinHealthCheckerCLI.Prompts;

public interface IPrompter
{
    /// <summary>
    /// The option(s) from the prompt that the user selected.
    /// </summary>
    public string[] UserSelectedOptions { get; protected set; }
    
    /// <summary>
    /// The IPrompter that was previously displayed.
    /// </summary>
    public IPrompter PreviousPrompter { get; protected set; }
    
    /// <summary>
    /// The IPrompter that will be displayed next.
    /// </summary>
    public IPrompter NextPrompter { get; protected set; }
    
    /// <summary>
    /// Displays the prompt in the CLI.
    /// </summary>
    public Task<string[]> DisplayPrompt();
    
    /// <summary>
    /// Displays the past prompt in the CLI.
    /// </summary>
    public void ReturnToPreviousPrompt();
    
    /// <summary>
    /// Displays the next prompt in the CLI.
    /// </summary>
    public void GoToNextPrompt();
}