
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;

using DashFramework.DashControls.Controls;


namespace DashFramework
{
    namespace Forms
    {
        public partial class HelperGUI
        {
            readonly DashPanel rightContentBasePanel = new DashPanel();
            readonly DashPanel rightContentPanel = new DashPanel();
            readonly DashPanel rightBasePanel = new DashPanel();
            readonly TextBox rightContent = new TextBox();

            public Color rightContentForeColor = Color.FromArgb(255, 255, 255);
            public Color rightContentBackColor = Color.FromArgb(51, 2, 16);
            public Color rightPanelBackColor = Color.FromArgb(51, 2, 16);

            public bool rightPanelDefaultContent = true;
            public int rightPanelDefaultContentId = 0;
            public int rightPanelWidth = 300;
        }
    }
}