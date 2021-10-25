
// Author: Dashie


using System.Linq;


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
                    windowInst.Show();
                }

                catch
                {
                    throw;
                }
            }

            public void Show(bool dialog)
            {
                try
                {
                    if (dialog)
                    {
                        Parent.ShowDialog();
                    }

                    else
                    {
                        Show();
                    }
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
                    windowInst.Hide();
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}