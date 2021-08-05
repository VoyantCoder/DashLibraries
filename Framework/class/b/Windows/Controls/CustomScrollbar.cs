// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.Windows.Forms;

using DashFramework.Erroring;


namespace DashFramework
{
    namespace DashControls
    {
	namespace Customs
	{
	    public class CustomScroller
	    {
		public class Properties
		{
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

		    public bool HasBeenSetup()
		    {
			return (Parent != null && Children != null && ContentContainer != null);
		    }
		}


		public readonly Properties properties = new Properties();


		public bool ScrollingDown(MouseEventArgs e)
		{
		    return (e.Delta < 1);
		}


		public int ContentContainerIncrement = 50;
		public int MinimumHeight = 304;

		public void RegMouseEventHandler()
		{
		    try
		    {
			if (!properties.HasBeenSetup())
			{
			    return;
			}

			foreach (Control Control in properties.Children)
			{
			    Control.MouseWheel += (s, e) =>
			    {
				if (properties.ContentContainer.Height <= properties.Parent.Height)
				{
				    return;
				}

				else if (ScrollingDown(e))
				{
				    if (properties.ContentContainer.Bottom >= properties.Parent.Height)
				    {
					properties.ContentContainer.Top = -(properties.ContentContainer.Height <= MinimumHeight
					    ? 0 : (properties.ContentContainer.Height - properties.ContentContainer.Parent.Height));

					return;
				    }

				    properties.ContentContainer.Top -= ContentContainerIncrement;
				}

				else
				{
				    if (properties.ContentContainer.Top <= ContentContainerIncrement)
				    {
					properties.ContentContainer.Top = 0;
					return;
				    }

				    properties.ContentContainer.Top += ContentContainerIncrement;
				}
			    };
			}
		    }

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
		    }
		}


		public void SetCollection(Control Parent = null)
		{
		    try
		    {
			Control parent = (Parent == null) ? properties.Parent : Parent;

			properties.Children = parent.Controls;

			void AddToCollection(Control This)
			{
			    properties.Children.Add(This);
			}

			foreach (Control a in parent.Controls)
			{
			    foreach (Control b in a.Controls)
			    {
				foreach (Control c in b.Controls)
				{
				    foreach (Control d in c.Controls)
				    {
					AddToCollection(d);
				    }

				    AddToCollection(c);
				}

				AddToCollection(b);
			    }

			    AddToCollection(a);
			}

			RegMouseEventHandler();
		    }

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
		    }
		}


		public void ScrollbarSet(Control parent, Control contentContainer)
		{
		    try
		    {
			properties.ContentContainer = contentContainer;
			properties.Parent = parent;

			SetCollection();
		    }

		    catch (Exception E)
		    {
			ErrorHandler.JustDoIt(E);
		    }
		}
	    }
	}
    }
}