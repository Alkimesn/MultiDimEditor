using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDimEditor
{
    class Face
    {
        public List<int> points { get; set; }
        public Face(params int[] points)
        {
            this.points = new List<int>();
            foreach (var p in points) this.points.Add(p);
        }
        public override string ToString()
        {
            string res = "";
            foreach (var p in points)
                res += p + " ";
            res.Remove(res.Length - 1);
            return res;
        }
    }
    class Edge
    {
        public int point1 { get; set; }
        public int point2 { get; set; }
        public Edge(int p1, int p2)
        {
            point1 = p1; point2 = p2;
        }
        public override string ToString()
        {
            return point1 + " " + point2;
        }
    }
}
