using Akatsuki.Loader.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Akatsuki.Loader
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

        private static void PatcherResponse(byte[] data, string filename)
        {
            try
            {
                if (Injector.Inject(Program.OsuExecutablePath, data, filename))
                {
                    PatchingInProgress = false;

                    // this is just stylization fun, it's not needed, and I might end up removing it
                    HideWindow("osu! (loading)", true);
                    new Thread(() =>
                    {
                        StartupForm startup = new StartupForm(Resources.PatchLogo);
                        startup.ShowDialog();
                        startup.BringToFront();
                        startup.Dispose();
                        Thread.Sleep(2000);
                        ForwardWindow("osu!");
                    }).Start();

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
                Console.WriteLine(ex.Message);
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

        public static void PatcherRequest(string releaseStream)
        {
            PatchingInProgress = true;

            BackgroundThreads.Stop();

            try
            {
                Process process = Process.GetProcessesByName("osu!").FirstOrDefault();

                if (process != null && !process.HasExited)
                {
                    Console.WriteLine("Closing osu!...");

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

            Console.WriteLine("Preparing patch...");

            Program.main.Invoke((MethodInvoker)delegate
            {
                Program.main.TitleText.Text = "Preparing patch...";
                Program.main.TitleText.ForeColor = Color.Gray;
            });

            var data = GetPatch(releaseStream);

            PatcherResponse(data.data, data.filename);

            PatchingInProgress = false;
        }

        public static bool PatchingInProgress { get; private set; } = false;

        private static (byte[] data, string filename) GetPatch(string branch)
        {
            var URL = $"https://air_conditioning.akatsuki.gg/patcher/patcher-version?branch={branch}";

            byte[] data = null;

            using (HttpClient client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = true }))
            {
                string fullPath = null;
                string tempPath = Path.GetTempPath() + "paplubun";

                Console.WriteLine($"Creating temp path for data... {tempPath}");
                Directory.CreateDirectory(tempPath);

                fullPath = $"{tempPath}\\{Injector.fileNamePattern}";
                Console.WriteLine($"Full path is: {fullPath}");

                void Download()
                {
                    Console.WriteLine("Downloading...");

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

                    if (tricks != Settings.Default.KnownTrickery)
                    {
                        Console.WriteLine($"Cache mismatch, the file will be deleted. ({tricks} != {Settings.Default.KnownTrickery})");

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

                Console.WriteLine("Using cache.");

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
