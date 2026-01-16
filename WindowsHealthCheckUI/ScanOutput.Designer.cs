using System.ComponentModel;

namespace WindowsHealthCheckUI;

partial class ScanOutput
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        groupBoxScanOutput = new System.Windows.Forms.GroupBox();
        buttonHide = new System.Windows.Forms.Button();
        txtBoxScanOutput = new System.Windows.Forms.TextBox();
        groupBoxScanOutput.SuspendLayout();
        SuspendLayout();
        // 
        // groupBoxScanOutput
        // 
        groupBoxScanOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        groupBoxScanOutput.Controls.Add(buttonHide);
        groupBoxScanOutput.Controls.Add(txtBoxScanOutput);
        groupBoxScanOutput.Font = new System.Drawing.Font("Segoe UI Semibold", 13.875F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        groupBoxScanOutput.Location = new System.Drawing.Point(12, 12);
        groupBoxScanOutput.Name = "groupBoxScanOutput";
        groupBoxScanOutput.Size = new System.Drawing.Size(1068, 574);
        groupBoxScanOutput.TabIndex = 0;
        groupBoxScanOutput.TabStop = false;
        groupBoxScanOutput.Text = "Scan Output:";
        // 
        // buttonHide
        // 
        buttonHide.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        buttonHide.Font = new System.Drawing.Font("Segoe UI", 9F);
        buttonHide.Location = new System.Drawing.Point(866, 500);
        buttonHide.Name = "buttonHide";
        buttonHide.Size = new System.Drawing.Size(167, 59);
        buttonHide.TabIndex = 1;
        buttonHide.Text = "Hide";
        buttonHide.UseVisualStyleBackColor = true;
        // 
        // txtBoxScanOutput
        // 
        txtBoxScanOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        txtBoxScanOutput.Cursor = System.Windows.Forms.Cursors.Arrow;
        txtBoxScanOutput.Font = new System.Drawing.Font("Consolas", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        txtBoxScanOutput.Location = new System.Drawing.Point(6, 54);
        txtBoxScanOutput.Multiline = true;
        txtBoxScanOutput.Name = "txtBoxScanOutput";
        txtBoxScanOutput.ReadOnly = true;
        txtBoxScanOutput.Size = new System.Drawing.Size(1056, 429);
        txtBoxScanOutput.TabIndex = 0;
        // 
        // ScanOutput
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1092, 598);
        ControlBox = false;
        Controls.Add(groupBoxScanOutput);
        Text = "ScanOutput";
        groupBoxScanOutput.ResumeLayout(false);
        groupBoxScanOutput.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button buttonHide;

    private System.Windows.Forms.TextBox txtBoxScanOutput;

    private System.Windows.Forms.GroupBox groupBoxScanOutput;

    #endregion
}