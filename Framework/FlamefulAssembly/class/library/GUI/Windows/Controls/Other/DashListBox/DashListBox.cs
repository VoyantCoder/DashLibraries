
// Author: Dashie


#pragma warning disable IDE1006


using System.Windows.Forms;


namespace FlamefulAssembly
{
    namespace DashControls.Controls
    {
        public class DashListBox : ListBox
        {
            public void Add(object obj)
            {
                Items.Add(obj);
            }


            public void Remove(int Id = 0)
            {
                if (Items.Count > Id)
                {
                    Items.RemoveAt(Id);
                }
            }


            public string Get(int Id = -1, object Item = null)
            {
                if (Id > -1)
                {
                    if (Items.Count > -1)
                    {
                        return Items[Id].ToString();
                    }
                }

                else if (Item != null)
                {
                    if (Items.Contains(Item))
                    {
                        return Items[Items.IndexOf(Item)].ToString();
                    }
                }

                return string.Empty;
            }


            public bool IsNull()
            {
                return (this == null);
            }
        }
    }
}