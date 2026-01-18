namespace Commands;
using System.IO;

public class Drives
{
    public List<string> DriveNames { get; private set; } = new();

    public Drives()
    {
        foreach (DriveInfo drive in DriveInfo.GetDrives()) 
        {
            DriveNames.Add(drive.Name);
        }
    }
}