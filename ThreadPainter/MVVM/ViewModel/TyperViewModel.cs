using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using ThreadPainter.Core;
using ThreadPainter.MVVM.Model;
using ThreadPainter.Pool;

namespace ThreadPainter.MVVM.ViewModel
{

    class TyperViewModel : ObservableObject
    {
        Brush customColor;
        Random random = new Random();
        private int threadNumber;
        private int speed;
        public ICommand StartButtonCommand { get; set; }
        public ICommand StopButtonCommand { get; set; }
        public ICommand ClearButtonCommand { get; set; }

        private static ThreadManager threadManager = new ThreadManager();

        private ObservableCollection<EllipseItemModel> ellipseItems;

        //PointsViewModel Points { get; set; }
        public TyperViewModel()
        {          
            EllipseItems = new ObservableCollection<EllipseItemModel>();
            StartButtonCommand = new RelayCommand(o => StartButtonClick("StartButton"));
            StopButtonCommand = new RelayCommand(o => StopButtonClick("StopButton"));
            ClearButtonCommand = new RelayCommand(o => ClearButtonClick("ClearButton"));
        }

        private void StartButtonClick(object obj)
        {
            if (ThreadNumber == 0)
            {
                return; 
            }

            //threadManager.CreateThreads(ThreadNumber, () => RandomPointCreator());

            threadManager.StartThreads();
        }
        private void StopButtonClick(object obj)
        {
            
        }
        private void ClearButtonClick(object obj)
        {
            EllipseItems.Clear();
        }

        public void RandomPointCreator()
        {
            double x, y, radius = 0.1;
            
            while (true)
            {
                x = random.NextDouble();
                y = random.NextDouble();
                EllipseItems.Add(new EllipseItemModel { X = x, Y = y, Radius = radius });
            }
            
        }

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
        public ObservableCollection<EllipseItemModel> EllipseItems
        {
            get { return ellipseItems; }
            set
            {
                if (ellipseItems == value) return;

                ellipseItems = value;

                OnPropertyChanged("EllipseItems");
            }
        }
    }
}
