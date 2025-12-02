namespace PatcherPlus.Loader
{
    partial class WonkyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WonkyForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.TitleText = new System.Windows.Forms.Label();
            this.SubtitleText = new System.Windows.Forms.Label();
            this.ErrorInfoOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 2);
            this.panel1.TabIndex = 8;
            // 
            // TitleText
            // 
            this.TitleText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.TitleText.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleText.Font = new System.Drawing.Font("Arial", 26F);
            this.TitleText.ForeColor = System.Drawing.Color.White;
            this.TitleText.Image = global::PatcherPlus.Loader.Properties.Resources.TriangleTop;
            this.TitleText.Location = new System.Drawing.Point(0, 0);
            this.TitleText.Margin = new System.Windows.Forms.Padding(0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.TitleText.Size = new System.Drawing.Size(463, 60);
            this.TitleText.TabIndex = 7;
            this.TitleText.Text = "Things went wonky!";
            this.TitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SubtitleText
            // 
            this.SubtitleText.BackColor = System.Drawing.Color.White;
            this.SubtitleText.Dock = System.Windows.Forms.DockStyle.Top;
            this.SubtitleText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.SubtitleText.ForeColor = System.Drawing.Color.Black;
            this.SubtitleText.Location = new System.Drawing.Point(0, 62);
            this.SubtitleText.Margin = new System.Windows.Forms.Padding(0);
            this.SubtitleText.Name = "SubtitleText";
            this.SubtitleText.Size = new System.Drawing.Size(463, 56);
            this.SubtitleText.TabIndex = 9;
            this.SubtitleText.Text = "Something didn\'t work as intended.\r\nPlease report this problem if it keeps happen" +
    "ing!";
            this.SubtitleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ErrorInfoOutput
            // 
            this.ErrorInfoOutput.BackColor = System.Drawing.Color.White;
            this.ErrorInfoOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ErrorInfoOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorInfoOutput.Location = new System.Drawing.Point(0, 118);
            this.ErrorInfoOutput.Multiline = true;
            this.ErrorInfoOutput.Name = "ErrorInfoOutput";
            this.ErrorInfoOutput.ReadOnly = true;
            this.ErrorInfoOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ErrorInfoOutput.Size = new System.Drawing.Size(463, 225);
            this.ErrorInfoOutput.TabIndex = 10;
            this.ErrorInfoOutput.WordWrap = false;
            // 
            // WonkyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(463, 343);
            this.Controls.Add(this.ErrorInfoOutput);
            this.Controls.Add(this.SubtitleText);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TitleText);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WonkyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PatcherPlus - uuuuuuuuu";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label TitleText;
        public System.Windows.Forms.Label SubtitleText;
        public System.Windows.Forms.TextBox ErrorInfoOutput;
    }
}