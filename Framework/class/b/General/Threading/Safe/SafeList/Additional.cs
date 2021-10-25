
// Author: Dashie


using System.Collections.Generic;


namespace DashFramework
{
    namespace Threading
    {
        public partial class SafeList<T>
        {
            public int Count()
            {
                try
                {
                    return pElementCount;
                }

                catch
                {
                    throw;
                }
            }

            private bool ThreadEntryExists(int threadID)
            {
                try
                {
                    return threadID >= 0 && pCollection.Count > threadID;
                }

                catch
                {
                    throw;
                }
            }

            public int Remove(T value, int threadID)
            {
                try
                {
                    if (!ThreadEntryExists(threadID))
                    {
                        return -1;
                    }

                    else if (!pCollection[threadID].Contains(value))
                    {
                        return -1;
                    }

                    pCollection[threadID].Remove(value);
                    pElementCount -= 1;
                }

                catch
                {
                    throw;
                }

                return 0;
            }

            public int Remove(int index, int threadID)
            {
                try
                {
                    if (!ThreadEntryExists(threadID))
                    {
                        return -1;
                    }

                    else if (index < pCollection[threadID].Count && index >= 0)
                    {
                        return -1;
                    }

                    pCollection[threadID].RemoveAt(index);
                    pElementCount -= 1;
                }

                catch
                {
                    throw;
                }

                return 0;
            }

            public int Clear(int threadID)
            {
                try
                {
                    if (!ThreadEntryExists(threadID))
                    {
                        return -1;
                    }

                    pCollection[threadID].Clear();
                }

                catch
                {
                    throw;
                }

                return 0;
            }

            public void ClearAll()
            {
                try
                {
                    foreach (var collection in pCollection)
                    {
                        collection.Clear();
                    }
                }

                catch
                {
                    throw;
                }
            }

            public int Add(T value, int threadID)
            {
                try
                {
                    if (!ThreadEntryExists(threadID))
                    {
                        return -1;
                    }

                    pCollection[threadID].Add(value);
                    pElementCount += 1;
                }

                catch
                {
                    throw;
                }

                return 0;
            }

            public void AddRange(int threadID, params T[] values)
            {
                try
                {
                    foreach (T value in values)
                    {
                        Add(value, threadID);
                    }
                }

                catch
                {
                    throw;
                }
            }

            private void RefreshValues()
            {
                try
                {
                    if (pCollection.Count > 0)
                    {
                        List<T> temp = new List<T>();

                        foreach (List<T> entry in pCollection)
                        {
                            if (entry.Count > 0)
                            {
                                temp.AddRange(entry);
                            }
                        }

                        mCollection = temp;
                    }
                }

                catch
                {
                    throw;
                }
            }

            public T Get(int index)
            {
                try
                {
                    RefreshValues();

                    if (index < 0 || index >= mCollection.Count)
                    {
                        return default(T);
                    }
                }

                catch
                {
                    throw;
                }

                return mCollection[index];
            }

            public IEnumerable<T> Get(params int[] indexes)
            {
                foreach (int index in indexes)
                {
                    yield return Get(index);
                }
            }

            public List<T> GetElements()
            {
                try
                {
                    RefreshValues();
                }

                catch
                {
                    throw;
                }

                return mCollection;
            }

            public T First()
            {
                RefreshValues();

                try
                {
                    dynamic elements = mCollection.Count;

                    if (elements == 1)
                    {
                        elements = mCollection[0];
                    }

                    else if (elements > 1)
                    {
                        elements = mCollection[elements - 1];
                    }

                    else
                    {
                        elements = default(T);
                    }

                    return elements;
                }

                catch
                {
                    throw;
                }
            }

            public T Last()
            {
                RefreshValues();

                try
                {
                    dynamic elements = mCollection.Count;

                    if (elements >= 1)
                    {
                        elements = mCollection[0];
                    }

                    else
                    {
                        elements = default(T);
                    }

                    return elements;
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}