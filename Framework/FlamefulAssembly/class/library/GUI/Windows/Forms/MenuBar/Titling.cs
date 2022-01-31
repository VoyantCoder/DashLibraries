
// Author: Dashie


using FlamefulAssembly.Data;
using System.Drawing;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace Forms
    {
        public partial class MenuBar
        {
            public void SetTitleFont(int FontPoints, int FontTypeId)
            {
                try
                {
                    Font TitleFont = ResourceTool.GetFont(FontTypeId, FontPoints);

                    if (TitleFont != null)
                    {
                        this.FontPoints = FontPoints;
                        this.FontTypeId = FontTypeId;

                        Label1.Font = TitleFont;
                    }
                }

                catch
                {
                    throw;
                }
            }

            public TitlePosition ExTitlePosition = TitlePosition.Center;

            public void UpdateTitlePosition()
            {
                try
                {
                    Label1.Location = GetTitlePosition(ExTitlePosition);
                }

                catch
                {
                    throw;
                }
            }

            public void SetTitleSize(int FontPoints)
            {
                try
                {
                    Label1.Size = DataTool.GetFontSize(Label1.Text, FontPoints, FontTypeId);
                    Label1.Font = new Font(Label1.Font.FontFamily, FontPoints);

                    UpdateTitlePosition();
                }

                catch
                {
                    throw;
                }
            }

            readonly DataTools DataTool = new DataTools();

            public Point GetTitlePosition(TitlePosition TitlePos, string TitleText = ".")
            {
                try
                {
                    if (TitleText.Equals("."))
                    {
                        TitleText = Label1.Text;
                    }

                    Size TitleSize = DataTool.GetFontSize(TitleText, FontPoints, FontTypeId);

                    int DetermineBottom()
                    {
                        try
                        {
                            if (Panel1.Height <= TitleSize.Height)
                            {
                                return Panel1.Height - TitleSize.Height;
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

                    int DetermineRight()
                    {
                        try
                        {
                            return (Panel1.Width - TitleSize.Width);
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    Point TitleLocation = new Point(-1, -1);

                    switch (TitlePos)
                    {
                        case TitlePosition.Top:
                        {
                            TitleLocation.X = 0;
                            TitleLocation.Y = 0;
                            break;
                        }

                        case TitlePosition.TopMiddle:
                        {
                            TitleLocation.Y = 0;
                            break;
                        }

                        case TitlePosition.Bottom:
                        {
                            TitleLocation.Y = DetermineBottom();
                            TitleLocation.X = 0;
                            break;
                        }

                        case TitlePosition.BottomMiddle:
                        {
                            TitleLocation.Y = DetermineBottom();
                            break;
                        }

                        case TitlePosition.Right:
                        {
                            TitleLocation.X = DetermineRight();
                            TitleLocation.Y = 0;
                            break;
                        }

                        case TitlePosition.RightMiddle:
                        {
                            TitleLocation.X = DetermineRight();
                            break;
                        }

                        case TitlePosition.Left:
                        {
                            TitleLocation.X = 10;
                            TitleLocation.Y = 0;
                            break;
                        }

                        case TitlePosition.LeftMiddle:
                        {
                            TitleLocation.X = 10;
                            break;
                        }
                    }

                    return TitleLocation;
                }

                catch
                {
                    throw;
                }
            }

            public void SetTitlePosition(TitlePosition Position)
            {
                try
                {
                    Label1.Location = GetTitlePosition(Position);
                }

                catch
                {
                    throw;
                }
            }

            public void SetTitleLocation(Point Location)
            {
                try
                {
                    if (Location.X == -1 || Location.Y == -1)
                    {
                        if (Location.Y == -1)
                        {
                            Location.Y = (Panel1.Height - Label1.Height) / 2;
                        }

                        if (Location.X == -1)
                        {
                            Location.X = (Panel1.Width - Label1.Width) / 2;
                        }
                    }

                    Label1.Location = Location;
                }

                catch
                {
                    throw;
                }
            }

            public void SetTitleBackColor(Color Color)
            {
                try
                {
                    Label1.BackColor = Color;
                }

                catch
                {
                    throw;
                }
            }

            public void SetTitleForeColor(Color Color)
            {
                try
                {
                    Label1.ForeColor = Color;
                }

                catch
                {
                    throw;
                }
            }

            public void Integrate(Control Parent, Size BarSize, Point BarLoca, Color BarBColor, string TitleText, Color TitleFColor, TitlePosition TitleLoca)
            {
                try
                {
                    Sort.Sort(("Top Call"), () =>
                    {
                        Integrate(Parent, BarSize, BarLoca, BarBColor);
                    });

                    Sort.Sort(("Label Integration"), () =>
                    {
                        Size TitleSize = DataTool.GetFontSize(TitleText, FontPoints, FontTypeId);
                        Point TitlePosition = GetTitlePosition(TitleLoca, TitleText);

                        Integrator.Label(Panel1, Label1, TitleSize, TitlePosition,
                            Color.Empty, TitleFColor, FontPoints, TitleText, true);

                        ExTitlePosition = TitleLoca;
                    });
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}