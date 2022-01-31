
// Author: Dashie


using System;
using System.Drawing;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace DashControls
    {
        public partial class ControlIntegrator
        {
            public void Button(Control parent, Button button, Size size, Point location, int fontPts, string text)
            {
                try
                {
                    if (button == null)
                    {
                        button = new Button();
                        Register(parent, button);
                    }

                    button.Font = ResourceTool.GetFont(1, fontPts);
                    button.Text = text;

                    SetLocation(location, parent, size, button);

                    Transform.Resize(button, size);
                    parent.Controls.Add(button);

                    UpdateRegister(parent, button);
                }

                catch
                {
                    throw;
                }
            }

            public void Button(Control parent, Button button, Size size, Point location, int fontPts, string text, Color backColor, Color foreColor, bool additionals = true)
            {
                try
                {
                    Button(parent, button, size, location, fontPts, text);

                    button.BackColor = backColor;
                    button.ForeColor = foreColor;

                    if (additionals)
                    {
                        button.FlatAppearance.CheckedBackColor = button.FlatAppearance.MouseDownBackColor;
                        button.FlatAppearance.BorderColor = backColor;
                        button.FlatAppearance.BorderSize = 0;
                        button.FlatStyle = FlatStyle.Flat;
                    }

                    UpdateRegister(parent, button);
                }

                catch
                {
                    throw;
                }
            }

            public void Button(Control parent, Button button, Size size, Point location, int fontPts, string text, Color backColor, Color foreColor, bool additionals, Action onClick)
            {
                try
                {
                    Button(parent, button, size, location, fontPts, text, backColor, foreColor, additionals);

                    if (onClick != null)
                    {
                        button.Click += (s, e) =>
                        {
                            try
                            {
                                onClick();
                            }

                            catch
                            {
                                throw;
                            }
                        };
                    }

                    UpdateRegister(parent, button);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}