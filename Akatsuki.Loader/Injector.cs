using HoLLy.ManagedInjector;
using System;
using System.Collections;
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

        public static bool Inject(string osuPath, byte[] patcherBytes, string filename)
        {
            bool InjectNow()
            {
                Console.WriteLine("Applying patch...");
                if (patcherBytes != null) Console.WriteLine("Using bytes.");
                else if (!string.IsNullOrWhiteSpace(filename)) Console.WriteLine("Using filename.");

                Program.main.Invoke((MethodInvoker)delegate
                {
                    Program.main.TitleText.Text = "Applying patch...";
                    Program.main.TitleText.ForeColor = Color.Gray;
                });

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
                    Process process = Process.Start(new ProcessStartInfo { UseShellExecute = true, FileName = osuPath, Arguments = "-devserver akatsuki.gg" });
                    
                    int num = 0;

                    while (getAuth(process) == null)
                    {
                        Console.WriteLine($"Waiting for osu!... ({num})");
                        if (num >= 50)
                        {
                            Console.WriteLine($"Failed to patch the osu! client because the wait took too long.");
                            //MessageBox.Show("Failed loading Akatsuki Patcher.\nPlease make sure you're running the latest osu! or relocate/repair your osu! install.");
                            return false;
                        }
                        Thread.Sleep(100);
                        if (process == null || process.HasExited)
                        {
                            Console.WriteLine($"Failed to patch the osu! client because it has unexpectedly closed.");
                            return false;
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

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (InjectNow()) return true;

                Program.main.Invoke((MethodInvoker)delegate
                {
                    Program.main.TitleText.Text = "Patching failed...";
                    Program.main.TitleText.ForeColor = Color.DarkGray;
                });

                Thread.Sleep(1000);
            }

            return false;
        }
    }
}
