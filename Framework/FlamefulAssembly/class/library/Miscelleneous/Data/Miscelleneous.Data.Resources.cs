
// Author: Dashie


using FlamefulAssembly.resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace DashResources
    {
        public class ResourceTools
        {
            // Cursor Related:
            [DllImport("User32.dll")] static extern IntPtr CreateIconFromResource(byte[] presbits, uint dwResSize, bool fIcon, uint dwVer);
            public void UseResourceCursor(Control Object, byte[] BYTES)
            {
                var curse = new Cursor(CreateIconFromResource(BYTES, (uint)BYTES.Length, false, 0x00030000));

                Object.Cursor = curse;
                Object.Update();
            }


            // Font Related:
            [DllImport("gdi32.dll")] private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
            readonly PrivateFontCollection FontCollection = new PrivateFontCollection();

            public Font GetFont(int FontId, int Height)
            {
                try
                {
                    if (FontCollection.Families.Length < 2)
                    {
                        var RawDataCollection = new List<byte[]>()
                {
                Resources.primary,
                Resources.secondary,
                };

                        for (int k = 0; k < RawDataCollection.Count; k += 1)
                        {
                            byte[] RawData = RawDataCollection[k];

                            var Pointer = Marshal.AllocCoTaskMem(RawData.Length);

                            Marshal.Copy(RawData, 0, Pointer, RawData.Length);

                            uint Reference = 0;

                            AddFontMemResourceEx(Pointer, (uint)RawData.Length, IntPtr.Zero, ref Reference);
                            FontCollection.AddMemoryFont(Pointer, RawData.Length);
                        };
                    };

                    return new Font(FontCollection.Families[FontId], Height);
                }

                catch
                {
                    return new Font("Modern", Height, FontStyle.Regular);
                };
            }


            // Current Instance Related:
            public string GetCurrentNamespace() =>
            Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.Namespace;

            public string GetStringFrom(string fn)
            {
                try
                {
                    string nsn = GetType().Namespace;

                    using (Stream strm = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{nsn}.{fn}"))
                    {
                        using (StreamReader rdr = new StreamReader(strm))
                        {
                            return rdr.ReadToEnd();
                        }
                    }
                }

                catch
                {
                    return string.Empty;
                }
            }
        }
    }
}