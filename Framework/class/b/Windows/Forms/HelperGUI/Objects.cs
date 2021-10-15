
// Author: Dashie


using System.Drawing;

using DashFramework.Forms;
using DashFramework.Erroring;


namespace DashFramework
{
    namespace Forms
    {
        public partial class HelperGUI
        {//helper objects
            readonly HandleError ErrorHandler = new HandleError();
            readonly DashWindow WindowInst = new DashWindow();

        }

        public partial class HelperGUI
        {//settings
            public Color WindowBackColor = Color.FromArgb(30, 30, 30);
            public Color BorderBackColor = Color.FromArgb(8, 8, 8);
            public Color MenubarBackColor = Color.FromArgb(8, 8, 8);
            public Color MenubarForeColor = Color.White;
            public Size WindowSize = new Size(400, 350);
            public Image MenubarIcon = resources.Resources.LOGO;
            public bool DoRoundSides = true;
            public string WindowTitle = "Helper Dialog";
        }
    }
}