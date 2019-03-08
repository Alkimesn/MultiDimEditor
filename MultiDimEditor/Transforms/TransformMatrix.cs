using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDimEditor
{
    class TransformMatrix:Transform
    {
        DMatrix transmatr;
        public override DVector ApplyTo(DVector v)
        {
            return transmatr * v;
        }
        public TransformMatrix(DMatrix matr)
        {
            transmatr = matr * 1;
        }
        public override TransformDouble ToTrDouble()
        {
            return new TransformDouble(transmatr, new DVector(transmatr.DimNumber));
        }
    }
}
