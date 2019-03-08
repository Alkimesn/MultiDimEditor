using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDimEditor
{
    class TransformVector:Transform
    {
        DVector transvect;
        public override DVector ApplyTo(DVector v)
        {
            return transvect + v;
        }
        public override TransformDouble ToTrDouble()
        {
            return new TransformDouble(DMatrix.Get1Matrix(transvect.DimNumber), transvect);
        }
        public TransformVector(DVector transvect)
        {
            this.transvect = transvect;
        }
    }
}
