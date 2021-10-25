
// Author: Dashie


using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;


namespace DashFramework
{
    namespace CLI
    {
        public partial class ConsoleText
        {
            public void Shuffle(string input, out string output, string separator)
            {
                try
                {
                    string[] sliceUp()
                    {
                        return input.Split
                        (
                            new string[] { separator },
                            StringSplitOptions.None
                        );
                    }

                    StringBuilder build = new StringBuilder();
                    List<string> buffer1 = sliceUp().ToList();

                    var count = buffer1.Count;
                    var rand = new Random();

                    for (int a = 0; a < count; a += 1)
                    {
                        int id = rand.Next(buffer1.Count);
                        build.Append(buffer1[id] + " ");
                        buffer1.RemoveAt(id);
                    }

                    output = build.ToString();

                    if (output.EndsWith(" "))
                    {
                        if (output.Length > 1)
                        {
                            output = output.Remove(output.Length - 1);
                        }

                        else if (output.Length >= 1)
                        {
                            output = output.Remove(0);
                        }
                    }
                }

                catch
                {
                    throw;
                }
            }

            public void Shuffle(string input, out string output)
            {
                try
                {
                    Shuffle(input, out output, " ");
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}