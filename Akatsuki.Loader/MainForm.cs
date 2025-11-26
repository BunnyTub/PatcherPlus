using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Akatsuki.Loader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TitleText.Text = "Ready to play?";
            TitleText.ForeColor = Color.White;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            PlayButton.Enabled = false;
            PlayButton.Visible = false;
            TitleText.Text = "Launching...";
            TitleText.ForeColor = Color.Gray;
            LoaderHub.PatcherRequest(releaseStreams.SelectedValue).Wait();
            //PlayLoading();
        }

        private void Failure()
        {
            TitleText.Text = "Launch failed.";
            TitleText.ForeColor = Color.Red;
        }

        public void FoundOsuAt(string path)
        {
            //if (Config.ExecutablePath != path)
            //{
            //    Config.ExecutablePath = path;
            //    Akatsuki.Loader.Config.Save(Config);
            //}

            OsuLocationText.Text = $"Located osu! at {path}, but if this isn't right, you can click the Change button.";
            Activate();
        }
    }
}
