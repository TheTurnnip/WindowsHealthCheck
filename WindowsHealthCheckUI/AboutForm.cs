using System.Diagnostics;

namespace WinHealthCheckerUI;

public partial class AboutForm : Form
{
    public AboutForm()
    {
        InitializeComponent();
        
        btnClose.Click += (_, _) => Close();
        linkLabelLicense.Click += (_, _) =>
        {
            Process.Start("explorer.exe", linkLabelLicense.Text);
        };
        linkLableDocs.Click += (_, _) =>
        {
            Process.Start("explorer.exe", linkLableDocs.Text);
        };
    }
}