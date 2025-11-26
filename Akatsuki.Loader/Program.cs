using System;
using System.Windows.Forms;

namespace Akatsuki.Loader
{
    internal static class Program
    {
        public static string OsuExecutablePath = string.Empty;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
