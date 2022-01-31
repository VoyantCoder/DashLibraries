
// Author: Dashie


using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace Forms
    {
        public partial class HelperGUI
        {
            public MenuBar Menubar
            {
                get
                {
                    return windowInst.Menubar;
                }
            }

            public DashWindow Window
            {
                get
                {
                    return windowInst;
                }
            }

            public Form Parent
            {
                get
                {
                    return windowInst.Instance;
                }
            }
        }
    }
}