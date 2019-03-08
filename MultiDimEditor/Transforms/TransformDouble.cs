using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDimEditor
{
    class TransformDouble:Transform//v=A*v+sh
    {
        DMatrix transmatr;
        DVector transvect;
        public TransformDouble(DMatrix transmatr, DVector transvect)
        {
            this.transmatr = transmatr;
            this.transvect = transvect;
        }
        public override DVector ApplyTo(DVector v)
        {
            return transmatr * v + transvect;
        }
        public override string ToString()
        {
            string res = "";
            res += transmatr.DimNumber+"|";
            res += transmatr + "|" + transvect;
            return res;
        }
        public override TransformDouble ToTrDouble()
        {
            return this;
        }
        public static TransformDouble Parse(string str)
        {
            string[] lines=str.Split('|');
            int dimnum = int.Parse(lines[0]);
            int cnum = 0;
            string[] smatrcoords=lines[1].Split(' ');
            double[,] matrcoords=new double[dimnum, dimnum];
            for (int i = 0; i < dimnum; i++)
                for (int j = 0; j < dimnum; j++)
                    matrcoords[i, j] = double.Parse(smatrcoords[cnum++]);
            string[] svectcoords = lines[2].Split(' ');
            double[] vectcoords = svectcoords.Select(x => double.Parse(x)).ToArray();
            return new TransformDouble(new DMatrix(matrcoords), new DVector(vectcoords));
        }
        public static TransformDouble GetIdentityTransform(int dimnum)
        { return new TransformDouble(DMatrix.Get1Matrix(dimnum), new DVector(dimnum)); }
    }
}
