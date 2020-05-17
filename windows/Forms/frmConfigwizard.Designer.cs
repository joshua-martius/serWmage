namespace serwmImageUploader
{
    partial class frmConfigwizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigwizard));
            this.tbxServerAddress = new System.Windows.Forms.TextBox();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.lblServeraddress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveRun = new System.Windows.Forms.Button();
            this.lblRemoteDirectory = new System.Windows.Forms.Label();
            this.tbxRemoteDirectory = new System.Windows.Forms.TextBox();
            this.chkOpenAfterCreation = new System.Windows.Forms.CheckBox();
            this.grpServerSettings = new System.Windows.Forms.GroupBox();
            this.grpHotkeys = new System.Windows.Forms.GroupBox();
            this.cmbReOpenForm = new System.Windows.Forms.ComboBox();
            this.lblFocusForm = new System.Windows.Forms.Label();
            this.cmbCroppedScreenshot = new System.Windows.Forms.ComboBox();
            this.lblCroppedScreenshot = new System.Windows.Forms.Label();
            this.cmbFullscreenScreenshot = new System.Windows.Forms.ComboBox();
            this.lblFullscreen = new System.Windows.Forms.Label();
            this.grpServerSettings.SuspendLayout();
            this.grpHotkeys.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxServerAddress
            // 
            this.tbxServerAddress.Location = new System.Drawing.Point(104, 15);
            this.tbxServerAddress.MaxLength = 32;
            this.tbxServerAddress.Name = "tbxServerAddress";
            this.tbxServerAddress.Size = new System.Drawing.Size(185, 20);
            this.tbxServerAddress.TabIndex = 0;
            // 
            // tbxUsername
            // 
            this.tbxUsername.Location = new System.Drawing.Point(104, 41);
            this.tbxUsername.MaxLength = 10;
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(185, 20);
            this.tbxUsername.TabIndex = 1;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(104, 67);
            this.tbxPassword.MaxLength = 32;
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = 'X';
            this.tbxPassword.Size = new System.Drawing.Size(185, 20);
            this.tbxPassword.TabIndex = 2;
            // 
            // lblServeraddress
            // 
            this.lblServeraddress.AutoSize = true;
            this.lblServeraddress.Location = new System.Drawing.Point(6, 18);
            this.lblServeraddress.Name = "lblServeraddress";
            this.lblServeraddress.Size = new System.Drawing.Size(78, 13);
            this.lblServeraddress.TabIndex = 3;
            this.lblServeraddress.Text = "Serveraddress:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // btnSaveRun
            // 
            this.btnSaveRun.Location = new System.Drawing.Point(12, 161);
            this.btnSaveRun.Name = "btnSaveRun";
            this.btnSaveRun.Size = new System.Drawing.Size(296, 67);
            this.btnSaveRun.TabIndex = 5;
            this.btnSaveRun.Text = "Save && Run";
            this.btnSaveRun.UseVisualStyleBackColor = true;
            this.btnSaveRun.Click += new System.EventHandler(this.btnSaveRun_Click);
            // 
            // lblRemoteDirectory
            // 
            this.lblRemoteDirectory.AutoSize = true;
            this.lblRemoteDirectory.Location = new System.Drawing.Point(6, 96);
            this.lblRemoteDirectory.Name = "lblRemoteDirectory";
            this.lblRemoteDirectory.Size = new System.Drawing.Size(90, 13);
            this.lblRemoteDirectory.TabIndex = 8;
            this.lblRemoteDirectory.Text = "Remote directory:";
            // 
            // tbxRemoteDirectory
            // 
            this.tbxRemoteDirectory.Location = new System.Drawing.Point(104, 93);
            this.tbxRemoteDirectory.MaxLength = 128;
            this.tbxRemoteDirectory.Name = "tbxRemoteDirectory";
            this.tbxRemoteDirectory.Size = new System.Drawing.Size(185, 20);
            this.tbxRemoteDirectory.TabIndex = 3;
            // 
            // chkOpenAfterCreation
            // 
            this.chkOpenAfterCreation.AutoSize = true;
            this.chkOpenAfterCreation.Location = new System.Drawing.Point(104, 119);
            this.chkOpenAfterCreation.Name = "chkOpenAfterCreation";
            this.chkOpenAfterCreation.Size = new System.Drawing.Size(159, 17);
            this.chkOpenAfterCreation.TabIndex = 4;
            this.chkOpenAfterCreation.Text = "Open Image after Uploading";
            this.chkOpenAfterCreation.UseVisualStyleBackColor = true;
            // 
            // grpServerSettings
            // 
            this.grpServerSettings.Controls.Add(this.label1);
            this.grpServerSettings.Controls.Add(this.chkOpenAfterCreation);
            this.grpServerSettings.Controls.Add(this.tbxServerAddress);
            this.grpServerSettings.Controls.Add(this.lblRemoteDirectory);
            this.grpServerSettings.Controls.Add(this.tbxUsername);
            this.grpServerSettings.Controls.Add(this.tbxRemoteDirectory);
            this.grpServerSettings.Controls.Add(this.tbxPassword);
            this.grpServerSettings.Controls.Add(this.lblServeraddress);
            this.grpServerSettings.Controls.Add(this.label2);
            this.grpServerSettings.Location = new System.Drawing.Point(12, 12);
            this.grpServerSettings.Name = "grpServerSettings";
            this.grpServerSettings.Size = new System.Drawing.Size(296, 143);
            this.grpServerSettings.TabIndex = 9;
            this.grpServerSettings.TabStop = false;
            this.grpServerSettings.Text = "Server Settings";
            // 
            // grpHotkeys
            // 
            this.grpHotkeys.Controls.Add(this.cmbReOpenForm);
            this.grpHotkeys.Controls.Add(this.lblFocusForm);
            this.grpHotkeys.Controls.Add(this.cmbCroppedScreenshot);
            this.grpHotkeys.Controls.Add(this.lblCroppedScreenshot);
            this.grpHotkeys.Controls.Add(this.cmbFullscreenScreenshot);
            this.grpHotkeys.Controls.Add(this.lblFullscreen);
            this.grpHotkeys.Location = new System.Drawing.Point(327, 12);
            this.grpHotkeys.Name = "grpHotkeys";
            this.grpHotkeys.Size = new System.Drawing.Size(223, 216);
            this.grpHotkeys.TabIndex = 10;
            this.grpHotkeys.TabStop = false;
            this.grpHotkeys.Text = "Custom Hotkeys";
            // 
            // cmbReOpenForm
            // 
            this.cmbReOpenForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReOpenForm.FormattingEnabled = true;
            this.cmbReOpenForm.Location = new System.Drawing.Point(130, 93);
            this.cmbReOpenForm.Name = "cmbReOpenForm";
            this.cmbReOpenForm.Size = new System.Drawing.Size(87, 21);
            this.cmbReOpenForm.TabIndex = 16;
            // 
            // lblFocusForm
            // 
            this.lblFocusForm.Location = new System.Drawing.Point(6, 83);
            this.lblFocusForm.Name = "lblFocusForm";
            this.lblFocusForm.Size = new System.Drawing.Size(118, 39);
            this.lblFocusForm.TabIndex = 15;
            this.lblFocusForm.Text = "Re-open Form:";
            this.lblFocusForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCroppedScreenshot
            // 
            this.cmbCroppedScreenshot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCroppedScreenshot.FormattingEnabled = true;
            this.cmbCroppedScreenshot.Location = new System.Drawing.Point(130, 58);
            this.cmbCroppedScreenshot.Name = "cmbCroppedScreenshot";
            this.cmbCroppedScreenshot.Size = new System.Drawing.Size(87, 21);
            this.cmbCroppedScreenshot.TabIndex = 14;
            // 
            // lblCroppedScreenshot
            // 
            this.lblCroppedScreenshot.Location = new System.Drawing.Point(6, 48);
            this.lblCroppedScreenshot.Name = "lblCroppedScreenshot";
            this.lblCroppedScreenshot.Size = new System.Drawing.Size(118, 39);
            this.lblCroppedScreenshot.TabIndex = 13;
            this.lblCroppedScreenshot.Text = "Cropped Screenshot:";
            this.lblCroppedScreenshot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbFullscreenScreenshot
            // 
            this.cmbFullscreenScreenshot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFullscreenScreenshot.FormattingEnabled = true;
            this.cmbFullscreenScreenshot.Location = new System.Drawing.Point(130, 26);
            this.cmbFullscreenScreenshot.Name = "cmbFullscreenScreenshot";
            this.cmbFullscreenScreenshot.Size = new System.Drawing.Size(87, 21);
            this.cmbFullscreenScreenshot.TabIndex = 12;
            // 
            // lblFullscreen
            // 
            this.lblFullscreen.Location = new System.Drawing.Point(6, 16);
            this.lblFullscreen.Name = "lblFullscreen";
            this.lblFullscreen.Size = new System.Drawing.Size(118, 39);
            this.lblFullscreen.TabIndex = 11;
            this.lblFullscreen.Text = "Fullscreen Screenshot:";
            this.lblFullscreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmConfigwizard
            // 
            this.AcceptButton = this.btnSaveRun;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 240);
            this.Controls.Add(this.grpHotkeys);
            this.Controls.Add(this.grpServerSettings);
            this.Controls.Add(this.btnSaveRun);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfigwizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration Creator";
            this.grpServerSettings.ResumeLayout(false);
            this.grpServerSettings.PerformLayout();
            this.grpHotkeys.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxServerAddress;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label lblServeraddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveRun;
        private System.Windows.Forms.Label lblRemoteDirectory;
        private System.Windows.Forms.TextBox tbxRemoteDirectory;
        private System.Windows.Forms.CheckBox chkOpenAfterCreation;
        private System.Windows.Forms.GroupBox grpServerSettings;
        private System.Windows.Forms.GroupBox grpHotkeys;
        private System.Windows.Forms.Label lblFullscreen;
        private System.Windows.Forms.ComboBox cmbFullscreenScreenshot;
        private System.Windows.Forms.ComboBox cmbCroppedScreenshot;
        private System.Windows.Forms.Label lblCroppedScreenshot;
        private System.Windows.Forms.ComboBox cmbReOpenForm;
        private System.Windows.Forms.Label lblFocusForm;
    }
}