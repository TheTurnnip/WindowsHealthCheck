using System.Diagnostics;

namespace Commands;

public class CommandRunner
{
    private readonly Process _process;
    private readonly string? _arguments;

    public event EventHandler<OutputDataReceivedArgs>? StandardOutputDataReceived;

    /// <summary>
    /// Creates an instance of the CommandRunner class.
    /// </summary>
    /// <param name="command">The command to run. (Ex. "ping 8.8.8.8")</param>
    public CommandRunner(string command)
    {
        _arguments = command;
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
            _process.OutputDataReceived += (sender, args) => OnStandardOutputDataReceived(args.Data);
            _process.ErrorDataReceived += (sender, args) => OnStandardOutputDataReceived(args.Data);
            _process.BeginOutputReadLine();
            _process.BeginErrorReadLine();
            await _process.WaitForExitAsync();
            var exitCode = _process.ExitCode;

            if (exitCode != 0)
            {
                Console.WriteLine("The command exited with a non-zero exit code: " + exitCode);
                return false;
            }

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("There was an error running the command: " + e.Message);
            return false;
        }
    }

    protected virtual void OnStandardOutputDataReceived(string? outputLine)
    {
        if (StandardOutputDataReceived == null)
        {
            throw new NullReferenceException("The StandardOutputDataReceived even has no subscribers.");
        }
        
        StandardOutputDataReceived.Invoke(this, new OutputDataReceivedArgs(_arguments, outputLine)); 
    }
}

