
// Author: Dashie


using System;
using System.Drawing;
using System.Windows.Forms;

using DashFramework.DashControls.Controls;


namespace DashFramework
{
    namespace DashControls
    {
        public partial class ControlIntegrator
        {
            public DashCheckBox CheckBox(Control parent, Size size, Point location)
            {
                DashCheckBox checkBox = new DashCheckBox();

                try
                {
                    checkBox.AddCheckBox(parent, location, false, 0);
                    Size size2 = new Size(size.Width - 8, size.Height - 8);
                    checkBox.UpdateSize(size, size2);
                    Register(parent, checkBox);
                }

                catch
                {
                    throw;
                }

                return checkBox;
            }

            public DashCheckBox CheckBox(Control parent, Size size, Point location, Color backColor1, Color backColor2)
            {
                DashCheckBox checkBox = default(DashCheckBox);

                try
                {
                    checkBox = CheckBox(parent, size, location);
                    checkBox.CheckBoxOutter().BackColor = backColor1;
                    checkBox.CheckBoxInner().BackColor = backColor2;
                    checkBox.CheckBoxDefaultColor = backColor1;
                    checkBox.MarkBoxDefaultColor = backColor2;
                    Register(parent, checkBox);
                }

                catch
                {
                    throw;
                }

                return checkBox;
            }

            public DashCheckBox CheckBox(Control parent, Size size, Point location, Color backColor1, Color backColor2, Color clickColor1, Color clickColor2)
            {
                DashCheckBox checkBox = default(DashCheckBox);

                try
                {
                    checkBox = CheckBox(parent, size, location, backColor1, backColor2);
                    checkBox.CheckBoxCheckedColor = clickColor1;
                    checkBox.MarkBoxCheckedColor = clickColor2;
                    checkBox.CheckBoxDefaultColor = backColor1;
                    checkBox.MarkBoxDefaultColor = backColor2;
                    Register(parent, checkBox);
                }

                catch
                {
                    throw;
                }

                return checkBox;
            }

            public DashCheckBox CheckBox(Control parent, Size size, Point location, Color backColor1, Color backColor2, Color clickColor1, Color clickColor2, bool round)
            {
                DashCheckBox checkBox = default(DashCheckBox);

                try
                {
                    checkBox = CheckBox(parent, size, location, backColor1, backColor2, clickColor1, clickColor2);

                    if (round)
                    {
                        Transform.Round(checkBox.CheckBoxOutter(), 12);
                    }

                    Register(parent, checkBox);
                }

                catch
                {
                    throw;
                }

                return checkBox;
            }

            public DashCheckBox CheckBox(Control parent, Size size, Point location, Color backColor1, Color backColor2, Color clickColor1, Color clickColor2, bool round, Action onCheck, Action onUncheck)
            {
                DashCheckBox checkBox = default(DashCheckBox);

                try
                {
                    checkBox = CheckBox(parent, size, location, backColor1, backColor2, clickColor1, clickColor2, round);
                    checkBox.OnUncheck = onUncheck;
                    checkBox.OnCheck = onCheck;
                    Register(parent, checkBox);
                }

                catch
                {
                    throw;
                }

                return checkBox;
            }
        }
    }
}