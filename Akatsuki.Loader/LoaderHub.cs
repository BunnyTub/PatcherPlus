using PatcherPlus.Loader.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PatcherPlus.Loader
{
    public static class LoaderHub
    {
        //nullable
        //private static async Task LoaderUpdates(LoaderUpdates updates)
        //{
        //    if (await Updater.CheckUpdates(updates.Loader))
        //    {
        //        app.Exit();
        //    }
        //    Program.main.Invoke((MethodInvoker)delegate
        //    {

        //    });
        //}

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(
            IntPtr hWnd,
            IntPtr hWndInsertAfter,
            int X,
            int Y,
            int cx,
            int cy,
            uint uFlags);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        const uint SWP_NOMOVE = 0x0002;
        const uint SWP_NOSIZE = 0x0001;
        const uint SWP_NOACTIVATE = 0x0010;
        const uint SWP_SHOWWINDOW = 0x0040;

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        const uint SWP_NOZORDER = 0x0004;

        private readonly static Random rnd = new Random();

        public static bool NudgeWindow(string title)
        {
            IntPtr hWnd = FindWindow(null, title);
            if (hWnd == IntPtr.Zero) return false;

            if (!GetWindowRect(hWnd, out RECT rect)) return false;

            int x = rect.Left;
            int y = rect.Top;

            int direction = rnd.Next(4);

            switch (direction)
            {
                case 0: x += 5; break;
                case 1: x -= 5; break;
                case 2: y += 5; break;
                case 3: y -= 5; break;
            }

            return SetWindowPos(hWnd, IntPtr.Zero, x, y, 0, 0, SWP_NOSIZE | SWP_NOZORDER);
        }

        public static bool HideWindow(string title, bool hide)
        {
            IntPtr hWnd = FindWindow(null, title);
            if (hWnd == IntPtr.Zero) return false;

            if (hide) return ShowWindow(hWnd, SW_HIDE);
            else return ShowWindow(hWnd, SW_SHOW);
        }

        public static bool ForwardWindow(string title)
        {
            IntPtr hWnd = FindWindow(null, title);
            if (hWnd == IntPtr.Zero) return false;

            return SetWindowPos(
                hWnd,
                new IntPtr(0),
                0, 0,
                0, 0,
                SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW
            );
        }

        public static bool PatchedSuccessfully { get; private set; } = false;

        private static void PatcherResponse(Server server, byte[] data, string filename)
        {
            try
            {
                string type = string.Empty;
                string method = string.Empty;

                switch (server)
                {
                    case Server.Akatsuki:
                        type = "Akatsuki.Patcher.Main";
                        method = "Initialize";
                        break;
                    case Server.Realistik:
                        type = "RealistikOsu.Patcher.Main";
                        method = "Inject";
                        break;
                }

                Process process = Injector.Inject(server, Program.OsuExecutablePath, data, filename, type, method);

                if (process != null)
                {
                    PatchingInProgress = false;
                    PatchedSuccessfully = true;

                    // this is just stylization fun, it's not needed, and I might end up removing it

                    new Thread(() =>
                    {
                        for (int i = 0; i <= 300; i++)
                        {
                            NudgeWindow("osu! (loading)");
                            Thread.Sleep(30);
                        }
                    }).Start();

                    //new Thread(() =>
                    //{
                    //    StartupForm startup = new StartupForm(Resources.PatchLogo);
                    //    startup.ShowDialog();
                    //    startup.BringToFront();
                    //    startup.Dispose();
                    //    Thread.Sleep(2000);
                    //    ForwardWindow("osu!");
                    //}).Start();

                    Program.main.Invoke((MethodInvoker)delegate
                    {
                        Program.main.TitleText.Text = "See you there!";
                        Program.main.TitleText.ForeColor = Color.White;
                        Program.main.BackgroundProgressBar.Visible = false;
                        Program.main.FadeOut.Enabled = true;
                    });
                }
                else
                {
                    PatchingInProgress = false;
                    Program.main.Invoke((MethodInvoker)delegate
                    {
                        Program.main.FinalFailure();
                    });
                }
            }
            catch (Exception ex)
            {
                PatchingInProgress = false;
                Log.WriteLog(ex.Message);
                Program.main.Invoke((MethodInvoker)delegate
                {
                    Program.main.FinalFailure();
                });
            }
        }

        public static void LoaderHub_OnRetry()
        {
            //MainWindow context = App.Context;
            //context.Dispatcher.Invoke(context.PlayLoading);
        }

        public static void LoaderHub_OnConnectionFailure()
        {
            //MainWindow app = App.Context;
            //app.Dispatcher.Invoke(app.FailedLoading);
            //int i;
            //for (i = 10; i > 0; i--)
            //{
            //    app.Dispatcher.Invoke(delegate
            //    {
            //        app.UpdateRetrySeconds(i);
            //    });
            //    Thread.Sleep(1000);
            //}
        }

        public static void PatcherRequest(Server server, string releaseStream)
        {
            BackgroundThreads.Stop();

            try
            {
                Process process = Process.GetProcessesByName("osu!").FirstOrDefault();

                if (process != null && !process.HasExited)
                {
                    Log.WriteLog("Closing osu!...");

                    Program.main.Invoke((MethodInvoker)delegate
                    {
                        Program.main.TitleText.Text = "Closing osu!...";
                        Program.main.TitleText.ForeColor = Color.Gray;
                    });

                    // to basically let osu know to close instead of full throttle killing it immediately

                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            process.CloseMainWindow();
                        }
                        catch
                        {
                        }
                        Thread.Sleep(500);
                    }

                    try
                    {
                        process.Kill();
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }

            Log.WriteLog("Preparing patch...");

            Program.main.Invoke((MethodInvoker)delegate
            {
                Program.main.TitleText.Text = "Preparing patch...";
                Program.main.TitleText.ForeColor = Color.Gray;
            });

            var data = GetPatch(server, releaseStream);

            string require = Path.GetDirectoryName(Program.OsuExecutablePath) + "\\.require_update";
            string pending = Path.GetDirectoryName(Program.OsuExecutablePath) + "\\_pending";

            if (File.Exists(require) || Directory.Exists(pending))
            {
                DialogResult question = DialogResult.No;

                Program.main.Invoke((MethodInvoker)delegate
                {
                    Program.main.TitleText.Text = "Patching paused.";
                    Program.main.TitleText.ForeColor = Color.Yellow;
                    question = MessageBox.Show("PatcherPlus found that osu! needs need to update or repair itself. Do you want to try bypassing this and continue?", Program.main.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                });

                if (question != DialogResult.Yes)
                {
                    Program.main.Invoke((MethodInvoker)delegate
                    {
                        Program.main.TitleText.Text = "Patching stopped.";
                        Program.main.TitleText.ForeColor = Color.Yellow;
                    });

                    PatchingInProgress = false;
                    return;
                }

                if (File.Exists(require)) File.Delete(require);
                if (Directory.Exists(pending)) Directory.Delete(pending, true);
            }

            PatcherResponse(server, data.data, data.filename);

            PatchingInProgress = false;
        }

        public enum Server
        {
            Unknown = 0,
            Akatsuki = 1,
            Realistik = 2
        }

        private static bool _PatchingInProgress = false;
        public static bool PatchingInProgress
        {
            get
            {
                return _PatchingInProgress;
            }
            set
            {
                _PatchingInProgress = value;
                Program.main.Invoke((MethodInvoker)delegate
                {
                    Program.main.BottomPanel.Enabled = !value;
                    if (value) Program.main.BackgroundProgressBar.BringToFront();
                    else Program.main.BackgroundProgressBar.SendToBack();
                });
            }
        }

        private static (byte[] data, string filename) GetPatch(Server server, string branch)
        {
            string URL = string.Empty;
            
            switch (server)
            {
                case Server.Akatsuki:
                    URL = $"https://air_conditioning.akatsuki.gg/patcher/patcher-version?branch={branch}";
                    break;
                case Server.Realistik:
                    URL = $"https://ussr.pl/api/v1/patcher/branches/{branch}/patcher/file";
                    break;
                default:
                    return (null, null);
            }

            byte[] data = null;

            using (HttpClient client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = true }))
            {
                //client.Timeout = TimeSpan.FromSeconds(10);

                string fullPath = null;
                string tempPath = Path.GetTempPath() + "paplubun";

                Log.WriteLog($"Creating temp path for data... {tempPath}");
                Directory.CreateDirectory(tempPath);

                fullPath = $"{tempPath}\\{Injector.fileNamePattern}";
                Log.WriteLog($"Full path is: {fullPath}");

                void Download()
                {
                    Log.WriteLog("Downloading...");

                    Program.main.Invoke((MethodInvoker)delegate
                    {
                        Program.main.TitleText.Text = "Downloading patch...";
                        Program.main.TitleText.ForeColor = Color.Gray;
                    });

                    var byteResponse = client.GetByteArrayAsync(URL).Result;
                    File.WriteAllBytes(fullPath, byteResponse);
                    Settings.Default.LastServerPull = DateTime.UtcNow;
                    Settings.Default.KnownTrickery = _Trickery.Learn(byteResponse);
                    Settings.Default.Save();
                }

                if (!File.Exists(fullPath))
                {
                    Download();
                }

                try
                {
                    byte[] bytes = File.ReadAllBytes(fullPath);
                    string tricks = _Trickery.Learn(bytes);

                    if (tricks != Settings.Default.KnownTrickery ||
                        server.ToString().ToLowerInvariant() != Settings.Default.LastServer.ToLowerInvariant() ||
                        branch.ToLowerInvariant() != Settings.Default.LastBranch.ToLowerInvariant())
                    {
                        //Log.WriteLog($"Cache mismatch, the file will be deleted.");
                        Log.WriteLog($"Cache deletion reason or reasons: {tricks} != {Settings.Default.KnownTrickery} / {server.ToString().ToLowerInvariant()} != {Settings.Default.LastServer.ToLowerInvariant()} / {branch.ToLowerInvariant()} != {Settings.Default.LastBranch.ToLowerInvariant()}");

                        Program.main.Invoke((MethodInvoker)delegate
                        {
                            Program.main.TitleText.Text = "Cache mismatch...";
                            Program.main.TitleText.ForeColor = Color.Gray;
                        });

                        File.Delete(fullPath);

                        Download();
                        return (data, null);
                    }
                }
                catch (Exception)
                {
                }

                if (Settings.Default.LastServerPull != null)
                {
                    TimeSpan diff = DateTime.UtcNow - Settings.Default.LastServerPull;
                    if (diff.TotalDays > 3)
                    {
                        Download();
                    }
                }
                else
                {
                    Download();
                }

                Log.WriteLog("Using cache.");

                Program.main.Invoke((MethodInvoker)delegate
                {
                    Program.main.TitleText.Text = "Using cached patch...";
                    Program.main.TitleText.ForeColor = Color.Gray;
                });

                return (null, fullPath);
            }
        }

        //public static async void Connect()
        //{
        //    bool flag = false;
        //    while (true)
        //    {
        //        try
        //        {
        //            if (flag && LoaderHub.OnRetry != null)
        //            {
        //                LoaderHub.OnRetry();
        //            }
        //            await LoaderUpdates(await new HttpClient().GetFromJsonAsync<LoaderUpdates>("https://air_conditioning.akatsuki.gg/loader/loader-updates"));
        //            break;
        //        }
        //        catch (Exception)
        //        {
        //            if (LoaderHub.OnConnectionFailure != null)
        //            {
        //                LoaderHub.OnConnectionFailure();
        //            }
        //            flag = true;
        //        }
        //    }
        //}
    }
}
