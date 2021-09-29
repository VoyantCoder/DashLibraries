 
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.Windows.Forms;

using DashFramework.Erroring;


namespace DashFramework
{
    namespace DashControls.Controls
    {
	public partial class CustomScrollbar
	{ 

	    public bool ScrollingDown(MouseEventArgs e)
	    {
		return (e.Delta < 1);
	    }

	    public void RegMouseEventHandler()
	    {
		try
		{
		    if (!HasBeenSetup())
		    {
			return;
		    }

		    foreach (Control Control in Children)
		    {
			Control.MouseWheel += (s, e) =>
			{
			    if (ContentContainer.Height <= Parent.Height)
			    {
				return;
			    }

			    else if (ScrollingDown(e))
			    {
				if (ContentContainer.Bottom >= Parent.Height)
				{
				    ContentContainer.Top = -(ContentContainer.Height <= MinimumHeight
					? 0 : (ContentContainer.Height - ContentContainer.Parent.Height));

				    return;
				}

				ContentContainer.Top -= ContentContainerIncrement;
			    }

			    else
			    {
				if (ContentContainer.Top <= ContentContainerIncrement)
				{
				    ContentContainer.Top = 0;
				    return;
				}

				ContentContainer.Top += ContentContainerIncrement;
			    }
			};
		    }
		}

		catch
		{
		    ;
		}
	    }


	    public void SetCollection(Control Parent = null)
	    {
		try
		{
		    Control parent = (Parent == null) ? Parent : Parent;
		    Children = parent.Controls;

		    var controls = Loopsies.GetSubControls(parent);
		    foreach (Control control in controls)
		    {
			Children.Add(control);
		    }

		    RegMouseEventHandler();
		}

		catch
		{
		    ;
		}
	    }


	    public void ScrollbarSet(Control parent, Control contentContainer)
	    {
		try
		{
		    ContentContainer = contentContainer;
		    Parent = parent;
		    SetCollection();
		}

		catch
		{
		    throw;
		}
	    }
	}
    }
}