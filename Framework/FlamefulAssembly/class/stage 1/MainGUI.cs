
// Author: Dashie
// Version: 1.0


using FlamefulAssembly.Erroring;
using FlamefulAssembly.Forms;
using System;


namespace FlamefulAssembly
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
