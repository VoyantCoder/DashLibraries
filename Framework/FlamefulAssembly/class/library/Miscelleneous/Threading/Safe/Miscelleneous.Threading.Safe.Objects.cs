
// Author: Dashie


using System.Collections.Generic;


namespace FlamefulAssembly
{
    namespace Threading
    {
        public partial class SafeList<T>
        {
            private System.Timers.Timer pUpdater = new System.Timers.Timer();

            private List<List<T>> pCollection = new List<List<T>>();
            private List<T> mCollection = new List<T>();

            private int pCacheUpdateDelay = 10;
            private int pElementCount = 0;

            public int CacheUpdateDelay
            {
                set
                {
                    pCacheUpdateDelay = value;
                    pUpdater.Interval = value;
                }

                get
                {
                    return pCacheUpdateDelay;
                }
            }
        }
    }
}