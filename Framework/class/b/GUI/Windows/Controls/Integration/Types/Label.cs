
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace DashControls
    {
        public partial class ControlIntegrator
        {
            public void Label(Control parent, Label label, Size size, Point location, Color backColor, Color foreColor, int fontPts, string text, bool additionals = true)
            {
                try
                {
                    if (label == null)
                    {
                        label = new Label();
                        Register(parent, label);
                    }

                    if (size == Size.Empty)
                    {
                        size = DataTool.GetFontSize(text, fontPts);
                    }

                    label.Font = ResourceTool.GetFont(1, fontPts);
                    label.BackColor = backColor;
                    label.ForeColor = foreColor;
                    label.Text = text;

                    SetLocation(location, parent, size, label);

                    if (additionals)
                    {
                        label.BorderStyle = BorderStyle.None;
                        label.FlatStyle = FlatStyle.Flat;
                    }

                    parent.Controls.Add(label);
                    Transform.Resize(label, size);

                    UpdateRegister(parent, label);
                }

                catch
                {
                    throw;
                }
            }

            public void Label(Control parent, Label label, Size size, Point location, Color backColor, Color foreColor, int fontPts, string text, bool additionals, bool centered)
            {
                try
                {
                    Label(parent, label, size, location, backColor, foreColor, fontPts, text, additionals);

                    if (centered)
                    {
                        label.TextAlign = ContentAlignment.MiddleCenter;
                    }

                    UpdateRegister(parent, label);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}