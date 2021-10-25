
// Author: Dashie


using System;
using System.Collections.Generic;


namespace DashFramework
{
    namespace CLI
    {
        public partial class ConsoleText
        {
            public string Crumber(string charset, string str)
            {
                try
                {
                    char[] arr = str.ToCharArray();
                    Random rand = new Random();

                    for (int k = 0; k < rand.Next(str.Length); k += 1)
                    {
                        int a = rand.Next(arr.Length);
                        int b = rand.Next(charset.Length);
                        arr[a] = charset[b];
                    }

                    return string.Empty;
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}