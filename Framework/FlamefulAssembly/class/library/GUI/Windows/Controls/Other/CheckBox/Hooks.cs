
// Author: Dashie


using System;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace DashControls.Controls
    {
        public partial class DashCheckBox
        {
            static void DefaultRunnable()
            {
                MessageBox.Show("Standard Runnable Message for CheckBox", "Standard Message");
            }

            public Action OnUncheck = DefaultRunnable;
            public Action OnCheck = DefaultRunnable;

            public void SetOnUncheck(Action code)
            {
                OnUncheck = code;
            }

            public void SetOncheck(Action code)
            {
                OnCheck = code;
            }
        }
    }
}