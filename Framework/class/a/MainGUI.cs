
// Author: Dashie
// Version: 1.0


using System;

using DashFramework.Forms;
using DashFramework.Erroring;


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
