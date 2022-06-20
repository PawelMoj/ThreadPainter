using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using ThreadPainter.Core;
using ThreadPainter.MVVM.Model;

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

        PointsViewModel Points { get; set; }
        public TyperViewModel()
        {
            this.Points = new PointsViewModel();
            StartButtonCommand = new RelayCommand(o => StartButtonClick("StartButton"));
            StopButtonCommand = new RelayCommand(o => StopButtonClick("StartButton"));
            ClearButtonCommand = new RelayCommand(o => ClearButtonClick("StartButton"));
        }

        private void StartButtonClick(object obj)
        {
            if (ThreadNumber != 0)
            {
                EllipseGeometry ellipse = new EllipseGeometry();
                
                Points.RandomPointCreator();
            }
        }
        private void StopButtonClick(object obj)
        {

        }
        private void ClearButtonClick(object obj)
        {

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
    }
}
