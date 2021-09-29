
// Author: Dashie


using System.Drawing;


namespace DashFramework
{
    namespace Forms
    {
	public partial class DashWindow
	{
	    public MenuBar Menubar()
	    {
		try
		{
		    if (MenubarInstance.HasMenubarBeenAdded())
		    {
			return MenubarInstance;
		    }

		    return null;
		}

		catch
		{
		    throw;
		}
	    }

	    public void DrawWindowBorder(Color Color, int Thickness)
	    {
		try
		{
		    Size Size = new Size(WindowInstance.Width - (Thickness - 1), WindowInstance.Height - (Thickness - 1));
		    Point Location = new Point(0, 0);

		    if (Menubar() != null)
		    {
			Location.Y = Menubar().GetMenubarSize().Height + Menubar().GetMenubarLocation().Y;
		    }

		    Transform.PaintRectangle(WindowInstance, Thickness, Size, Location, Color);
		}

		catch
		{
		    throw;
		}
	    }

	    public void Integrate(DashWindowPosition Position, Size Size, Color BackColor, Color BorderColor, bool DisableWindowsBorder = true)
	    {
		try
		{
		    Integrate(Position, Size, BackColor, DisableWindowsBorder);
	
		    if (BorderColor != null || BorderColor == Color.Empty)
		    {
			DrawWindowBorder(BorderColor, 2);
		    }
		}

		catch
		{
		    throw;
		}
	    }
	}
    }
}