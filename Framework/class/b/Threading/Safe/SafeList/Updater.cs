
// Author: Dashie


namespace DashFramework
{
    namespace Threading
    {
        public partial class SafeList<T>
        {
            public void StartCacheUpdater()
            {
                try
                {
                    pUpdater.Elapsed += (s, e) =>
                    {
                        RefreshValues();
                    };

                    pUpdater.Interval = pCacheUpdateDelay;
                    pUpdater.AutoReset = true;
                    pUpdater.Enabled = true;
                    pUpdater.Start();
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}