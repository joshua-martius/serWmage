namespace serwmImageUploader.Forms
{
    partial class frmCrashlog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrashlog));
            this.rtbCrashlog = new System.Windows.Forms.RichTextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbCrashlog
            // 
            this.rtbCrashlog.Location = new System.Drawing.Point(12, 12);
            this.rtbCrashlog.Name = "rtbCrashlog";
            this.rtbCrashlog.ReadOnly = true;
            this.rtbCrashlog.Size = new System.Drawing.Size(459, 229);
            this.rtbCrashlog.TabIndex = 0;
            this.rtbCrashlog.Text = "";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(12, 247);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(459, 23);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "Clear Logfile";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // frmCrashlog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 277);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.rtbCrashlog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCrashlog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "serWmage - Crashlog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbCrashlog;
        private System.Windows.Forms.Button btnClearLog;
    }
}