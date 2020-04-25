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
            this.btnHide = new System.Windows.Forms.Button();
            this.btnOpenConfiguration = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(12, 63);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(139, 45);
            this.btnHide.TabIndex = 0;
            this.btnHide.Text = "Minimize";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnOpenConfiguration
            // 
            this.btnOpenConfiguration.Location = new System.Drawing.Point(12, 12);
            this.btnOpenConfiguration.Name = "btnOpenConfiguration";
            this.btnOpenConfiguration.Size = new System.Drawing.Size(139, 45);
            this.btnOpenConfiguration.TabIndex = 1;
            this.btnOpenConfiguration.Text = "Open Configuration";
            this.btnOpenConfiguration.UseVisualStyleBackColor = true;
            this.btnOpenConfiguration.Click += new System.EventHandler(this.btnOpenConfiguration_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(163, 118);
            this.Controls.Add(this.btnOpenConfiguration);
            this.Controls.Add(this.btnHide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "serWmImageUploader";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnOpenConfiguration;
    }
}

