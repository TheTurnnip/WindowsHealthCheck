namespace WindowsHealthCheckUI
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            viewLastTestOutputToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            documentationToolStripMenuItem = new ToolStripMenuItem();
            licenceToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            chkWindowsSystemChecks = new CheckedListBox();
            lblMainMenuInstuctionHeader = new Label();
            cboDiskSelection = new ComboBox();
            grpDiskScanOptions = new GroupBox();
            radScanAndFixDisk = new RadioButton();
            radScanDiskOnly = new RadioButton();
            grpWindowsSystemChecks = new GroupBox();
            btnStartScans = new Button();
            grpStartStopProgress = new GroupBox();
            btnCancelScans = new Button();
            progressBar1 = new ProgressBar();
            helpToolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            grpDiskScanOptions.SuspendLayout();
            grpWindowsSystemChecks.SuspendLayout();
            grpStartStopProgress.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(605, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, saveAsToolStripMenuItem, closeToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(180, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(180, 22);
            closeToolStripMenuItem.Text = "Close";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewLastTestOutputToolStripMenuItem, helpToolStripMenuItem1 });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // viewLastTestOutputToolStripMenuItem
            // 
            viewLastTestOutputToolStripMenuItem.Name = "viewLastTestOutputToolStripMenuItem";
            viewLastTestOutputToolStripMenuItem.Size = new Size(187, 22);
            viewLastTestOutputToolStripMenuItem.Text = "View Last Test Output";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { documentationToolStripMenuItem, licenceToolStripMenuItem, aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            documentationToolStripMenuItem.Size = new Size(180, 22);
            documentationToolStripMenuItem.Text = "Documentation";
            // 
            // licenceToolStripMenuItem
            // 
            licenceToolStripMenuItem.Name = "licenceToolStripMenuItem";
            licenceToolStripMenuItem.Size = new Size(180, 22);
            licenceToolStripMenuItem.Text = "Licence";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(180, 22);
            aboutToolStripMenuItem.Text = "About";
            // 
            // chkWindowsSystemChecks
            // 
            chkWindowsSystemChecks.BorderStyle = BorderStyle.None;
            chkWindowsSystemChecks.CheckOnClick = true;
            chkWindowsSystemChecks.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkWindowsSystemChecks.FormattingEnabled = true;
            chkWindowsSystemChecks.Items.AddRange(new object[] { "Run Deployment Image Servicing and Management Restore Health (DISM)", "Run System File Checker (SFC)" });
            chkWindowsSystemChecks.Location = new Point(6, 22);
            chkWindowsSystemChecks.Name = "chkWindowsSystemChecks";
            chkWindowsSystemChecks.Size = new Size(542, 48);
            chkWindowsSystemChecks.TabIndex = 2;
            // 
            // lblMainMenuInstuctionHeader
            // 
            lblMainMenuInstuctionHeader.AutoSize = true;
            lblMainMenuInstuctionHeader.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblMainMenuInstuctionHeader.Location = new Point(12, 33);
            lblMainMenuInstuctionHeader.Name = "lblMainMenuInstuctionHeader";
            lblMainMenuInstuctionHeader.Size = new Size(511, 30);
            lblMainMenuInstuctionHeader.TabIndex = 3;
            lblMainMenuInstuctionHeader.Text = "Select the options that you wish to use in the check:";
            // 
            // cboDiskSelection
            // 
            cboDiskSelection.FormattingEnabled = true;
            cboDiskSelection.Location = new Point(5, 71);
            cboDiskSelection.Name = "cboDiskSelection";
            cboDiskSelection.Size = new Size(142, 23);
            cboDiskSelection.TabIndex = 6;
            cboDiskSelection.Text = "Select a Disk to Scan";
            // 
            // grpDiskScanOptions
            // 
            grpDiskScanOptions.BackgroundImageLayout = ImageLayout.None;
            grpDiskScanOptions.Controls.Add(radScanAndFixDisk);
            grpDiskScanOptions.Controls.Add(cboDiskSelection);
            grpDiskScanOptions.Controls.Add(radScanDiskOnly);
            grpDiskScanOptions.Location = new Point(12, 155);
            grpDiskScanOptions.Name = "grpDiskScanOptions";
            grpDiskScanOptions.Padding = new Padding(2);
            grpDiskScanOptions.Size = new Size(325, 108);
            grpDiskScanOptions.TabIndex = 7;
            grpDiskScanOptions.TabStop = false;
            grpDiskScanOptions.Text = "Windows Disk Checks:";
            // 
            // radScanAndFixDisk
            // 
            radScanAndFixDisk.AutoSize = true;
            radScanAndFixDisk.Location = new Point(5, 46);
            radScanAndFixDisk.Name = "radScanAndFixDisk";
            radScanAndFixDisk.Size = new Size(300, 19);
            radScanAndFixDisk.TabIndex = 1;
            radScanAndFixDisk.TabStop = true;
            radScanAndFixDisk.Text = "Check Disk and Attemp to Fix Issues (CHKDSK /F /R)";
            radScanAndFixDisk.UseVisualStyleBackColor = true;
            // 
            // radScanDiskOnly
            // 
            radScanDiskOnly.AutoSize = true;
            radScanDiskOnly.Location = new Point(5, 21);
            radScanDiskOnly.Name = "radScanDiskOnly";
            radScanDiskOnly.Size = new Size(159, 19);
            radScanDiskOnly.TabIndex = 0;
            radScanDiskOnly.TabStop = true;
            radScanDiskOnly.Text = "Scan Disk Only (CHKDSK)";
            radScanDiskOnly.UseVisualStyleBackColor = true;
            // 
            // grpWindowsSystemChecks
            // 
            grpWindowsSystemChecks.Controls.Add(chkWindowsSystemChecks);
            grpWindowsSystemChecks.Location = new Point(12, 70);
            grpWindowsSystemChecks.Name = "grpWindowsSystemChecks";
            grpWindowsSystemChecks.Size = new Size(567, 79);
            grpWindowsSystemChecks.TabIndex = 8;
            grpWindowsSystemChecks.TabStop = false;
            grpWindowsSystemChecks.Text = "Windows System Checks:";
            // 
            // btnStartScans
            // 
            btnStartScans.Location = new Point(454, 22);
            btnStartScans.Name = "btnStartScans";
            btnStartScans.Size = new Size(94, 23);
            btnStartScans.TabIndex = 9;
            btnStartScans.Text = "Start Scans";
            btnStartScans.UseVisualStyleBackColor = true;
            // 
            // grpStartStopProgress
            // 
            grpStartStopProgress.Controls.Add(btnCancelScans);
            grpStartStopProgress.Controls.Add(progressBar1);
            grpStartStopProgress.Controls.Add(btnStartScans);
            grpStartStopProgress.Location = new Point(12, 269);
            grpStartStopProgress.Name = "grpStartStopProgress";
            grpStartStopProgress.Size = new Size(567, 63);
            grpStartStopProgress.TabIndex = 10;
            grpStartStopProgress.TabStop = false;
            grpStartStopProgress.Text = "Progress:";
            // 
            // btnCancelScans
            // 
            btnCancelScans.Location = new Point(354, 22);
            btnCancelScans.Name = "btnCancelScans";
            btnCancelScans.Size = new Size(94, 23);
            btnCancelScans.TabIndex = 11;
            btnCancelScans.Text = "Cancel Scans";
            btnCancelScans.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(6, 22);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(329, 23);
            progressBar1.TabIndex = 0;
            // 
            // helpToolStripMenuItem1
            // 
            helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            helpToolStripMenuItem1.Size = new Size(187, 22);
            helpToolStripMenuItem1.Text = "Help";
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 347);
            Controls.Add(grpStartStopProgress);
            Controls.Add(grpWindowsSystemChecks);
            Controls.Add(grpDiskScanOptions);
            Controls.Add(lblMainMenuInstuctionHeader);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainMenu";
            Text = "MainMenu";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            grpDiskScanOptions.ResumeLayout(false);
            grpDiskScanOptions.PerformLayout();
            grpWindowsSystemChecks.ResumeLayout(false);
            grpStartStopProgress.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem documentationToolStripMenuItem;
        private ToolStripMenuItem licenceToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem viewLastTestOutputToolStripMenuItem;
        private CheckedListBox chkWindowsSystemChecks;
        private Label lblMainMenuInstuctionHeader;
        private ComboBox cboDiskSelection;
        private GroupBox grpDiskScanOptions;
        private RadioButton radScanAndFixDisk;
        private RadioButton radScanDiskOnly;
        private GroupBox grpWindowsSystemChecks;
        private Button btnStartScans;
        private GroupBox grpStartStopProgress;
        private Button btnCancelScans;
        private ProgressBar progressBar1;
        private ToolStripMenuItem helpToolStripMenuItem1;
    }
}