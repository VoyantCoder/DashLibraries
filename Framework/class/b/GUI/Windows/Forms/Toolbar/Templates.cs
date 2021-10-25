
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;


namespace DashFramework
{
    namespace Forms
    {
        public partial class Toolbar
        {
            public IEnumerable<Button> GetTemplateBabies()
            {
                foreach (Button Button in ButtonCache)
                {
                    yield return Button;
                }
            }

            void UpdateButtonCache()
            {
                try
                {
                    ButtonCache.Clear();

                    List<Button> ControlCache = new List<Button>();

                    foreach (Control A in Panel2.Controls)
                    {
                        if (A is Button)
                        {
                            ControlCache.Add((Button)A);
                        }
                    }

                    ButtonCache.AddRange(ControlCache);
                }

                catch
                {
                    throw;
                }
            }

            void ResizeTemplateContainer()
            {
                try
                {
                    Size PreferredSize()
                    {
                        try
                        {
                            if (Panel2.Controls.Count > 0)
                            {
                                Control Control = Panel2.Controls[Panel2.Controls.Count - 1];
                                return new Size(Control.Left + Control.Width, Control.Parent.Height);
                            }

                            return new Size(0, 0);
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    Transform.Resize(Panel2, PreferredSize());

                    Point GetCenter()
                    {
                        try
                        {
                            int y = (Panel2.Parent.Height - Panel2.Height) / 2;
                            int x = (Panel2.Parent.Width - Panel2.Width) / 2;

                            if (y < 0)
                            {
                                y = 0;
                            }

                            if (x < 0)
                            {
                                x = 0;
                            }

                            return new Point(x, y);
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    Panel2.Location = GetCenter();
                }

                catch
                {
                    throw;
                }
            }

            public void IntegrateTemplate(ToolbarTemplate Template, bool ResetExisting = true, string info = "[Only works for bottom bars]")
            {
                try
                {
                    Sort.Sort(("Startup Flags"), () =>
                    {
                        if (Panel1.Parent == null)
                        {
                            return;
                        }

                        else if (ResetExisting)
                        {
                            if (Panel2.Controls.Count > 0)
                            {
                                foreach (Control Control in Panel2.Controls)
                                {
                                    Control.Dispose();
                                }

                                Panel2.Controls.Clear();
                            }
                        }
                    });

                    Sort.Sort(("Quickify Settings"), () =>
                    {
                        QuickyInjector.BttnParent = Panel2;
                        QuickyInjector.BttnSize = new Size(95, Panel1.Height - 10); // 5 from top
                QuickyInjector.BttnBorder = true;

                        QuickyInjector.BttnBCol = Panel1.BackColor;
                        QuickyInjector.BttnFCol = Color.White;

                        QuickyInjector.BttnFpts = 10;
                        QuickyInjector.BttnFid = 1;
                    });

                    Sort.Sort(("Template Container"), () =>
                    {
                        Size ContainerSize = new Size(10, Panel1.Height - 10);
                        Point ContainerLoca = new Point(-1, 5);
                        Color ContainerBackColor = Panel1.BackColor;

                        Integrator.Panel(Panel1, Panel2, ContainerSize, ContainerLoca, ContainerBackColor);
                    });

                    void Hook1()
                    {
                        try
                        {
                            Sort.Sort(("SaveLoadOpen Template"), () =>
                            {
                                QuickyInjector.QuickButton(new Button(), "Save", new Point(0, 0));
                                QuickyInjector.QuickButton(new Button(), "Load", new Point(105, 0));
                                QuickyInjector.QuickButton(new Button(), "Open", new Point(210, 0));

                                ResizeTemplateContainer();
                                UpdateButtonCache();
                            });
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
                            Sort.Sort(("OkayCancel Template"), () =>
                            {
                                QuickyInjector.QuickButton(new Button(), "Close", new Point(105, 0));
                                QuickyInjector.QuickButton(new Button(), "Okay", new Point(0, 0));

                                ResizeTemplateContainer();
                                UpdateButtonCache();
                            });
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
                            Sort.Sort(("Close Template"), () =>
                            {
                                QuickyInjector.QuickButton(new Button(), "Close", new Point(0, 0));

                                ResizeTemplateContainer();
                                UpdateButtonCache();
                            });
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    switch (Template)
                    {
                        case ToolbarTemplate.SaveLoadOpen: Hook1(); break;
                        case ToolbarTemplate.OkayCancel: Hook2(); break;
                        case ToolbarTemplate.Close: Hook3(); break;
                    }
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}