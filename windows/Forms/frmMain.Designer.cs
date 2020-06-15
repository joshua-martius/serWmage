namespace serwmImageUploader
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnHide = new System.Windows.Forms.Button();
            this.btnOpenConfiguration = new System.Windows.Forms.Button();
            this.btnShowCrashfile = new System.Windows.Forms.Button();
            this.btnUploadCustom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(12, 165);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(139, 45);
            this.btnHide.TabIndex = 2;
            this.btnHide.Text = "Move to Background";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnOpenConfiguration
            // 
            this.btnOpenConfiguration.Location = new System.Drawing.Point(12, 63);
            this.btnOpenConfiguration.Name = "btnOpenConfiguration";
            this.btnOpenConfiguration.Size = new System.Drawing.Size(139, 45);
            this.btnOpenConfiguration.TabIndex = 3;
            this.btnOpenConfiguration.Text = "Open Configuration";
            this.btnOpenConfiguration.UseVisualStyleBackColor = true;
            this.btnOpenConfiguration.Click += new System.EventHandler(this.btnOpenConfiguration_Click);
            // 
            // btnShowCrashfile
            // 
            this.btnShowCrashfile.Location = new System.Drawing.Point(12, 114);
            this.btnShowCrashfile.Name = "btnShowCrashfile";
            this.btnShowCrashfile.Size = new System.Drawing.Size(139, 45);
            this.btnShowCrashfile.TabIndex = 1;
            this.btnShowCrashfile.Text = "Show Crashfile";
            this.btnShowCrashfile.UseVisualStyleBackColor = true;
            this.btnShowCrashfile.Click += new System.EventHandler(this.btnShowCrashfile_Click);
            // 
            // btnUploadCustom
            // 
            this.btnUploadCustom.Location = new System.Drawing.Point(12, 12);
            this.btnUploadCustom.Name = "btnUploadCustom";
            this.btnUploadCustom.Size = new System.Drawing.Size(139, 45);
            this.btnUploadCustom.TabIndex = 0;
            this.btnUploadCustom.Text = "Upload own Image";
            this.btnUploadCustom.UseVisualStyleBackColor = true;
            this.btnUploadCustom.Click += new System.EventHandler(this.btnUploadCustom_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(164, 216);
            this.Controls.Add(this.btnUploadCustom);
            this.Controls.Add(this.btnShowCrashfile);
            this.Controls.Add(this.btnOpenConfiguration);
            this.Controls.Add(this.btnHide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "serWmage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnOpenConfiguration;
        private System.Windows.Forms.Button btnShowCrashfile;
        private System.Windows.Forms.Button btnUploadCustom;
    }
}

