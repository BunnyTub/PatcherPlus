using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace PatcherPlus.Loader
{
    internal class WindowMethods
    {
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxCount);

        [DllImport("user32.dll")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        public static List<(IntPtr handle, string title)> GetProcessWindows(Process process)
        {
            if (process == null) return new List<(IntPtr, string)>();

            List<(IntPtr, string)> result = new List<(IntPtr, string)>();

            EnumWindows((hWnd, lParam) =>
            {
                //if (!IsWindowVisible(hWnd))
                //    return true;
                try
                {
                    GetWindowThreadProcessId(hWnd, out uint pid);

                    if (pid == process.Id)
                    {
                        int length = GetWindowTextLength(hWnd);
                        var builder = new StringBuilder(length + 1);
                        GetWindowText(hWnd, builder, builder.Capacity);
                        result.Add((hWnd, builder.ToString()));
                    }
                }
                catch
                {
                }

                return true;
            }, IntPtr.Zero);

            return result;
        }
    }
}
