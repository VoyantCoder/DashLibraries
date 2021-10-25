
// Author: Dashie


using System;
using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace DashDialogs
    {
        public partial class SimpleDialog
        {
            public virtual void ConstructSector1()
            {
                try
                {
                    void Register(Label label, int fontSize)
                    {
                        Integrate.Label(Window.Instance, label, Size.Empty,
                        Point.Empty, UIBackColor, UITextForeColor, fontSize, "");

                        label.TextAlign = ContentAlignment.MiddleCenter;
                    }

                    Register(HeadLabel, 16);
                    Register(BodyLabel, 11);
                }

                catch
                {
                    throw;
                }

                HeadLabel.Top = 43;
            }

            public virtual void ConstructSector2()
            {
                try
                {
                    Point buttonLocation = new Point(-1, 0);
                    Size buttonSize = new Size(150, 28);

                    Integrate.Button(Window.Instance, CloseBttn, buttonSize,
                    buttonLocation, 10, "Close", UIButtonColor, UITextForeColor, true);

                    CloseBttn.Click += (s, e) =>
                    {
                        try
                        {
                            CloseCode();
                        }

                        catch
                        {
                            throw;
                        }
                    };

                    Transform.Round(CloseBttn, 6);
                }

                catch
                {
                    throw;
                }
            }

            private void ConstructWindow(string title)
            {
                try
                {
                    Window.Integrate(Forms.DashWindowPosition.Center, new Size(350, 78), UIBackColor, Color.Empty,
                    RoundSides, Forms.DashWindowRoundRadius.MoreSo, UIMenubarBackColor, UITextForeColor, null, title);

                    ConstructSector1();
                    ConstructSector2();

                    SetContents("Default Header", "Default Body");
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}