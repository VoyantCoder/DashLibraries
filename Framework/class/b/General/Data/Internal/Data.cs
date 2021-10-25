
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.DashResources;
using DashFramework.Erroring;


namespace DashFramework
{
    namespace Data
    {
        public class DataTools
        {
            // Date & Times:
            public string GetCurrentDate() => DateTime.Now.ToLongDateString();
            public string GetCurrentTime() => DateTime.Now.ToLongTimeString();


            // Color Related:
            public string RGBString(Color cc) => ($"{cc.R},{cc.G},{cc.B}");

            public Color NegativeRGB(int minus, Color origin)
            {
                if (origin.R - minus < 0)
                    minus = 0;
                else if (origin.G - minus < 0)
                    minus = 0;
                else if (origin.B - minus < 0)
                    minus = 0;

                return
                (
                    Color.FromArgb
                    (
                    origin.R - minus,
                    origin.G - minus,
                    origin.B - minus
                    )
                );
            }

            public Color PositiveRGB(int plus, Color origin)
            {
                if (origin.R + plus > 255)
                    plus = 0;
                else if (origin.G + plus > 255)
                    plus = 0;
                else if (origin.B + plus > 255)
                    plus = 0;

                return
                (
                    Color.FromArgb
                    (
                    origin.R + plus,
                    origin.G + plus,
                    origin.B + plus
                    )
                );
            }

            public Size ResizeSize(Size Original, int X, int Y, bool Add = true)
            {
                Original.Height += Y;
                Original.Width += X;

                if (!Add)
                {
                    Original.Height -= (2 * Y);
                    Original.Width -= (2 * X);
                }

                return (Original);
            }

            public Size SubstractSize(int Amount, Size Size)
            {
                return new Size(Size.Width - Amount, Size.Height - Amount);
            }


            // Coordinate Related:
            public Point GetCenterFor(Control This, Control BasedOn, bool FromLeft = true, bool FromTop = true, int X = -1, int Y = -1)
            {
                try
                {
                    int x = FromLeft ? (BasedOn.Width - This.Width) / 2 : (X != -1 ? X : 0);
                    int y = FromTop ? (BasedOn.Height - This.Height) / 2 : (Y != -1 ? Y : 0);

                    return new Point(x, y);
                }

                catch
                {
                    return Point.Empty;
                }
            }


            public Point OGetCenter(Control BasedOn, Control This, Point Coords)
            {
                try
                {
                    int x = (Coords.X == -1 ? (BasedOn.Width - This.Width) / 2 : Coords.X);
                    int y = (Coords.Y == -1 ? (BasedOn.Height - This.Height) / 2 : Coords.Y);

                    return new Point(x, y);
                }

                catch
                {
                    return Point.Empty;
                }
            }


            // Font Related:
            readonly ResourceTools ResourceTool = new ResourceTools();
            public Size GetFontSize(string Text, int Size = 10, int Id = 1)
            {
                return TextRenderer.MeasureText(Text, ResourceTool.GetFont(Id, Size));
            }
        }
    }
}