
// Author: Dashie


using System;


namespace DashFramework
{
    namespace NETExtensions
    {
        public enum RidSpaceMode
        {
            End, Start, Double, All
        }

        public static class StringExtension
        {
            public static string[] ISplit(this string inst, params char[] chars)
            {
                return inst.Split(chars, StringSplitOptions.RemoveEmptyEntries);
            }

            public static string RemoveAll(this string inst, params string[] crits)
            {
                foreach (string crit in crits)
                {
                    inst = inst.Replace(crit, "");
                }

                return inst;
            }

            public static string RidSpaces(this string inst, RidSpaceMode mode)
            {
                try
                {
                    void Double()
                    {
                        try
                        {
                            while (inst.Contains("  "))
                            {
                                inst = inst.Replace("  ", " ");
                            }
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    void Start()
                    {
                        try
                        {
                            while (inst.StartsWith(" "))
                            {
                                inst = inst.Remove(0, 1);
                            }
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    void End()
                    {
                        try
                        {
                            while (inst.EndsWith(" "))
                            {
                                inst = inst.Remove(inst.Length - 1, 1);
                            }
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    void All()
                    {
                        try
                        {
                            Start();
                            End();
                            Double();
                        }
                        
                        catch
                        {
                            throw;
                        }
                    }

                    switch (mode)
                    {
                        case RidSpaceMode.Double: Double(); break;
                        case RidSpaceMode.Start: Start(); break;
                        case RidSpaceMode.End: End();  break;
                        case RidSpaceMode.All: All(); break;
                    }

                    return inst;
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}