
// Author: Dashie


using System.Collections.Generic;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace Forms
    {
        public partial class DashWindow
        {
            public bool RemoveChild(int cid)
            {
                try
                {
                    if (ChildIdentifiers.ContainsKey(cid))
                    {
                        ChildIdentifiers[cid].Parent.Controls.Remove(ChildIdentifiers[cid]);
                        ChildIdentifiers[cid].Dispose();
                        ChildIdentifiers.Remove(cid);
                    }

                    return ChildIdentifiers.ContainsKey(cid);
                }

                catch
                {
                    return false;
                }
            }

            public bool AddChild(Control child, int cid)
            {
                try
                {
                    if (!ChildIdentifiers.ContainsKey(cid))
                    {
                        WindowInstance.Controls.Add(child);

                        if (WindowInstance.Controls.Contains(child))
                        {
                            ChildIdentifiers.Add(cid, child);
                            return true;
                        }
                    }

                    return false;
                }

                catch
                {
                    throw;
                }
            }

            public IEnumerable<Control> GetChildren(params int[] cids)
            {
                foreach (int cid in cids)
                {
                    if (ChildIdentifiers.ContainsKey(cid))
                    {
                        yield return ChildIdentifiers[cid];
                    }
                }
            }

            public Control GetChild(int cid)
            {
                try
                {
                    if (ChildIdentifiers.ContainsKey(cid))
                    {
                        return ChildIdentifiers[cid];
                    }

                    return null;
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}