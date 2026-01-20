namespace Commands;

public class OutputDataReceivedArgs(string? commandName, string? outputLine) : EventArgs
{
    public string? OutputLine { get; set; } = outputLine;
    public string? CommandName { get; set; } = commandName;
}