using System.ComponentModel;

namespace WinHealthCheckerUI;

partial class AboutForm
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
        lblTitle = new System.Windows.Forms.Label();
        openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        lblDescription = new System.Windows.Forms.Label();
        btnClose = new System.Windows.Forms.Button();
        lblVersion = new System.Windows.Forms.Label();
        lblLicense = new System.Windows.Forms.Label();
        lblDocs = new System.Windows.Forms.Label();
        lblCopyright = new System.Windows.Forms.Label();
        linkLableDocs = new System.Windows.Forms.LinkLabel();
        linkLabelLicense = new System.Windows.Forms.LinkLabel();
        lblVersionValue = new System.Windows.Forms.Label();
        lblCopyrightValue = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lblTitle.Location = new System.Drawing.Point(12, 19);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(822, 64);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "WindowsHealthCheck";
        // 
        // lblDescription
        // 
        lblDescription.Location = new System.Drawing.Point(12, 94);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new System.Drawing.Size(750, 74);
        lblDescription.TabIndex = 1;
        lblDescription.Text = ("Windows Health Check is a simple un-official tool that can be used to check for a" + "nd fix various windows realted errors and issues.\r\n");
        // 
        // btnClose
        // 
        btnClose.AutoSize = true;
        btnClose.Location = new System.Drawing.Point(807, 266);
        btnClose.Name = "btnClose";
        btnClose.Size = new System.Drawing.Size(107, 42);
        btnClose.TabIndex = 2;
        btnClose.Text = "Close";
        btnClose.UseVisualStyleBackColor = true;
        // 
        // lblVersion
        // 
        lblVersion.AutoSize = true;
        lblVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lblVersion.Location = new System.Drawing.Point(12, 238);
        lblVersion.Name = "lblVersion";
        lblVersion.Size = new System.Drawing.Size(114, 37);
        lblVersion.TabIndex = 3;
        lblVersion.Text = "Version:";
        // 
        // lblLicense
        // 
        lblLicense.AutoSize = true;
        lblLicense.Font = new System.Drawing.Font("Segoe UI Semibold", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lblLicense.Location = new System.Drawing.Point(12, 202);
        lblLicense.Name = "lblLicense";
        lblLicense.Size = new System.Drawing.Size(113, 37);
        lblLicense.TabIndex = 4;
        lblLicense.Text = "License:";
        // 
        // lblDocs
        // 
        lblDocs.AutoSize = true;
        lblDocs.Font = new System.Drawing.Font("Segoe UI Semibold", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lblDocs.Location = new System.Drawing.Point(12, 165);
        lblDocs.Name = "lblDocs";
        lblDocs.Size = new System.Drawing.Size(215, 37);
        lblDocs.TabIndex = 5;
        lblDocs.Text = "Documentation:";
        // 
        // lblCopyright
        // 
        lblCopyright.AutoSize = true;
        lblCopyright.Font = new System.Drawing.Font("Segoe UI Semibold", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lblCopyright.Location = new System.Drawing.Point(12, 270);
        lblCopyright.Name = "lblCopyright";
        lblCopyright.Size = new System.Drawing.Size(146, 37);
        lblCopyright.TabIndex = 6;
        lblCopyright.Text = "Copyright:";
        // 
        // linkLableDocs
        // 
        linkLableDocs.Location = new System.Drawing.Point(221, 168);
        linkLableDocs.Name = "linkLableDocs";
        linkLableDocs.Size = new System.Drawing.Size(674, 37);
        linkLableDocs.TabIndex = 7;
        linkLableDocs.TabStop = true;
        linkLableDocs.Text = "https://github.com/ryansteffan/WindowsHealthCheck/";
        // 
        // linkLabelLicense
        // 
        linkLabelLicense.Location = new System.Drawing.Point(120, 205);
        linkLabelLicense.Name = "linkLabelLicense";
        linkLabelLicense.Size = new System.Drawing.Size(834, 37);
        linkLabelLicense.TabIndex = 8;
        linkLabelLicense.TabStop = true;
        linkLabelLicense.Text = "https://github.com/ryansteffan/WindowsHealthCheck/blob/main/LICENSE.txt";
        // 
        // lblVersionValue
        // 
        lblVersionValue.AutoSize = true;
        lblVersionValue.Location = new System.Drawing.Point(118, 242);
        lblVersionValue.Name = "lblVersionValue";
        lblVersionValue.Size = new System.Drawing.Size(63, 32);
        lblVersionValue.TabIndex = 9;
        lblVersionValue.Text = "0.1.0";
        // 
        // lblCopyrightValue
        // 
        lblCopyrightValue.AutoSize = true;
        lblCopyrightValue.Location = new System.Drawing.Point(150, 275);
        lblCopyrightValue.Name = "lblCopyrightValue";
        lblCopyrightValue.Size = new System.Drawing.Size(371, 32);
        lblCopyrightValue.TabIndex = 10;
        lblCopyrightValue.Text = "(C) Ryan Steffan and Contributors";
        // 
        // AboutForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(960, 331);
        ControlBox = false;
        Controls.Add(lblCopyrightValue);
        Controls.Add(lblVersionValue);
        Controls.Add(linkLabelLicense);
        Controls.Add(linkLableDocs);
        Controls.Add(lblCopyright);
        Controls.Add(lblDocs);
        Controls.Add(lblLicense);
        Controls.Add(lblVersion);
        Controls.Add(btnClose);
        Controls.Add(lblDescription);
        Controls.Add(lblTitle);
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "About";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label lblCopyrightValue;

    private System.Windows.Forms.LinkLabel linkLabelLicense;
    private System.Windows.Forms.Label lblVersionValue;

    private System.Windows.Forms.LinkLabel linkLableDocs;

    private System.Windows.Forms.Label lblCopyright;

    private System.Windows.Forms.Label lblDocs;

    private System.Windows.Forms.Label lblLicense;

    private System.Windows.Forms.Label lblVersion;

    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Label lblDescription;
    private System.Windows.Forms.Button btnClose;

    private System.Windows.Forms.Label lblTitle;

    #endregion
}