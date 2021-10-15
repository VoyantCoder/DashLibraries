
// Author: Dashie


using System;


namespace DashFramework
{
    namespace NETExtensions
    {
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
        }
    }
}