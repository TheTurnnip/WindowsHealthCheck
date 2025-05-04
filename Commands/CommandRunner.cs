using System.Diagnostics;

namespace Commands;

public class CommandRunner
{
    private readonly Process _process;
    
    public event EventHandler<OutputDataReceivedArgs>? StandardOutputDataReceived;
    
    /// <summary>
    /// Creates an instance of the CommandRunner class.
    /// </summary>
    /// <param name="command">The command to run. (Ex. "ping 8.8.8.8")</param>
    public CommandRunner(string command)
    {
        ProcessStartInfo processStartInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = "/c " + command,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        
        _process = new Process()
        {
            StartInfo = processStartInfo,
        };
    }
    
    public async Task<bool> RunAsync()
    {
        try
        {
            _process.Start();
            using (StreamReader reader = _process.StandardOutput)
            {
                while (!reader.EndOfStream)
                {
                    string? outputLine = await reader.ReadLineAsync();
                    if (outputLine != null)
                    {
                        OnStandardOutputDataReceived(outputLine);
                    }
                }
            }
            await _process.WaitForExitAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("There was an error running the command: " + e.Message);
            return false;
        }
        finally
        {
            _process.Dispose();
        }
    }
    
    protected virtual void OnStandardOutputDataReceived(string? outputLine)
    {
        if (StandardOutputDataReceived == null)
        {
            throw new NullReferenceException("The StandardOutputDataReceived even has no subscribers.");
        }
        StandardOutputDataReceived.Invoke(this, new OutputDataReceivedArgs(outputLine));
    }
}
