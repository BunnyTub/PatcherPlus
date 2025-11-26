namespace Akatsuki.Loader
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.PlayButton = new System.Windows.Forms.Button();
            this.TitleText = new System.Windows.Forms.Label();
            this.BackgroundProgressBar = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.OsuLocationText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayButton.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.PlayButton.Location = new System.Drawing.Point(498, 228);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(135, 47);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Launch";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // TitleText
            // 
            this.TitleText.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleText.ForeColor = System.Drawing.Color.White;
            this.TitleText.Location = new System.Drawing.Point(9, 9);
            this.TitleText.Margin = new System.Windows.Forms.Padding(0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(627, 60);
            this.TitleText.TabIndex = 1;
            this.TitleText.Text = "Ready to play?";
            // 
            // BackgroundProgressBar
            // 
            this.BackgroundProgressBar.Location = new System.Drawing.Point(498, 228);
            this.BackgroundProgressBar.MarqueeAnimationSpeed = 22;
            this.BackgroundProgressBar.Name = "BackgroundProgressBar";
            this.BackgroundProgressBar.Size = new System.Drawing.Size(135, 47);
            this.BackgroundProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.BackgroundProgressBar.TabIndex = 2;
            this.BackgroundProgressBar.Value = 50;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // OsuLocationText
            // 
            this.OsuLocationText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OsuLocationText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.OsuLocationText.Location = new System.Drawing.Point(9, 228);
            this.OsuLocationText.Margin = new System.Windows.Forms.Padding(0);
            this.OsuLocationText.Name = "OsuLocationText";
            this.OsuLocationText.Size = new System.Drawing.Size(486, 47);
            this.OsuLocationText.TabIndex = 3;
            this.OsuLocationText.Text = "Located osu! at C:\\Users\\example\\osu!.exe, but if this isn\'t right, you can click" +
    " the Change button.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(645, 287);
            this.Controls.Add(this.OsuLocationText);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.BackgroundProgressBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PatcherPlus";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.ProgressBar BackgroundProgressBar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label OsuLocationText;
    }
}