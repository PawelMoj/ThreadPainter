using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ThreadPainter.Pool
{
    class ThreadManager : IThreadManager
    {
        public delegate void CallbackMethod();

        public List<Thread> threads = new List<Thread>();

        public List<Brush> brushes { get; set; } = new List<Brush>();

        public void CreateThreads(int threadsNumber, CallbackMethod method)
        {
            for (int k = 0; k < threadsNumber; k++)
            {
                threads.Add(new Thread(() => method()));
            }

        }
        public void StartThreads()
        {
            foreach (var thread in threads)
            {
                if (thread.ThreadState == ThreadState.Suspended)
                {
                    thread.Resume();
                    return;
                }
                else if (thread.ThreadState == ThreadState.Running)
                {
                    return;
                }
                else
                {
                    try
                    {
                        thread.Start();
                    }
                    catch { }
                }
            }
        }

        public void AbortThreads()
        {
            foreach (var thread in threads)
            {
                try
                {
                    if (thread.ThreadState == ThreadState.Suspended)
                    {
                        thread.Resume();
                    }
                    thread.Abort();
                }
                catch
                { 
                    
                }
            }
            threads.Clear();
        }

        public void StopThreads()
        {
            foreach (var thread in threads)
            {
                thread.Suspend();
            }
        }
    }
}
