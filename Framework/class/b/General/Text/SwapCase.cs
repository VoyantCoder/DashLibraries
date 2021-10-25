
// Author: Dashie


using System;
using System.Linq;


namespace DashFramework
{
    namespace CLI
    {
        public partial class ConsoleText
        {
            public string SwapCase(string str)
            {
                try
                {
                    char[] arr = str.ToCharArray();

                    for (int k = 0; k < arr.Length; k += 1)
                    {
                        if (Char.IsUpper(arr[k]))
                        {
                            arr[k] = Char.ToLower(arr[k]);
                        }

                        else
                        {
                            arr[k] = Char.ToUpper(arr[k]);
                        }
                    }

                    return new string(arr);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}