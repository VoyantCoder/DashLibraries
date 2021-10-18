
// Author: Dashie


using System;
using System.Drawing;
using System.Windows.Forms;

using DashFramework.Forms;


namespace DashFramework
{
    namespace DashDialogs
    {
        public partial class SimpleDialog
        {
            public void UUIMenubarBackColor(Color color)
            {
                try
                {
                    if (Window.Menubar != null)
                    {
                        Window.Menubar.SetMenubarBackColor(color);
                    }

                    UIMenubarBackColor = color;
                }

                catch
                {
                    throw;
                }
            }

            public void UUIBackColor(Color color)
            {
                try
                {
                    Window.SetWindowBackColor(color);
                    UIBackColor = color;
                }

                catch
                {
                    throw;
                }
            }

            public void UUITextForeColor(Color color)
            {
                try
                {
                    if (Window.Menubar != null)
                    {
                        Window.Menubar.SetTitleForeColor(color);
                    }

                    HeadLabel.ForeColor = color;
                    BodyLabel.ForeColor = color;
                    CloseBttn.ForeColor = color;
                    UITextForeColor = color;
                }

                catch
                {
                    throw;
                }
            }

            public void UpdateColor(Color color, DiagColorType colorType)
            {
                try
                {
                    void Hook1()
                    {
                        try
                        {
                            UUIMenubarBackColor(color);
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    void Hook2()
                    {
                        try
                        {
                            UUITextForeColor(color);
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    void Hook3()
                    {
                        try
                        {
                            UUIBackColor(color);
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    switch (colorType)
                    {
                        case DiagColorType.UIMenuBar: Hook1(); break;
                        case DiagColorType.UIText: Hook2(); break;
                        case DiagColorType.UI: Hook3(); break;
                    }
                }

                catch
                {
                    throw;
                }
            }

            public void UpdateColors(Color[] colors, params DiagColorType[] colorTypes)
            {
                try
                {
                    Exception Exception(string desc) => throw new Exception(desc);

                    if (colors.Length != colorTypes.Length)
                        throw Exception("Inequal length of colors and types of colors.");

                    for (int k = 0; k < colors.Length; k += 1)
                    {
                        UpdateColor(colors[k], colorTypes[k]);
                    }
                }

                catch
                {
                    throw;
                }
            }

            public void UpdateWindowSize()
            {
                try
                {
                    int height = CloseBttn.Height + CloseBttn.Top + 15;
                    Size windowSize = new Size(350, height);
                    Window.SetWindowSize(windowSize);
                }

                catch
                {
                    throw;
                }
            }

            public void SetContents(string head, string body)
            {
                try
                {
                    Size SizeFor(Label lbl, string str)
                    {
                        try
                        {
                            Size comparer = TextRenderer.MeasureText(str, lbl.Font);

                            return comparer.Width >= 300 ? TextRenderer.MeasureText
                            (str, lbl.Font, new Size(300, 0), TextFormatFlags.WordBreak) : comparer;
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    Size size1 = SizeFor(HeadLabel, head);
                    Size size2 = SizeFor(BodyLabel, body);

                    Transform.Resize(HeadLabel, size1);
                    Transform.Resize(BodyLabel, size2);

                    HeadLabel.Text = head;
                    BodyLabel.Text = body;

                    Control parent = HeadLabel.Parent;

                    HeadLabel.Left = (parent.Width - HeadLabel.Width) / 2;
                    BodyLabel.Left = (parent.Width - BodyLabel.Width) / 2;
                    BodyLabel.Top = HeadLabel.Top + HeadLabel.Height + 15;
                    CloseBttn.Top = BodyLabel.Top + BodyLabel.Height + 25;

                    UpdateWindowSize();
                }

                catch
                {
                    throw;
                }
            }

            public void SetCloseHandler(Action code)
            {
                try
                {
                    CloseCode = code;
                }

                catch
                {
                    throw;
                }
            }

            public void SetButtonText(string text)
            {
                try
                {
                    CloseBttn.Text = text;
                }

                catch
                {
                    throw;
                }
            }

            public void Show()
            {
                try
                {
                    Window.Show();
                    Window.BringToFront();
                }

                catch
                {
                    throw;
                }
            }

            public void Show(string head, string body)
            {
                try
                {
                    SetContents(head, body);
                }

                catch
                {
                    throw;
                }

                Show();
            }

            public void Hide()
            {
                try
                {
                    Window.Hide();
                    Window.SendToBack();
                }

                catch
                {
                    throw;
                }
            }

            public DashWindow getWindow()
            {
                try
                {
                    return Window;
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}