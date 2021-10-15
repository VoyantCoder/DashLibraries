
// Author: Dashie


using System.Windows.Forms;


namespace DashFramework
{
    namespace DashControls.Controls
    {
        public partial class DashPanel
        {
            public static class Children
            {
                public static void Add(Control control)
                {
                    try
                    {
                        inst.Controls.Add(control);
                    }

                    catch
                    {
                        throw;
                    }
                }
            }
        }
    }
}