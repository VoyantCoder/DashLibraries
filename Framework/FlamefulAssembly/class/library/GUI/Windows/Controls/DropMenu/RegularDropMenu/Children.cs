
// Author: Dashie


using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace DashControls.Controls
    {
        public partial class RegularDropMenu
        {
            public Point NextLicensePlateLocation()
            {
                try
                {
                    Point Location = new Point(0, 0);

                    if (AddedItems.Count > 0)
                    {
                        var LicensePlateId = AddedItems.Count - 1;
                        var LicensePlate = AddedItems[LicensePlateId].Item1.LicensePlate;

                        Location = new Point(0, LicensePlate.Top + LicensePlate.Height);
                    }

                    return Location;
                }

                catch
                {
                    return Point.Empty;
                }
            }

            public Size LicensePlateSize()
            {
                try
                {
                    return new Size(Settings.ItemWidth,
                    Settings.ItemHeight);
                }

                catch
                {
                    return Size.Empty;
                }
            }

            public bool RegisterItemContainer()
            {
                try
                {
                    Size Size = new Size(Settings.ItemWidth, 6);
                    Point Location = new Point(2, 2);
                    Color BackColor = Settings.BackColor;

                    Integrate.Panel(Panel1, Panel2, Size, Location, BackColor);
                }

                catch
                {
                    return false;
                }

                return true;
            }

            public void UpdateContainerSizes()
            {
                try
                {
                    int Height = NextLicensePlateLocation().Y;
                    int Width = Settings.ItemWidth;

                    Size Size1 = new Size(Width + 4, Height + 4);
                    Size Size2 = new Size(Width, Height);

                    Transform.Resize(Panel1, Size1);
                    Transform.Resize(Panel2, Size2);
                }

                catch
                {
                    throw;
                }
            }

            public bool AddItem(string Name, Action Code)
            {
                try
                {
                    Exception False = new Exception("!");

                    if (!Sort.BSort(("Oh, yes"), () =>
                    {
                        if (!Settings.GetStatus(1))
                        {
                            throw False;
                        }

                        else
                        {
                            if (!Settings.GetStatus(2))
                            {
                                if (!RegisterItemContainer())
                                {
                                    throw False;
                                }

                                Settings.ToggleInit(2);
                            }
                        }
                    })) return false;

                    FancyItem MrFancyItem = new FancyItem();

                    Sort.Sort(("License Plate"), () =>
                    {
                        Point Location = NextLicensePlateLocation();
                        Color BackColor = Settings.BackColor;
                        Size Size = LicensePlateSize();

                        Integrate.Panel(Panel2, MrFancyItem.LicensePlate, Size, Location, BackColor);
                    });

                    Sort.Sort(("License"), () =>
                    {
                        Color BackColor = Settings.BackColor;
                        Color ForeColor = Settings.ForeColor;
                        Point Location = new Point(-1, -1);

                        int FontSize = Settings.FontSize;
                        int FontId = Settings.FontId;

                        Integrate.Label(MrFancyItem.LicensePlate, MrFancyItem.License, Size.Empty, Location, BackColor, ForeColor, FontSize, Name);
                        AddedItems.Add((MrFancyItem, Code));
                    });

                    UpdateContainerSizes();
                }

                catch
                {
                    return false;
                }

                return true;
            }

            public bool Integrator(Control Parent, Point Location, Color BackColor, Color ForeColor, Size ItemSize, params string[] ItemNames)
            {
                try
                {
                    if (!Integrator(Parent, Location, BackColor, ForeColor, ItemSize.Width))
                    {
                        return false;
                    }

                    void DefaultRunnable()
                    {
                        /*#include <iostream>
							using namespace std;

						int main(void)
						{
							std::cout << "Can you believe that?" << std::endl;
							std::cout << "I cannot, lol." << std::endl;
							std::cout << "fun fact, C++ is my first language." << std::endl;
							// ^^^ Errors
							cout << "so yea, it is quite fun....\n";
							cout << "I find it unnecessary to setup a standard method.\n";
							cout << "So I do not ;)\n";

							return -1;
						}*/
                    }

                    Settings.ItemHeight = ItemSize.Height;
                    Settings.ItemWidth = ItemSize.Width;

                    foreach (string ItemName in ItemNames)
                    {
                        AddItem(ItemName, DefaultRunnable);
                    }
                }

                catch
                {
                    return false;
                }

                return true;
            }

            public FancyItem GetLatestItem()
            {
                try
                {
                    FancyItem Item = null;

                    if (AddedItems.Count > 0)
                    {
                        Item = AddedItems[AddedItems.Count - 1].Item1;
                    }

                    return Item;
                }

                catch
                {
                    return null;
                }
            }

            public void RegisterClickCode(FancyItem Item, Action Code)
            {
                try
                {
                    void Register(Control Control)
                    {
                        Control.Click += (s, e) =>
                        {
                            Code();
                        };
                    }

                    Register(Item.LicensePlate);
                    Register(Item.License);
                }

                catch
                {
                    throw;
                }
            }

            public bool Integrator(Control Parent, Point Location, Color BackColor, Color ForeColor, Size ItemSize, params (string, Action)[] ItemSets)
            {
                try
                {
                    string[] ItemNames = ItemSets.ToList().ConvertAll(a => a.Item1).ToArray();

                    if (!Integrator(Parent, Location, BackColor, ForeColor, ItemSize, ItemNames))
                    {
                        return false;
                    }

                    for (int k = 0; k < ItemSets.Length; k += 1)
                    {
                        FancyItem Object = AddedItems[k].Item1;
                        Action Code = ItemSets[k].Item2;

                        RegisterClickCode(Object, Code);
                    }

                    foreach (var ItemSet in AddedItems)
                    {
                        RegisterClickCode(ItemSet.Item1, ItemSet.Item2);
                    }

                    Settings.ItemHeight = ItemSize.Height;
                    Settings.ItemWidth = ItemSize.Width;
                }

                catch
                {
                    return false;
                }

                return true;
            }
        }
    }
}