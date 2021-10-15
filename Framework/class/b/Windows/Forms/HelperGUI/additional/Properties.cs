
// Author: Dashie


namespace DashFramework
{
    namespace Forms
    {
        public partial class HelperGUI
        {
            public MenuBar Menubar
            {
                get
                {
                    return WindowInst.Menubar();
                }
            }

            public DashWindow Window
            {
                get
                {
                    return WindowInst;
                }
            }

            public Form Parent
            {
                get
                {
                    return WindowInst.Instance;
                }
            }
        }
    }
}