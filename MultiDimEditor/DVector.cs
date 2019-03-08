using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDimEditor
{
    class DVector //1*n
    {
        public int DimNumber { get; private set; }
        private double[] coordinates;
        public DVector(int dimnum) 
        { 
            DimNumber = dimnum; 
            coordinates = new double[DimNumber]; 
        }
        public DVector(params double[] coords) :this(coords.Length)
        {
            for (int i = 0; i < DimNumber; i++) coordinates[i] = coords[i];
        }
        public double this[int index]
        {
            get { return coordinates[index]; }
            set { coordinates[index] = value; }
        }
        public static DVector operator +(DVector a, DVector b)
        {
            if (a.DimNumber != b.DimNumber) throw new ArgumentException();
            DVector res = new DVector(a.DimNumber);
            for (int i = 0; i < a.DimNumber; i++) res[i] = a[i] + b[i];
            return res;
        }
        public static DVector operator *(DVector a, double b)//multiplication by scalar
        {
            DVector res = new DVector(a.DimNumber);
            for (int i = 0; i < a.DimNumber; i++) res[i] = a[i]*b;
            return res;
        }
        public static DVector operator *(double b, DVector a)//multiplication by scalar
        {
            DVector res = new DVector(a.DimNumber);
            for (int i = 0; i < a.DimNumber; i++) res[i] = a[i] * b;
            return res;
        }
        public static DVector operator -(DVector a)
        {
            return a * (-1);
        }
        public static DVector operator -(DVector a, DVector b)
        {
            return a + (-b);
        }
        public static double operator *(DVector a, DVector b)//scalar multiplication
        {
            if (a.DimNumber != b.DimNumber) throw new ArgumentException();
            double res = 0;
            for (int i = 0; i < a.DimNumber; i++) res+= a[i] * b[i];
            return res;
        }
        public static DVector GetOrt(int dim, int dimnum)
        {
            DVector res = new DVector(dimnum);
            res[dim] = 1;
            return res;
        }
        public override string ToString()
        {
            string res = "";
            foreach (var c in coordinates)
                res += c + " ";
            return res.Remove(res.Length - 1);
        }
    }

    class DMatrix //n*n
    {
        public int DimNumber { get; private set; }
        private double[,] coordinates;
        public DMatrix(int dimnum)
        {
            DimNumber = dimnum;
            coordinates = new double[DimNumber, DimNumber];
        }
        public DMatrix(double[,] coords):this(coords.GetUpperBound(0)+1)
        {
            for (int row = 0; row < DimNumber; row++)
                for (int col = 0; col < DimNumber; col++)
                    coordinates[row, col] = coords[row, col];
        }
        double this[int row, int col]
        {
            get { return coordinates[row, col]; }
            set { coordinates[row, col] = value; }
        }
        DVector GetRow(int row)
        {
            double[] res = new double[DimNumber];
            for (int i = 0; i < DimNumber; i++) res[i] = coordinates[row,i];
            return new DVector(res);
        }
        DVector GetCol(int col)
        {
            double[] res = new double[DimNumber];
            for (int i = 0; i < DimNumber; i++) res[i] = coordinates[i, col];
            return new DVector(res);
        }
        public static DMatrix Get1Matrix(int dimnum)
        {
            DMatrix res = new DMatrix(dimnum);
            for (int i = 0; i < dimnum; i++) res[i, i] = 1;
            return res;
        }
        public static DMatrix GetRotMatrix(int dimnum, int axis1, int axis2, double angle)//rotation from axis1 to axis2 by angle
        {
            DMatrix res = DMatrix.Get1Matrix(dimnum);
            res[axis1, axis1] = Math.Cos(angle);
            res[axis2, axis2] = Math.Cos(angle);
            res[axis1, axis2] = -Math.Sin(angle);
            res[axis2, axis1] = Math.Sin(angle);
            return res;
        }
        public static DMatrix GetDiagMatrix(double[] diagelems)
        {
            DMatrix res = DMatrix.Get1Matrix(diagelems.Length);
            for (int i = 0; i < res.DimNumber; i++)
                res[i, i] = diagelems[i];
            return res;
        }
        public static DMatrix GetDiagMatrix(DVector diagelems)
        {
            DMatrix res = DMatrix.Get1Matrix(diagelems.DimNumber);
            for (int i = 0; i < res.DimNumber; i++)
                res[i, i] = diagelems[i];
            return res;
        }
        public static DMatrix GetScaleMatrix(int dimnum, int dim, double scale)
        {
            DMatrix res = DMatrix.Get1Matrix(dimnum);
            for (int i = 0; i < res.DimNumber; i++)
                res[i, i] = i==dim?scale:1;
            return res;
        }
        public static DMatrix operator *(DMatrix a, DMatrix b)//matrix multiplication
        {
            if (a.DimNumber != b.DimNumber) throw new ArgumentException();
            DMatrix res = new DMatrix(a.DimNumber);
            for(int row=0;row<a.DimNumber;row++)
                for (int col = 0; col < a.DimNumber; col++)
                {
                    double sum=0;
                    for (int i = 0; i < a.DimNumber; i++) sum += a[row, i] * b[i, col];
                    res[row, col] = sum;
                }
            return res;
        }
        public static DVector operator *(DMatrix a, DVector b)//matrix*vector
        {
            if (a.DimNumber != b.DimNumber) throw new ArgumentException();
            double[] res = new double[a.DimNumber];
            for (int i = 0; i < a.DimNumber; i++) res[i] = a.GetRow(i) * b;
            return new DVector(res);
        }
        public static DMatrix operator *(DMatrix a, double b)//multiplication by scalar
        {
            DMatrix res = new DMatrix(a.DimNumber);
            for (int i = 0; i < a.DimNumber; i++)
                for (int j = 0; j < a.DimNumber; j++)
                    res[i, j] = a[i, j] * b;
            return res;
        }
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < DimNumber; i++)
                for (int j = 0; j < DimNumber;j++ )
                    res += coordinates[i,j] + " ";
            return res.Remove(res.Length - 1);
        }
    }
}
