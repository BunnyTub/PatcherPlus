// Akatsuki.Loader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Akatsuki.Loader.Injector
using HoLLy.ManagedInjector;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace Akatsuki.Loader
{
    public static class Injector
    {
        //private const string fileNamePattern = "flAmEWaShEre.tmp";

        private static readonly Random Random = new Random();

        internal static string GenerateRandomString(string pattern)
        {
            return string.Concat(pattern.Select((char x) => (x != '?') ? x : "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"[Random.Next("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".Length)]));
        }

        public static void CleanupPatchers()
        {
            foreach (string item in Directory.EnumerateFiles(Path.GetTempPath(), "flAmEWaShEre.tmp"))
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
        private static ProcessModule getAuth(int processId)
        {
            return (Process.GetProcessById(processId)?.Modules).Cast<ProcessModule>().FirstOrDefault((ProcessModule mod) => mod.ModuleName == "osu!auth.dll");
        }

        public static bool Inject(string osuPath, byte[] patcherBytes)
        {
            //IL_0083: Unknown result type (might be due to invalid IL or missing references)
            //IL_0089: Expected O, but got Unknown
            string tempPath = Path.GetTempPath();
            string path = GenerateRandomString("flAmEWaShEre.tmp");
            string text = Path.Combine(tempPath, path);
            File.WriteAllBytes(text, patcherBytes);
            //Process process = Process.Start(osuPath, new string[2] { "-devserver", "akatsuki.gg" });
            Process process = Process.Start(osuPath, "-devserver akatsuki.gg");
            int num = 0;
            while (getAuth(process.Id) == null)
            {
                if (num == 10)
                {
                    MessageBox.Show("Failed loading Akatsuki Patcher.\nPlease make sure you're running the latest osu! or relocate/repair your osu! install.");
                    return false;
                }
                Thread.Sleep(200);
                if (process == null || process.HasExited)
                {
                    return false;
                }
                num++;
            }
            InjectableProcess val = new InjectableProcess((uint)process.Id);
            while (true)
            {
                try
                {
                    val.Inject(text, "Akatsuki.Patcher.Main", "Initialize");
                }
                catch
                {
                    continue;
                }
                break;
            }
            return true;
        }
    }
}
