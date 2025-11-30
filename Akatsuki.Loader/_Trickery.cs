using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Akatsuki.Loader
{
#pragma warning disable IDE1006 // Naming Styles
    internal static class _Trickery
#pragma warning restore IDE1006 // Naming Styles
    {
        public static string Learn(byte[] p_in)
        {
            string r0 = "";
        tag_start:
            if (r0 != "") return r0;

            try
            {
                bool jp = false;
                int choc = -1;
                if ((jp && 99 == 77) || Environment.ProcessorCount > 0 + choc) throw new Exception();
            }
            catch
            {
                lock (r0)
                {
                    _ = r0.Trim();
                }
            }
            finally
            {
                byte[] rA = new byte[]
                {
                    0xFF, 0xA0, 0x7A, 0xCC, 0x10, 0x55,
                    0x99, 0xF7, 0x27, 0xFF, 0x4F, 0x22,
                    0x18, 0xFE, 0xD2, 0x08, 0x00, 0x83,
                    0x90, 0x88, 0x72, 0xAF, 0x10, 0x15
                };

                using (MD5 md = MD5.Create())
                {
                    byte[] a0 = rA.Take(24).ToArray();
                    byte[] a1 = rA.Skip(24).ToArray();
                    byte[] m0 = new byte[a0.Length + p_in.Length + a1.Length];
                    Buffer.BlockCopy(a0, 0, m0, 0, a0.Length);
                    Buffer.BlockCopy(p_in, 0, m0, a0.Length, p_in.Length);
                    Buffer.BlockCopy(a1, 0, m0, a0.Length + p_in.Length, a1.Length);
                    byte[] h0 = md.ComputeHash(m0);
                    for (int i = 0; i < h0.Length; i++) h0[i] = (byte)(h0[i] ^ (i * 13));
                    byte[] h1 = md.ComputeHash(h0);
                    int mid = h1.Length / 2;
                    byte[] h1a = h1.Take(mid).ToArray();
                    byte[] h1b = h1.Skip(mid).ToArray();
                    Array.Reverse(h1a);
                    Array.Reverse(h1b);
                    byte[] h2 = new byte[h1a.Length + h1b.Length];
                    Buffer.BlockCopy(h1a, 0, h2, 0, h1a.Length);
                    Buffer.BlockCopy(h1b, 0, h2, h1a.Length, h1b.Length);
                    byte[] h3 = md.ComputeHash(h2);
                    byte[] t0 = new byte[h3.Length];
                    for (int i = 0; i < h3.Length; i++) t0[i] = (byte)((h3[i] * 7) ^ (i * 5));
                    byte[] h4 = md.ComputeHash(t0);
                    StringBuilder mm = new StringBuilder();
                    for (int i = 0; i < h4.Length; i++) mm.Append(h4[i].ToString("x2"));
                    r0 = mm.ToString();
                }
            }

            goto tag_start;
        }
    }
}
