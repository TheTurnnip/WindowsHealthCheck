using System.Diagnostics;
using System.IO;

namespace Commands;

public sealed class CommandRunner
{
    /// <summary>
    /// The command arguments to run as a string
    /// </summary>
    private readonly string _arguments;
    
    /// <summary>
    /// Sets a command runner to require shell execution.
    /// </summary>
    private readonly bool _requireShellExecution;

    /// <summary>
    /// Occurs when 1024 characters of output data is received from the command process.
    /// </summary>
    public event EventHandler<OutputDataReceivedArgs>? OutputDataReceived;

    /// <summary>
    /// Creates an instance of the CommandRunner class.
    /// </summary>
    /// <param name="command">The command to run. (Ex. "ping 8.8.8.8")</param>
    /// <param name="requireShellExecution">
    /// If true the command will be executed in a real shell.
    /// </param>
    public CommandRunner(string command, bool requireShellExecution)
    {
        _arguments = command;
        _requireShellExecution = requireShellExecution;
    }

    /// <summary>
    /// Runs the configured command asynchronously and reports progress and completion status.
    /// </summary>
    /// <param name="progress">An IProgress reporter that recieves progress when the command completes.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the running command.</param>
    /// <returns>
    /// Returns a task that resolves to a CommandRunnerExistStatus. The status is Success when the command 
    /// exits with a code 0, Failure when the command exits with a non-zero code, Cancelled when the method 
    /// is cancelled, and CodeException when an exception occurs during execution.
    /// </returns>
    public async Task<CommandRunnerExitStatus> RunAsync(IProgress<int>? progress, CancellationToken cancellationToken)
    {
        try
        {
            using var process = new Process();
            
            if (_requireShellExecution)
            {
                var tempFile = Path.GetTempFileName();
                try
                {
                    process.StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = "/c " + _arguments + " > \"" + tempFile + "\" 2>&1",
                        RedirectStandardOutput = false,
                        RedirectStandardError = false,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    };

                    OnOutputDataReceived("\r\nExecuting command in shell mode...\r\n" +
                                         "ALERT: Output for this command will be displayed after completion.\r\n" +
                                         "Current command: " + _arguments + "\r\n\r\n");
                    process.Start();

                    await process.WaitForExitAsync(cancellationToken);

                    // File reader for captured output.
                    // TODO: Investigate reason for file not printing to output window.
                    using var fileReader = new StreamReader(new FileStream(tempFile, FileMode.Open));
                    while (!fileReader.EndOfStream)
                    {
                        OnOutputDataReceived(await fileReader.ReadLineAsync(cancellationToken));
                    }
                }
                catch (Exception exception)
                {
                    OnOutputDataReceived($"There was an error executing the command in shell mode: " +
                                         $"{exception.Message}\n");
                }
                finally
                {
                    try
                    {
                        File.Delete(tempFile);
                    }
                    catch (Exception exception)
                    {
                        OnOutputDataReceived($"There was an error in temp file deletion: {exception.Message}\n");
                    }
                }

                progress?.Report(1);
                var exitCode = process.ExitCode;

                return exitCode != 0 ? CommandRunnerExitStatus.Failure : CommandRunnerExitStatus.Success;
            }

            // Default behavior: capture redirected stdout/stderr streams.
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

            var stdOutTask = HandleStreamReadAsync(process.StandardOutput, OnOutputDataReceived, cancellationToken);
            var stdErrTask = HandleStreamReadAsync(process.StandardError, OnOutputDataReceived, cancellationToken);

            await process.WaitForExitAsync(cancellationToken);

            await Task.WhenAll(stdOutTask, stdErrTask);
            progress?.Report(1);
            var exitCodeDefault = process.ExitCode;

            return exitCodeDefault != 0 ? CommandRunnerExitStatus.Failure : CommandRunnerExitStatus.Success;
        }
        catch (TaskCanceledException)
        {
            return CommandRunnerExitStatus.Cancelled;
        }
        catch (Exception)
        {
            return CommandRunnerExitStatus.CodeException;
        }
    }

    /// <summary>
    /// Handles continuous reading from a stream asynchronously.
    /// Data is continously read into a buffer, and then passed to a callback,
    /// where it can be processed in some way.
    /// </summary>
    /// <param name="reader">The StreamReader to read from.</param>
    /// <param name="onOutput">A callback for the method handling read data.</param>
    /// <param name="cancellationToken">The CancellationToken used to cancle the task.</param>
    /// <returns></returns>
    private static async Task HandleStreamReadAsync(StreamReader reader, 
        Action<string?> onOutput, 
        CancellationToken cancellationToken)
    {
        try
        {
            var buffer = new char[1024];
            while (true)
            {
                var charsRead = await reader.ReadAsync(buffer, cancellationToken);
                if (charsRead <= 0) break;
                onOutput(new string(buffer, 0, charsRead));
            }
        } 
        catch (OperationCanceledException)
        {
            return;
        }
    }

    /// <summary>
    /// Handles received output data from the command process.
    /// </summary>
    /// <param name="outputLine">The string text from the command process.</param>
    private void OnOutputDataReceived(string? outputLine)
    {
        OutputDataReceived?.Invoke(this, new OutputDataReceivedArgs(_arguments, outputLine));
    }
}