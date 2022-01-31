
// Author: Dashie


using FlamefulAssembly.Erroring;
using System;
using System.Diagnostics;


namespace FlamefulAssembly
{
    namespace ControlTools
    {
        public class Extern
        {
            public void StartProcess(string Path, bool UseShell = true, bool NoAppear = false)
            {
                try
                {
                    using (Process proc = new Process())
                    {
                        proc.StartInfo = new ProcessStartInfo()
                        {
                            UseShellExecute = UseShell,
                            CreateNoWindow = !NoAppear,
                            FileName = Path,
                        };

                        proc.Start();
                    }
                }

                catch
                {
                    throw;
                }
            }


            public void OpenUrl(string Destination)
            {
                try
                {
                    using (var Process = new Process())
                    {
                        Process.StartInfo = new ProcessStartInfo()
                        {
                            FileName = Destination,
                            UseShellExecute = true,
                        };

                        Process.Start();
                    }
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}