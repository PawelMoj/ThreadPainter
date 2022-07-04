using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPainter.PoolThreadManager
{
    interface IThreadManager
    {
        void CreateThreads(int number, Action action);
        void StartThreads();
        void StopThreads();
        void AbortThreads();
    }
}
