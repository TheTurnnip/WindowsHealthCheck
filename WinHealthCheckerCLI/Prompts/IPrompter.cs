namespace WinHealthCheckerCLI.Prompts;

public interface IPrompter
{
    /// <summary>
    /// The option(s) from the prompt that the user selected.
    /// </summary>
    public string[] UserSelectedOptions { get; protected set; }

    /// <summary>
    /// Displays the prompt in the CLI.
    /// </summary>
    public Task<string[]> DisplayPrompt();
}