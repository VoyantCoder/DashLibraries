
// Author: Dashie


using System;


namespace FlamefulAssembly
{
    namespace CLI
    {
        public partial class ConsoleText
        {
            protected static string[] Split(string str, char c)
            {
                return str.Split(new char[] { c },
                    StringSplitOptions.RemoveEmptyEntries);
            }

            protected static ConsoleColor GetMessageForeColor(char code)
            {
                return code.ToString().ToLower() switch
                {
                    "2" => ConsoleColor.DarkGreen,
                    "3" => ConsoleColor.DarkCyan,
                    "4" => ConsoleColor.Red,
                    "5" => ConsoleColor.DarkMagenta,
                    "6" => ConsoleColor.DarkYellow,
                    "7" => ConsoleColor.Gray,
                    "8" => ConsoleColor.DarkGray,
                    "0" => ConsoleColor.Black,
                    "d" => ConsoleColor.Magenta,
                    "b" => ConsoleColor.Cyan,
                    "e" => ConsoleColor.Yellow,
                    "f" => ConsoleColor.White,
                    "a" => ConsoleColor.Green,
                    "c" => ConsoleColor.DarkRed,
                    _ => ConsoleColor.DarkBlue
                };
            }

            public static void ColorText(string text, bool newline, string format = "[!] Error: %text%")
            {
                try
                {
                    string[] temp = Split(format.Replace("%text%", "`"), '`');

                    if (temp.Length > 0)
                    {
                        ColorText(temp[0], false);
                    }

                    else if (!text.Contains("&"))
                    {
                        Console.Write(text);

                        if (newline)
                        {
                            Console.WriteLine();
                        }

                        return;
                    }

                    string[] splitMessage = Split(text, '&');
                    string message = string.Empty;

                    for (int a = 0; a < splitMessage.Length; a += 1)
                    {
                        message = splitMessage[a];

                        int messageLength = message.Length;

                        if (messageLength > 1)
                        {
                            ConsoleColor messageForeColor = GetMessageForeColor(message[0]);

                            if (!messageForeColor.Equals(ConsoleColor.DarkBlue))
                            {
                                int length = messageLength - 1;
                                int start = 1;

                                message = message.Substring(start);
                            }

                            Console.ForegroundColor = messageForeColor;
                            Console.Write(message);
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
                }

                catch
                {
                    throw;
                }
            }

            public static void ColorText(string text, bool newline)
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

            public static void ColorText(string text)
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