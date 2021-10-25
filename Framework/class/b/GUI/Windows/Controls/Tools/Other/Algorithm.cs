
// Author: Dashie


using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;


namespace DashFramework
{
    namespace ControlTools.Algorithms
    {
        public partial class OutsmartLoops
        {
            bool returnParent = false;

            public OutsmartLoops(bool returnParent)
            {
                this.returnParent = returnParent;
            }

            public OutsmartLoops() 
            { 
                //nothing special.
            }

            public List<Control> GetSubControls(Control parent)
            {
                IEnumerable<Control> AsList(Control.ControlCollection collection)
                {
                    foreach (Control control in collection)
                    {
                        yield return control;
                    }
                }

                List<Control> added = AsList(parent.Controls).ToList();

                try
                {
                    int r = 0;

                    do
                    {
                        r = added.Count;

                        for (int a = 0; a < added.Count; a += 1)
                        {
                            for (int b = 0; b < added[a].Controls.Count; b += 1)
                            {
                                if (!added.Contains(added[a].Controls[b]))
                                {
                                    added.Add(added[a].Controls[b]);
                                }
                            }
                        }

                        if (added.Count == r)
                        {
                            break;
                        }
                    }

                    while (true);

                    if (returnParent)
                    {
                        added.Add(parent);
                    }
                }

                catch
                {
                    return null;
                }

                return added;
            }
        }
    }
}