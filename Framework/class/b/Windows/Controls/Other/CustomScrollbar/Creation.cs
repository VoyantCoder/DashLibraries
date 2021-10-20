
// Author: Dashie


using System.Windows.Forms;


namespace DashFramework
{
    namespace DashControls.Controls
    {
        public partial class Scroller
        {
            public void Create(Control control, Control parent)
            {
                try
                {
                    RegisterParent(control, parent, false);
                }

                catch
                {
                    throw;
                }
            }

            public void Create(Control content, Control parent, bool includeSub)
            {
                try
                {
                    RegisterParent(content, parent, includeSub);
                }

                catch
                {
                    throw;
                }
            }

            private void Cleanup(bool clean)
            {
                try
                {
                    if (clean)
                    {
                        Parents.Clear();
                    }
                }

                catch
                {
                    throw;
                }
            }

            public void Create(Control content, Control parent, bool includeSub, bool clean)
            {
                try
                {
                    Cleanup(clean);
                    RegisterParent(content, parent, includeSub);
                }

                catch
                {
                    throw;
                }
            }

            public void Create(Control content, bool includeSub, bool clean, params Control[] parents)
            {
                try
                {
                    Cleanup(clean);

                    foreach (Control parent in parents)
                    {
                        RegisterParent(content, parent, includeSub);
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