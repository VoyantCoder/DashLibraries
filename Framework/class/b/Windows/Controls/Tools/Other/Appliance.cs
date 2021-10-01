
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace ControlTools
    {
	public class Appliance
	{
	    public void MakeDraggable(Control Object, Control Target)
	    {
		var Location = Point.Empty;
		
		Object.MouseMove += (s, e) =>
		{
		    if (Location.IsEmpty)
		    {
			return;
		    }

		    Target.Location = new Point(Target.Location.X + (e.X - Location.X),
			Target.Location.Y + (e.Y - Location.Y));
		};

		Object.MouseDown += (s, e) =>
		{
		    Location = new Point(e.X, e.Y);
		};

		Object.MouseUp += (s, e) =>
		{
		    Location = Point.Empty;
		};
	    }
	}
    }
}