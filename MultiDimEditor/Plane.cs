using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDimEditor
{
    class Plane
    {
        int dimnum;
        DVector basepoint;
        DVector parvect1, parvect2;
        //Func<DVector, double> equation { get { } }
        public Plane(DVector p1, DVector p2, DVector p3)
        {
            dimnum = p1.DimNumber;
            basepoint = p1 * 1;
            parvect1 = p2 - p1;
            parvect2 = p3 - p1;
        }
    }
}
