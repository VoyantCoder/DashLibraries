
// Author: Dashie


using System;
using System.Drawing;


namespace FlamefulAssembly
{
    namespace Erroring
    {
        public enum HandlerDialogColor
        {
            Window, Menubar, Content
        }

        public partial class HandleError
        {
            Action onProceed = () => Environment.Exit(-1);

            //set methods for action.
        }
    }
}