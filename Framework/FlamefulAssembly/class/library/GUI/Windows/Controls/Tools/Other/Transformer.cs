
// Author: Dashie


using FlamefulAssembly.Erroring;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace ControlTools
    {
        public class Transformer
        {
            public void Resize(Control Object, Size Size)
            {
                Object.MaximumSize = Size;
                Object.MinimumSize = Size;
                Object.Size = Size;
            }


            public void RoundContainerControls(Control container)
            {
                try
                {
                    foreach (Control a1 in container.Controls)
                    {
                        foreach (Control a2 in a1.Controls)
                        {
                            Round(a2, 6);
                        }

                        Round(a1, 6);
                    }
                }

                catch
                {
                    throw;
                }
            }


            readonly ReadOnlyForm ReadForm = new ReadOnlyForm();
            class ReadOnlyForm : System.Windows.Forms.Form
            {
                public void PaintOwner(PaintEventArgs e)
                {
                    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                    base.OnPaint(e);
                }
            }

            public void Round(Control Object, int Radius)
            {
                try
                {
                    Object.Paint += (s, e) =>
                    {
                        try
                        {
                            ReadForm.PaintOwner(e);

                            GraphicsPath GraphicsPath = new GraphicsPath();

                            var Rectangle = new Rectangle(0, 0, Object.Width, Object.Height);

                            int R = Radius * 3;

                            int H = Rectangle.Height;
                            int W = Rectangle.Width;

                            int X = Rectangle.X;
                            int Y = Rectangle.X;

                            GraphicsPath.AddArc(X, Y, R, R, 170, 90);
                            GraphicsPath.AddArc(X + W - R, Y, R, R, 270, 90);
                            GraphicsPath.AddArc(X + W - R, Y + H - R, R, R, 0, 90);
                            GraphicsPath.AddArc(X, Y + H - R, R, R, 80, 90);

                            Object.Region = new Region(GraphicsPath);
                        }

                        catch
                        {
                            throw;
                        }
                    };
                }

                catch
                {
                    throw;
                }
            }


            public void AddBorderTo(Control Con, int Ptw, Color BCol)
            {
                try
                {
                    Size Size = new Size(Con.Width - Ptw, Con.Height - Ptw);
                    Point Loca = new Point(Ptw / 2, Ptw / 2);

                    PaintRectangle(Con, Ptw, Size, Loca, BCol);
                }

                catch
                {
                    throw;
                }
            }


            public void PaintRectangle(Control Object, int Thickness, Size Size, Point Location, Color Color)
            {
                Object.Paint += (s, e) =>
                {
                    var graphics = e.Graphics;

                    graphics.SmoothingMode = SmoothingMode.HighQuality;

                    using (Pen pen = new Pen(Color, Thickness))
                    {
                        graphics.DrawRectangle(pen, new Rectangle(Location, Size));
                    };
                };
            }


            public void PaintLine(Control Object, Color Color, int Thickness, Point Location1, Point Location2)
            {
                Object.Paint += (s, e) =>
                {
                    var graphics = e.Graphics;

                    graphics.SmoothingMode = SmoothingMode.HighQuality;

                    using (Pen pen = new Pen(Color, Thickness))
                    {
                        graphics.DrawLine(pen, Location1, Location2);
                    };
                };
            }


            public void PaintCircle(Control Object, Color Color, int Thickness, Point Location, Size Size)
            {
                Object.Paint += (s, e) =>
                {
                    var graphics = e.Graphics;

                    graphics.SmoothingMode = SmoothingMode.HighQuality;

                    using (Pen pen = new Pen(Color, Thickness))
                    {
                        graphics.DrawEllipse(pen, new RectangleF(Location, Size));
                    };
                };
            }
        }
    }
}