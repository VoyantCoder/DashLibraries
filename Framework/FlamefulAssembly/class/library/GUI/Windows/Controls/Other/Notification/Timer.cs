
// Author: Dashie


using FlamefulAssembly.Runnables;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace DashControls.Controls
    {
        public partial class Notification
        {
            public void EnableAppearanceTimer(int Delay)
            {
                try
                {
                    if (timer.Enabled)
                    {
                        timer.Enabled = false;
                    }

                    timer.Elapsed += (s, e) =>
                    {
                        try
                        {
                            new Thread(() =>
                    {
                        try
                        {
                            void setOpacity(int opacity)
                            {
                                try
                                {
                                    Run.RunTaskSynchronously
                            (
                            Panel1.Parent,

                            () =>
                            {
                                if (opacity == -1)
                                {
                                    Panel1.Hide();
                                    opacity = 255;
                                }

                                Panel1.BackColor = Color.FromArgb(opacity, Panel1.BackColor);
                                Panel1.ForeColor = Color.FromArgb(opacity, Panel1.ForeColor);
                                Label1.ForeColor = Color.FromArgb(opacity, Label1.ForeColor);
                                Label2.ForeColor = Color.FromArgb(opacity, Label2.ForeColor);

                                Panel1.Refresh();
                            }
                            );
                                }

                                catch
                                {
                                    throw;
                                }
                            }

                            void Wait()
                            {
                                try
                                {
                                    Thread.Sleep(50);
                                }

                                catch
                                {
                                    throw;
                                }
                            }

                            for (int a = 250; a > 40; a -= 5, Wait())
                            {
                                setOpacity(a);
                            }

                            setOpacity(-1);
                        }

                        catch
                        {
                            throw;
                        }

                        timer.Enabled = false;
                    })

                            { IsBackground = true }.Start();
                        }

                        catch
                        {
                            throw;
                        }
                    };

                    timer.Interval = Delay;
                    timer.Enabled = true;

                    Panel1.VisibleChanged += (s, e) =>
                    {
                        try
                        {
                            if (Panel1.Visible)
                            {
                                timer.Start();
                            }
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
        }
    }
}