using System.Diagnostics;

namespace WindowsHealthCheck.WindowsHealthCheckCommands
{
    public static class HealthCheckTasks
    {
        public static async Task SystemFileChecker()
        {
            Process command = new Process();
            command.StartInfo.FileName = "sfc";
            command.StartInfo.Arguments = "/scannow";
            Task task = new Task(() => command.Start());
            await task;
        }

        public static async Task DISMScan()
        {
            Process command = new Process();
            command.StartInfo.FileName = "dism";
            command.StartInfo.Arguments = "/Online /Cleanup-Image /RestoreHealth";
            Task task = new Task(() => command.Start());
            await task;
        }

        public static async Task CheckDisk()
        {
            Process command = new Process();
            command.StartInfo.FileName = "chkdsk";
            command.StartInfo.Arguments = "";
            Task task = new Task(() => command.Start());
            await task;
        }
    }
}
