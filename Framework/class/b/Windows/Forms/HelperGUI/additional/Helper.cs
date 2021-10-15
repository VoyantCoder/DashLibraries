
// Author: Dashie


using System.Windows.Forms;

using DashFramework.Forms;


namespace DashFramework
{
    namespace Forms
    {
        public partial class HelperGUI
        {
            public void Show()
            {
                try
                {
                    WindowInst.Show();
                }

                catch
                {
                    throw;
                }
            }

            public void Hide()
            {
                try
                {
                    WindowInst.Hide();
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}