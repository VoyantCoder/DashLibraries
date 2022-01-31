
// Author: Dashie


using FlamefulAssembly.DashControls.Controls;
using System.Collections.Generic;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace DashControls
    {
        public partial class ControlIntegrator
        {
            private void Register(Control parent, DashCheckBox checkBox)
            {
                try
                {
                    if (!Checkboxes.ContainsKey(parent))
                    {
                        Checkboxes.Add(parent, new List<DashCheckBox>());
                    }

                    Checkboxes[parent].Add(checkBox);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}