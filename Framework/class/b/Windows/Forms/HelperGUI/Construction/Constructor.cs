
// Author: Dashie


using System;


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
                    WindowG();
                    BasePanel();
                    LeftPanel();
                    RightPanel();
                    Finalization();
                }

                catch (Exception E)
                {
                    HandleError(E);
                }
            }
        }
    }
}