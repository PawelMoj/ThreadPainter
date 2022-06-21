using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPainter.Pool
{
    interface IThreadManager
    {

        void StartThreads();
        void StopThreads();
        void AbortThreads();
    }
}
