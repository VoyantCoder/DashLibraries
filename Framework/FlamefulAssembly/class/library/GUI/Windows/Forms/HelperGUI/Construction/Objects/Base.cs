
// Author: Dashie


using FlamefulAssembly.DashControls.Controls;
using System.Drawing;


namespace FlamefulAssembly
{
    namespace Forms
    {
        public partial class HelperGUI
        {
            readonly DashWindow windowInst = new DashWindow();
            readonly DashPanel mainBasePanel = new DashPanel();

            public Color windowBackColor = Color.FromArgb(89, 4, 28);
            public Color borderBackColor = Color.FromArgb(51, 2, 16);
            public Color menubarBackColor = Color.FromArgb(51, 2, 16);//89, 4, 28);
            public Color menubarForeColor = Color.White;

            public Image menubarIcon = resources.Resources.LOGO;
            public Size windowSize = new Size(500, 350);

            public string windowTitle = "Helper Dialog";
            public bool sizeToButtons = false;
            public bool doRoundSides = true;
        }
    }
}