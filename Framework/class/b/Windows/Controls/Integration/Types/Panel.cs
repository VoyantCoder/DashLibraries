
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;

using DashFramework.DashControls.Controls;


namespace DashFramework
{
    namespace DashControls
    {
        public partial class ControlIntegrator
        { 
            public void Panel(Control parent, DashPanel panel, Size size, Point location)
            {
                try
                {
                    if (panel == null)
                    {
                        panel = new DashPanel();
                        Register(parent, panel);
                    }

                    SetLocation(location, parent, size, panel);
                    Transform.Resize(panel, size);

                    panel.BackColor = parent.BackColor;
                    parent.Controls.Add(panel);

                    UpdateRegister(parent, panel);
                }

                catch
                {
                    throw;
                }
            }

            public void Panel(Control parent, DashPanel panel, Size size, Point location, Color backColor)
            {
                try
                {
                    Panel(parent, panel, size, location);
                    panel.BackColor = backColor;
                    UpdateRegister(parent, panel);
                }

                catch
                {
                    throw;
                }
            }

            public void Panel(Control parent, DashPanel panel, Size size, Point location, Color backColor, bool additionals)
            {
                try
                {
                    Panel(parent, panel, size, location, backColor);

                    if (additionals)
                    {
                        panel.BorderStyle = BorderStyle.None;
                    }

                    UpdateRegister(parent, panel);
                }

                catch
                {
                    throw;
                }
            }

            public void Panel(Control parent, DashPanel panel, Size size, Point location, Color backColor, bool additionals, params Control[] children)
            {
                try
                {
                    Panel(parent, panel, size, location, backColor, additionals);
                    parent.Controls.AddRange(children);
                    UpdateRegister(parent, panel);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}