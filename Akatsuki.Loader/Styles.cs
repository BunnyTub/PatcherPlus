using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace Akatsuki.Loader
{
    internal class Styles
    {
        private static PrivateFontCollection PrivateFC { get; set; }

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        static Styles()
        {
            if (PrivateFC == null) PrivateFC = new PrivateFontCollection();
        }

        public static void AddMemoryFont(byte[] fontResource)
        {
            IntPtr p;
            uint a = 0;
            p = Marshal.AllocCoTaskMem(fontResource.Length);
            Marshal.Copy(fontResource, 0, p, fontResource.Length);
            AddFontMemResourceEx(p, (uint)fontResource.Length, IntPtr.Zero, ref a);
            PrivateFC.AddMemoryFont(p, fontResource.Length);
            Marshal.FreeCoTaskMem(p);
            p = IntPtr.Zero;
        }

        public static Font GetFont(int fontIndex, float fontSize = 20, FontStyle fontStyle = FontStyle.Regular)
        {
            return new Font(PrivateFC.Families[fontIndex], fontSize, fontStyle);
        }
    }
}
