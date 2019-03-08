using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDimEditor
{
    class TransformScale:TransformMatrix
    {
        public TransformScale(double[] coefs):base(DMatrix.GetDiagMatrix(coefs))
        { }
        public TransformScale(int dimnum, int dim, double coef)
            : base(DMatrix.GetScaleMatrix(dimnum,dim,coef))
        { }
        public TransformScale(int dimnum, double coef):base(DMatrix.Get1Matrix(dimnum)*coef)
        { }
    }
}
