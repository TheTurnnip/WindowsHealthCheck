namespace WinHealthCheckerCLI.Prompts;

public class ToolOptionsPrompt : IPrompter
{
    public string[] UserSelectedOptions { get; set; }
    public IPrompter PreviousPrompter { get; set; }
    public IPrompter NextPrompter { get; set; }

    public Task<string[]> DisplayPrompt()
    {
        throw new NotImplementedException();
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