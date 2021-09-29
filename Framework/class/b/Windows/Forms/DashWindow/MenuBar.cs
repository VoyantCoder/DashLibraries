
// Author: Dashie


using System.Drawing;


namespace DashFramework
{
    namespace Forms
    {
	public partial class DashWindow
	{
	    public void Integrate(DashWindowPosition Position, Size Size, Color BackColor, Color BorderColor, bool RoundSides, DashWindowRoundRadius RoundRadius, Color MenuBarBackColor, Color MenuBarForeColor, Image MenuBarIcon, string MenuBarTitle, bool DisableWindowsBorder = true)
	    {
		try
		{
		    Sort.Sort(("dependency"), () =>
		    {
			Integrate(Position, Size, BackColor, BorderColor, RoundSides, RoundRadius, DisableWindowsBorder);
		    });

		    Sort.Sort(("integration extension"), () =>
		    {
			Size MenubarSize = new Size(Size.Width, 28);
			Point MenubarLocation = new Point(0, 0);

			MenubarInstance.Integrate(WindowInstance, MenubarSize, MenubarLocation, MenuBarBackColor, MenuBarTitle,
			    MenuBarForeColor, TitlePosition.LeftMiddle, MenuBarIcon, IconPosition.LeftMiddle, ButtonSet.Close);

			Menubar().SetMenubarDraggability();
		    });
		}

		catch
		{
		    throw;
		}
	    }
	}
    }
}