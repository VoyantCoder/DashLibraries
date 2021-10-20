
// Author: Dashie


using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;


namespace DashFramework
{
    namespace Forms
    {
        public partial class HelperGUI
        {
            private void UpdateSize()
            {
                try
                {
                    Control basis = leftHelpControls.Last();
                    int height = basis.Top + basis.Height;
                    int width = leftContentPanel.Width;
                    Size size = new Size(width, height);

                    if (sizeToButtons)
                    {
                        int height2 = mainBasePanel.Height + mainBasePanel.Top + 42;
                        int height1 = size.Height + 11;

                        Size size1 = new Size(rightBasePanel.Width, height1);
                        Size size2 = new Size(leftBasePanel.Width, height1);
                        Size size3 = new Size(mainBasePanel.Width, height1);
                        Size size4 = new Size(Window.Parent.Width, height2);
                        Size size5 = new Size(size.Width -6, size.Height-6);

                        var buffer = new List<(Control, Size)>()
                        {
                            (rightContentBasePanel, size1), (leftContentBasePanel, size2),
                            (rightContentPanel, size), (mainBasePanel, size3),
                            (leftBasePanel, size2), (Window.Parent, size4), (rightContent, size5)
                        };

                        foreach (var entry in buffer)
                        {
                            Transform.Resize(entry.Item1, entry.Item2);
                        }

                        Transform.AddBorderTo(Window.Parent, 3, borderBackColor);
                    }

                    Transform.Resize(leftContentPanel, size);
                }

                catch
                {
                    throw;
                }
            }

            public void AddEntry(Button bttn)
            {
                try
                {
                    if (leftHelpControls.Contains(bttn))
                    {
                        leftHelpControls.Remove(bttn);
                    }

                    leftHelpControls.Add(bttn);
                    UpdateSize();
                }

                catch
                {
                    throw;
                }
            }

            public Button GetEntry(int id)
            {
                try
                {
                    Button result = null;

                    if (leftHelpControls.Count > id)
                    {
                        result = leftHelpControls[id];
                    }

                    return result;
                }

                catch
                {
                    throw;
                }
            }

            public void RemoveEntry(int id)
            {
                try
                {
                    if (leftHelpControls.Count > id)
                    {
                        leftHelpControls.RemoveAt(id);
                        UpdateSize();
                    }
                }

                catch
                {
                    throw;
                }
            }

            private void RegisterHelpEntry(Button bttn)
            {
                try
                {
                    AddEntry(bttn);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}