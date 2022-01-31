
// Author: Dashie


using FlamefulAssembly.Erroring;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace Forms
    {
        public class Forms
        {
            public void CenterDialog(Control Dialog, Control Parent)
            {
                try
                {
                    Point ParentLoca = Parent.PointToScreen(Point.Empty);

                    int Y = ParentLoca.Y + ((Parent.Height - Dialog.Height) / 2);
                    int X = ParentLoca.X + ((Parent.Width - Dialog.Width) / 2);

                    Dialog.Location = new Point(X, Y);
                }

                catch
                {
                    throw;
                }
            }

            // Auto Update Ideology: (Future Feature)
            // - When parent GUI moves update added dialog
            // - Old Dialog Location on Screen
            // - Update it by changed value of Parent
            // - If changed value is higher than old +
            // - If changed value is lower than old -
        }
    }
}