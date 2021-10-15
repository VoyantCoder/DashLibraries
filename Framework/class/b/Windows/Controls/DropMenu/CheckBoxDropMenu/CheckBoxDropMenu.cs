
// Author: Dashie
// Version: 1.0


using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace DashControls.Controls
    {
        public partial class CBDropMenu
        {
            public bool Integrator(Control Parent, Point Location, Color BackColor, int MenuWidth = 110)
            {
                try
                {
                    if (ExInfo.Added)
                    {
                        return false;
                    }

                    Sort.Sort(("Base"), () =>
                    {
                        Size Size = new Size(MenuWidth, 40);
                        Integrate.Panel(Parent, Layer1, Size, Location, Color.Transparent);
                        Integrate.Panel(Layer1, Layer2, Size, new Point(0, 0), BackColor);
                    });

                    Sort.Sort(("Layer3"), () =>
                    {
                        Size Size = new Size(MenuWidth - 30 - 6, Layer1.Height - 4);
                        Point _Location = new Point(MenuWidth - Size.Width - 2, 2);
                        Integrate.Panel(Layer2, Layer3, Size, _Location, BackColor);
                    });

                    Sort.Sort(("Layer4"), () =>
                    {
                        Size Size = new Size(30, Layer1.Height - 4);
                        Point _Location = new Point(2, 2);
                        Integrate.Panel(Layer2, Layer4, Size, _Location, BackColor);
                    });

                    ExInfo.Toggle();
                    Hide(true);
                }

                catch
                {
                    return false;
                }

                return true;
            }
        }
    }
}
