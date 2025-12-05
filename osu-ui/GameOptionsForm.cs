using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osu_ui
{
    public partial class GameOptionsForm : Form
    {
        public GameOptionsForm()
        {
            InitializeComponent();
        }

        private void GameOptionsForm_Load(object sender, EventArgs e)
        {

        }

        private void CrashGameButton_Click(object sender, EventArgs e)
        {
            Hide();
            new Thread(() => throw new TimeoutException()).Start();
        }
    }
}
