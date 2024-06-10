namespace WindowsHealthCheck.WindowsHealthCheckUI
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            msMainMenu = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuSave = new ToolStripMenuItem();
            mnuSaveAs = new ToolStripMenuItem();
            mnuClose = new ToolStripMenuItem();
            mnuView = new ToolStripMenuItem();
            mnuViewLastOutput = new ToolStripMenuItem();
            mnuHelp = new ToolStripMenuItem();
            mnuDocumentation = new ToolStripMenuItem();
            mnuLicence = new ToolStripMenuItem();
            mnuAbout = new ToolStripMenuItem();
            chkWindowsSystemChecks = new CheckedListBox();
            lblMainMenuInstructionHeader = new Label();
            cboDiskSelection = new ComboBox();
            grpDiskScanOptions = new GroupBox();
            radScanAndFixDisk = new RadioButton();
            radScanDiskOnly = new RadioButton();
            grpWindowsSystemChecks = new GroupBox();
            btnStartScans = new Button();
            grpStartStopProgress = new GroupBox();
            btnCancelScans = new Button();
            progressBarScans = new ProgressBar();
            msMainMenu.SuspendLayout();
            grpDiskScanOptions.SuspendLayout();
            grpWindowsSystemChecks.SuspendLayout();
            grpStartStopProgress.SuspendLayout();
            SuspendLayout();
            // 
            // msMainMenu
            // 
            msMainMenu.ImageScalingSize = new Size(32, 32);
            msMainMenu.Items.AddRange(new ToolStripItem[] { mnuFile, mnuView, mnuHelp });
            msMainMenu.Location = new Point(0, 0);
            msMainMenu.Name = "msMainMenu";
            msMainMenu.Padding = new Padding(11, 4, 0, 4);
            msMainMenu.Size = new Size(1193, 44);
            msMainMenu.TabIndex = 0;
            msMainMenu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuSave, mnuSaveAs, mnuClose });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(71, 36);
            mnuFile.Text = "File";
            // 
            // mnuSave
            // 
            mnuSave.Name = "mnuSave";
            mnuSave.Size = new Size(318, 44);
            mnuSave.Text = "Save (CTRL + S)";
            // 
            // mnuSaveAs
            // 
            mnuSaveAs.Name = "mnuSaveAs";
            mnuSaveAs.Size = new Size(318, 44);
            mnuSaveAs.Text = "Save As (F12)";
            // 
            // mnuClose
            // 
            mnuClose.Name = "mnuClose";
            mnuClose.Size = new Size(318, 44);
            mnuClose.Text = "Close (ALT + F4)";
            // 
            // mnuView
            // 
            mnuView.DropDownItems.AddRange(new ToolStripItem[] { mnuViewLastOutput });
            mnuView.Name = "mnuView";
            mnuView.Size = new Size(85, 36);
            mnuView.Text = "View";
            // 
            // mnuViewLastOutput
            // 
            mnuViewLastOutput.Name = "mnuViewLastOutput";
            mnuViewLastOutput.Size = new Size(497, 44);
            mnuViewLastOutput.Text = "View Last Test Output (CTRL + V)";
            // 
            // mnuHelp
            // 
            mnuHelp.DropDownItems.AddRange(new ToolStripItem[] { mnuDocumentation, mnuLicence, mnuAbout });
            mnuHelp.Name = "mnuHelp";
            mnuHelp.Size = new Size(84, 36);
            mnuHelp.Text = "Help";
            // 
            // mnuDocumentation
            // 
            mnuDocumentation.Name = "mnuDocumentation";
            mnuDocumentation.Size = new Size(434, 44);
            mnuDocumentation.Text = "Documentation (CTRL + H)";
            // 
            // mnuLicence
            // 
            mnuLicence.Name = "mnuLicence";
            mnuLicence.Size = new Size(434, 44);
            mnuLicence.Text = "Licence";
            // 
            // mnuAbout
            // 
            mnuAbout.Name = "mnuAbout";
            mnuAbout.Size = new Size(434, 44);
            mnuAbout.Text = "About";
            // 
            // chkWindowsSystemChecks
            // 
            chkWindowsSystemChecks.BackColor = SystemColors.Control;
            chkWindowsSystemChecks.BorderStyle = BorderStyle.None;
            chkWindowsSystemChecks.CheckOnClick = true;
            chkWindowsSystemChecks.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkWindowsSystemChecks.FormattingEnabled = true;
            chkWindowsSystemChecks.Items.AddRange(new object[] { "Run Deployment Image Servicing and Management Restore Health (DISM)", "Run System File Checker (SFC)" });
            chkWindowsSystemChecks.Location = new Point(11, 47);
            chkWindowsSystemChecks.Margin = new Padding(6);
            chkWindowsSystemChecks.Name = "chkWindowsSystemChecks";
            chkWindowsSystemChecks.Size = new Size(1109, 94);
            chkWindowsSystemChecks.TabIndex = 2;
            // 
            // lblMainMenuInstructionHeader
            // 
            lblMainMenuInstructionHeader.AutoSize = true;
            lblMainMenuInstructionHeader.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblMainMenuInstructionHeader.Location = new Point(22, 70);
            lblMainMenuInstructionHeader.Margin = new Padding(6, 0, 6, 0);
            lblMainMenuInstructionHeader.Name = "lblMainMenuInstructionHeader";
            lblMainMenuInstructionHeader.Size = new Size(1017, 57);
            lblMainMenuInstructionHeader.TabIndex = 3;
            lblMainMenuInstructionHeader.Text = "Select the options that you wish to use in the check:";
            // 
            // cboDiskSelection
            // 
            cboDiskSelection.FormattingEnabled = true;
            cboDiskSelection.Location = new Point(9, 151);
            cboDiskSelection.Margin = new Padding(6);
            cboDiskSelection.Name = "cboDiskSelection";
            cboDiskSelection.Size = new Size(260, 40);
            cboDiskSelection.TabIndex = 6;
            // 
            // grpDiskScanOptions
            // 
            grpDiskScanOptions.BackgroundImageLayout = ImageLayout.None;
            grpDiskScanOptions.Controls.Add(radScanAndFixDisk);
            grpDiskScanOptions.Controls.Add(cboDiskSelection);
            grpDiskScanOptions.Controls.Add(radScanDiskOnly);
            grpDiskScanOptions.Location = new Point(22, 331);
            grpDiskScanOptions.Margin = new Padding(6);
            grpDiskScanOptions.Name = "grpDiskScanOptions";
            grpDiskScanOptions.Padding = new Padding(4);
            grpDiskScanOptions.Size = new Size(627, 230);
            grpDiskScanOptions.TabIndex = 7;
            grpDiskScanOptions.TabStop = false;
            grpDiskScanOptions.Text = "Windows Disk Checks:";
            // 
            // radScanAndFixDisk
            // 
            radScanAndFixDisk.AutoSize = true;
            radScanAndFixDisk.Location = new Point(9, 98);
            radScanAndFixDisk.Margin = new Padding(6);
            radScanAndFixDisk.Name = "radScanAndFixDisk";
            radScanAndFixDisk.Size = new Size(599, 36);
            radScanAndFixDisk.TabIndex = 1;
            radScanAndFixDisk.TabStop = true;
            radScanAndFixDisk.Text = "Check Disk and Attemp to Fix Issues (CHKDSK /F /R)";
            radScanAndFixDisk.UseVisualStyleBackColor = true;
            // 
            // radScanDiskOnly
            // 
            radScanDiskOnly.AutoSize = true;
            radScanDiskOnly.Location = new Point(9, 45);
            radScanDiskOnly.Margin = new Padding(6);
            radScanDiskOnly.Name = "radScanDiskOnly";
            radScanDiskOnly.Size = new Size(315, 36);
            radScanDiskOnly.TabIndex = 0;
            radScanDiskOnly.TabStop = true;
            radScanDiskOnly.Text = "Scan Disk Only (CHKDSK)";
            radScanDiskOnly.UseVisualStyleBackColor = true;
            // 
            // grpWindowsSystemChecks
            // 
            grpWindowsSystemChecks.Controls.Add(chkWindowsSystemChecks);
            grpWindowsSystemChecks.Location = new Point(22, 149);
            grpWindowsSystemChecks.Margin = new Padding(6);
            grpWindowsSystemChecks.Name = "grpWindowsSystemChecks";
            grpWindowsSystemChecks.Padding = new Padding(6);
            grpWindowsSystemChecks.Size = new Size(1140, 169);
            grpWindowsSystemChecks.TabIndex = 8;
            grpWindowsSystemChecks.TabStop = false;
            grpWindowsSystemChecks.Text = "Windows System Checks:";
            // 
            // btnStartScans
            // 
            btnStartScans.Location = new Point(914, 47);
            btnStartScans.Margin = new Padding(6);
            btnStartScans.Name = "btnStartScans";
            btnStartScans.Size = new Size(175, 49);
            btnStartScans.TabIndex = 9;
            btnStartScans.Text = "Start Scans";
            btnStartScans.UseVisualStyleBackColor = true;
            // 
            // grpStartStopProgress
            // 
            grpStartStopProgress.Controls.Add(btnCancelScans);
            grpStartStopProgress.Controls.Add(progressBarScans);
            grpStartStopProgress.Controls.Add(btnStartScans);
            grpStartStopProgress.Location = new Point(22, 574);
            grpStartStopProgress.Margin = new Padding(6);
            grpStartStopProgress.Name = "grpStartStopProgress";
            grpStartStopProgress.Padding = new Padding(6);
            grpStartStopProgress.Size = new Size(1120, 134);
            grpStartStopProgress.TabIndex = 10;
            grpStartStopProgress.TabStop = false;
            grpStartStopProgress.Text = "Progress:";
            // 
            // btnCancelScans
            // 
            btnCancelScans.Location = new Point(728, 47);
            btnCancelScans.Margin = new Padding(6);
            btnCancelScans.Name = "btnCancelScans";
            btnCancelScans.Size = new Size(175, 49);
            btnCancelScans.TabIndex = 11;
            btnCancelScans.Text = "Cancel Scans";
            btnCancelScans.UseVisualStyleBackColor = true;
            // 
            // progressBarScans
            // 
            progressBarScans.Location = new Point(11, 47);
            progressBarScans.Margin = new Padding(6);
            progressBarScans.Name = "progressBarScans";
            progressBarScans.Size = new Size(683, 49);
            progressBarScans.TabIndex = 0;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1193, 733);
            Controls.Add(grpStartStopProgress);
            Controls.Add(grpWindowsSystemChecks);
            Controls.Add(grpDiskScanOptions);
            Controls.Add(lblMainMenuInstructionHeader);
            Controls.Add(msMainMenu);
            MainMenuStrip = msMainMenu;
            Margin = new Padding(6);
            Name = "MainMenu";
            Text = "MainMenu";
            msMainMenu.ResumeLayout(false);
            msMainMenu.PerformLayout();
            grpDiskScanOptions.ResumeLayout(false);
            grpDiskScanOptions.PerformLayout();
            grpWindowsSystemChecks.ResumeLayout(false);
            grpStartStopProgress.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip msMainMenu;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuSave;
        private ToolStripMenuItem mnuSaveAs;
        private ToolStripMenuItem mnuClose;
        private ToolStripMenuItem mnuView;
        private ToolStripMenuItem mnuHelp;
        private ToolStripMenuItem mnuDocumentation;
        private ToolStripMenuItem mnuLicence;
        private ToolStripMenuItem mnuAbout;
        private ToolStripMenuItem mnuViewLastOutput;
        private CheckedListBox chkWindowsSystemChecks;
        private Label lblMainMenuInstructionHeader;
        private ComboBox cboDiskSelection;
        private GroupBox grpDiskScanOptions;
        private RadioButton radScanAndFixDisk;
        private RadioButton radScanDiskOnly;
        private GroupBox grpWindowsSystemChecks;
        private Button btnStartScans;
        private GroupBox grpStartStopProgress;
        private Button btnCancelScans;
        private ProgressBar progressBarScans;
    }
}