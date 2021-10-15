
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;

using DashFramework.DashControls;
using DashFramework.DashResources;


namespace DashFramework
{
    namespace ControlTools.Simplifiers
    {
        public partial class Ashamedify//I spit on it.
        {
            public void AddTextBox(TextBox TextBox, Size Size, Point Loca, string Text, int FontHeight = 8)
            {
                try
                {
                    TextBox.TextAlign = HorizontalAlignment.Center;
                    TextBox.Text = (Text);

                    Control.TextBox(TextBoxParent, TextBox, Size, Loca, TextBoxBCol, TextBoxFCol, Text, FontHeight);
                }

                catch
                {
                    throw;
                }
            }


            public Size TextBoxSize(Size Size, Point Loca, int Height = 21)
            {
                try
                {
                    int Width = (TextBoxParent.Width - Loca.X - Size.Width);
                    return new Size(Width, Height);
                }

                catch
                {
                    throw;
                }
            }

            public void AddLabel(Label Label, Size Size, Point Loca, string Text, int FontHeight = 10)
            {
                try
                {
                    Control.Label(LabelParent, Label, Size, Loca, LabelBCol, LabelFCol, FontHeight, Text);
                }

                catch
                {
                    throw;
                }
            }

            public Size GetFontSize(string Text, int FontHeight = 10)
            {
                try
                {
                    return TextRenderer.MeasureText(Text,
                    ResourceTool.GetFont(1, FontHeight));
                }

                catch
                {
                    throw;
                }
            }


            public Point ControlX(Size Size, Point Loca, int Y = -1, int Extra = 0)
            {
                try
                {
                    int X = (Size.Width + Loca.X + Extra);

                    if (Y == -1)
                        Y = Loca.Y;

                    return new Point(X, Y);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}