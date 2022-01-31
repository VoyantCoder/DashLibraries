
// Author: Dashie


using FlamefulAssembly.ControlTools;
using FlamefulAssembly.Data;
using FlamefulAssembly.Runnables;
using FlamefulAssembly.Sorters;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace DashControls.Controls
    {
        public partial class Notification
        {
            readonly ControlIntegrator Integrator = new ControlIntegrator();
            readonly Transformer Transform = new Transformer();
            readonly GenericSorter Sort = new GenericSorter();
            readonly DataTools DataTool = new DataTools();
            readonly Runnable Run = new Runnable();

            readonly Label Label1 = new Label();
            readonly Label Label2 = new Label();
            readonly DashPanel Panel1 = new DashPanel();
        }
    }
}