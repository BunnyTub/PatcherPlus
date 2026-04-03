using PatcherPlus.Loader.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using static PatcherPlus.Loader.LoaderHub;

namespace PatcherPlus.Loader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Styles.AddMemoryFont(Resources.Montserrat_Regular);
            TitleText.Font = Styles.GetFont(0, 26, FontStyle.Regular);
            OsuServerText.Font = Styles.GetFont(0, 11, FontStyle.Regular);
            //OsuLocationText.Font = Styles.GetFont(0, 11, FontStyle.Regular); // mehh, it gets lower quality the lower the size is (obviously), doesn't look great
            //PlayButton.Font = Styles.GetFont(0, 18, FontStyle.Regular);
            Opacity = 0;
            LogoBox.Height = 1;
        }

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);

        private bool IsShiftDown()
        {
            return (GetAsyncKeyState(Keys.ShiftKey) & 0x8000) != 0;
        }

        private bool _ShowMore = false;
        private bool ShowMore
        {
            get
            {
                return _ShowMore;
            }
            set
            {
                _ShowMore = value;
                if (value)
                {
                    ShowMoreButton.Text = "Less";
                }
                else
                {
                    ShowMoreButton.Text = "More";
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TitleText.Text = "Ready to play?";
            TitleText.ForeColor = Color.White;
            if (!string.IsNullOrEmpty(Program.OsuExecutablePath))
            {
                FoundOsuAt(Program.OsuExecutablePath);
            }
            else
            {
                OsuLocationText.Text = $"Could not find osu! on your system. Try opening the game!";

                string text = Utilities.FindInRegistry();

                if (!string.IsNullOrWhiteSpace(text))
                {
                    Program.OsuExecutablePath = text;
                    FoundOsuAt(text);
                }
                else
                {
                }
            }

            AutoPatchBox.Checked = Settings.Default.AutoPatch;
            ShowMore = Settings.Default.ShowPath;

            if (ShowMore)
            {
                OsuLocationText.Visible = true;
                AnimateLogo(96);
            }
            else
            {
                OsuLocationText.Visible = false;
                AnimateLogo(148);
            }

            switch (Settings.Default.LastServer.ToLowerInvariant())
            {
                case "akatsuki":
                    CurrentServer = Server.Akatsuki;
                    break;
                case "realistik":
                    CurrentServer = Server.Realistik;
                    break;
            }

            IgnoreChanges = false;
        }

        private bool StartedWithAutoPatching = false;

        private void RevealServerOptions()
        {
            if (_server == Server.Realistik)
            {
                EnableOsuCoinsBox.Visible = true;
                NoAdditionalOptionsText.Visible = false;
            }
            else
            {
                EnableOsuCoinsBox.Visible = false;
                NoAdditionalOptionsText.Visible = true;
            }
        }

        private Server _server = Server.Unknown;
        private Server CurrentServer
        {
            get
            {
                return _server;
            }
            set
            {
                _server = value;

                switch (value)
                {
                    case Server.Akatsuki:
                        LogoBox.Image = Resources.AkatsukiLogoLowRes;
                        break;
                    case Server.Realistik:
                        LogoBox.Image = Resources.RealistikOsuLogo;
                        break;
                }

                OsuServerText.Text = value.ToString();
                RevealServerOptions();
            }
        }
        private string CurrentStream = "stable";

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (PatchingInProgress) return;
            PatchingInProgress = true;

            if (string.IsNullOrWhiteSpace(Program.OsuExecutablePath))
            {
                MessageBox.Show("Could not find osu! on your system. Try opening the game, or click the \"Change\" button to browse to the executable.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (CurrentServer == Server.Unknown)
            {
                MessageBox.Show("Please choose a server to play.\r\nYou can switch servers by clicking the bunny.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TitleText.Text = "Please wait...";
            TitleText.ForeColor = Color.Gray;
            if (StartedWithAutoPatching)
            {
                Size = new Size(Size.Width, 98);
                CenterToScreen();
            }

            if (CurrentServer == Server.Realistik) if (EnableOsuCoinsBox.Checked) CurrentStream = "coins";
            else CurrentStream = "stable";
            new Thread(() => PatcherRequest(CurrentServer, CurrentStream)).Start();
            //PlayLoading();
        }

        public void FinalFailure()
        {
            bool DoNotPerformAutomaticClose = false;

            if (Injector.LastInjectUpdateOrOperationDetected)
            {
                TitleText.Text = "osu! update required.";
                TitleText.ForeColor = Color.Maroon;
                BottomPanel.Enabled = true;

                Log.WriteLog("osu! may be updating, so it wasn't patched properly.");

                if (MessageBox.Show("Looks like osu! was/is updating, so patching stopped.\r\nDo you want to start patching again?\r\n\r\n(Ensure that osu! isn't updating before continuing!)", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BottomPanel.Enabled = true;
                    PlayButton.PerformClick();
                    DoNotPerformAutomaticClose = true;
                }
            }
            else
            {
                TitleText.Text = "Launch failed.";
                TitleText.ForeColor = Color.Maroon;
                BottomPanel.Enabled = true;

                Log.WriteLog("osu! wasn't able to be patched properly.");

                MessageBox.Show("Looks like osu! couldn't be patched properly. If it was checking for updates, simply try again once the game opens. Consider visiting https://akatsuki.gg/doc/patcher_troubleshooting for common troubleshooting steps!\r\n\r\n(Please close other patchers, they may also interfere.)", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (StartedWithAutoPatching)
            {
                if (!DoNotPerformAutomaticClose) Close();
            }
        }

        //public void Failure()
        //{
        //    TitleText.Text = "Still launching...";
        //    TitleText.ForeColor = Color.Orange;
        //}

        private string LastFoundOsu = string.Empty;

        public void FoundOsuAt(string path)
        {
            //if (Config.ExecutablePath != path)
            //{
            //    Config.ExecutablePath = path;
            //    PatcherPlus.Loader.Config.Save(Config);
            //}

            if (PatchingInProgress)
            {
            }
            else
            {
                //BottomPanel.Enabled = true;
            }

            //if (Settings.Default.ShowPath) OsuLocationText.Text = $"Using: {path} | Incorrect? Open the game, or click \"Change File Path\".";
            //else OsuLocationText.Text = $"osu! was located. Click play when you're ready!\r\nClick here to see the discovered location.";

            OsuLocationText.Text = $"{path} | Incorrect? Click \"Change File Path\" or open osu!.";
            OsuLocationText.ForeColor = Color.White;
            PlayButton.BackColor = Color.DarkGreen;

            LastFoundOsu = path;
        }

        private void OsuLocationText_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"osu! was located: {LastFoundOsu}", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FadeOut_Tick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Opacity -= 0.05;
            //if (Opacity <= 0) Environment.Exit(0);
            if (Opacity <= 0.50) Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PatchingInProgress)
            {
                SystemSounds.Asterisk.Play();
                DialogResult question = MessageBox.Show("Closing while patching may cause problems.\r\nAre you sure you want to close PatcherPlus?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (question != DialogResult.Yes) e.Cancel = true;
            }
            else
            {
                BackgroundThreads.Stop();
                Settings.Default.LastServer = CurrentServer.ToString();
                Settings.Default.LastBranch = CurrentStream;
            }
            Settings.Default.Save();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            if (PatchingInProgress)
            {
                MessageBox.Show("You cannot change the file path right now.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //switch (MessageBox.Show("Here are your options.\r\n[Choosing YES] Locate the file manually.\r\n[Choosing NO] Locate the file by detecting your open game.", Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
            //{

            //}

            OpenOsuExeFileWindow.ShowDialog();
        }

        private void OpenOsuExeFileWindow_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BackgroundThreads.Stop();
            MessageBox.Show($"PatcherPlus will use the executable \"{OpenOsuExeFileWindow.FileName}\", and also stop searching for osu! until you restart this program.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Program.OsuExecutablePath = OpenOsuExeFileWindow.FileName;
            FoundOsuAt(Program.OsuExecutablePath);
        }

        private void AutoPatch_Tick(object sender, EventArgs e)
        {
            AutoPatch.Stop();

            if (!IsShiftDown())
            {
                if (Settings.Default.AutoPatch)
                {
                    Log.WriteLog($"Auto patching is enabled. Patching will attempt to begin automatically.");
                    StartedWithAutoPatching = true;
                    PlayButton.PerformClick();
                }
            }
        }

        private bool IgnoreChanges = true;

        private void AutoPatchBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IgnoreChanges) return;

            Settings.Default.AutoPatch = AutoPatchBox.Checked;
            if (AutoPatchBox.Checked)
            {
                MessageBox.Show("PatcherPlus will automatically start opening and patching the game when you open this tool. To pause this behavior, hold the SHIFT key immediately after you open the program.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CheckButton_Tick(object sender, EventArgs e)
        {
            //bool Visibility = PlayButton.Visible && PlayButton.Enabled;
            //bool Visibility = BottomPanel.Visible && BottomPanel.Enabled;

            //ChangeButton.Visible = Visibility;
            //AutoPatchBox.Visible = Visibility;
            //ShowMoreButton.Visible = Visibility;
            //OsuLocationText.Enabled = Visibility;
        }

        private void ShowPathBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IgnoreChanges) return;
        }

        private void InfoText_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PatcherPlus is not owned or officially endorsed by Akatsuki. PatcherPlus is a modification of the original Akatsuki Patcher, intended as an alternative patcher. This patcher does not modify the patches downloaded from Akatsuki's file hosts. You do not lose or gain any in-game benefits compared to using the official Akatsuki Patcher.\r\n\r\n- BunnyTub", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private readonly object FadeObject = new object();

        private void FadeInAnimation_Tick(object sender, EventArgs e)
        {
            lock (FadeObject)
            {
                if (Opacity >= 1)
                {
                    FadeInAnimation.Enabled = false;
                    return;
                }

                Opacity += 0.05;
            }
        }

        private void BannerMessageBox_Click(object sender, EventArgs e)
        {
            InfoText_Click(sender, e);
        }

        private void BannerMessageText_Click(object sender, EventArgs e)
        {
            // osu!(lazer) is NOT the same as osu!(stable/cuttingedge). It is a complete rewrite of the game, and thus, does not have the exact same code that can be patched. Consider visiting  https://osu.ppy.sh/wiki/en/Client/Release_stream/Lazer  for a little more information.
            MessageBox.Show("PatcherPlus works by sideloading data into osu!.\r\n\r\n" +
                "When you click \"Play\", PatcherPlus first starts a download.\r\n" +
                "That download contains a (.)DLL file with code that will be sideloaded into the game. No download will happen if a cached version of it is saved.\r\n\r\n" +
                "Many servers use sideloading to add features, such as adding a performance points counter, or changing how the Relax mod works to reveal misses.\r\n\r\n" +
                "After the download is done, osu! is started, and the (.)DLL file is sideloaded into the game.\r\n\r\n" +
                "After that, PatcherPlus is done!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BannerMessageBox_MouseEnter(object sender, EventArgs e)
        {
            BannerMessageBox.Image = Resources.NotByAkatsukiHover;
        }

        private void BannerMessageBox_MouseLeave(object sender, EventArgs e)
        {
            BannerMessageBox.Image = Resources.NotByAkatsuki;
        }

        private void BannerMessageText_MouseEnter(object sender, EventArgs e)
        {
            BannerMessageText.ForeColor = Color.Silver;
            //BannerMessageText.Text = "Click here to know why it isn't compatible.";
        }

        private void BannerMessageText_MouseLeave(object sender, EventArgs e)
        {
            BannerMessageText.ForeColor = Color.Gray;
            //BannerMessageText.Text = "This tool is not compatible with osu!(lazer).";
        }

        private void LogoBox_MouseEnter(object sender, EventArgs e)
        {
            //AnimateLogo(78);
            LogoBox.BackColor = Color.FromArgb(40, 40, 40);
        }

        private void LogoBox_MouseLeave(object sender, EventArgs e)
        {
            //AnimateLogo(148);
            LogoBox.BackColor = Color.FromArgb(16, 16, 16);
        }

        private void LogoBox_MouseDown(object sender, MouseEventArgs e)
        {
            LogoBox.BackColor = Color.FromArgb(60, 60, 60);
        }

        private void LogoBox_MouseUp(object sender, MouseEventArgs e)
        {
            LogoBox.BackColor = Color.FromArgb(40, 40, 40);
        }

        private void AnimateLogo(int targetHeight)
        {
            TargetHeight = targetHeight;
            
            if (LogoAnimation.Enabled)
            {
            }
            else
            {
                LogoAnimation.Enabled = true;
            }
        }

        private int TargetHeight = 32;
        private const double EaseFactor = 0.12;
        private const int StopThreshold = 1;

        private void LogoAnimation_Tick(object sender, EventArgs e)
        {
            if (Opacity < 0.25) return;

            int current = LogoBox.Height;
            int delta = TargetHeight - current;

            if (Math.Abs(delta) <= StopThreshold)
            {
                LogoBox.Height = TargetHeight;
                LogoAnimation.Enabled = false;

                //if (OsuLocationText.ForeColor == Color.Orange)
                //{
                //    AnimateLogo(86);
                //}
                //else
                //{
                //    if (!ShowMore) AnimateLogo(148);
                //}

                return;
            }

            int step = (int)Math.Ceiling(delta * EaseFactor);

            if (step == 0) step = -1;
            LogoBox.Height += step;
        }

        private void LogoBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (File.Exists(Settings.Default.LastPath))
                {
                    DialogResult result = MessageBox.Show($"Clear the cache now?\r\n{Settings.Default.LastPath}", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        File.Delete(Settings.Default.LastPath);
                    }
                }

                return;
            }

            switch (CurrentServer)
            {
                default:
                case Server.Unknown:
                case Server.Realistik:
                    CurrentServer = Server.Akatsuki;
                    LogoBox.Image = Resources.AkatsukiLogoLowRes;
                    break;
                case Server.Akatsuki:
                    CurrentServer = Server.Realistik;
                    LogoBox.Image = Resources.RealistikOsuLogo;
                    break;
            }

            //MessageBox.Show($"Switched to \"{CurrentServer}\".", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            //MessageBox.Show($"You'll be connecting to \"{server}\".\r\nDouble-click the same area to switch servers.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LogoBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LogoBox_MouseClick(sender, e);
        }

        private void TitleText_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void EnableOsuCoinsBox_CheckedChanged(object sender, EventArgs e)
        {
            if (EnableOsuCoinsBox.Checked)
            {
                MessageBox.Show("You will gain and lose coins while you play.\r\n\r\n" +
                    "- Playing any ranked map costs 1 coin.\r\n" +
                    "- Gaining 100 combo awards 1 coin (200 combo with Relax/Autopilot).\r\n" +
                    "- Passing a ranked map awards 1 coin.\r\n\r\n" +
                    "You can change coin settings in osu! options.",
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void ShowMoreButton_Click(object sender, EventArgs e)
        {
            ShowMore = !ShowMore;
            Settings.Default.ShowPath = ShowMore;

            if (ShowMore)
            {
                OsuLocationText.Visible = true;
                AnimateLogo(96);
            }
            else
            {
                OsuLocationText.Visible = false;
                AnimateLogo(148);
            }
        }
    }
}
