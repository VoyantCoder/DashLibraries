
// Author: Dashie


using System.Windows.Forms;

using DashFramework.ControlTools;
using DashFramework.Runnables;
using DashFramework.Sorters;
using DashFramework.Data;


namespace DashFramework
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