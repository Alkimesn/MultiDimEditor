using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDimEditor
{
    abstract class Transform
    {
        public abstract DVector ApplyTo(DVector v);
        public abstract TransformDouble ToTrDouble();
        public override string ToString()
        {
            return ToTrDouble().ToString();
        }
    }
}
