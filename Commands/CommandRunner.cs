using System.Diagnostics;

namespace Commands;

public sealed class CommandRunner
{
    private readonly string _arguments;

    public event EventHandler<OutputDataReceivedArgs>? StandardOutputDataReceived;

    /// <summary>
    /// Creates an instance of the CommandRunner class.
    /// </summary>
    /// <param name="command">The command to run. (Ex. "ping 8.8.8.8")</param>
    public CommandRunner(string command)
    {
        _arguments = command;
    }

    public async Task<CommandRunnerExitStatus> RunAsync(IProgress<int>? progress)
    {
        try
        {
            using var process = new Process();

            process.StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c " + _arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            process.Start();
            process.OutputDataReceived += (_, args) => OnStandardOutputDataReceived(args.Data);
            process.ErrorDataReceived += (_, args) => OnStandardOutputDataReceived(args.Data);
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            await process.WaitForExitAsync();
            progress?.Report(1);
            var exitCode = process.ExitCode;

            return exitCode != 0 ? CommandRunnerExitStatus.Failure : CommandRunnerExitStatus.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return CommandRunnerExitStatus.CodeException;
        }
    }

    private void OnStandardOutputDataReceived(string? outputLine)
    {
        if (StandardOutputDataReceived == null)
        {
            throw new NullReferenceException("The StandardOutputDataReceived even has no subscribers.");
        }

        StandardOutputDataReceived.Invoke(this, new OutputDataReceivedArgs(_arguments, outputLine));
    }
}