
// Author: Dashie


using FlamefulAssembly.DashDialogs;


namespace FlamefulAssembly
{
    namespace Erroring
    {
        public partial class HandleError
        {
            readonly SimpleDialog dialog = new SimpleDialog("Error Handler");

            public void Initialize()
            {
                try
                {
                    dialog.SetButtonText("Close Session");
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}