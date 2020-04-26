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
            this.SuspendLayout();
            // 
            // tbxServerAddress
            // 
            this.tbxServerAddress.Location = new System.Drawing.Point(110, 6);
            this.tbxServerAddress.MaxLength = 32;
            this.tbxServerAddress.Name = "tbxServerAddress";
            this.tbxServerAddress.Size = new System.Drawing.Size(185, 20);
            this.tbxServerAddress.TabIndex = 0;
            // 
            // tbxUsername
            // 
            this.tbxUsername.Location = new System.Drawing.Point(110, 32);
            this.tbxUsername.MaxLength = 10;
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(185, 20);
            this.tbxUsername.TabIndex = 1;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(110, 58);
            this.tbxPassword.MaxLength = 32;
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = 'X';
            this.tbxPassword.Size = new System.Drawing.Size(185, 20);
            this.tbxPassword.TabIndex = 2;
            // 
            // lblServeraddress
            // 
            this.lblServeraddress.AutoSize = true;
            this.lblServeraddress.Location = new System.Drawing.Point(12, 9);
            this.lblServeraddress.Name = "lblServeraddress";
            this.lblServeraddress.Size = new System.Drawing.Size(78, 13);
            this.lblServeraddress.TabIndex = 3;
            this.lblServeraddress.Text = "Serveradresse:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // btnSaveRun
            // 
            this.btnSaveRun.Location = new System.Drawing.Point(12, 133);
            this.btnSaveRun.Name = "btnSaveRun";
            this.btnSaveRun.Size = new System.Drawing.Size(283, 23);
            this.btnSaveRun.TabIndex = 5;
            this.btnSaveRun.Text = "Save && Run";
            this.btnSaveRun.UseVisualStyleBackColor = true;
            this.btnSaveRun.Click += new System.EventHandler(this.btnSaveRun_Click);
            // 
            // lblRemoteDirectory
            // 
            this.lblRemoteDirectory.AutoSize = true;
            this.lblRemoteDirectory.Location = new System.Drawing.Point(12, 87);
            this.lblRemoteDirectory.Name = "lblRemoteDirectory";
            this.lblRemoteDirectory.Size = new System.Drawing.Size(90, 13);
            this.lblRemoteDirectory.TabIndex = 8;
            this.lblRemoteDirectory.Text = "Remote directory:";
            // 
            // tbxRemoteDirectory
            // 
            this.tbxRemoteDirectory.Location = new System.Drawing.Point(110, 84);
            this.tbxRemoteDirectory.MaxLength = 128;
            this.tbxRemoteDirectory.Name = "tbxRemoteDirectory";
            this.tbxRemoteDirectory.Size = new System.Drawing.Size(185, 20);
            this.tbxRemoteDirectory.TabIndex = 3;
            // 
            // chkOpenAfterCreation
            // 
            this.chkOpenAfterCreation.AutoSize = true;
            this.chkOpenAfterCreation.Location = new System.Drawing.Point(110, 110);
            this.chkOpenAfterCreation.Name = "chkOpenAfterCreation";
            this.chkOpenAfterCreation.Size = new System.Drawing.Size(159, 17);
            this.chkOpenAfterCreation.TabIndex = 4;
            this.chkOpenAfterCreation.Text = "Open Image after Uploading";
            this.chkOpenAfterCreation.UseVisualStyleBackColor = true;
            // 
            // frmConfigwizard
            // 
            this.AcceptButton = this.btnSaveRun;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 162);
            this.Controls.Add(this.chkOpenAfterCreation);
            this.Controls.Add(this.lblRemoteDirectory);
            this.Controls.Add(this.tbxRemoteDirectory);
            this.Controls.Add(this.btnSaveRun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblServeraddress);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.tbxUsername);
            this.Controls.Add(this.tbxServerAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfigwizard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration Creator";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}