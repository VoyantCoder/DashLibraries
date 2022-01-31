
// Author: Dashie


using FlamefulAssembly.ControlTools;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace Interact
    {
        public class CurrentInstance
        {
            public bool IsAdministrator() => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
            public bool IsRunning(string ProcessName) => Process.GetProcessesByName(ProcessName).Length > 1;
            public string GetFilePath() => Assembly.GetExecutingAssembly().Location;


            public void Restart()
            {
                Start();
                Close();
            }

            public void Close()
            {
                Application.Exit();
            }

            readonly Extern Externality = new Extern();

            public void Start()
            {
                try
                {
                    Externality.StartProcess(GetFilePath());
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}