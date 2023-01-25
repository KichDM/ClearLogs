using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace LogsDeleteApp.Clear
{
    internal class Core
    {
        private static readonly List<IClean> Cleans = new List<IClean>
        {
            new Prefetch(),
            new ShellBags(),
            new EventsLog()
        };

        public static void Start()
        {
            DoClean();
            StartThread();
        }

        private static void StartThread()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.Priority = ThreadPriority.Lowest;


                while (true)
                {
                    Thread.Sleep(60000);
                    DoClean();
                }
            }).Start();
        }

        public static void DoClean()
        {
            try
            {
                foreach (var cl in Cleans)
                    try
                    {
                        cl.Do();
                    }
                    catch
                    {
                    }
            }
            catch (Exception ex)
            {
            }

        }
    }
}