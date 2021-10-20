
// Author: Dashie


using System.Drawing;


namespace DashFramework
{
    namespace Forms
    {
        public partial class HelperGUI
        {
            public void LeftPanel()
            {
                try
                {
                    Size size1 = new Size(leftPanelWidth - 3, mainBasePanel.Height);
                    Size size2 = new Size(size1.Width - 8, size1.Height - 10);

                    Point location1 = new Point(0, 0);
                    Point location2 = new Point(4, 4);

                    Integrate.Panel(mainBasePanel, leftBasePanel, size1, location1, leftPanelBackColor);
                    Integrate.Panel(leftBasePanel, leftContentBasePanel, size2, location2, leftPanelBackColor);
                    Integrate.Panel(leftContentBasePanel, leftContentPanel, size2, location1);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}