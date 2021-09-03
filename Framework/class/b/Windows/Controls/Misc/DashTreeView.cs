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
	    public class DashTreeView : TreeView
	    {
		public void AddNode(string name)
		{
		    try
		    {
			TreeNode node = new TreeNode(name);

			Nodes.Add(node);
			Update();
		    }

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
		    }
		}


		public void RemoveNode(string node)
		{
		    try
		    {
			if (Nodes.ContainsKey(node))
			{
			    Nodes.RemoveByKey(node);
			    Update();
			}
		    }

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
		    }
		}


		public void ResetNodes()
		{
		    try
		    {
			Nodes.Clear();
			Update();
		    }

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
		    }
		}
	    }
	}
    }
}