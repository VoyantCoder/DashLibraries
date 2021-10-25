
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace Forms
    {
        public partial class DashWindow
        {
            public bool ChangeParent(Control NewParent)
            {
                try
                {
                    WindowInstance.Parent = NewParent;
                    return (WindowInstance.Parent == NewParent);
                }

                catch
                {
                    return false;
                }
            }

            public MenuBar Menubar
            {
                get
                { 
                    if (MenubarInstance.Added)
                    {
                        return MenubarInstance;
                    }

                    return null;
                }
            }

            public Form Parent
            {
                get
                {
                    return WindowInstance;
                }
            }

            public Form Instance
            {
                get
                {
                    return WindowInstance;
                }
            }

            public bool Registered()
            {
                try
                {
                    return Initialized;
                }

                catch
                {
                    throw;
                }
            }

            public Size GetWindowSize()
            {
                try
                {
                    return WindowInstance.Size;
                }

                catch
                {
                    return Size.Empty;
                }
            }

            public void SetWindowSize(Size size)
            {
                try
                {
                    Transform.Resize(WindowInstance, size);

                    int height = Menubar.GetMenubarSize().Height;
                    Size newMSize = new Size(size.Width, height);
                    
                    Menubar.SetMenubarSize(newMSize);
                }

                catch
                {
                    throw;
                }
            }

            public void SetWindowBackColor(Color Color)
            {
                try
                {
                    Instance.BackColor = Color;
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}