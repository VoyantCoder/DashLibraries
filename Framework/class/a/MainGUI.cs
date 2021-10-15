
// Author: Dashie
// Version: 1.0


using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.Forms;
using DashFramework.Erroring;
using DashFramework.DashDialogs;
using DashFramework.DashControls.Controls;


namespace DashFramework
{
    public partial class MainGUI
    {
        readonly HandleError errorHandler = new HandleError();

        public void Initiator(DashWindow inst)
        {
            try
            {
            }

            catch (Exception E)
            {
                errorHandler.Handle(E);
            }
        }
    }
}
