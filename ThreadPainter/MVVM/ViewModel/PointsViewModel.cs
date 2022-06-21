using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ThreadPainter.Core;

namespace ThreadPainter.MVVM.ViewModel
{
    
    class PointsViewModel : ObservableObject
    {
        //private ObservableCollection<EllipseItem> ellipseItems;
        //public ObservableCollection<EllipseItem> EllipseItems
        //{
        //    get { return ellipseItems; }
        //    set
        //    {
        //        if (ellipseItems == value) return;

        //        ellipseItems = value;

        //        OnPropertyChanged("EllipseItems");
        //    }
        //}

        public PointsViewModel()
        {
            //ellipseItems = new ObservableCollection<EllipseItem>();
        }

        //public void RandomPointCreator()
        //{
        //    ellipseItems.Add(new EllipseItem { X = 200, Y = 200 });
        //}
    }
}
