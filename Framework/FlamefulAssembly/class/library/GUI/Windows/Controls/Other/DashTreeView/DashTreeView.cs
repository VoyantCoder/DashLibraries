
// Author: Dashie


using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace DashControls.Controls
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

                catch
                {
                    throw;
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

                catch
                {
                    throw;
                }
            }


            public void ResetNodes()
            {
                try
                {
                    Nodes.Clear();
                    Update();
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}