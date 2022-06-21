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
using System.Windows.Threading;
using ThreadPainter.Core;
using ThreadPainter.MVVM.Model;
using ThreadPainter.Pool;

namespace ThreadPainter.MVVM.ViewModel
{
    class EllipseItemModel
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double Radius { get; set; }
        public Brush Color { get; set; }
    }
    class TyperViewModel : ObservableObject
    {
        private List<Brush> brushes = new List<Brush>() 
        {
            new SolidColorBrush(Color.FromArgb(255,27,161,226)),
            new SolidColorBrush(Color.FromArgb(255,160,80,0)),
            new SolidColorBrush(Color.FromArgb(255, 51,153,51)),
            new SolidColorBrush(Color.FromArgb(255,162,193,57)),
            new SolidColorBrush(Color.FromArgb(255,216,0,115)),
            new SolidColorBrush(Color.FromArgb(255,240,150,9)),
            new SolidColorBrush(Color.FromArgb(255,230,113,184)),
            new SolidColorBrush(Color.FromArgb(255,162,0,255)),
            new SolidColorBrush(Color.FromArgb(255,229,20,0)), 
            new SolidColorBrush(Color.FromArgb(255,0,171,169)),

            new SolidColorBrush(Color.FromArgb(255,27,161,13)),
            new SolidColorBrush(Color.FromArgb(255,160,80,50)),
            new SolidColorBrush(Color.FromArgb(255, 51,112,51)),
            new SolidColorBrush(Color.FromArgb(255,61,193,57)),
            new SolidColorBrush(Color.FromArgb(255,216,200,115)),
            new SolidColorBrush(Color.FromArgb(255,69,150,9)),
            new SolidColorBrush(Color.FromArgb(255,230,113,18)),
            new SolidColorBrush(Color.FromArgb(255,12,0,255)),
            new SolidColorBrush(Color.FromArgb(255,34,235,0)),
            new SolidColorBrush(Color.FromArgb(255,0,171,69))

        };
        Random random = new Random();
        private int threadNumber;
        private int speed;
        private double height;
        private double width;
        public ICommand StartButtonCommand { get; set; }
        public ICommand StopButtonCommand { get; set; }
        public ICommand ClearButtonCommand { get; set; }

        private ThreadManager threadManager = new ThreadManager();

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
            if (ThreadNumber == 0 || Speed == 0)
            {
                return; 
            }
            if (threadManager.threads.Count() == 0)
            {
                threadManager.brushes = brushes.Take(ThreadNumber).ToList();
                threadManager.CreateThreads(ThreadNumber, () => RandomPointCreator());
            }
            threadManager.StartThreads();
        }
        private void StopButtonClick(object obj)
        {
            threadManager.StopThreads();
        }
        private void ClearButtonClick(object obj)
        {
            threadManager.AbortThreads();
            Thread.Sleep(2000);
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                EllipseItems.Clear();
            }));
        }

        public void RandomPointCreator()
        {
            double x, y, radius = 10;
            Brush brush = threadManager.brushes.FirstOrDefault();
            threadManager.brushes.Remove(brush);
            while (true)
            {
                x = random.NextDouble() * Width;
                y = random.NextDouble() * (Height+120);
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                {
                    this.EllipseItems.Add(new EllipseItemModel { X = x, Y = y, Radius = radius, Color = brush });
                }));
                Thread.Sleep(1000/Speed);
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

        public double Height
        {
            get { return height; }
            set
            {
                height = value;
                OnPropertyChanged("Height");
            }
        }
        public double Width
        {
            get { return width; }
            set
            {
                width = value;
                OnPropertyChanged("Width");
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
