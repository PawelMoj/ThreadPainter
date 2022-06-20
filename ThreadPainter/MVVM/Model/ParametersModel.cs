using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadPainter.Core;

namespace ThreadPainter.MVVM.Model
{
    class ParametersModel : ObservableObject
    {
        private int threadNumber;
        private int speed;
        public int ThreadNumber 
        {
            get { return threadNumber; }
            set 
            {
                threadNumber = value;
                OnPropertyChanged("ThreadNumber");
            } 
        }
        public int Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                OnPropertyChanged("Speed");
            }
        }
    }
}
