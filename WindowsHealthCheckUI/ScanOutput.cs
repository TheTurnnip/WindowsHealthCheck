namespace WindowsHealthCheckUI;

public partial class ScanOutput : Form
{
    private string _defaultText = "No scan has been started. Click 'Start Scans' to begin.";
    
    public ScanOutput()
    {
        InitializeComponent();
        txtBoxScanOutput.ScrollBars = ScrollBars.Vertical;
        txtBoxScanOutput.Text = _defaultText;
        
        buttonHide.Click += (_, _) => Hide();
    }

    public void AddNewLine(string line)
    {
        txtBoxScanOutput.Text += line + "\r\n";
        txtBoxScanOutput.SelectionStart = txtBoxScanOutput.Text.Length;
        txtBoxScanOutput.ScrollToCaret();
    }
    
    public void ClearOutput()
    {
        txtBoxScanOutput.Text = string.Empty;
    }
    
    public string GetOutput()
    {
        return txtBoxScanOutput.Text;
    }
    
    public void ResetToDefault()
    {
        txtBoxScanOutput.Text = _defaultText;
    }
}