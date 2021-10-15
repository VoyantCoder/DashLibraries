
// Author: Dashie


using System;
using System.Collections.Generic;


namespace DashFramework
{
    namespace Data
    {
        public class FixedList<T>
        {
            readonly List<T> Data = new List<T>();


            // Index Accessibility:
            public int Sets = 0;
            public int Gets = 0;

            public T this[int index, string o]
            {
                get
                {
                    Gets += 1;

                    if (Data.Count > index)
                    {
                        return Data[index];
                    }

                    return default(T);
                }

                set
                {
                    Sets += 1;

                    if (Data.Count > index)
                    {
                        Data[index] = value;
                    }
                }
            }


            // Base Methods:
            public int Removes = 0;

            public bool Remove(T Entry)
            {
                try
                {
                    if (Data.Contains(Entry))
                    {
                        Data.Remove(Entry);
                        Removes += 1;

                        return true;
                    }

                    return false;
                }

                catch
                {
                    return false;
                }
            }

            public bool Remove(int Index)
            {
                try
                {
                    if (Data.Count > Index)
                    {
                        Data.RemoveAt(Index);
                        Removes += 1;

                        return true;
                    }

                    return false;
                }

                catch
                {
                    return false;
                }
            }

            public bool Set(int Index, T Entry, bool Overwrite = true)
            {
                try
                {
                    if (Data.Count <= Index)
                    {
                        return false;
                    }

                    else if (Data[Index].Equals(Entry))
                    {
                        if (!Overwrite)
                        {
                            return false;
                        }
                    }

                    else
                    {
                        Data[Index] = Entry;
                        Sets += 1;
                    }

                    return true;
                }

                catch
                {
                    return false;
                }
            }

            public int Adds = 0;

            public bool Add(T Entry, bool IgnoreExistence = true)
            {
                try
                {
                    if (Data.Contains(Entry))
                    {
                        if (!IgnoreExistence)
                        {
                            return false;
                        }
                    }

                    else
                    {
                        Data.Add(Entry);
                        Adds += 1;
                    }

                    return true;
                }

                catch
                {
                    return false;
                }
            }

            public bool AddRange(bool AllowNulls = false, params T[] Entries)
            {
                try
                {
                    if (Entries.Length > 0)
                    {
                        if (!AllowNulls)
                        {
                            foreach (T Entry in Entries)
                            {
                                if (Entry != null)
                                {
                                    Data.Add(Entry);
                                }
                            }

                            Adds += 1;
                        }

                        else
                        {
                            Data.AddRange(Entries);
                            Adds += 1;
                        }

                        return true;
                    }

                    return false;
                }

                catch
                {
                    return false;
                }
            }

            public int Clears = 0;

            public void Clear()
            {
                try
                {
                    Data.Clear();
                    Clears += 1;
                }

                catch
                {
                    throw;
                }
            }


            // Utility Methods:
            public List<T> Cache()
            {
                try
                {
                    return Data;
                }

                catch
                {
                    throw;
                }
            }

            public Array ToArray()
            {
                try
                {
                    return Data.ToArray();
                }

                catch
                {
                    throw;
                }
            }

            public List<T> ToList()
            {
                try
                {
                    return Data;
                }

                catch
                {
                    throw;
                }
            }

            public Dictionary<int, T> GetAllNulls(string Info = "[stored as: (index, value)]")
            {
                try
                {
                    var Nulls = new Dictionary<int, T>();

                    for (int k = 0; k < Data.Count; k += 1)
                    {
                        if (Data[k] == null || Data[k].Equals(null))
                        {
                            Nulls.Add(k, Data[k]);
                        }
                    }

                    return Nulls;
                }

                catch
                {
                    throw;
                }
            }

            public IEnumerable<T> GetAllNulls()
            {
                foreach (T Entry in Data)
                {
                    if (Entry == null || Entry.Equals(null))
                    {
                        yield return Entry;
                    }
                }
            }

            public Dictionary<int, T> GetAllNoneNulls(string Info = "[stored as: (index, value)]")
            {
                try
                {
                    var Nulls = new Dictionary<int, T>();

                    for (int k = 0; k < Data.Count; k += 1)
                    {
                        if (Data[k] != null && !Data[k].Equals(null))
                        {
                            Nulls.Add(k, Data[k]);
                        }
                    }

                    Gets += 1;

                    return Nulls;
                }

                catch
                {
                    throw;
                }
            }

            public IEnumerable<T> GetAllNoneNulls()
            {
                foreach (T Entry in Data)
                {
                    if (Entry != null && !Entry.Equals(null))
                    {
                        yield return Entry;
                    }
                }

                Gets += 1;
            }
        }


        public class Lists
        {
            public class Dashlet<A, B, C>//Three Datatype Storage
            {
                public A a;
                public B b;
                public C c;

                public A Item1() => a;
                public B Item2() => b;
                public C Item3() => c;

                public Dashlet(A a, B b, C c)
                {
                    this.a = a;
                    this.b = b;
                    this.c = c;
                }
            }


            public class DashList<A>//One Datatype Storage
            {
                private readonly List<A> a = new List<A>();

                public A Get(int id)
                {
                    if (a.Count - 1 < id)
                    {
                        return default(A);
                    }

                    return a[id];
                }

                public bool Remove(int id)
                {
                    if (a.Count - 1 < id)
                    {
                        return false;
                    }

                    a.RemoveAt(id);

                    return true;
                }
            }
        }
    }
}