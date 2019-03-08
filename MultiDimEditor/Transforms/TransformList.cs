using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDimEditor
{
    class TransformList:Transform
    {
        int dimnum;
        List<Transform> transforms;
        public TransformList(int dimnum)
        {
            transforms = new List<Transform>();
            this.dimnum = dimnum;
        }
        public void AddLast(Transform t)
        {
            transforms.Add(t);
        }
        public void AddFirst(Transform t)
        { 
            transforms.Insert(0, t);
        }
        public override DVector ApplyTo(DVector v)
        {
            DVector res=v*1;
            foreach (var t in transforms) res = t.ApplyTo(res);
            return res;
        }
        public override TransformDouble ToTrDouble()
        {
            DVector origin=ApplyTo(new DVector(dimnum));
            DVector[] orts=new DVector[dimnum];
            for(int i=0;i<dimnum;i++) orts[i]=ApplyTo(DVector.GetOrt(i,dimnum));
            double[,] mcoords = new double[dimnum, dimnum];
            for(int i=0;i<dimnum;i++)
                for(int j=0; j<dimnum;j++)
                    mcoords[i,j]=(orts[j]-origin)[i];
            return new TransformDouble(new DMatrix(mcoords), origin);
        }
    }
}
