
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace DashControls.Controls
    {
        public partial class DashCheckBox
        {
            public void UpdateColor(Color[] CheckBox = null, Color[] MarkBox = null, bool UpdateNow = true, string Order = ("Unchecked, Checked, Default"))
            {
                try
                {
                    if (CheckBox != null && CheckBox.Length > 2)
                    {
                        CheckBoxUncheckedColor = CheckBox[0];
                        CheckBoxCheckedColor = CheckBox[1];
                        CheckBoxDefaultColor = CheckBox[2];

                        if (UpdateNow)
                        {
                            Panel2.BackColor = CheckBoxDefaultColor;
                        }
                    }

                    if (MarkBox != null && MarkBox.Length > 2)
                    {
                        MarkBoxUncheckedColor = MarkBox[0];
                        MarkBoxCheckedColor = MarkBox[1];
                        MarkBoxDefaultColor = MarkBox[2];

                        if (UpdateNow)
                        {
                            Panel1.BackColor = MarkBoxDefaultColor;
                        }
                    }
                }

                catch
                {
                    throw;
                }
            }

            public void UpdateSize(Size A, Size B)
            {
                try
                {
                    CheckBoxHeight = A.Height;
                    CheckBoxWidth = A.Width;

                    MarkBoxHeight = B.Height;
                    MarkBoxWidth = B.Width;

                    Transform.Resize(Panel1, A);
                    Transform.Resize(Panel2, B);

                    Panel2.Location = new Point
                    (
                        (Panel1.Width - Panel2.Width) / 2,
                        (Panel1.Height - Panel2.Height) / 2
                    );
                }

                catch
                {
                    throw;
                }
            }

            public void UpdateLocation(Point Location)
            {
                try
                {
                    if (!Panel1.Location.Equals(Location))
                    {
                        Panel1.Location = Location;
                    }
                }

                catch
                {
                    throw;
                }
            }

            public void AddCheckBox(Control Parent, Point Location, bool Round = false, int RoundRadius = 12)
            {
                Sort.Sort(("Containers"), () =>
                {
                    Size Panel1Size = new Size(CheckBoxWidth, CheckBoxHeight);
                    Size Panel2Size = new Size(MarkBoxWidth, MarkBoxHeight);
                    Point Panel2Loca = new Point(-1, -1);
                    Point Panel1Loca = Location;

                    Integrate.Panel(Parent, Panel1, Panel1Size, Panel1Loca, CheckBoxDefaultColor);
                    Integrate.Panel(Panel1, Panel2, Panel2Size, Panel2Loca, MarkBoxDefaultColor);

                    if (Round)
                    {
                        Transform.Round(Panel1, RoundRadius);
                        Transform.Round(Panel2, RoundRadius);
                    }
                });

                Sort.Sort(("Hook Handler Setup"), () =>
                {
                    void CheckBoxEvent()
                    {
                        try
                        {
                            if (Panel2.BackColor.Equals(MarkBoxCheckedColor))
                            {
                                Panel2.BackColor = MarkBoxUncheckedColor;
                                Panel1.BackColor = CheckBoxUncheckedColor;

                                OnCheck();
                            }

                            else
                            {
                                Panel2.BackColor = MarkBoxCheckedColor;
                                Panel1.BackColor = CheckBoxCheckedColor;

                                OnUncheck();
                            }
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    Panel1.Click += (s, e) => CheckBoxEvent();
                    Panel2.Click += (s, e) => CheckBoxEvent();
                });
            }
        }
    }
}