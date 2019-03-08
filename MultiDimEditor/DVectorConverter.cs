using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MultiDimEditor
{
    static class DVectorConverter
    {
        public static Point ConvertTo2D(this DVector vect, Point center, bool InvertY=true)
        {
            Point p = new Point(vect[0] + center.X, (InvertY ? -1 : 1) * vect[1] + center.Y);
            return p;
        }
    }
}
