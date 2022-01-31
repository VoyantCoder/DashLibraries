
// Author: Dashie


using System.Collections.Generic;


namespace FlamefulAssembly
{
    namespace Threading
    {
        public partial class SafeList<T>
        {
            public SafeList(int expectedThreads)
            {
                try
                {
                    for (int k = 0; k < expectedThreads; k += 1)
                    {
                        pCollection.Add(new List<T>());
                    }

                    StartCacheUpdater();
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}