
// Author: Dashie


using System.Drawing;


namespace DashFramework
{
    namespace Forms
    {
        public partial class HelperGUI
        {
            public void BasePanel()
            {
                try
                {
                    Size size = new Size(Parent.Width - 20, Parent.Height - 48);
                    Point location = new Point(10, 38);

                    Integrate.Panel(Parent, mainBasePanel, size, location, windowBackColor, true);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}