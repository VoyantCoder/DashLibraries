
// Author: Dashie


using System.Drawing;


namespace DashFramework
{
    namespace Forms
    {
        public partial class DashWindow
        {
            public void SetWindowRounding(DashWindowRoundRadius RoundRadius)
            {
                try
                {
                    int Radius = 4;

                    switch ((int)RoundRadius)
                    {
                        case 1: Radius = 6; break;
                        case 2: Radius = 8; break;
                    }

                    Transform.Round(WindowInstance, Radius);
                }

                catch
                {
                    throw;
                }
            }

            public void Integrate(DashWindowPosition Position, Size Size, Color BackColor, Color BorderColor, bool RoundSides, DashWindowRoundRadius RoundRadius, bool DisableWindowsBorder = true)
            {
                try
                {
                    Sort.Sort(("dependency"), () =>
                    {
                        Integrate(Position, Size, BackColor, BorderColor, DisableWindowsBorder);
                    });

                    Sort.Sort(("integration extension"), () =>
                    {
                        if (RoundSides)
                        {
                            SetWindowRounding(RoundRadius);
                        }
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