
// Author: Dashie


using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;


namespace DashFramework
{
    namespace Networking
    {
        public partial class Network
        {
            public partial class HttpServer
            {
                public bool ValidPageArguments(ref string Directory, ref string FileName)
                {
                    try
                    {
                        if (Directory.Length < 1)
                        {
                            return false;
                        }

                        if (Directory.Length > 1 && Directory.StartsWith("/"))
                        {
                            Directory = Directory.Substring(1, Directory.Length - 1);
                        }

                        if (!Directory.StartsWith("/"))
                        {
                            Directory = $"/{Directory}";
                        }

                        if (FileName.Length > 1 && FileName.StartsWith("/"))
                        {
                            FileName = FileName.Substring(1, FileName.Length - 1);
                        }
                    }

                    catch
                    {
                        return false;
                    }

                    return true;
                }

                public bool AddPage(byte[] HTMLSource, string Directory = "/", string FileName = "index.html")
                {
                    try
                    {
                        if (!ValidPageArguments(ref Directory, ref FileName))
                        {
                            return false;
                        }

                        UrlPageCache.Add(Directory + FileName, HTMLSource);
                    }

                    catch
                    {
                        return false;
                    }

                    return true;
                }

                public bool AddPage(byte[] HTMLSource, string Directory, string FileName, Action Code)
                {
                    try
                    {
                        if (!ValidPageArguments(ref Directory, ref FileName))
                        {
                            return false;
                        }

                        string path = Directory + FileName;

                        UrlExecutionCache.Add(path, Code);
                        UrlPageCache.Add(path, HTMLSource);
                    }

                    catch
                    {
                        return false;
                    }

                    return true;
                }

                public bool RepathPage(string CurrentPath, string NewPath)
                {
                    try
                    {
                        if (CurrentPath.Equals(NewPath))
                        {
                            return true;
                        }

                        if (UrlPageCache.ContainsKey(CurrentPath))
                        {
                            byte[] html = UrlPageCache[CurrentPath];

                            if (UrlExecutionCache.ContainsKey(CurrentPath))
                            {
                                Action code = UrlExecutionCache[CurrentPath];

                                UrlExecutionCache.Remove(CurrentPath);
                                UrlExecutionCache.Add(NewPath, code);
                            }

                            UrlPageCache.Remove(CurrentPath);
                            UrlPageCache.Add(NewPath, html);

                            return true;
                        }

                        return false;
                    }

                    catch
                    {
                        return false;
                    }
                }

                public bool SetPageHtml(string FullUrl, byte[] HTMLSource)
                {
                    try
                    {
                        if (!UrlPageCache.ContainsKey(FullUrl))
                        {
                            return false;
                        }

                        UrlPageCache[FullUrl] = HTMLSource;
                    }

                    catch
                    {
                        return false;
                    }

                    return true;
                }

                public bool SetOpenFileDialogDefaults(OpenFileDialog Diag)
                {
                    try
                    {
                        Diag.InitialDirectory = Environment.CurrentDirectory;
                        Diag.Filter = "Any Source (*.*)|*.*";
                        Diag.Title = "Select your HTML file";
                        Diag.DefaultExt = "html";
                        Diag.RestoreDirectory = true;
                        Diag.CheckFileExists = true;
                        Diag.CheckPathExists = true;
                    }

                    catch
                    {
                        return false;
                    }

                    return true;
                }

                public bool SetPageHtml(string FullUrl, bool CancelFalse = true)
                {
                    try
                    {
                        using (var Diag = new OpenFileDialog())
                        {
                            if (SetOpenFileDialogDefaults(Diag))
                            {
                                if (Diag.ShowDialog() != DialogResult.OK)
                                {
                                    return !CancelFalse;
                                }

                                SetPageHtml(FullUrl, File
                                    .ReadAllBytes(Diag.FileName));
                            }
                        }
                    }

                    catch
                    {
                        return false;
                    }

                    return true;
                }

                void StartPageHandler()
                {
                    try
                    {
                        PageHandlerThread = new Thread(() =>
                        {
                            while (Listener.IsListening)
                            {
                                HttpListenerContext context = Listener.GetContext();
                                HttpListenerResponse response = context.Response;

                                string ru = context.Request.RawUrl;

                                if (UrlPageCache.ContainsKey(ru))
                                {
                                    byte[] pageSource = UrlPageCache[ru];

                                    response.ContentLength64 = pageSource.Length;

                                    using (Stream s = response.OutputStream)
                                    {
                                        s.Write(pageSource, 0, pageSource.Length);
                                    }

                                    context.Response.Close();
                                }

                                if (AutoStartCodeHandler)
                                {
                                    if (UrlExecutionCache.ContainsKey(ru))
                                    {
                                        UrlExecutionCache[ru]();
                                    }
                                }
                            }
                        });

                        PageHandlerThread.IsBackground = true;
                        PageHandlerThread.Start();
                    }

                    catch
                    {
                        throw;
                    }
                }
            }
        }
    }
}