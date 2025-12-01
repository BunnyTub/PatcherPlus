using Akatsuki.Loader.Properties;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Akatsuki.Loader
{
    internal static class Program
    {
        // we love popplio

        public static string OsuExecutablePath = string.Empty;
        public static MainForm main;
        public static bool Closing = false;

        [STAThread]
        static void Main()
        {
            Mutex mutex = new Mutex(false, "AKATSUKI_PATCHER_PLUS_INSANITY");

            if (!mutex.WaitOne(0, false))
            {
                new Thread(() =>
                {
                    Thread.Sleep(1000 * 15);
                    Environment.Exit(0);
                }).Start();
                MessageBox.Show("Hold up! PatcherPlus is already running. You can't run multiple instances at the same time. If you don't see it, check your taskbar to see if it may have minimized.",
                    "PatcherPlus",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                Environment.Exit(0);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (a, b) =>
            {
                MessageBox.Show($"Something screwed up. {b.Exception.Message} {b.Exception.StackTrace}", "PatcherPlus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Settings.Default.Save();
                Environment.Exit(0);
            };
            main = new MainForm();
            //LoaderHub.OnRetry += LoaderHub.LoaderHub_OnRetry;
            //LoaderHub.OnConnectionFailure += LoaderHub.LoaderHub_OnConnectionFailure;
            BackgroundThreads.Start();
            Application.Run(main);
            Settings.Default.Save();
            Thread.Sleep(2000);
            Closing = true;
            
            if (!LoaderHub.PatchedSuccessfully) Log.DumpLog();

            //if (LoaderHub.PatchedSuccessfully) Application.Run(new GameOptionsForm());
            //Settings.Default.Save();
        }
    }
}
