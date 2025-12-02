using Microsoft.Win32;
using System.Diagnostics;
using System.Linq;

namespace PatcherPlus.Loader
{
    internal static class Utilities
    {
        //public static void Invoke(this FrameworkElement elem, Action callback)
        //{
        //    elem.Dispatcher.Invoke(callback);
        //}

        internal static Process FindOsuProcess()
        {
            return Process.GetProcessesByName("osu!").FirstOrDefault();
        }

        internal static string FindInRegistry()
        {
            string MethodOne()
            {
                RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey("osu!\\shell\\open\\command");
                if (registryKey == null)
                {
                    return null;
                }
                return ((string)registryKey.GetValue(null)).Replace(" \"%1\"", "").Replace("\"", "");
            }

            string MethodTwo()
            {
                RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey("osustable.Uri.osu\\shell\\open\\command");
                if (registryKey == null)
                {
                    return null;
                }
                return ((string)registryKey.GetValue(null)).Replace(" \"%1\"", "").Replace("\"", "");
            }

            string mone = MethodOne();
            string mtwo = MethodTwo();

            if (!string.IsNullOrWhiteSpace(mone)) return mone;
            if (!string.IsNullOrWhiteSpace(mtwo)) return mtwo;

            return null;
        }
    }
}
