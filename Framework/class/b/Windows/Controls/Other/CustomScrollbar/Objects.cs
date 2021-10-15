
// Author: Dashie


using System.Windows.Forms;

using DashFramework.ControlTools.Algorithms;


namespace DashFramework
{
    namespace DashControls.Controls
    {
        public partial class CustomScrollbar
        {
            public bool HasBeenSetup()
            {
                return (ContentContainer != null
                    && Children != null && Parent != null);
            }

            public Control.ControlCollection Children;
            public Control ContentContainer;
            public Control Parent;

            public Control.ControlCollection GetCollection()
            {
                return Children;
            }

            public Control GetContentContainer()
            {
                return ContentContainer;
            }

            public Control GetParent()
            {
                return Parent;
            }

            public int ContentContainerIncrement = 50;
            public int MinimumHeight = 304;

            readonly OutsmartLoops Loopsies = new OutsmartLoops();
        }
    }
}