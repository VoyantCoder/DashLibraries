
// Author: Dashie


using System;
using System.Drawing;


namespace DashFramework
{
    namespace Forms
    {
        public partial class HelperGUI
        {
            public void HandleError(Exception E)
            {
                try
                {
                    ErrorHandler.Handle(E);
                }

                catch
                {
                    throw;
                }
            }
            
            public HelperGUI()
            {
                try
                {
                    WindowInst.Integrate(DashWindowPosition.Center, WindowSize, WindowBackColor, BorderBackColor, DoRoundSides, DashWindowRoundRadius.Slightly, MenubarBackColor, MenubarForeColor, MenubarIcon, WindowTitle);
                }

                catch (Exception E)
                {
                    HandleError(E);
                }
            }
        }
    }
}