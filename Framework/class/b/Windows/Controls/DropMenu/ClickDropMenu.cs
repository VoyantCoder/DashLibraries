// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.ControlTools;
using DashFramework.Sorters;


namespace DashFramework
{
    namespace DashControls
    {
	namespace Customs
	{
	    public class ClickDropMenu
	    {
		public class DropItem { public readonly Label Item = new Label(); } /*class for future multi-use*/

		readonly ControlIntegrator Controls = new ControlIntegrator();
		readonly Transformer Transform = new Transformer();
		readonly PlainSorters Sorter = new PlainSorters();

		public Color ItemBackColor = Color.FromArgb(5, 23, 31);
		public Color ItemForeColor = Color.White;

		public bool ItemCenterText = true;

		public int ItemFontSize = 12;
		public int ItemHeight = 24;
		public int ItemWidth = 100;
		public int ItemFontId = 1;

		public int GetItemTop(int Id = -19)
		{
		    try
		    {
			if (Id == -19)
			{
			    if (ItemStack.Count < 1)
			    {
				return 0;
			    }

			    Id = ItemStack.Count - 1;
			}

			else
			{
			    if (ItemStack.Count <= Id)
			    {
				return 0;
			    }
			}

			return (ItemStack[Id].Item.Height + ItemStack[Id].Item.Top);
		    }

		    catch
		    {
			return -1;
		    }
		}

		public void InsertItem(DropItem item, string name)
		{
		    Sorter.SortCode(("Insert item into Container"), () =>
		    {
			try
			{
			    Size ItemSize = new Size(ItemWidth, ItemHeight);
			    Point ItemLoca = new Point(0, GetItemTop());

			    Controls.Label(LowerContainer, item.Item, ItemSize, ItemLoca,
				ItemBackColor, ItemForeColor, (name), ItemFontId, ItemFontSize);

			    if (ItemCenterText)
			    {
				item.Item.TextAlign = ContentAlignment.MiddleCenter;
			    }

			    ItemStack.Add(item);
			}

			catch
			{
			    return;
			}
		    });

		    Sorter.SortCode(("Adjust Size"), () =>
		    {
			try
			{
			    UpdateContainerSizes();
			}

			catch
			{
			    return;
			}
		    });
		}

		public void AddItem(params string[] names)
		{
		    Sorter.SortCode(("Add items to Container"), () =>
		    {
			try
			{
			    DropItem GetItem() => new DropItem();

			    for (int k = 0; k < names.Length; k += 1)
			    {
				InsertItem(GetItem(), names[k].Replace(Environment.NewLine, ""));
			    }
			}

			catch
			{
			    return;
			}
		    });
		}


		public readonly List<DropItem> ItemStack = new List<DropItem>();
		public List<DropItem> GetItemStack() => ItemStack;

		public bool ItemExists(int Id = -1)
		{
		    try
		    {
			if (Id != -19 && ItemStack.Count <= Id)
			{
			    return false;
			}

			else if (Id == -19 && ItemStack.Count < 1)
			{
			    return false;
			}

			return (ItemStack.Count - 1 > -1);
		    }

		    catch
		    {
			return false;
		    }
		}

		public void UpdateItemLocations()
		{
		    try
		    {
			for (int k = 0, y = 0; k < LowerContainer.Controls.Count; k += 1, y += ItemHeight)
			{
			    LowerContainer.Controls[k].Top = y;
			}
		    }

		    catch
		    {
			return;
		    }
		}

		public bool RemoveItem(int Id = -19)
		{
		    try
		    {
			if (!ItemExists())
			{
			    return false;
			}

			LowerContainer.Controls.RemoveAt(Id);
			ItemStack.RemoveAt(Id);

			UpdateContainerSizes();
			UpdateItemLocations();

			return true;
		    }

		    catch
		    {
			return false;
		    }
		}

		public bool RenameItem(string newName, int Id = -19)
		{
		    try
		    {
			if (!ItemExists())
			{
			    return false;
			}

			ItemStack[Id].Item.Text = newName;

			return true;
		    }

		    catch
		    {
			return false;
		    }
		}


		public DashPanel UpperContainer = new DashPanel() { Visible = false };
		public DashPanel LowerContainer = new DashPanel() { Visible = true };

