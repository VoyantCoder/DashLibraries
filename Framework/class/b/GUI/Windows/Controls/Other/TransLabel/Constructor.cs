
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace DashControls.Controls
    {
        public partial class TransLabel
        {
            public TransLabel()
            {
                try
                {
                    SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                    SetStyle(ControlStyles.Opaque, true);
                    BackColor = Color.Transparent;
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}