
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace DashControls
    {
        public partial class ControlIntegrator
        {
            private void SetLocation(Point location, Control parent, Size size, Control control)
            {
                try
                {
                    void CenterY() => location.Y = (parent.Height - size.Height) / 2;
                    void CenterX() => location.X = (parent.Width - size.Width) / 2;

                    if (location != null && location != Point.Empty)
                    {
                        if (location.Y == -1)
                        {
                            CenterY();
                        }

                        if (location.X == -1)
                        {
                            CenterX();
                        }
                    }

                    else
                    {
                        CenterY();
                        CenterX();
                    }

                    control.Location = location;
                }

                catch
                {
                    throw; 
                }
            }
        }
    }
}