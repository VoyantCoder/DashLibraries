
// Author: Dashie


using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;


namespace DashFramework
{
    namespace Forms
    {
        public partial class HelperGUI
        {
            private void DisplayHelp(string desc)
            {
                try
                {
                    rightContent.Text = desc;
                    rightContent.Refresh();
                }

                catch
                {
                    throw;
                }
            }
        }

        public partial class HelperGUI
        {
            private string ObtainFormat()
            {
                try
                {
                    dynamic format = null;

                    format = resources.Resources.HelperConfiguration;
                    format = Encoding.ASCII.GetString(format);
                    format = format.Replace("</section>", "`");

                    List<string> blacklist = new List<string>()
                    {
                        "section", "description",
                        "/description", "/section",
                        "name", "/name"
                    };

                    foreach (string item in blacklist)
                    {
                        string target = $"<{item}>";

                        if (format.Contains(target))
                        {
                            format = format.Replace(target, "");
                        }
                    }

                    return format;
                }

                catch
                {
                    throw;
                }
            }

            private IEnumerable<(string, string)> Reformat()
            {
                string[] buffer1 = ObtainFormat().Split('`');
                StringBuilder builder = new StringBuilder();

                for (int a = 0; a < buffer1.Length; a += 1, builder.Clear())
                {
                    string[] buffer2 = buffer1[a].Split
                    (
                        new string[]
                        {
                            Environment.NewLine
                        },

                        StringSplitOptions.RemoveEmptyEntries
                    );

                    if (buffer2.Length >= 2)
                    {
                        for (int b = 1; b < buffer2.Length; b += 1)
                        {
                            builder.Append(buffer2[b].Replace(@"\n", "\r\n"));
                        }

                        yield return (buffer2[0], builder.ToString());
                    }
                }
            }

            private Point GetEntryCoordinates()
            {
                try
                {
                    int count = leftContentPanel.Controls.Count - 1;
                    int x = 0;
                    int y = 2;

                    if (count + 1 > 0)
                    {
                        y = leftContentPanel.Controls[count].Top + 2 +
                            leftContentPanel.Controls[count].Height;
                    }

                    return new Point(x, y);
                }

                catch
                {
                    throw;
                }
            }

            private void AddHelpControl(string name, string desc)
            {
                try
                {
                    Size size = new Size(leftContentPanel.Width, leftPanelEntryHeight);
                    Point location = GetEntryCoordinates();
                    Action hook =()=>DisplayHelp(desc);

                    Button button = new Button();

                    Integrate.Button(leftContentPanel, button, size, location, 10, 
                        name, leftPanelEntryBackColor, leftPanelEntryForeColor, true, hook);

                    Transform.Round(button, 6);
                    leftButtonHooks.Add(hook);

                    RegisterHelpEntry(button);
                }

                catch
                {
                    throw;
                }
            }

            private void LoadHelpConfiguration()
            {
                try
                {
                    foreach (var section in Reformat())
                    {
                        string name = section.Item1;
                        string desc = section.Item2;

                        AddHelpControl(name, desc);
                    }
                }

                catch
                {
                    throw;
                }
            }

            public void RightPanel()
            {
                try
                {

                    Size size1 = new Size(rightPanelWidth - 3, mainBasePanel.Height);
                    Size size2 = new Size(size1.Width - 8, size1.Height - 8);

                    Point location1 = new Point(leftPanelWidth + 6, 0);
                    Point location2 = new Point(4, 4);
                    Point location3 = new Point(0, 0);

                    Integrate.Panel(rightContentBasePanel, rightContentPanel, size2, location3, rightContentBackColor);
                    Integrate.Panel(rightBasePanel, rightContentBasePanel, size2, location2, rightPanelBackColor);
                    Integrate.Panel(mainBasePanel, rightBasePanel, size1, location1, rightPanelBackColor);

                    Size size = new Size(rightContentPanel.Width - 10, rightContentPanel.Height - 10);
                    Point location = new Point(5, 5);

                    Integrate.TextBox(rightContentPanel, rightContent, size, location,
                        rightContentBackColor, rightContentForeColor, "", 10, true, false, 0, true, true);

                    LoadHelpConfiguration();
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}