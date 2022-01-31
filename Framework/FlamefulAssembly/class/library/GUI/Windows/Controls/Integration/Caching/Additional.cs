
// Author: Dashie


using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace DashControls
    {
        public enum ControlCacheType
        {
            CheckBox, Global
        }

        public partial class ControlIntegrator
        {
            private dynamic ParentExist(ControlCacheType type, Control parent)
            {
                try
                {
                    switch (type)
                    {
                        case ControlCacheType.Global:
                        {
                            if (!Controls.ContainsKey(parent))
                            {
                                return null;
                            }

                            return Controls[parent];
                        }

                        case ControlCacheType.CheckBox:
                        {
                            if (!Checkboxes.ContainsKey(parent))
                            {
                                return null;
                            }

                            return Checkboxes[parent];
                        }

                        default: return null;
                    }
                }

                catch
                {
                    throw;
                }
            }

            public IEnumerable<Control> GetControls(ControlCacheType type, Control parent, params Type[] types)
            {
                dynamic parentControls = ParentExist(type, parent);

                if (parentControls == null)
                {
                    yield break;
                }

                foreach (Control control in parentControls)
                {
                    if (types.Contains(control.GetType()))
                    {
                        yield return control;
                    }
                }
            }

            public dynamic GetAll(ControlCacheType type, Control parent)
            {
                try
                {
                    return ParentExist(type, parent);
                }

                catch
                {
                    throw;
                }
            }

            public dynamic Get(ControlCacheType type, Control parent, int id)
            {
                try
                {
                    dynamic parentControls = ParentExist(type, parent);

                    if (parentControls != null && parentControls.Count > id)
                    {
                        return parentControls[id];
                    }

                    return null;
                }

                catch
                {
                    throw;
                }
            }

            public int Elements(ControlCacheType type, Control parent)
            {
                try
                {
                    dynamic parentControls = ParentExist(type, parent);

                    if (parentControls == null)
                    {
                        return -1;
                    }

                    return parentControls.Count;
                }

                catch
                {
                    throw;
                }
            }

            public int Elements(ControlCacheType type)
            {
                try
                {
                    switch (type)
                    {
                        case ControlCacheType.CheckBox:
                            return Checkboxes.Count;

                        case ControlCacheType.Global:
                            return Controls.Count;

                        default:
                            return -1;
                    }
                }

                catch
                {
                    throw;
                }
            }

            public void Remove(ControlCacheType type, Control parent, int id)
            {
                try
                {
                    dynamic parentControls = ParentExist(type, parent);

                    if (parentControls != null && parentControls.Count > id)
                    {
                        if (type == ControlCacheType.CheckBox)
                        {
                            Checkboxes[parent].RemoveAt(id);
                        }

                        else
                        {
                            Controls[parent].RemoveAt(id);
                        }
                    }
                }

                catch
                {
                    throw;
                }
            }

            public void Remove(ControlCacheType type, Control parent)
            {
                try
                {
                    dynamic parentControls = ParentExist(type, parent);

                    if (parentControls != null)
                    {
                        if (type == ControlCacheType.CheckBox)
                        {
                            Checkboxes.Remove(parent);
                        }

                        else
                        {
                            Controls.Remove(parent);
                        }
                    }

                }

                catch
                {
                    throw;
                }
            }

            public void RemoveAll(ControlCacheType type)
            {
                try
                {
                    switch (type)
                    {
                        case ControlCacheType.CheckBox: Checkboxes.Clear(); break;
                        case ControlCacheType.Global: Controls.Clear(); break;
                    }
                }

                catch
                {
                    throw;
                }
            }

            public void RemoveAll()
            {
                try
                {
                    Checkboxes.Clear();
                    Controls.Clear();
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}