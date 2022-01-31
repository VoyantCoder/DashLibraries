// Author: Dashie


using System.Drawing;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace Forms
    {
        public partial class DashWindow
        {
            public void SetWindowBorderStyle(FormBorderStyle BorderStyle)
            {
                try
                {
                    WindowInstance.FormBorderStyle = BorderStyle;
                    WindowInstance.Update();
                }

                catch
                {
                    throw;
                }
            }

            public Point GetWindowLocation(DashWindowPosition Position, Size Size = default(Size))
            {
                try
                {
                    Point WindowLocation = Point.Empty;

                    void SetLocation(int x = -20, int y = -20)
                    {
                        try
                        {
                            if (x == -20)
                            {
                                x = 0;
                            }

                            if (y == -20)
                            {
                                y = 0;
                            }

                            WindowLocation = new Point(x, y);
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    int MonitorHeight = SystemInformation.PrimaryMonitorSize.Height;
                    int MonitorWidth = SystemInformation.PrimaryMonitorSize.Width;

                    if (Size == default(Size))
                    {
                        Size = WindowInstance.Size;
                    }

                    void Hook1()
                    {
                        try
                        {
                            Sort.Sort(("Bottom"), () =>
                            {
                                int y = MonitorHeight - Size.Height - 30;
                                int x = (MonitorWidth - Size.Width) / 2;

                                if (x >= 0 && y >= 0)
                                {
                                    SetLocation(x, y);
                                }
                            });
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    void Hook2()
                    {
                        try
                        {
                            Sort.Sort(("Center"), () =>
                            {
                                int y = (MonitorHeight - Size.Height) / 2;
                                int x = (MonitorWidth - Size.Width) / 2;

                                if (x >= 0 && y >= 0)
                                {
                                    SetLocation(x, y);
                                }
                            });
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    void Hook3()
                    {
                        try
                        {
                            Sort.Sort(("Right"), () =>
                            {
                                int y = (MonitorHeight - Size.Height) / 2;
                                int x = MonitorWidth - Size.Width - 30;

                                if (x >= 0)
                                {
                                    SetLocation(x);
                                }
                            });
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    void Hook4()
                    {
                        try
                        {
                            Sort.Sort(("Left"), () =>
                            {
                                int y = (MonitorWidth - Size.Width) / 2;

                                if (y >= 0)
                                {
                                    SetLocation(y: y);
                                }
                            });
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    void Hook5()
                    {
                        try
                        {
                            Sort.Sort(("Top"), () =>
                            {
                                int x = (MonitorWidth - Size.Width) / 2;
                                SetLocation(x + 30);
                            });
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    switch (Position)
                    {
                        case DashWindowPosition.Bottom: Hook1(); break;
                        case DashWindowPosition.Center: Hook2(); break;
                        case DashWindowPosition.Right: Hook3(); break;
                        case DashWindowPosition.Left: Hook4(); break;
                        case DashWindowPosition.Top: Hook5(); break;
                    }

                    return WindowLocation;
                }

                catch
                {
                    return Point.Empty;
                }
            }

            public void Integrate(DashWindowPosition Position, Size Size, Color BackColor, bool DisableWindowsBorder = true)
            {
                try
                {
                    Point WindowLocation = GetWindowLocation(Position, Size);

                    if (!WindowLocation.Equals(Point.Empty))
                    {
                        WindowInstance.Location = WindowLocation;
                    }

                    WindowInstance.StartPosition = FormStartPosition.Manual;
                    WindowInstance.BackColor = BackColor;
                    WindowInstance.Icon = resources.Resources.ICON;

                    if (DisableWindowsBorder)
                    {
                        SetWindowBorderStyle(FormBorderStyle.None);
                    }

                    Transform.Resize(WindowInstance, Size);

                    if (!Initialized)
                    {
                        Initialized = true;
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