
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace Forms
    {
        public partial class Toolbar
        {
            public void SetLocation(Point Location)
            {
                try
                {
                    Panel1.Location = Location;
                }

                catch
                {
                    throw;
                }
            }

            public Point GetPosition(ToolbarPosition Position, Control Parent = default(Control), Size Size = default(Size))
            {
                try
                {
                    if (Parent == default(Control))
                    {
                        if (Panel1.Parent == null)
                        {
                            return Point.Empty;
                        }

                        Parent = Panel1.Parent;
                    }

                    if (Size == default(Size))
                    {
                        if (Panel1.Parent == null)
                        {
                            return Point.Empty;
                        }

                        Size = Panel1.Size;
                    }

                    Point Location = new Point(-2, -2);

                    switch (Position)
                    {
                        case ToolbarPosition.Top:
                        {
                            Location.Y = 0;
                            break;
                        }

                        case ToolbarPosition.Bottom:
                        {
                            Location.Y = Parent.Height - Size.Height;
                            break;
                        }

                        case ToolbarPosition.Right:
                        {
                            Location.X = Parent.Width - Size.Width;
                            break;
                        }

                        case ToolbarPosition.Left:
                        {
                            Location.X = 0;
                            break;
                        }
                    }

                    return Location;
                }

                catch
                {
                    throw;
                }
            }

            public void SetPosition(ToolbarPosition Position)
            {
                try
                {
                    SetLocation(GetPosition(Position, null, Size.Empty));
                }

                catch
                {
                    throw;
                }
            }

            public void Integrate(Control Parent, Color BackColor, Size Size, ToolbarPosition Position)
            {
                try
                {
                    Integrate(Parent, BackColor, Size, GetPosition(Position, Parent, Size));
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}