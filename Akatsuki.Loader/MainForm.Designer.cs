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
            this.BannerMessageBox = new System.Windows.Forms.PictureBox();
            this.BannerMessageText = new System.Windows.Forms.Label();
            this.ShowMoreButton = new System.Windows.Forms.Button();
            this.AutoPatchBox = new System.Windows.Forms.CheckBox();
            this.ServerOptionsText = new System.Windows.Forms.Label();
            this.ServerOptionsPanel = new System.Windows.Forms.Panel();
            this.EnableOsuCoinsBox = new System.Windows.Forms.CheckBox();
            this.NoAdditionalOptionsText = new System.Windows.Forms.Label();
            this.SideSpacerPanel = new System.Windows.Forms.Panel();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.OpenOsuExeFileWindow = new System.Windows.Forms.OpenFileDialog();
            this.AutoPatch = new System.Windows.Forms.Timer(this.components);
            this.CheckButton = new System.Windows.Forms.Timer(this.components);
            this.SpacerPanel = new System.Windows.Forms.Panel();
            this.FadeInAnimation = new System.Windows.Forms.Timer(this.components);
            this.LogoAnimation = new System.Windows.Forms.Timer(this.components);
            this.OsuServerText = new System.Windows.Forms.Label();
            this.LogoBox = new System.Windows.Forms.PictureBox();
            this.TitleText = new System.Windows.Forms.Label();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BannerMessageBox)).BeginInit();
            this.ServerOptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.PlayButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.PlayButton.FlatAppearance.BorderSize = 2;
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayButton.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.PlayButton.ForeColor = System.Drawing.Color.Cornsilk;
            this.PlayButton.Location = new System.Drawing.Point(317, 81);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(135, 47);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // BackgroundProgressBar
            // 
            this.BackgroundProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundProgressBar.Location = new System.Drawing.Point(317, 82);
            this.BackgroundProgressBar.MarqueeAnimationSpeed = 22;
            this.BackgroundProgressBar.Name = "BackgroundProgressBar";
            this.BackgroundProgressBar.Size = new System.Drawing.Size(135, 45);
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
            this.OsuLocationText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.OsuLocationText.ForeColor = System.Drawing.Color.Orange;
            this.OsuLocationText.Location = new System.Drawing.Point(0, 187);
            this.OsuLocationText.Margin = new System.Windows.Forms.Padding(0);
            this.OsuLocationText.Name = "OsuLocationText";
            this.OsuLocationText.Size = new System.Drawing.Size(464, 44);
            this.OsuLocationText.TabIndex = 3;
            this.OsuLocationText.Text = "Searching for osu!...";
            this.OsuLocationText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OsuLocationText.Click += new System.EventHandler(this.OsuLocationText_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.BannerMessageBox);
            this.BottomPanel.Controls.Add(this.BannerMessageText);
            this.BottomPanel.Controls.Add(this.ShowMoreButton);
            this.BottomPanel.Controls.Add(this.AutoPatchBox);
            this.BottomPanel.Controls.Add(this.ServerOptionsText);
            this.BottomPanel.Controls.Add(this.ServerOptionsPanel);
            this.BottomPanel.Controls.Add(this.ChangeButton);
            this.BottomPanel.Controls.Add(this.PlayButton);
            this.BottomPanel.Controls.Add(this.BackgroundProgressBar);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 221);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(464, 140);
            this.BottomPanel.TabIndex = 4;
            // 
            // BannerMessageBox
            // 
            this.BannerMessageBox.Image = global::PatcherPlus.Loader.Properties.Resources.NotByAkatsuki;
            this.BannerMessageBox.Location = new System.Drawing.Point(12, -12);
            this.BannerMessageBox.Name = "BannerMessageBox";
            this.BannerMessageBox.Size = new System.Drawing.Size(304, 47);
            this.BannerMessageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BannerMessageBox.TabIndex = 7;
            this.BannerMessageBox.TabStop = false;
            this.BannerMessageBox.Visible = false;
            this.BannerMessageBox.Click += new System.EventHandler(this.BannerMessageBox_Click);
            this.BannerMessageBox.MouseEnter += new System.EventHandler(this.BannerMessageBox_MouseEnter);
            this.BannerMessageBox.MouseLeave += new System.EventHandler(this.BannerMessageBox_MouseLeave);
            // 
            // BannerMessageText
            // 
            this.BannerMessageText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BannerMessageText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.BannerMessageText.ForeColor = System.Drawing.Color.Gray;
            this.BannerMessageText.Location = new System.Drawing.Point(124, 52);
            this.BannerMessageText.Margin = new System.Windows.Forms.Padding(0);
            this.BannerMessageText.Name = "BannerMessageText";
            this.BannerMessageText.Size = new System.Drawing.Size(186, 26);
            this.BannerMessageText.TabIndex = 7;
            this.BannerMessageText.Text = "How does this tool work?";
            this.BannerMessageText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BannerMessageText.Click += new System.EventHandler(this.BannerMessageText_Click);
            this.BannerMessageText.MouseEnter += new System.EventHandler(this.BannerMessageText_MouseEnter);
            this.BannerMessageText.MouseLeave += new System.EventHandler(this.BannerMessageText_MouseLeave);
            // 
            // ShowMoreButton
            // 
            this.ShowMoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowMoreButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ShowMoreButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ShowMoreButton.FlatAppearance.BorderSize = 2;
            this.ShowMoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowMoreButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.ShowMoreButton.ForeColor = System.Drawing.Color.Cornsilk;
            this.ShowMoreButton.Location = new System.Drawing.Point(406, 52);
            this.ShowMoreButton.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.ShowMoreButton.Name = "ShowMoreButton";
            this.ShowMoreButton.Size = new System.Drawing.Size(46, 26);
            this.ShowMoreButton.TabIndex = 11;
            this.ShowMoreButton.Text = "More";
            this.ShowMoreButton.UseVisualStyleBackColor = false;
            this.ShowMoreButton.Click += new System.EventHandler(this.ShowMoreButton_Click);
            // 
            // AutoPatchBox
            // 
            this.AutoPatchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoPatchBox.AutoSize = true;
            this.AutoPatchBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AutoPatchBox.Location = new System.Drawing.Point(367, 27);
            this.AutoPatchBox.Name = "AutoPatchBox";
            this.AutoPatchBox.Size = new System.Drawing.Size(85, 19);
            this.AutoPatchBox.TabIndex = 6;
            this.AutoPatchBox.Text = "Auto Patch";
            this.AutoPatchBox.UseVisualStyleBackColor = true;
            this.AutoPatchBox.CheckedChanged += new System.EventHandler(this.AutoPatchBox_CheckedChanged);
            // 
            // ServerOptionsText
            // 
            this.ServerOptionsText.Location = new System.Drawing.Point(12, 52);
            this.ServerOptionsText.Name = "ServerOptionsText";
            this.ServerOptionsText.Size = new System.Drawing.Size(299, 26);
            this.ServerOptionsText.TabIndex = 10;
            this.ServerOptionsText.Text = "Server Options";
            this.ServerOptionsText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ServerOptionsPanel
            // 
            this.ServerOptionsPanel.BackColor = System.Drawing.Color.Black;
            this.ServerOptionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServerOptionsPanel.Controls.Add(this.EnableOsuCoinsBox);
            this.ServerOptionsPanel.Controls.Add(this.NoAdditionalOptionsText);
            this.ServerOptionsPanel.Controls.Add(this.SideSpacerPanel);
            this.ServerOptionsPanel.Location = new System.Drawing.Point(12, 81);
            this.ServerOptionsPanel.Name = "ServerOptionsPanel";
            this.ServerOptionsPanel.Size = new System.Drawing.Size(299, 47);
            this.ServerOptionsPanel.TabIndex = 9;
            // 
            // EnableOsuCoinsBox
            // 
            this.EnableOsuCoinsBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.EnableOsuCoinsBox.Location = new System.Drawing.Point(1, 20);
            this.EnableOsuCoinsBox.Name = "EnableOsuCoinsBox";
            this.EnableOsuCoinsBox.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.EnableOsuCoinsBox.Size = new System.Drawing.Size(296, 19);
            this.EnableOsuCoinsBox.TabIndex = 8;
            this.EnableOsuCoinsBox.Text = "Enable Coins";
            this.EnableOsuCoinsBox.UseVisualStyleBackColor = true;
            this.EnableOsuCoinsBox.Visible = false;
            this.EnableOsuCoinsBox.CheckedChanged += new System.EventHandler(this.EnableOsuCoinsBox_CheckedChanged);
            // 
            // NoAdditionalOptionsText
            // 
            this.NoAdditionalOptionsText.Dock = System.Windows.Forms.DockStyle.Top;
            this.NoAdditionalOptionsText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.NoAdditionalOptionsText.Location = new System.Drawing.Point(1, 0);
            this.NoAdditionalOptionsText.Name = "NoAdditionalOptionsText";
            this.NoAdditionalOptionsText.Size = new System.Drawing.Size(296, 20);
            this.NoAdditionalOptionsText.TabIndex = 11;
            this.NoAdditionalOptionsText.Text = "This server has no additional options.";
            this.NoAdditionalOptionsText.Visible = false;
            // 
            // SideSpacerPanel
            // 
            this.SideSpacerPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SideSpacerPanel.Location = new System.Drawing.Point(0, 0);
            this.SideSpacerPanel.Name = "SideSpacerPanel";
            this.SideSpacerPanel.Size = new System.Drawing.Size(1, 45);
            this.SideSpacerPanel.TabIndex = 12;
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
            this.ChangeButton.Location = new System.Drawing.Point(317, 52);
            this.ChangeButton.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(86, 26);
            this.ChangeButton.TabIndex = 3;
            this.ChangeButton.Text = "Change Path";
            this.ChangeButton.UseVisualStyleBackColor = false;
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
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
            // SpacerPanel
            // 
            this.SpacerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.SpacerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SpacerPanel.Location = new System.Drawing.Point(0, 60);
            this.SpacerPanel.Name = "SpacerPanel";
            this.SpacerPanel.Size = new System.Drawing.Size(464, 4);
            this.SpacerPanel.TabIndex = 6;
            // 
            // FadeInAnimation
            // 
            this.FadeInAnimation.Enabled = true;
            this.FadeInAnimation.Interval = 10;
            this.FadeInAnimation.Tick += new System.EventHandler(this.FadeInAnimation_Tick);
            // 
            // LogoAnimation
            // 
            this.LogoAnimation.Interval = 15;
            this.LogoAnimation.Tick += new System.EventHandler(this.LogoAnimation_Tick);
            // 
            // OsuServerText
            // 
            this.OsuServerText.Dock = System.Windows.Forms.DockStyle.Top;
            this.OsuServerText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.OsuServerText.ForeColor = System.Drawing.Color.White;
            this.OsuServerText.Location = new System.Drawing.Point(0, 64);
            this.OsuServerText.Name = "OsuServerText";
            this.OsuServerText.Size = new System.Drawing.Size(464, 26);
            this.OsuServerText.TabIndex = 12;
            this.OsuServerText.Text = "Welcome to PatcherPlus!";
            this.OsuServerText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogoBox
            // 
            this.LogoBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.LogoBox.Image = global::PatcherPlus.Loader.Properties.Resources.NoServerSelected;
            this.LogoBox.Location = new System.Drawing.Point(0, 90);
            this.LogoBox.Name = "LogoBox";
            this.LogoBox.Size = new System.Drawing.Size(464, 96);
            this.LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoBox.TabIndex = 5;
            this.LogoBox.TabStop = false;
            this.LogoBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LogoBox_MouseClick);
            this.LogoBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LogoBox_MouseDoubleClick);
            this.LogoBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LogoBox_MouseDown);
            this.LogoBox.MouseEnter += new System.EventHandler(this.LogoBox_MouseEnter);
            this.LogoBox.MouseLeave += new System.EventHandler(this.LogoBox_MouseLeave);
            this.LogoBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LogoBox_MouseUp);
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
            this.TitleText.Size = new System.Drawing.Size(464, 60);
            this.TitleText.TabIndex = 1;
            this.TitleText.Text = "Ready to play?";
            this.TitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TitleText.Click += new System.EventHandler(this.TitleText_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(464, 361);
            this.Controls.Add(this.LogoBox);
            this.Controls.Add(this.OsuServerText);
            this.Controls.Add(this.SpacerPanel);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.OsuLocationText);
            this.Controls.Add(this.BottomPanel);
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
            this.ServerOptionsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button PlayButton;
        public System.Windows.Forms.Label TitleText;
        public System.Windows.Forms.Label OsuLocationText;
        public System.Windows.Forms.Timer FadeOut;
        public System.Windows.Forms.ProgressBar BackgroundProgressBar;
        public System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.OpenFileDialog OpenOsuExeFileWindow;
        private System.Windows.Forms.Timer AutoPatch;
        private System.Windows.Forms.CheckBox AutoPatchBox;
        private System.Windows.Forms.Timer CheckButton;
        private System.Windows.Forms.Panel SpacerPanel;
        private System.Windows.Forms.PictureBox BannerMessageBox;
        private System.Windows.Forms.Timer FadeInAnimation;
        public System.Windows.Forms.Label BannerMessageText;
        private System.Windows.Forms.Timer LogoAnimation;
        private System.Windows.Forms.CheckBox EnableOsuCoinsBox;
        private System.Windows.Forms.Panel ServerOptionsPanel;
        private System.Windows.Forms.Label ServerOptionsText;
        private System.Windows.Forms.Label NoAdditionalOptionsText;
        private System.Windows.Forms.Label OsuServerText;
        private System.Windows.Forms.Panel SideSpacerPanel;
        public System.Windows.Forms.Button ShowMoreButton;
        public System.Windows.Forms.Panel BottomPanel;
    }
}