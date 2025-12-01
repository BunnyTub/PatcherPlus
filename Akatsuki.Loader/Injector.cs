using HoLLy.ManagedInjector;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Akatsuki.Loader
{
    public static class Injector
    {
        internal const string fileNamePattern = "WaRcHeStSaUcE";

        private static readonly Random Random = new Random();

        internal static string GenerateRandomString(string pattern)
        {
            return string.Concat(pattern.Select((char x) => (x != '?') ? x : "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"[Random.Next("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".Length)]));
        }

        public static void CleanupPatchers()
        {
            foreach (string item in Directory.EnumerateFiles(Path.GetTempPath(), fileNamePattern))
            {
                try
                {
                    File.Delete(item);
                }
                catch
                {
                }
            }
        }

        // can return null, but Framework doesn't support nullable return types
        private static ProcessModule getAuth(Process process)
        {
            if (process.HasExited) Console.WriteLine("osu! exited...?");
            return (Process.GetProcessById(process.Id)?.Modules).Cast<ProcessModule>().FirstOrDefault((ProcessModule mod) => mod.ModuleName == "osu!auth.dll");
        }

        public static bool LastInjectUpdateOrOperationDetected { get; private set; } = false;

        public static Process Inject(string osuPath, byte[] patcherBytes, string filename)
        {
            LastInjectUpdateOrOperationDetected = false;
            bool ReturnedNullDueToUpdateOrCrucialOperation = false;

            Process InjectNow()
            {
                Console.WriteLine("Applying patch...");

                if (patcherBytes != null) Console.WriteLine("Using bytes.");
                else if (!string.IsNullOrWhiteSpace(filename)) Console.WriteLine("Using filename.");

                string fullPath = "";

                string tempPath = Path.GetTempPath() + "paplubun";
                Console.WriteLine("Creating temp path for data...");
                Directory.CreateDirectory(tempPath);
                string path = fileNamePattern;
                fullPath = $"{tempPath}\\{path}";

                if (!string.IsNullOrWhiteSpace(filename)) fullPath = filename;
                else if (patcherBytes != null)
                {
                    Console.WriteLine($"Writing data to temp path at {fullPath}...");
                    File.WriteAllBytes(fullPath, patcherBytes);
                }

                try
                {
                    Console.WriteLine($"Starting osu!... {osuPath}");

                    Process process = null;
                    if (ReturnedNullDueToUpdateOrCrucialOperation)
                    {
                        foreach (Process proc in Process.GetProcesses())
                        {
                            try
                            {
                                if (proc.MainModule.FileName.ToLowerInvariant() == osuPath.ToLowerInvariant())
                                {
                                    foreach (var (handle, title) in WindowMethods.GetProcessWindows(process))
                                    {
                                        if (title.Contains("updater"))
                                        {
                                            Program.main.Invoke((MethodInvoker)delegate
                                            {
                                                Program.main.TitleText.Text = "osu! is updating...";
                                                Program.main.TitleText.ForeColor = Color.Gray;
                                            });

                                            LastInjectUpdateOrOperationDetected = true;

                                            //ReturnedNullDueToUpdateOrCrucialOperation = true;
                                            //return null;
                                        }
                                        else
                                        {
                                            process = proc;
                                        }
                                    }

                                    break;
                                }
                            }
                            catch
                            {
                            }
                        }
                        process = new Process();
                    }
                    else process = Process.Start(new ProcessStartInfo { UseShellExecute = true, FileName = osuPath, Arguments = "-devserver akatsuki.gg" });

                    ReturnedNullDueToUpdateOrCrucialOperation = false;

                    int num = 0;

                    ProcessModule processModule = null;

                    while (processModule == null)
                    {
                        Console.WriteLine($"Waiting for osu!... ({num})");

                        bool UpdateOrCrucialOperationInProgress = false;

                        foreach (var (handle, title) in WindowMethods.GetProcessWindows(process))
                        {
                            if (title.Contains("updater"))
                            {
                                Program.main.Invoke((MethodInvoker)delegate
                                {
                                    Program.main.TitleText.Text = "osu! is updating...";
                                    Program.main.TitleText.ForeColor = Color.Gray;
                                });

                                LastInjectUpdateOrOperationDetected = true;

                                UpdateOrCrucialOperationInProgress = true;
                                ReturnedNullDueToUpdateOrCrucialOperation = true;
                                return null;
                            }
                        }

                        if (num >= 50)
                        {
                            Console.WriteLine($"Failed to patch the osu! client because the wait to verify loaded resources took too long.");
                            if (!process.HasExited) process?.Kill();
                            //MessageBox.Show("Failed loading Akatsuki Patcher.\nPlease make sure you're running the latest osu! or relocate/repair your osu! install.");
                            return null;
                        }

                        processModule = getAuth(process);

                        if (UpdateOrCrucialOperationInProgress) continue;

                        Thread.Sleep(100);

                        if (process.HasExited)
                        {
                            Console.WriteLine($"Failed to patch the osu! client because it has unexpectedly closed.");
                            return null;
                        }

                        num++;
                    }

                    InjectableProcess val = new InjectableProcess((uint)process.Id);

                    while (true)
                    {
                        try
                        {
                            val.Inject(fullPath, "Akatsuki.Patcher.Main", "Initialize");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                        break;
                    }

                    return process;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }

            Program.main.Invoke((MethodInvoker)delegate
            {
                Program.main.TitleText.Text = "Applying patch...";
                Program.main.TitleText.ForeColor = Color.Gray;
            });

            for (int i = 0; i < 3; i++)
            {
                Process process = InjectNow();

                if (process != null) return process;

                if (!ReturnedNullDueToUpdateOrCrucialOperation)
                {
                    Program.main.Invoke((MethodInvoker)delegate
                    {
                        Program.main.TitleText.Text = $"Patching failed... ({i + 1})";
                        Program.main.TitleText.ForeColor = Color.DarkGray;
                    });
                }

                Thread.Sleep(1000);
            }

            return null;
        }
    }
}
