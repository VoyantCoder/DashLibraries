
// Author: Dashie


using System;
using System.Linq;
using System.Collections.Generic;


namespace DashFramework
{
    namespace NETExtensions
    {
        public static class ArrayExtension
        {
            public static void RemDups<A>(this A[] arr)
            {
                try
                {
                    List<A> s_arr = arr.ToList();

                    for (int a = 0; a < arr.Length; a += 1)
                    {
                        while (s_arr.LastIndexOf(arr[a]) != s_arr.IndexOf(arr[a]))
                        {
                            s_arr.RemoveAt(a);
                        }
                    }

                    Array.Copy(s_arr.ToArray(), arr, s_arr.Count);
                }

                catch
                {
                    throw;
                }
            }

            public static void RemDups<A>(this A[] arr, A criteria)
            {
                try
                {
                    List<A> s_arr = arr.ToList();

                    void remove(int index) => s_arr.RemoveAt(index);

                    for (int a = 0; a < arr.Length; a += 1)
                    {
                        if (arr[a] is object && (object) arr[a] == (object)criteria)
                        {
                            remove(a);
                        }

                        else if (arr[a].Equals(criteria))
                        {
                            remove(a);
                        }
                    }

                    Array.Copy(s_arr.ToArray(), arr, s_arr.Count);
                }

                catch
                {
                    throw;
                }
            }

            public static void ForEveryItem<A>(this A[] arr, Action<A> code)
            {
                try
                {
                    foreach (A a in arr)
                    {
                        code(a);
                    }
                }

                catch
                {
                    throw;
                }
            }

            public static void SetSize<A>(this A[] arr, int size)
            {
                try
                {
                    Array.Copy(arr, arr, size);
                }

                catch
                {
                    throw;
                }
            }

            public static void UpSize<A>(this A[] arr, int increment = 1)
            {
                try
                {
                    SetSize<A>(arr, size: arr.Length + increment);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}