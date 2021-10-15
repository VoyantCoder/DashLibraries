
// Author: Dashie


#pragma warning disable IDE1006


using System.Collections.Generic;

using DashFramework.Runnables;


namespace DashFramework
{
    namespace AsyncSafety
    {
        public class AsyncSendMessage
        {
            // AsyncLists
            // AsyncControlInteraction
            // ....

            Runnable runnables = new Runnable();// needs work before use.

            public delegate void runnableDelegate();
            public runnableDelegate messageHandler;
            public int updateInterval = 350;

            public AsyncSendMessage()
            {
                runnables.RunTaskLaterAsynchronously
                (
                    null,

                    () =>
                    {
                        foreach (string message in messageQueue)
                        {
                            if (messageHandler == null)
                            {
                                continue;
                            }

                            messageHandler();
                        }
                    },

                    updateInterval,
                    true
                );
            }


            readonly List<string> messageQueue = new List<string>();

            public void Send(string content)
            {
                messageQueue.Add(content);
            }
        }
    }
}