		public bool UpdateContainerSizes()
		{
		    try
		    {
			Size UpperSize = Size.Empty;
			Size LowerSize = Size.Empty;

			if (ItemStack.Count > 0)
			{
			    LowerSize = new Size(ItemWidth - 4, ItemHeight - 10);
			    UpperSize = new Size(ItemWidth, ItemHeight);
			}

			else
			    goto skip;

			Label Item = ItemStack[ItemStack.Count - 1].Item;

			if (Item.Height + Item.Top > LowerContainer.Height)
			{
			    LowerSize = new Size(LowerContainer.Width, Item.Height + Item.Top);
			    UpperSize = new Size(UpperContainer.Width, Item.Height + Item.Top);
			}

		    skip:
			if (UpperSize != Size.Empty && LowerSize != Size.Empty)
			{
			    LowerSize.Height -= 2;
			    UpperSize.Height += 8;

			    Transform.Resize(UpperContainer, UpperSize);
			    Transform.Resize(LowerContainer, LowerSize);
			}

			return true;
		    }

		    catch
		    {
			return false;
		    }
		}


		public Control ContainerParent = new Control();

		public void AddTo(Control ContainerParent, Point ContainerLoca, Color UpperBCol, Color LowerBCol)
		{
		    Sorter.SortCode(("Container Insertions"), () =>
		    {
			try
			{
			    Size UpperContainerSize = new Size(ItemWidth, ItemHeight);
			    Size LowerContainerSize = new Size(ItemWidth - 4, ItemHeight - 10);
			    Point LowerContainerLoca = new Point(2, 5);

			    Controls.Panel(UpperContainer, LowerContainer, LowerContainerSize, LowerContainerLoca, LowerBCol);
			    Controls.Panel(ContainerParent, UpperContainer, UpperContainerSize, ContainerLoca, UpperBCol);

			    this.ContainerParent = ContainerParent;
			}

			catch
			{
			    return;
			}
		    });
		}


		public void AddTrigger(Control Trigger, bool Hider = true)
		{
		    if (Hider && (Trigger == UpperContainer || Trigger == LowerContainer
			|| LowerContainer.Controls.Contains(Trigger))) return;

		    Trigger.MouseEnter += (s, e) =>
		    {
			UpperContainer.Visible = !Hider;
			if (!Hider) UpperContainer.BringToFront();
		    };
		}


		public void RegisterVisibilityTrigger(Control ShowTrigger, params Control[] HideTrigger)
		{
		    try
		    {
			Sorter.SortCode(("Hide Trigger Setup"), () =>
			{
			    foreach (Control ParentA in HideTrigger)
			    {
				AddTrigger(ParentA);

				foreach (Control ParentB in ParentA.Controls)
				{
				    AddTrigger(ParentB);

				    foreach (Control ParentC in ParentB.Controls)
				    {
					AddTrigger(ParentC);

					foreach (Control ParentD in ParentC.Controls)
					{
					    AddTrigger(ParentD);
					}
				    }
				}
			    }
			});

			Sorter.SortCode(("Show Trigger Setup"), () =>
			{
			    AddTrigger(ShowTrigger, false);
			});
		    }

		    catch
		    {
			return;
		    }
		}


		public void RegisterUpdateColor(Color onHover, Color onMouseDown, Color onClick)
		{
		    try
		    {
			foreach (Label item in LowerContainer.Controls)
			{
			    item.MouseLeave += (s, e) => item.BackColor = ItemBackColor;
			    item.MouseDown += (s, e) => item.BackColor = onMouseDown;
			    item.MouseEnter += (s, e) => item.BackColor = onHover;
			    item.MouseClick += (s, e) => item.BackColor = onClick;
			    item.MouseUp += (s, e) => item.BackColor = onHover;
			}
		    }

		    catch
		    {
			return;
		    }
		}


		public void LinkTriggerBackColorToMenu(Control Trigger, Color OriginalColor)
		{
		    try
		    {
			UpperContainer.VisibleChanged += (s, e) =>
			{
			    if (UpperContainer.Visible)
			    {
				Trigger.BackColor = UpperContainer.BackColor;
			    }

			    else
			    {
				Trigger.BackColor = OriginalColor;
			    }
			};
		    }

		    catch
		    {
			return;
		    }
		}


		public delegate void RunHook();

		public bool SetMouseClickHook(int Id, RunHook Run)
		{
		    try
		    {
			if (!ItemExists(Id))
			{
			    return false;
			}

			ItemStack[Id].Item.Click += (s, e) =>
			{
			    try
			    {
				Run();
			    }

			    catch
			    {
				return;
			    }
			};

			return true;
		    }

		    catch
		    {
			return false;
		    }
		}
	    }
	}
    }
}