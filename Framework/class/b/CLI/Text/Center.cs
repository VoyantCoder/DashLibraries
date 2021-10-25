
// Author: Dashie


using System;


namespace DashFramework
{
    namespace CLI
    {
        public partial class ConsoleText
        {
            public void Center(int width, string text, char filling, bool newline = true)
            {
                try
                {
                    int a = (width - text.Length) / 2;
                    string b = new string(filling, a);
                    string c = b + text + b;
                    string d = newline ? "\n" : "";
                    Console.Write("{0}{1}", c, d);
                }

                catch
                {
                    throw;
                }
            }

            public void Center(int width, string text, bool newline = true)
            {
                try
                {
                    Center(width, text, ' ', newline);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}