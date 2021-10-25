
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.Drawing;
using System.Windows.Forms;

using DashFramework.DashResources;
using DashFramework.ControlTools;
using DashFramework.Erroring;


namespace DashFramework
{
    namespace DashControls.Controls
    {
        public partial class LabelPage
        {
            private void Init1(PictureBox Capsule, Size ContainerSize, Point ContainerLoca)
            {
                try
                {
                    Control.PictureBox(Capsule, S1Container1, ContainerLoca, null, Color.MidnightBlue, ContainerSize);
                    Transform.Round(S1Container1, 6);
                }

                catch
                {
                    throw;
                }
            }

            private void SetPageCount(string PageData, Size ConSize)
            {
                try
                {
                    S2Pages = (TextRenderer.MeasureText
                    (
                        PageData, ResourceTool.GetFont(1, 9), new Size(ConSize.Width, 800),
                        flags: TextFormatFlags.WordBreak // ^ USE WORDWRAP U STOOPID
                    )

                    .Height / ConSize.Height) + 1;
                }

                catch
                {
                    throw;
                }
            }


            private void Init2(string PageData, Size ConSize)
            {
                try
                {
                    var ContainerSize = new Size(S1Container1.Width, 24);
                    var ContainerLoca = new Point(0, 0);

                    Control.PictureBox(S1Container1, S2Container1, ContainerLoca, null, Color.MidnightBlue, ContainerSize);

                    SetPageCount(PageData, ConSize);

                    var Label1Size = DataTool.GetFontSize("Page:", 9);
                    var Label2Size = DataTool.GetFontSize($"1/{S2Pages} ", 9);

                    var Label1Loca = new Point((S2Container1.Width - (Label1Size.Width + Label2Size.Width)) / 2, (S2Container1.Height - Label1Size.Height) / 2);
                    var Label2Loca = new Point(Label1Loca.X + Label1Size.Width, Label1Loca.Y);

                    Control.Label(S2Container1, S2Label2, Label2Size, Label2Loca, S2Container1.BackColor, Color.White, 9, ($"1/{S2Pages}"));
                    Control.Label(S2Container1, S2Label1, Label1Size, Label1Loca, S2Container1.BackColor, Color.White, 9, ("Page:"));
                }

                catch
                {
                    throw;
                }
            }

            private void S3ChangePage(bool Forward)
            {
                try
                {
                    if (Forward)
                    {
                        if (S2PageID >= S2Pages)
                        {
                            return;
                        }

                        S4Label1.Top -= S4Container1.Height;
                        S2PageID += 1;
                    }

                    else
                    {
                        if (S2PageID < 2)
                        {
                            return;
                        }

                        S4Label1.Top += S4Container1.Height;
                        S2PageID -= 1;
                    }

                    S2Label2.Text = $"{S2PageID}" + S2Label2.Text.Substring(1, 2);
                }

                catch
                {
                    throw;
                }
            }

            private void Init3(string Title)
            {
                try
                {
                    var Container1Size = new Size(S2Container1.Width, 30);
                    var Container1Loca = new Point(0, S1Container1.Height - 30);

                    var Container2Size = new Size(95, 26);
                    var Container2Loca = new Point(Container1Size.Width - 105, 1);

                    var ContainerBCol = S2Container1.BackColor;

                    Control.PictureBox(S1Container1, S3Container1, Container1Loca, null, ContainerBCol, Container1Size);
                    Control.PictureBox(S3Container1, S3Container2, Container2Loca, null, ContainerBCol, Container2Size);

                    var LabelText = ($"{Title}");
                    var LabelSize = DataTool.GetFontSize(LabelText, 9);
                    var LabelLoca = new Point(10, (S3Container1.Height - LabelSize.Height) / 2);

                    Control.Label(S3Container1, S3Label1, LabelSize, LabelLoca, ContainerBCol, Color.White, 9, LabelText);

                    var Button2Loca = new Point(50, 0);
                    var Button1Loca = new Point(0, 0);

                    var ButtonSize = new Size(45, 26);

                    Control.Button(S3Container2, S3Button1, ButtonSize, Button1Loca, 9, ("<"), ContainerBCol, Color.White);
                    Control.Button(S3Container2, S3Button2, ButtonSize, Button2Loca, 9, (">"), ContainerBCol, Color.White);

                    S3Button1.Click += (s, e) => S3ChangePage(false);
                    S3Button2.Click += (s, e) => S3ChangePage(true);

                    Transform.Round(S3Button1, 6);
                    Transform.Round(S3Button2, 6);
                }

                catch
                {
                    throw;
                }
            }

            private void Init4(string Message, Color LabelBCol, Color LabelFCol)
            {
                try
                {
                    var ContainerSize = new Size(S1Container1.Width - 5, S1Container1.Height - S3Container1.Height - S2Container1.Height - 4);
                    var ContainerLoca = new Point(3, S2Container1.Height + 2);
                    var ContainerBCol = LabelBCol;

                    Control.PictureBox(S1Container1, S4Container1, ContainerLoca, null, ContainerBCol, ContainerSize);

                    var LabelText = Message;
                    var LabelFSiz = TextRenderer.MeasureText(LabelText, ResourceTool.GetFont(1, 9), Size.Empty, flags: TextFormatFlags.WordBreak);
                    var LabelSize = new Size(ContainerSize.Width - 4, LabelFSiz.Height - 4);
                    var LabelLoca = new Point(2, 2);

                    Control.Label(S4Container1, S4Label1, LabelSize, LabelLoca, LabelBCol, LabelFCol, 9, LabelText);
                }

                catch
                {
                    throw;
                }
            }


            public void SetupPages(PictureBox Capsule, Tuple<string, Size, Point> ContainerSetup, Tuple<Color, Color, string> LabelSetup)
            {
                try
                {
                    Init1(Capsule, ContainerSetup.Item2, ContainerSetup.Item3);
                    Init2(LabelSetup.Item3, ContainerSetup.Item2);
                    Init3(ContainerSetup.Item1);
                    Init4(LabelSetup.Item3, LabelSetup.Item1, LabelSetup.Item2);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}