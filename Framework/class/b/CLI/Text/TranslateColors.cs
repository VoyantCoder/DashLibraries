
// Author: Dashie


using System;


namespace DashFramework
{
    namespace CLI
    {
        public partial class ConsoleText 
        {
            private string[] Split(string str, char c)
            {
                return str.Split(new char[] { c }, 
                    StringSplitOptions.RemoveEmptyEntries);
            }


            public void ColorText(string text, bool newline, string format = "[!] Error: %text%")
            {
                try
                {
                    string[] temp = Split(format.Replace("%text%", "`"), '`');

                    if (temp.Length > 0)
                    {
                        ColorText(temp[0], false);
                    }

                    string[] buffer1 = Split(text, '&');

                    for (int a = 0; a < buffer1.Length; a += 1)
                    {
                        if (buffer1[a].Length > 0)
                        {
                            int buff1 = buffer1[a].Length > 1 ? 1 : 0;
                            int buff2 = buffer1[a].Length > 1 ? buffer1[a].Length - 1 : 1;

                            ConsoleColor color = ConsoleColor.Blue;

                            switch (buffer1[a][0].ToString().ToLower())
                            {
                                case "2": color = ConsoleColor.DarkGreen; break;
                                case "3": color = ConsoleColor.DarkCyan; break;
                                case "4": color = ConsoleColor.Red; break;
                                case "5": color = ConsoleColor.DarkMagenta; break;
                                case "6": color = ConsoleColor.DarkYellow; break;
                                case "7": color = ConsoleColor.Gray; break;
                                case "8": color = ConsoleColor.DarkGray; break;
                                case "0": color = ConsoleColor.Black; break;
                                case "d": color = ConsoleColor.Magenta;  break;
                                case "b": color = ConsoleColor.Cyan; break;
                                case "e": color = ConsoleColor.Yellow; break;
                                case "f": color = ConsoleColor.White; break;
                                case "a": color = ConsoleColor.Green; break;
                                case "c": color = ConsoleColor.DarkRed; break;
                                default: color = ConsoleColor.DarkBlue; break;
                            }

                            if (color != ConsoleColor.DarkBlue)
                            {
                                buffer1[a] = buffer1[a].Substring(buff1, buff2);
                                Console.ForegroundColor = color;
                            }

                            Console.Write(buffer1[a]);
                        }
                    }

                    if (temp.Length > 1)
                    {
                        ColorText(temp[1], false);
                    }

                    else
                    {
                        if (newline)
                        {
                            Console.WriteLine();
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                }

                catch
                { 
                    throw;
                }
            }

            public void ColorText(string text, bool newline)
            {
                try
                {
                    ColorText(text, newline, "%text%");
                }

                catch
                {
                    throw;
                }
            }

            public void ColorText(string text)
            {
                try
                {
                    ColorText(text, true);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}