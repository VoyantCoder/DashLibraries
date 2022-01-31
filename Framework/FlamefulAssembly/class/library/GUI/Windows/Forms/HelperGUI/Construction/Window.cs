
// Author: Dashie


namespace FlamefulAssembly
{
    namespace Forms
    {
        public partial class HelperGUI
        {
            public void WindowG()
            {
                try
                {
                    windowInst.Integrate(DashWindowPosition.Center, windowSize, windowBackColor, borderBackColor, doRoundSides, DashWindowRoundRadius.Slightly, menubarBackColor, menubarForeColor, menubarIcon, windowTitle);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}