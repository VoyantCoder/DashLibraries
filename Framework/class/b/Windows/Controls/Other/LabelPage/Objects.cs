
// Author: Dashie


using System.Windows.Forms;

using DashFramework.DashResources;
using DashFramework.ControlTools;


namespace DashFramework
{
    namespace DashControls.Controls
    {
	public partial class LabelPage
	{
	    readonly ControlIntegrator Control = new ControlIntegrator();
	    readonly ResourceTools ResourceTool = new ResourceTools();
	    readonly Transformer Transform = new Transformer();
	    readonly DataTools DataTool = new DataTools();

	    readonly PictureBox S1Container1 = new PictureBox();
	    readonly PictureBox S2Container1 = new PictureBox();
	    readonly PictureBox S3Container1 = new PictureBox();
	    readonly PictureBox S3Container2 = new PictureBox();
	    readonly PictureBox S4Container1 = new PictureBox();

	    readonly Button S3Button1 = new Button();
	    readonly Button S3Button2 = new Button();

	    readonly Label S2Label1 = new Label();
	    readonly Label S2Label2 = new Label();
	    readonly Label S3Label1 = new Label();
	    readonly Label S4Label1 = new Label();

	    int S2PageID = 1;
	    int S2Pages = 0;
	}
    }
}