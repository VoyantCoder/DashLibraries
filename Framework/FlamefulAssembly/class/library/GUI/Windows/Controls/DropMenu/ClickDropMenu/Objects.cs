
// Author: Dashie


using FlamefulAssembly.ControlTools;
using FlamefulAssembly.ControlTools.Algorithms;
using FlamefulAssembly.Sorters;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace DashControls.Controls
    {
        public partial class ClickDropMenu
        {
            public readonly List<DropItem> ItemStack = new List<DropItem>();

            public class DropItem
            {
                public readonly Label Item = new Label();

            }

            public List<DropItem> GetItemStack()
            {
                return ItemStack;
            }

            public Color ItemBackColor = Color.FromArgb(5, 23, 31);
            public Color ItemForeColor = Color.White;

            public DashPanel UpperContainer = new DashPanel();
            public DashPanel LowerContainer = new DashPanel();
            public Control ContainerParent = new Control();

            public int ItemFontSize = 12, ItemHeight = 24;
            public int ItemWidth = 100, ItemFontId = 1;
            public bool ItemCenterText = true;

            public ClickDropMenu()
            {
                UpperContainer.Visible = false;
            }

            readonly ControlIntegrator Controls = new ControlIntegrator();
            readonly OutsmartLoops Loopsies = new OutsmartLoops();
            readonly Transformer Transform = new Transformer();
            readonly GenericSorter Sort = new GenericSorter();
        }
    }
}