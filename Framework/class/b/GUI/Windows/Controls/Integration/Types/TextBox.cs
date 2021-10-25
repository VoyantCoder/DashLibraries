
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
            public void TextBox(Control parent, TextBox textbox, Size size, Point location, Color backColor, Color foreColor, string text, int fontPts)
            {
                try
                {
                    if (textbox == null)
                    {
                        textbox = new TextBox();
                        Register(parent, textbox);
                    }

                    SetLocation(location, parent, size, textbox);

                    textbox.Font = ResourceTool.GetFont(1, fontPts);
                    textbox.BackColor = backColor;
                    textbox.ForeColor = foreColor;
                    textbox.Text = text;

                    parent.Controls.Add(textbox);

                    Transform.Resize(textbox, size);
                    UpdateRegister(parent, textbox);
                }

                catch
                {
                    throw;
                }
            }

            public void TextBox(Control parent, TextBox textbox, Size size, Point location, Color backColor, Color foreColor, string text, int fontPts, bool additionals1, bool additionals2)
            {
                try
                {
                    TextBox(parent, textbox, size, location, backColor, foreColor, text, fontPts);

                    if (additionals1)
                    {
                        textbox.BorderStyle = BorderStyle.None;
                        textbox.WordWrap = true;
                    }

                    if (additionals2)
                    {
                        textbox.TextAlign = HorizontalAlignment.Center;
                    }
                }

                catch
                {
                    throw;
                }
            }

            public void TextBox(Control parent, TextBox textbox, Size size, Point location, Color backColor, Color foreColor, string text, int fontPts, bool additionals1, bool additionals2, int fixedBoxSpacing)
            {
                try
                {
                    if (fixedBoxSpacing < 1 || fixedBoxSpacing >= size.Height || fixedBoxSpacing >= size.Width)
                    {
                        return;
                    }

                    location = new Point(fixedBoxSpacing, fixedBoxSpacing);
                    DashPanel panel = new DashPanel();

                    TextBox(panel, textbox, size, location, backColor, foreColor, text, fontPts, additionals1, additionals2);

                    int height = size.Height + (fixedBoxSpacing * 2);
                    int width = size.Width + (fixedBoxSpacing * 2);
                    Size panelSize = new Size(width, height);

                    Panel(parent, panel, panelSize, location, backColor);
                    Register(parent, panel);
                    UpdateRegister(panel, textbox);
                }

                catch
                {
                    throw;
                }
            }

            public void TextBox(Control parent, TextBox textbox, Size size, Point location, Color backColor, Color foreColor, string text, int fontPts, bool additionals1, bool additionals2, int fixedBoxSpacing, bool multiline)
            {
                try
                {
                    TextBox(parent, textbox, size, location, backColor, foreColor, text, fontPts, additionals1, additionals2);

                    textbox.AcceptsTab = multiline;
                    textbox.Multiline = multiline;
                    
                    UpdateRegister(parent, textbox);
                }

                catch
                {
                    throw;
                }
            }

            public void TextBox(Control parent, TextBox textbox, Size size, Point location, Color backColor, Color foreColor, string text, int fontPts, bool additionals1, bool additionals2, int fixedBoxSpacing, bool multiline, bool horizontalScrollbar)
            {
                try
                {
                    TextBox(parent, textbox, size, location, backColor, foreColor, text, fontPts, additionals1, additionals2, fixedBoxSpacing, multiline);

                    if (horizontalScrollbar)
                    {
                        textbox.WordWrap = true;
                        textbox.ScrollBars = ScrollBars.Vertical;
                    }

                    UpdateRegister(parent, textbox);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}