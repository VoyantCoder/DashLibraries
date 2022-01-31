
// Author: Dashie


using System.Drawing;


namespace FlamefulAssembly
{
    namespace DashControls.Controls
    {
        public partial class Notification
        {
            public Size defaultSize = new Size(-1, 80);

            public bool autoResizeContainer = true;

            public int descriptionFontSize = 10;
            public int titleFontSize = 15;

            public Color backColor = Color.DarkRed;
            public Color foreColor = Color.White;
        }
    }
}