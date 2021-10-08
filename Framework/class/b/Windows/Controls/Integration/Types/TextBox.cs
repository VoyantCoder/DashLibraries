
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
            public void TextBox(Control parent, TextBox textbox, Size size, Point location, Color backColor, Color foreColor)
            {
                try
                {
                    if (textbox == null)
                    {
                        textbox = new TextBox();
                        Register(parent, textbox);
                    }

                    SetLocation(location, parent, size, textbox);

                    textbox.BackColor = backColor;
                    textbox.ForeColor = foreColor;

                    parent.Controls.Add(textbox);

                    Transform.Resize(textbox, size);
                    UpdateRegister(parent, textbox);
                }

                catch
                {
                    throw;
                }
            }

            public void TextBox(Control parent, TextBox textbox, Size size, Point location, Color backColor, Color foreColor, int fixedBoxSpacing, bool additionals)
            {
                try
                {
                    if (fixedBoxSpacing < 1 || fixedBoxSpacing >= size.Height || fixedBoxSpacing >= size.Width)
                    {
                        return;
                    }

                    int height = size.Height + (fixedBoxSpacing * 2);
                    int width = size.Width + (fixedBoxSpacing * 2);

                    Size panelSize = new Size(width, height);
                    DashPanel panel = new DashPanel();

                    Panel(parent, panel, panelSize, location, backColor);
                    Register(parent, panel);

                    if (additionals)
                    {
                        textbox.TextAlign = HorizontalAlignment.Center;
                        textbox.BorderStyle = BorderStyle.None;
                        textbox.WordWrap = true;
                    }

                    location = new Point(fixedBoxSpacing, fixedBoxSpacing);

                    TextBox(panel, textbox, size, location, backColor, foreColor);
                    UpdateRegister(panel, textbox);
                }

                catch
                {
                    throw;
                }
            }

            public void TextBox(Control parent, TextBox textbox, Size size, Point location, Color backColor, Color foreColor, int fixedBoxSpacing, bool additionals, bool multiline)
            {
                try
                {
                    TextBox(parent, textbox, size, location, backColor, foreColor, fixedBoxSpacing, additionals);

                    textbox.AcceptsTab = multiline;
                    textbox.Multiline = multiline;
                    textbox.Refresh();

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