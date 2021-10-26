
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
                CLI.ConsoleText text = new CLI.ConsoleText();

                text.ColorText("&aThis world is a crazy place. &6Peace!", true, format:"&e[&b!&e] &7Success: %text%");
            }

            catch (Exception E)
            {
                errorHandler.Handle(E);
            }
        }
    }
}
