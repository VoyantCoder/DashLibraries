
// Author: Dashie


using System;
using System.Drawing;


namespace FlamefulAssembly
{
    namespace DashControls.Controls
    {
        public partial class RegularDropMenu
        {
            public bool MenuInstalled()
            {
                try
                {
                    return Settings.HasBaseInit;
                }

                catch
                {
                    return false;
                }
            }

            public void InstallSubMenu(Color BackColor = default(Color), Color ForeColor = default(Color), int ItemWidth = 100)
            {
                try
                {
                    if (!MenuInstalled())
                    {
                        return;
                    }


                }

                catch
                {
                    throw;
                }
            }

            public void InstallSubMenu(Color BackColor, Color ForeColor, Size ItemSize, params string[] ItemNames)
            {
                try
                {
                    if (!MenuInstalled())
                    {
                        return;
                    }

                    Integrator();
                }

                catch
                {
                    throw;
                }
            }

            public void InstallSubMenu(Color BackColor, Color ForeColor, Size ItemSize, params (string, Action)[] ItemSets)
            {
                try
                {
                    if (!MenuInstalled())
                    {
                        return;
                    }
                }

                catch
                {
                    throw;
                }
            }

            public void Integrator()
            {
                // (Control Parent, Point Location, Color BackColor = default(Color), Color ForeColor = default(Color), int ItemWidth = 100)
                // (Control Parent, Point Location, Color BackColor, Color ForeColor, Size ItemSize, params string[] ItemNames)
                // (Control Parent, Point Location, Color BackColor, Color ForeColor, Size ItemSize, params (string, Action)[] ItemSets)
            }
        }
    }
}