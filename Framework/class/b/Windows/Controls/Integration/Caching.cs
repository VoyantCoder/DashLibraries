
// Author: Dashie


using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;


namespace DashFramework
{
    namespace DashControls
    {
        public partial class ControlIntegrator
        {
            private readonly Dictionary<Control, List<Control>> Controls = new Dictionary<Control, List<Control>>();

            public IEnumerable<Control> GetControls(Control parent, params Type[] type)
            {
                if (!Controls.ContainsKey(parent))
                {
                    yield return null;
                    yield break;
                }

                var types = type.ToList();

                foreach (Control control in Controls[parent])
                {
                    if (types.Contains(control.GetType()))
                    {
                        yield return control;
                    }
                }
            }

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
                        {
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