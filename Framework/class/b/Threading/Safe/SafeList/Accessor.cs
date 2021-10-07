
// Author: Dashie


using System.Collections.Generic;


namespace DashFramework
{
    namespace Threading
    {
        public partial class SafeList<T>
        {
            public void Add(T value, int threadID)
            {
                try
                {
                    if (threadID < 0 || threadID >= pCollection.Count)
                    {
                        return;
                    }

                    pCollection[threadID].Add(value);
                }

                catch
                {
                    throw;
                }
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

                    return mCollection[index];
                }

                catch
                {
                    throw;
                }
            }

            public IEnumerable<T> Get(params int[] indexes)
            {
                foreach (int index in indexes)
                {
                    yield return Get(index);
                }
            }
        }
    }
}