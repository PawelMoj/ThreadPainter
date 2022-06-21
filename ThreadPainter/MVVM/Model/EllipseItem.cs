using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ThreadPainter.MVVM.Model
{
    class EllipseItemModel
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double Radius { get; set; }
        public Brush Color { get; set; }
    }
}
