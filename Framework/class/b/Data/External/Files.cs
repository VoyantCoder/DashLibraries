
// Author: Dashie


using System;
using System.IO;

using DashFramework.Erroring;


namespace DashFramework
{
    namespace Data
    {
        public class Files
        {
            public bool MoveFile(string from, string to, bool exceptionFail = false)
            {
                try
                {
                    if (!File.Exists(from))
                    {
                        throw new Exception("#1");
                    }

                    else if (File.Exists(to))
                    {
                        File.Delete(to);
                    }

                    File.Move(from, to);

                    if (!File.Exists(to))
                    {
                        throw new Exception("#2");
                    }

                    return true;
                }

                catch
                {
                    if (exceptionFail)
                    {
                        throw;
                    }
                }

                return false;
            }
        }
    }
}