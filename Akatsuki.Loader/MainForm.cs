using PatcherPlus.Loader.Properties;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PatcherPlus.Loader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Styles.AddMemoryFont(Resources.Montserrat_Regular);
            TitleText.Font = Styles.GetFont(0, 26, FontStyle.Regular);
            //OsuLocationText.Font = Styles.GetFont(0, 11, FontStyle.Regular); // mehh, it gets lower quality the lower the size is (obviously), doesn't look great
            //PlayButton.Font = Styles.GetFont(0, 18, FontStyle.Regular);
            Opacity = 0;
        }

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);

        private bool IsShiftDown()
        {
            return (GetAsyncKeyState(Keys.ShiftKey) & 0x8000) != 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Injector.CleanupPatchers();
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
                    PlayButton.Enabled = true;
                    PlayButton.Visible = true;
                }
            }

            AutoPatchBox.Checked = Settings.Default.AutoPatch;
            ShowPathBox.Checked = Settings.Default.ShowPath;
            IgnoreChanges = false;
        }

        private bool StartedWithAutoPatching = false;

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Program.OsuExecutablePath))
            {
                MessageBox.Show("Could not find osu! on your system. Try opening the game, or click the \"Change\" button to browse to the executable.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            PlayButton.Enabled = false;
            PlayButton.Visible = false;
            TitleText.Text = "Launching...";
            TitleText.ForeColor = Color.Gray;
            if (StartedWithAutoPatching)
            {
                Size = new Size(Size.Width, 98);
                CenterToScreen();
            }
            //LoaderHub.PatcherRequest(releaseStreams.SelectedValue).Wait();
            new Thread(() => LoaderHub.PatcherRequest("stable")).Start();
            //PlayLoading();
        }

        public void FinalFailure()
        {
            bool DoNotPerformAutomaticClose = false;

            if (Injector.LastInjectUpdateOrOperationDetected)
            {
                TitleText.Text = "osu! update required.";
                TitleText.ForeColor = Color.Maroon;
                PlayButton.Enabled = true;
                PlayButton.Visible = true;

                Log.WriteLog("osu! may be updating, so it wasn't patched properly.");

                if (MessageBox.Show("Looks like osu! was/is updating, so patching stopped.\r\nDo you want to start patching again?\r\n\r\n(Ensure that osu! isn't updating before continuing!)", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PlayButton.Enabled = true;
                    PlayButton.Visible = true;
                    PlayButton.PerformClick();
                    DoNotPerformAutomaticClose = true;
                }
            }
            else
            {
                TitleText.Text = "Launch failed.";
                TitleText.ForeColor = Color.Maroon;
                PlayButton.Enabled = true;
                PlayButton.Visible = true;

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

            if (LoaderHub.PatchingInProgress)
            {
            }
            else
            {
                PlayButton.Enabled = true;
                PlayButton.Visible = true;
            }

            if (Settings.Default.ShowPath) OsuLocationText.Text = $"Using: {path} | Incorrect? Open the game, or click \"Change File Path\".";
            else OsuLocationText.Text = $"osu! was located. Click play when you're ready!\r\nClick here to see the discovered location.";
            OsuLocationText.ForeColor = Color.White;
            PlayButton.BackColor = Color.DarkGreen;


            LastFoundOsu = path;
        }

        private void OsuLocationText_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"osu! was located: {LastFoundOsu}");
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
            if (LoaderHub.PatchingInProgress)
            {
                Console.Beep();
                e.Cancel = true;
            }
            else
            {
                BackgroundThreads.Stop();
            }
            Settings.Default.Save();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            if (!PlayButton.Enabled)
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
                MessageBox.Show("PatcherPlus will automatically start opening and patching when you open it. To pause this behavior, hold the SHIFT key immediately after you open the program.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CheckButton_Tick(object sender, EventArgs e)
        {
            bool Visibility = PlayButton.Visible && PlayButton.Enabled;

            ChangeButton.Visible = Visibility;
            AutoPatchBox.Visible = Visibility;
            ShowPathBox.Visible = Visibility;
            OsuLocationText.Visible = Visibility;
        }

        private void ShowPathBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IgnoreChanges) return;

            Settings.Default.ShowPath = ShowPathBox.Checked;
            if (ShowPathBox.Checked)
            {
                MessageBox.Show("PatcherPlus will replace the generic found osu! text with file path information next time changes are made.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void InfoText_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PatcherPlus is not owned or officially endorsed by PatcherPlus. PatcherPlus is a modification of the original Akatsuki Patcher, intended as an alternative patcher. This patcher does not modify the patches downloaded from Akatsuki's file hosts. You do not lose or gain any in-game benefits compared to using the official Akatsuki Patcher.\r\n\r\n- BunnyTub\r\n(11/29/2025 | MM/DD/YYYY)", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            MessageBox.Show("osu!(lazer) is NOT the same codebase as osu!(stable or cuttingedge)", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
