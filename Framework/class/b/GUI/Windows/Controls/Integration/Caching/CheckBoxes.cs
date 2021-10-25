
// Author: Dashie


using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.DashControls.Controls;


namespace DashFramework
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