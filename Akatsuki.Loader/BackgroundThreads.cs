using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PatcherPlus.Loader
{
    internal static class BackgroundThreads
    {
        private static bool searchOsuProcess = false;

        private static Thread searchThread;

        public static void Start()
        {
            searchOsuProcess = true;
            searchThread = new Thread(SearchForOsu);
            searchThread.Start();
            //new Thread(LoaderHub.Connect).Start();
        }

        public static void Stop()
        {
            searchOsuProcess = false;
            searchThread.Abort();
        }

        public static void SearchForOsu()
        {
            while (searchOsuProcess)
            {
                try
                {
                    Thread.Sleep(50);
                    if (Program.main == null)
                    {
                        continue;
                    }
                    Process process = Utilities.FindOsuProcess();
                    if (process == null)
                    {
                        continue;
                    }
                    string osuPath = process.MainModule?.FileName;
                    if (osuPath != null)
                    {
                        Program.OsuExecutablePath = osuPath;
                        Program.main.Invoke((MethodInvoker)delegate
                        {
                            Program.main.FoundOsuAt(osuPath);
                        });
                    }
                }
                catch (ThreadAbortException)
                {
                }
                catch (Exception ex)
                {
                    Log.WriteLog($"An issue occurred while searching for osu!. {ex.Message}");
                }
            }
        }
    }

}
