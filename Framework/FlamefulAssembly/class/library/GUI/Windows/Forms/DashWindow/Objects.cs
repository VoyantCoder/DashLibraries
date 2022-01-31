
// Author: Dashie


using FlamefulAssembly.ControlTools;
using FlamefulAssembly.Sorters;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FlamefulAssembly
{
    namespace Forms
    {
        public enum DashWindowPosition
        {
            Left, Right, Top, Bottom, Center, None
        }

        public enum DashWindowRoundRadius
        {
            Slightly, MoreSo, Extreme
        }

        public partial class DashWindow
        {
            readonly Dictionary<int, Control> ChildIdentifiers = new Dictionary<int, Control>();

            readonly GenericSorter Sort = new GenericSorter();
            readonly Transformer Transform = new Transformer();

            readonly MenuBar MenubarInstance = new MenuBar();
            readonly Form WindowInstance = new Form();

            public bool Initialized = false;
        }
    }
}