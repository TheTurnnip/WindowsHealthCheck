namespace WinHealthCheckerCLI.KeyPressHandler;

public class ConsoleKeyEventArgs : EventArgs
{
    public ConsoleKeyInfo KeyInfo { get; }
    
    public ConsoleKeyEventArgs(ConsoleKeyInfo keyInfo)
    {
        KeyInfo = keyInfo;
    }
}