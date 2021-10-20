
// Author: Dashie


using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.DashControls.Controls;


namespace DashFramework
{
    namespace Forms
    {
        public partial class HelperGUI
        {
            readonly List<Button> leftHelpControls = new List<Button>();
            readonly List<Action> leftButtonHooks = new List<Action>();

            readonly DashPanel leftContentBasePanel = new DashPanel();
            readonly DashPanel leftContentPanel = new DashPanel();
            readonly DashPanel leftBasePanel = new DashPanel();

            public Color leftPanelEntryForeColor = Color.FromArgb(255, 255, 255);
            public Color leftPanelEntryBackColor = Color.FromArgb(110, 10, 38);//89, 28, 46);
            public Color leftPanelBackColor = Color.FromArgb(89, 4, 28);

            readonly Scroller Scroller = new Scroller();

            public int leftPanelEntryHeight = 28;
            public int leftPanelWidth = 175;
        }
    }
}