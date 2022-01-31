
// Author: Dashie


using FlamefulAssembly.ControlTools.Algorithms;
using FlamefulAssembly.DashControls.Controls;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace Forms
    {
        public partial class HelperGUI
        {
            private void Finalization()
            {
                try
                {
                    int id = rightPanelDefaultContentId;

                    if (rightPanelDefaultContent)
                    {
                        if (leftButtonHooks.Count > id)
                        {
                            leftButtonHooks[id]();
                        }
                    }

                    OutsmartLoops o = new OutsmartLoops(true);

                    foreach (Control control in o.GetSubControls(mainBasePanel))
                    {
                        if (control is DashPanel)
                        {
                            Transform.Round(control, 6);
                        }
                    }

                    Transform.AddBorderTo(Window.Parent, 4, borderBackColor);
                    Scroller.Create(leftContentPanel, Window.Parent, true);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}