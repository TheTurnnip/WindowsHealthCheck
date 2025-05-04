namespace Commands;

public class OutputDataReceivedArgs(string? outputLine) : EventArgs
{
    public string? OutputLine { get; set; } = outputLine;
}