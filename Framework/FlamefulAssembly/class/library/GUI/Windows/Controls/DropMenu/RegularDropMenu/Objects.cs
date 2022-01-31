
// Author: Dashie


using FlamefulAssembly.ControlTools;
using FlamefulAssembly.Sorters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace DashControls.Controls
    {
        public partial class RegularDropMenu
        {
            public readonly List<(FancyItem, Action)> AddedItems = new List<(FancyItem, Action)>();

            public class FancyItem
            {
                public DashPanel LicensePlate = new DashPanel();
                public Label License = new Label();
            }

            public readonly DashPanel Panel1 = new DashPanel();
            public readonly DashPanel Panel2 = new DashPanel();

            public struct Settings
            {
                public static bool HasCheckBoxInit;
                public static bool HasItemInit;
                public static bool HasBaseInit;

                public static void ToggleInit(int id, string info = "1,2,3")
                {
                    try
                    {
                        switch (id)
                        {
                            case 3:
                            {
                                HasCheckBoxInit = true;
                                break;
                            }
                            case 1:
                            {
                                HasBaseInit = true;
                                break;
                            }
                            case 2:
                            {
                                HasItemInit = true;
                                break;
                            }
                        }
                    }

                    catch
                    {
                        throw;
                    }
                }

                public static bool GetStatus(int id)
                {
                    try
                    {
                        switch (id)
                        {
                            case 3: return HasCheckBoxInit;
                            case 1: return HasBaseInit;
                            case 2: return HasItemInit;
                        }

                        return false;
                    }

                    catch
                    {
                        throw;
                    }
                }

                public static Color ForeColor;
                public static Color BackColor;

                public static int ItemHeight;
                public static int ItemWidth;

                public static int FontSize = 10;
                public static int FontId = 1;
            }

            readonly ControlIntegrator Integrate = new ControlIntegrator();
            readonly Transformer Transform = new Transformer();
            readonly GenericSorter Sort = new GenericSorter();
        }
    }
}