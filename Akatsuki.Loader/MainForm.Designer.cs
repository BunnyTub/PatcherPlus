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
            this.FadeOut = new System.Windows.Forms.Timer(this.components);
            this.OsuLocationText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AutoPatchBox = new System.Windows.Forms.CheckBox();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.OpenOsuExeFileWindow = new System.Windows.Forms.OpenFileDialog();
            this.AutoPatch = new System.Windows.Forms.Timer(this.components);
            this.CheckButton = new System.Windows.Forms.Timer(this.components);
            this.ShowPathBox = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.PlayButton.Enabled = false;
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PlayButton.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.PlayButton.ForeColor = System.Drawing.Color.Cornsilk;
            this.PlayButton.Location = new System.Drawing.Point(447, 36);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(135, 47);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Visible = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // TitleText
            // 
            this.TitleText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TitleText.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleText.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleText.ForeColor = System.Drawing.Color.White;
            this.TitleText.Location = new System.Drawing.Point(0, 0);
            this.TitleText.Margin = new System.Windows.Forms.Padding(0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.TitleText.Size = new System.Drawing.Size(594, 60);
            this.TitleText.TabIndex = 1;
            this.TitleText.Text = "Ready to play?";
            // 
            // BackgroundProgressBar
            // 
            this.BackgroundProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundProgressBar.Location = new System.Drawing.Point(447, 36);
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
            this.OsuLocationText.Location = new System.Drawing.Point(9, 228);
            this.OsuLocationText.Margin = new System.Windows.Forms.Padding(0);
            this.OsuLocationText.Name = "OsuLocationText";
            this.OsuLocationText.Size = new System.Drawing.Size(435, 47);
            this.OsuLocationText.TabIndex = 3;
            this.OsuLocationText.Text = "Searching for osu!...";
            this.OsuLocationText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OsuLocationText.Click += new System.EventHandler(this.OsuLocationText_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ShowPathBox);
            this.panel1.Controls.Add(this.AutoPatchBox);
            this.panel1.Controls.Add(this.ChangeButton);
            this.panel1.Controls.Add(this.PlayButton);
            this.panel1.Controls.Add(this.BackgroundProgressBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 192);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 95);
            this.panel1.TabIndex = 4;
            // 
            // AutoPatchBox
            // 
            this.AutoPatchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoPatchBox.AutoSize = true;
            this.AutoPatchBox.Location = new System.Drawing.Point(261, 13);
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
            this.ChangeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ChangeButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ChangeButton.ForeColor = System.Drawing.Color.Cornsilk;
            this.ChangeButton.Location = new System.Drawing.Point(447, 10);
            this.ChangeButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(135, 23);
            this.ChangeButton.TabIndex = 3;
            this.ChangeButton.Text = "Change File Path";
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
            // ShowPathBox
            // 
            this.ShowPathBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowPathBox.AutoSize = true;
            this.ShowPathBox.Location = new System.Drawing.Point(149, 13);
            this.ShowPathBox.Name = "ShowPathBox";
            this.ShowPathBox.Size = new System.Drawing.Size(106, 19);
            this.ShowPathBox.TabIndex = 7;
            this.ShowPathBox.Text = "Show file paths";
            this.ShowPathBox.UseVisualStyleBackColor = true;
            this.ShowPathBox.CheckedChanged += new System.EventHandler(this.ShowPathBox_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Akatsuki.Loader.Properties.Resources.AkatsukiLogoLowRes;
            this.pictureBox1.Location = new System.Drawing.Point(447, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(594, 287);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.OsuLocationText);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PatcherPlus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button PlayButton;
        public System.Windows.Forms.Label TitleText;
        public System.Windows.Forms.Label OsuLocationText;
        public System.Windows.Forms.Timer FadeOut;
        public System.Windows.Forms.ProgressBar BackgroundProgressBar;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog OpenOsuExeFileWindow;
        private System.Windows.Forms.Timer AutoPatch;
        private System.Windows.Forms.CheckBox AutoPatchBox;
        private System.Windows.Forms.Timer CheckButton;
        private System.Windows.Forms.CheckBox ShowPathBox;
    }
}