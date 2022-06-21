﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPainter.Pool
{
    class ThreadManager : IThreadManager
    {
        public delegate void CallbackMethod();

        public List<Thread> threads = new List<Thread>();
        public void CreateThreads(int threadsNumber, CallbackMethod method)
        {
            for (int k = 0; k < threadsNumber; k++)
            {
                threads[k] = new Thread(() => method());
            }
        }
        public void StartThreads()
        {
            foreach (var thread in threads)
            {
                if (thread.ThreadState == ThreadState.Stopped)
                {
                    thread.Resume();
                }
                else
                {
                    thread.Start();            
                }
            }
        }

        public void JoinThreads()
        {
            foreach (var thread in threads)
            {
                thread.Join();
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