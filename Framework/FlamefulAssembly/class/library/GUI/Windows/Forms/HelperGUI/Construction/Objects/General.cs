
// Author: Dashie


using FlamefulAssembly.ControlTools;
using FlamefulAssembly.DashControls;
using FlamefulAssembly.Erroring;


namespace FlamefulAssembly
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