
// Author: Dashie


using System.Collections.Generic;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace DashControls
    {
        public partial class ControlIntegrator
        {
            private void Register(Control parent, Control child)
            {
                try
                {
                    if (!Controls.ContainsKey(parent))
                    {
                        Controls.Add(parent, new List<Control>());
                    }

                    Controls[parent].Add(child);
                }

                catch
                {
                    throw;
                }
            }

            private void UpdateRegister(Control parent, Control control)
            {
                try
                {
                    if (Controls.ContainsKey(parent))
                    {
                        if (Controls[parent].Contains(control))
                        {//only works for first occurrence, but why occur twice?
                            int id = Controls[parent].IndexOf(control);
                            Controls[parent][id] = control;
                        }
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