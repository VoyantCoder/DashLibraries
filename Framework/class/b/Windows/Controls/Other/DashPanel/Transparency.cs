
// Author: Dashie


using System;
using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace DashControls.Controls
    {
        /*public partial class DashPanel : Panel
        { 
            public int Opacity
            {
            get
            {
                if (opacity > 100)
                {
                opacity = 100;
                }

                else if (opacity < 1)
                {
                opacity = 1;
                }

                return opacity;
            }

            set
            {
                opacity = value;

                if (Parent != null)
                {
                Parent.Invalidate(Bounds, true);
                }
            }
            }

            protected override CreateParams CreateParams
            {
            get
            {
                CreateParams cParams = base.CreateParams;
                cParams.ExStyle = cParams.ExStyle | 0x20;
                return cParams;
            }
            }

            protected override void OnPaint(PaintEventArgs e)
            {
            alpha = (opacity * 255) / 100;

            using (Brush BackColor = new SolidBrush(Color.FromArgb(alpha, this.BackColor)))
            {
                if (this.BackColor != Color.Transparent)
                {
                using (Graphics graphics = e.Graphics)
                {
                    Rectangle bounds = new Rectangle(0, 0, Width - 1, Height - 1);
                    graphics.FillRectangle(BackColor, bounds);
                }
                }
            }

            base.OnPaint(e);
            }

            protected override void OnBackColorChanged(EventArgs e)
            {
            if (Parent != null)
            {
                Parent.Invalidate(this.Bounds, true);
            }

            base.OnBackColorChanged(e);
            }

            protected override void OnParentBackColorChanged(EventArgs e)
            {
            Invalidate();
            base.OnParentBackColorChanged(e);
            }
        }*/
    }
}