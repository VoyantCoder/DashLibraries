
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;

using DashFramework.DashControls;
using DashFramework.DashResources;


namespace DashFramework
{
    namespace ControlTools.Simplifiers
    {
        public partial class Ashamedify
        {
            readonly ControlIntegrator Control = new ControlIntegrator();
            readonly ResourceTools ResourceTool = new ResourceTools();

            public Control TextBoxParent = new Control();
            public Control LabelParent = new Control();

            public Color TextBoxBCol = Color.FromArgb(28, 28, 28);
            public Color LabelBCol = Color.FromArgb(28, 28, 28);
            public Color TextBoxFCol = Color.White;
            public Color LabelFCol = Color.White;
        }
    }
}