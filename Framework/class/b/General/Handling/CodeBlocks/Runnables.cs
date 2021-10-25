
// Author: Dashie


#pragma warning disable IDE1006


using System.Threading;
using System.Windows.Forms;


namespace DashFramework
{
    namespace Runnables
    {
        public class Runnable
        {
            public delegate void RunnableHolder();


            public void RunTaskAsynchronously(Control parent, RunnableHolder execute)
            {
                try
                {
                    new Thread(() =>
                    {
                        if (parent != null)
                        {
                            parent.Invoke
                            (
                                new MethodInvoker
                                (
                                    () =>
                                    {
                                        try
                                        {
                                            execute();
                                        }

                                        catch
                                        {
                                            throw;
                                        }
                                    }
                                )
                            );
                        }

                        else
                        {
                            execute();
                        }
                    })

                    { IsBackground = true }.Start();
                }

                catch
                {
                    throw;
                }
            }


            public void RunTaskSynchronously(Control parent, RunnableHolder execute)
            {
                try
                {
                    parent.Invoke(new MethodInvoker(() =>
                    {
                        try
                        {
                            execute();
                        }

                        catch
                        {
                            throw;
                        }
                    }));
                }

                catch
                {
                    throw;
                }
            }


            public void RunTaskLater(Control parent, RunnableHolder execute, int startWhen, bool autoReset = false)
            {
                try
                {
                    System.Timers.Timer timer = new System.Timers.Timer();

                    timer.Elapsed += (s, e) =>
                    {
                        execute();
                    };

                    timer.AutoReset = autoReset;
                    timer.Interval = startWhen;
                    timer.Enabled = true;
                    timer.Start();
                }

                catch
                {
                    throw;
                }
            }


            public void RunTaskLaterAsynchronously(Control parent, RunnableHolder execute, int startWhen, bool autoReset = false)
            {
                try
                {
                    System.Timers.Timer timer = new System.Timers.Timer();

                    timer.Elapsed += (s, e) =>
                    {
                        new Thread(() =>
                        {
                            if (parent != null)
                            {
                                parent.Invoke
                                (
                                    new MethodInvoker
                                    (
                                        () =>
                                        {
                                            try
                                            {
                                                execute();
                                            }

                                            catch
                                            {
                                                throw;
                                            }
                                        }
                                    )
                                );
                            }

                            else
                            {
                                execute();
                            }
                        })

                        { IsBackground = true }.Start();
                    };

                    timer.AutoReset = autoReset;
                    timer.Interval = startWhen;
                    timer.Enabled = true;
                    timer.Start();
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}