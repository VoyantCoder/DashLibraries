
// Author: Dashie


using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace DashControls.Controls
    {
        public partial class Scroller
        {
            private void ScrollEventHandler(MouseEventArgs e, Control content)
            {
                try
                {
                    if (content.Height <= content.Parent.Height)
                    {
                        return;
                    }

                    int increment = content.Height / content.Parent.Height;
                    int decrement = increment;

                    if (e.Delta > 0)
                    {
                        int top = content.Top;

                        if (top <= 0)
                        {
                            content.Top += increment;
                        }
                    }

                    else
                    {
                        int bottom = content.Bottom;

                        if (content.Bottom - content.Parent.Height >= 0)
                        {
                            content.Top -= decrement;
                        }
                    }
                }

                catch
                {
                    throw;
                }
            }

            private void RegisterParent(Control content, Control parent, bool includeSub)
            {
                try
                {
                    void RegisterEvent(Control control)
                    {
                        try
                        {
                            control.MouseWheel += (s, e) =>
                            {
                                try
                                {
                                    ScrollEventHandler(e, content);
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

                    if (includeSub)
                    {
                        var buffer = Loopsies.GetSubControls(parent);

                        foreach (Control control in buffer)
                        {
                            RegisterEvent(control);
                        }
                    }

                    RegisterEvent(parent);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}