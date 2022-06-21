using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadPainter.Core;

namespace ThreadPainter.MVVM.ViewModel
{
    
    class MainViewModel : ObservableObject
    {
        private object currentView;
        public object CurrentView
        {
            get { return currentView; }
            set 
            {
                currentView = value;
                OnPropertyChanged();
            }
        }
        //private object canvasView;
        //public object CanvasView
        //{
        //    get { return canvasView; }
        //    set
        //    {
        //        canvasView = value;
        //        OnPropertyChanged();
        //    }
        //}
        public TyperViewModel typerViewModel { get; set; }
        //public PointsViewModel pointsViewModel { get; set; }
        public MainViewModel()
        {
            this.typerViewModel = new TyperViewModel();
            //this.pointsViewModel = new PointsViewModel();

            CurrentView = this.typerViewModel;
            //CanvasView = this.pointsViewModel;

        }

    }
}
