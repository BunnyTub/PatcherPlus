using System;
using System.IO;
using System.Windows.Forms;

namespace Akatsuki.Loader
{
    public static class Log
    {
        private static string CurrentLog = string.Empty;

        public static void WriteLog(string line)
        {
            Console.WriteLine(line);
            CurrentLog += $"Version ??? | {DateTimeOffset.UtcNow:R} | {line}" + "\r\n";
        }

        public static void DumpLog()
        {
            try
            {
                DirectoryInfo folder = Config.GetFolder();
                if (folder == null) return;

                string InfoFile = "info.log";

                using (FileStream stream = File.Create(folder.FullName + "\\" + InfoFile))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.WriteLine(CurrentLog);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.Message);
                if (MessageBox.Show($"Log dump failed. {ex.Message}", "PatcherPlus", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry) DumpLog();
            }
        }
    }
}
