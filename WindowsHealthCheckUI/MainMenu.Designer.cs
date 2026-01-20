namespace WinHealthCheckerUI
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
            radScanDiskOnly = new RadioButton();
            radScanAndFixDisk = new RadioButton();
            radNoScan = new RadioButton();
            grpWindowsSystemChecks = new GroupBox();
            btnStartScans = new Button();
            grpStartStopProgress = new GroupBox();
            btnShowScanOutput = new Button();
            btnCancelScans = new Button();
            progressBarScans = new ProgressBar();
            grpOverview = new GroupBox();
            lblScanErrorsValue = new Label();
            lblCompletedScansValue = new Label();
            lblSelectedScansValue = new Label();
            lblCurrentScanValue = new Label();
            lblScanErrors = new Label();
            lblCompletedScans = new Label();
            lblSelectedScans = new Label();
            lblCurrentScan = new Label();
            label1 = new Label();
            msMainMenu.SuspendLayout();
            grpDiskScanOptions.SuspendLayout();
            grpWindowsSystemChecks.SuspendLayout();
            grpStartStopProgress.SuspendLayout();
            grpOverview.SuspendLayout();
            SuspendLayout();
            // 
            // msMainMenu
            // 
            msMainMenu.ImageScalingSize = new Size(32, 32);
            msMainMenu.Items.AddRange(new ToolStripItem[] { mnuFile, mnuView, mnuHelp });
            msMainMenu.Location = new Point(0, 0);
            msMainMenu.Name = "msMainMenu";
            msMainMenu.Padding = new Padding(11, 4, 0, 4);
            msMainMenu.Size = new Size(1222, 44);
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
            lblMainMenuInstructionHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            cboDiskSelection.Location = new Point(178, 164);
            cboDiskSelection.Margin = new Padding(6);
            cboDiskSelection.Name = "cboDiskSelection";
            cboDiskSelection.Size = new Size(130, 40);
            cboDiskSelection.TabIndex = 6;
            // 
            // grpDiskScanOptions
            // 
            grpDiskScanOptions.BackgroundImageLayout = ImageLayout.None;
            grpDiskScanOptions.Controls.Add(label1);
            grpDiskScanOptions.Controls.Add(radScanDiskOnly);
            grpDiskScanOptions.Controls.Add(radScanAndFixDisk);
            grpDiskScanOptions.Controls.Add(cboDiskSelection);
            grpDiskScanOptions.Controls.Add(radNoScan);
            grpDiskScanOptions.Location = new Point(22, 305);
            grpDiskScanOptions.Margin = new Padding(6);
            grpDiskScanOptions.Name = "grpDiskScanOptions";
            grpDiskScanOptions.Padding = new Padding(4);
            grpDiskScanOptions.Size = new Size(633, 236);
            grpDiskScanOptions.TabIndex = 7;
            grpDiskScanOptions.TabStop = false;
            grpDiskScanOptions.Text = "Windows Disk Checks:";
            // 
            // radScanDiskOnly
            // 
            radScanDiskOnly.AutoSize = true;
            radScanDiskOnly.Location = new Point(9, 119);
            radScanDiskOnly.Margin = new Padding(6);
            radScanDiskOnly.Name = "radScanDiskOnly";
            radScanDiskOnly.Size = new Size(315, 36);
            radScanDiskOnly.TabIndex = 7;
            radScanDiskOnly.TabStop = true;
            radScanDiskOnly.Text = "Scan Disk Only (CHKDSK)";
            radScanDiskOnly.UseVisualStyleBackColor = true;
            // 
            // radScanAndFixDisk
            // 
            radScanAndFixDisk.AutoSize = true;
            radScanAndFixDisk.Location = new Point(9, 82);
            radScanAndFixDisk.Margin = new Padding(6);
            radScanAndFixDisk.Name = "radScanAndFixDisk";
            radScanAndFixDisk.Size = new Size(599, 36);
            radScanAndFixDisk.TabIndex = 1;
            radScanAndFixDisk.TabStop = true;
            radScanAndFixDisk.Text = "Check Disk and Attemp to Fix Issues (CHKDSK /F /R)";
            radScanAndFixDisk.UseVisualStyleBackColor = true;
            // 
            // radNoScan
            // 
            radNoScan.AutoSize = true;
            radNoScan.Location = new Point(9, 45);
            radNoScan.Margin = new Padding(6);
            radNoScan.Name = "radNoScan";
            radNoScan.Size = new Size(247, 36);
            radNoScan.TabIndex = 0;
            radNoScan.TabStop = true;
            radNoScan.Text = "Skip Disk Scanning";
            radNoScan.UseVisualStyleBackColor = true;
            // 
            // grpWindowsSystemChecks
            // 
            grpWindowsSystemChecks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpWindowsSystemChecks.Controls.Add(chkWindowsSystemChecks);
            grpWindowsSystemChecks.Location = new Point(22, 133);
            grpWindowsSystemChecks.Margin = new Padding(6);
            grpWindowsSystemChecks.Name = "grpWindowsSystemChecks";
            grpWindowsSystemChecks.Padding = new Padding(6);
            grpWindowsSystemChecks.Size = new Size(1185, 160);
            grpWindowsSystemChecks.TabIndex = 8;
            grpWindowsSystemChecks.TabStop = false;
            grpWindowsSystemChecks.Text = "Windows System Checks:";
            // 
            // btnStartScans
            // 
            btnStartScans.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStartScans.Location = new Point(968, 44);
            btnStartScans.Margin = new Padding(6);
            btnStartScans.Name = "btnStartScans";
            btnStartScans.Size = new Size(204, 49);
            btnStartScans.TabIndex = 9;
            btnStartScans.Text = "Start Scans";
            btnStartScans.UseVisualStyleBackColor = true;
            // 
            // grpStartStopProgress
            // 
            grpStartStopProgress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpStartStopProgress.Controls.Add(btnShowScanOutput);
            grpStartStopProgress.Controls.Add(btnCancelScans);
            grpStartStopProgress.Controls.Add(progressBarScans);
            grpStartStopProgress.Controls.Add(btnStartScans);
            grpStartStopProgress.Location = new Point(22, 553);
            grpStartStopProgress.Margin = new Padding(6);
            grpStartStopProgress.Name = "grpStartStopProgress";
            grpStartStopProgress.Padding = new Padding(6);
            grpStartStopProgress.Size = new Size(1185, 176);
            grpStartStopProgress.TabIndex = 10;
            grpStartStopProgress.TabStop = false;
            grpStartStopProgress.Text = "Progress:";
            // 
            // btnShowScanOutput
            // 
            btnShowScanOutput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnShowScanOutput.Location = new Point(11, 105);
            btnShowScanOutput.Margin = new Padding(6);
            btnShowScanOutput.Name = "btnShowScanOutput";
            btnShowScanOutput.Size = new Size(1161, 49);
            btnShowScanOutput.TabIndex = 12;
            btnShowScanOutput.Text = "Show Scan Output";
            btnShowScanOutput.UseVisualStyleBackColor = true;
            // 
            // btnCancelScans
            // 
            btnCancelScans.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelScans.Enabled = false;
            btnCancelScans.Location = new Point(752, 44);
            btnCancelScans.Margin = new Padding(6);
            btnCancelScans.Name = "btnCancelScans";
            btnCancelScans.Size = new Size(204, 49);
            btnCancelScans.TabIndex = 11;
            btnCancelScans.Text = "Cancel Scans";
            btnCancelScans.UseVisualStyleBackColor = true;
            // 
            // progressBarScans
            // 
            progressBarScans.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBarScans.Location = new Point(12, 44);
            progressBarScans.Margin = new Padding(6);
            progressBarScans.Name = "progressBarScans";
            progressBarScans.Size = new Size(717, 49);
            progressBarScans.TabIndex = 0;
            // 
            // grpOverview
            // 
            grpOverview.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpOverview.Controls.Add(lblScanErrorsValue);
            grpOverview.Controls.Add(lblCompletedScansValue);
            grpOverview.Controls.Add(lblSelectedScansValue);
            grpOverview.Controls.Add(lblCurrentScanValue);
            grpOverview.Controls.Add(lblScanErrors);
            grpOverview.Controls.Add(lblCompletedScans);
            grpOverview.Controls.Add(lblSelectedScans);
            grpOverview.Controls.Add(lblCurrentScan);
            grpOverview.Location = new Point(664, 305);
            grpOverview.Name = "grpOverview";
            grpOverview.Size = new Size(543, 236);
            grpOverview.TabIndex = 11;
            grpOverview.TabStop = false;
            grpOverview.Text = "Overview:";
            // 
            // lblScanErrorsValue
            // 
            lblScanErrorsValue.AutoSize = true;
            lblScanErrorsValue.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblScanErrorsValue.Location = new Point(176, 159);
            lblScanErrorsValue.Name = "lblScanErrorsValue";
            lblScanErrorsValue.Size = new Size(27, 32);
            lblScanErrorsValue.TabIndex = 7;
            lblScanErrorsValue.Text = "0";
            // 
            // lblCompletedScansValue
            // 
            lblCompletedScansValue.AutoSize = true;
            lblCompletedScansValue.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCompletedScansValue.Location = new Point(254, 122);
            lblCompletedScansValue.Name = "lblCompletedScansValue";
            lblCompletedScansValue.Size = new Size(63, 32);
            lblCompletedScansValue.TabIndex = 6;
            lblCompletedScansValue.Text = "0 / 0";
            // 
            // lblSelectedScansValue
            // 
            lblSelectedScansValue.AutoSize = true;
            lblSelectedScansValue.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSelectedScansValue.Location = new Point(221, 85);
            lblSelectedScansValue.Name = "lblSelectedScansValue";
            lblSelectedScansValue.Size = new Size(27, 32);
            lblSelectedScansValue.TabIndex = 5;
            lblSelectedScansValue.Text = "0";
            // 
            // lblCurrentScanValue
            // 
            lblCurrentScanValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCurrentScanValue.AutoEllipsis = true;
            lblCurrentScanValue.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCurrentScanValue.Location = new Point(197, 48);
            lblCurrentScanValue.Name = "lblCurrentScanValue";
            lblCurrentScanValue.Size = new Size(332, 37);
            lblCurrentScanValue.TabIndex = 4;
            lblCurrentScanValue.Text = "No Active Scans";
            // 
            // lblScanErrors
            // 
            lblScanErrors.AutoSize = true;
            lblScanErrors.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScanErrors.Location = new Point(18, 154);
            lblScanErrors.Name = "lblScanErrors";
            lblScanErrors.Size = new Size(166, 37);
            lblScanErrors.TabIndex = 3;
            lblScanErrors.Text = "Scan Errors:";
            // 
            // lblCompletedScans
            // 
            lblCompletedScans.AutoSize = true;
            lblCompletedScans.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompletedScans.Location = new Point(18, 117);
            lblCompletedScans.Name = "lblCompletedScans";
            lblCompletedScans.Size = new Size(244, 37);
            lblCompletedScans.TabIndex = 2;
            lblCompletedScans.Text = "Completed Scans:";
            // 
            // lblSelectedScans
            // 
            lblSelectedScans.AutoSize = true;
            lblSelectedScans.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelectedScans.Location = new Point(18, 80);
            lblSelectedScans.Name = "lblSelectedScans";
            lblSelectedScans.Size = new Size(211, 37);
            lblSelectedScans.TabIndex = 1;
            lblSelectedScans.Text = "Selected Scans:";
            // 
            // lblCurrentScan
            // 
            lblCurrentScan.AutoSize = true;
            lblCurrentScan.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCurrentScan.Location = new Point(17, 43);
            lblCurrentScan.Name = "lblCurrentScan";
            lblCurrentScan.Size = new Size(187, 37);
            lblCurrentScan.TabIndex = 0;
            lblCurrentScan.Text = "Current Scan:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(7, 161);
            label1.Name = "label1";
            label1.Size = new Size(167, 37);
            label1.TabIndex = 8;
            label1.Text = "Disk to Scan:";
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1222, 742);
            Controls.Add(grpOverview);
            Controls.Add(grpStartStopProgress);
            Controls.Add(grpWindowsSystemChecks);
            Controls.Add(grpDiskScanOptions);
            Controls.Add(lblMainMenuInstructionHeader);
            Controls.Add(msMainMenu);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = msMainMenu;
            Margin = new Padding(6);
            MaximizeBox = false;
            Name = "MainMenu";
            Text = "MainMenu";
            msMainMenu.ResumeLayout(false);
            msMainMenu.PerformLayout();
            grpDiskScanOptions.ResumeLayout(false);
            grpDiskScanOptions.PerformLayout();
            grpWindowsSystemChecks.ResumeLayout(false);
            grpStartStopProgress.ResumeLayout(false);
            grpOverview.ResumeLayout(false);
            grpOverview.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.RadioButton radScanDiskOnly;

        private System.Windows.Forms.Label lblScanErrorsValue;
        private System.Windows.Forms.Label lblCompletedScansValue;
        private System.Windows.Forms.Label lblSelectedScansValue;
        private System.Windows.Forms.Label lblCurrentScanValue;

        private System.Windows.Forms.Label lblSelectedScans;
        private System.Windows.Forms.Label lblCompletedScans;
        private System.Windows.Forms.Label lblScanErrors;

        private System.Windows.Forms.Label lblCurrentScan;

        private System.Windows.Forms.GroupBox grpOverview;

        private System.Windows.Forms.Button btnShowScanOutput;

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
        private System.Windows.Forms.CheckedListBox chkWindowsSystemChecks;
        private System.Windows.Forms.Label lblMainMenuInstructionHeader;
        private System.Windows.Forms.ComboBox cboDiskSelection;
        private System.Windows.Forms.GroupBox grpDiskScanOptions;
        private System.Windows.Forms.RadioButton radScanAndFixDisk;
        private RadioButton radNoScan;
        private System.Windows.Forms.GroupBox grpWindowsSystemChecks;
        private System.Windows.Forms.Button btnStartScans;
        private System.Windows.Forms.GroupBox grpStartStopProgress;
        private System.Windows.Forms.Button btnCancelScans;
        private System.Windows.Forms.ProgressBar progressBarScans;
        private Label label1;
    }
}