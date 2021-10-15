
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace Forms
    {
        public partial class MenuBar
        {
            public void UpdateIconLayers()
            {
                try
                {
                    if (Icon2.Parent.BackColor.Equals(Icon2.BackColor))
                    {
                        if (Icon2.Parent != null)
                        {
                            Icon2.BackColor = Icon2.Parent.BackColor;
                        }

                        Icon2.BringToFront();
                    }
                }

                catch
                {
                    throw;
                }
            }

            public void Integrate(Control Parent, Size BarSize, Point BarLoca, Color BarBColor, string TitleText, Color TitleFColor, TitlePosition TitlePos, Image Icon, IconPosition IconPos)
            {
                try
                {
                    Integrate(Parent, BarSize, BarLoca, BarBColor, TitleText, TitleFColor, TitlePos);

                    int DetermineBottom()
                    {
                        try
                        {
                            if (Panel1.Height <= Icon.Height)
                            {
                                return Panel1.Height - Icon.Height;
                            }

                            else
                            {
                                return 0;
                            }
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    Point Icon1Position = new Point(-1, -1);

                    void MayRepositionTitle()
                    {
                        try
                        {
                            if (Label1.Left <= 10)
                            {
                                Label1.Left = 10 + Icon.Width + Icon1Position.X;
                            }
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    switch (IconPos)
                    {
                        case IconPosition.Top:
                            {
                                Icon1Position.X = 0;
                                Icon1Position.Y = 0;
                                break;
                            }

                        case IconPosition.TopMiddle:
                            {
                                Icon1Position.Y = 0;
                                break;
                            }

                        case IconPosition.Right:
                            {
                                Icon1Position.X = Panel1.Width;
                                Icon1Position.Y = 0;
                                break;
                            }

                        case IconPosition.RightMiddle:
                            {
                                Icon1Position.X = Panel1.Width;
                                break;
                            }

                        case IconPosition.Left:
                            {
                                Icon1Position.Y = Icon1.Location.Y;
                                Icon1Position.X = 0;
                                MayRepositionTitle();
                                break;
                            }

                        case IconPosition.LeftMiddle:
                            {
                                Icon1Position.X = 0;
                                MayRepositionTitle();
                                break;
                            }

                        case IconPosition.Bottom:
                            {
                                Icon1Position.Y = DetermineBottom();
                                Icon1Position.X = 0;
                                break;
                            }

                        case IconPosition.BottomMiddle:
                            {
                                Icon1Position.Y = DetermineBottom();
                                break;
                            }
                    }

                    if (Icon.Height <= Panel1.Height)
                    {
                        Icon2.Visible = false;
                    }

                    Color IconBackColor = Panel1.BackColor;
                    Integrator.PictureBox(Panel1, Icon1, Icon1Position, Icon, IconBackColor);

                    Point Icon2Position = new Point(Icon1Position.X, Icon1.Top);
                    Integrator.PictureBox(Panel1.Parent, Icon2, Icon2Position, Icon, IconBackColor);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}