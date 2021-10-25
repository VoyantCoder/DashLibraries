
// Author: Dashie


using DashFramework.DashControls;
using DashFramework.ControlTools;
using DashFramework.Erroring;


namespace DashFramework
{
    namespace Forms
    {
        public partial class HelperGUI
        {
            readonly ControlIntegrator Integrate = new ControlIntegrator();
            readonly HandleError ErrorHandler = new HandleError();
            readonly Transformer Transform = new Transformer();
        }
    }
}