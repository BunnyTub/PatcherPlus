namespace PatcherPlus.Loader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PlayButton = new System.Windows.Forms.Button();
            this.BackgroundProgressBar = new System.Windows.Forms.ProgressBar();
            this.FadeOut = new System.Windows.Forms.Timer(this.components);
            this.OsuLocationText = new System.Windows.Forms.Label();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.BannerMessageText = new System.Windows.Forms.Label();
            this.ShowPathBox = new System.Windows.Forms.CheckBox();
            this.AutoPatchBox = new System.Windows.Forms.CheckBox();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.BannerMessageBox = new System.Windows.Forms.PictureBox();
            this.InfoText = new System.Windows.Forms.Label();
            this.OpenOsuExeFileWindow = new System.Windows.Forms.OpenFileDialog();
            this.AutoPatch = new System.Windows.Forms.Timer(this.components);
            this.CheckButton = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.LogoBox = new System.Windows.Forms.PictureBox();
            this.TitleText = new System.Windows.Forms.Label();
            this.FadeInAnimation = new System.Windows.Forms.Timer(this.components);
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BannerMessageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.PlayButton.Enabled = false;
            this.PlayButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.PlayButton.FlatAppearance.BorderSize = 2;
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayButton.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.PlayButton.ForeColor = System.Drawing.Color.Cornsilk;
            this.PlayButton.Location = new System.Drawing.Point(316, 83);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(135, 47);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Visible = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // BackgroundProgressBar
            // 
            this.BackgroundProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundProgressBar.Location = new System.Drawing.Point(316, 83);
            this.BackgroundProgressBar.MarqueeAnimationSpeed = 22;
            this.BackgroundProgressBar.Name = "BackgroundProgressBar";
            this.BackgroundProgressBar.Size = new System.Drawing.Size(135, 47);
            this.BackgroundProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.BackgroundProgressBar.TabIndex = 2;
            this.BackgroundProgressBar.Value = 50;
            // 
            // FadeOut
            // 
            this.FadeOut.Interval = 20;
            this.FadeOut.Tick += new System.EventHandler(this.FadeOut_Tick);
            // 
            // OsuLocationText
            // 
            this.OsuLocationText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OsuLocationText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.OsuLocationText.ForeColor = System.Drawing.Color.Orange;
            this.OsuLocationText.Location = new System.Drawing.Point(9, 154);
            this.OsuLocationText.Margin = new System.Windows.Forms.Padding(0);
            this.OsuLocationText.Name = "OsuLocationText";
            this.OsuLocationText.Size = new System.Drawing.Size(445, 44);
            this.OsuLocationText.TabIndex = 3;
            this.OsuLocationText.Text = "Searching for osu!...";
            this.OsuLocationText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OsuLocationText.Click += new System.EventHandler(this.OsuLocationText_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.BannerMessageText);
            this.BottomPanel.Controls.Add(this.ShowPathBox);
            this.BottomPanel.Controls.Add(this.AutoPatchBox);
            this.BottomPanel.Controls.Add(this.ChangeButton);
            this.BottomPanel.Controls.Add(this.PlayButton);
            this.BottomPanel.Controls.Add(this.BackgroundProgressBar);
            this.BottomPanel.Controls.Add(this.BannerMessageBox);
            this.BottomPanel.Controls.Add(this.InfoText);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 201);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(463, 142);
            this.BottomPanel.TabIndex = 4;
            // 
            // BannerMessageText
            // 
            this.BannerMessageText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BannerMessageText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.BannerMessageText.ForeColor = System.Drawing.Color.Gray;
            this.BannerMessageText.Location = new System.Drawing.Point(9, 54);
            this.BannerMessageText.Margin = new System.Windows.Forms.Padding(0);
            this.BannerMessageText.Name = "BannerMessageText";
            this.BannerMessageText.Size = new System.Drawing.Size(304, 26);
            this.BannerMessageText.TabIndex = 7;
            this.BannerMessageText.Text = "This tool is not compatible with osu!(lazer).";
            this.BannerMessageText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BannerMessageText.Click += new System.EventHandler(this.BannerMessageText_Click);
            // 
            // ShowPathBox
            // 
            this.ShowPathBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowPathBox.AutoSize = true;
            this.ShowPathBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ShowPathBox.Location = new System.Drawing.Point(345, 4);
            this.ShowPathBox.Name = "ShowPathBox";
            this.ShowPathBox.Size = new System.Drawing.Size(106, 19);
            this.ShowPathBox.TabIndex = 7;
            this.ShowPathBox.Text = "Show file paths";
            this.ShowPathBox.UseVisualStyleBackColor = true;
            this.ShowPathBox.CheckedChanged += new System.EventHandler(this.ShowPathBox_CheckedChanged);
            // 
            // AutoPatchBox
            // 
            this.AutoPatchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoPatchBox.AutoSize = true;
            this.AutoPatchBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AutoPatchBox.Location = new System.Drawing.Point(271, 29);
            this.AutoPatchBox.Name = "AutoPatchBox";
            this.AutoPatchBox.Size = new System.Drawing.Size(180, 19);
            this.AutoPatchBox.TabIndex = 6;
            this.AutoPatchBox.Text = "Automatically patch on open";
            this.AutoPatchBox.UseVisualStyleBackColor = true;
            this.AutoPatchBox.CheckedChanged += new System.EventHandler(this.AutoPatchBox_CheckedChanged);
            // 
            // ChangeButton
            // 
            this.ChangeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ChangeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ChangeButton.FlatAppearance.BorderSize = 2;
            this.ChangeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.ChangeButton.ForeColor = System.Drawing.Color.Cornsilk;
            this.ChangeButton.Location = new System.Drawing.Point(316, 54);
            this.ChangeButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(135, 26);
            this.ChangeButton.TabIndex = 3;
            this.ChangeButton.Text = "Change File Path";
            this.ChangeButton.UseVisualStyleBackColor = false;
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // BannerMessageBox
            // 
            this.BannerMessageBox.Image = global::PatcherPlus.Loader.Properties.Resources.NotByAkatsuki;
            this.BannerMessageBox.Location = new System.Drawing.Point(9, 83);
            this.BannerMessageBox.Name = "BannerMessageBox";
            this.BannerMessageBox.Size = new System.Drawing.Size(304, 47);
            this.BannerMessageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BannerMessageBox.TabIndex = 7;
            this.BannerMessageBox.TabStop = false;
            this.BannerMessageBox.Click += new System.EventHandler(this.BannerMessageBox_Click);
            // 
            // InfoText
            // 
            this.InfoText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.InfoText.Font = new System.Drawing.Font("Montserrat", 14F);
            this.InfoText.ForeColor = System.Drawing.Color.Cornsilk;
            this.InfoText.Location = new System.Drawing.Point(9, 83);
            this.InfoText.Margin = new System.Windows.Forms.Padding(0);
            this.InfoText.Name = "InfoText";
            this.InfoText.Size = new System.Drawing.Size(304, 47);
            this.InfoText.TabIndex = 6;
            this.InfoText.Text = "PatcherPlus is not owned by PatcherPlus. Click to know more.";
            this.InfoText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.InfoText.Click += new System.EventHandler(this.InfoText_Click);
            // 
            // OpenOsuExeFileWindow
            // 
            this.OpenOsuExeFileWindow.DefaultExt = "exe";
            this.OpenOsuExeFileWindow.Filter = "osu! executable files|osu!.exe";
            this.OpenOsuExeFileWindow.SupportMultiDottedExtensions = true;
            this.OpenOsuExeFileWindow.Title = "PatcherPlus - Select osu! executable (not compatible with osu!lazer)";
            this.OpenOsuExeFileWindow.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenOsuExeFileWindow_FileOk);
            // 
            // AutoPatch
            // 
            this.AutoPatch.Enabled = true;
            this.AutoPatch.Tick += new System.EventHandler(this.AutoPatch_Tick);
            // 
            // CheckButton
            // 
            this.CheckButton.Enabled = true;
            this.CheckButton.Tick += new System.EventHandler(this.CheckButton_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 2);
            this.panel1.TabIndex = 6;
            // 
            // LogoBox
            // 
            this.LogoBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoBox.Image = global::PatcherPlus.Loader.Properties.Resources.AkatsukiLogoLowRes;
            this.LogoBox.Location = new System.Drawing.Point(0, 68);
            this.LogoBox.Name = "LogoBox";
            this.LogoBox.Size = new System.Drawing.Size(463, 86);
            this.LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoBox.TabIndex = 5;
            this.LogoBox.TabStop = false;
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
            this.TitleText.TabIndex = 1;
            this.TitleText.Text = "Ready to play?";
            this.TitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FadeInAnimation
            // 
            this.FadeInAnimation.Enabled = true;
            this.FadeInAnimation.Interval = 2;
            this.FadeInAnimation.Tick += new System.EventHandler(this.FadeInAnimation_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(463, 343);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LogoBox);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.OsuLocationText);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PatcherPlus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BannerMessageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button PlayButton;
        public System.Windows.Forms.Label TitleText;
        public System.Windows.Forms.Label OsuLocationText;
        public System.Windows.Forms.Timer FadeOut;
        public System.Windows.Forms.ProgressBar BackgroundProgressBar;
        private System.Windows.Forms.Panel BottomPanel;
        public System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.OpenFileDialog OpenOsuExeFileWindow;
        private System.Windows.Forms.Timer AutoPatch;
        private System.Windows.Forms.CheckBox AutoPatchBox;
        private System.Windows.Forms.Timer CheckButton;
        private System.Windows.Forms.CheckBox ShowPathBox;
        public System.Windows.Forms.Label InfoText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox BannerMessageBox;
        private System.Windows.Forms.Timer FadeInAnimation;
        public System.Windows.Forms.Label BannerMessageText;
    }
}