using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace MultiDimEditor
{
    class Space
    {
        public List<DVector> points{get; private set;}
        public List<Edge> edges { get; private set; }
        public List<Face> faces { get; private set; }
        public List<Transform> views { get; private set; }
        public int dimnum { get; private set; }
        public Space(int dimnum)
        {
            points = new List<DVector>();
            edges = new List<Edge>();
            faces = new List<Face>();
            views = new List<Transform>();
            this.dimnum = dimnum;
        }
        public static Space Parse(string content)
        {
            string[] lines = content.Split('|');
            int dimnum = int.Parse(lines[0]);
            int pointnum = int.Parse(lines[1]);
            int curstr = 2;
            List<DVector> points = new List<DVector>();
            for(int i=0;i<pointnum;i++)
            {
                string[] strcoords = lines[curstr++].Split(' ');
                double[] coords = strcoords.Select(x => double.Parse(x)).ToArray();
                points.Add(new DVector(coords));
            }
            int edgenum = int.Parse(lines[curstr++]);
            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < edgenum; i++)
            {
                string[] strpoints = lines[curstr++].Split(' ');
                int p1 = int.Parse(strpoints[0]);
                int p2 = int.Parse(strpoints[1]);
                edges.Add(new Edge(p1, p2));
            }
            int facenum = int.Parse(lines[curstr++]);
            List<Face> faces = new List<Face>();
            for (int i = 0; i < facenum; i++)
            {
                string[] strfpoints = lines[curstr++].Split(' ');
                int[] fpoints = strfpoints.Select(x => int.Parse(x)).ToArray();
                faces.Add(new Face(fpoints));
            }
            Space s = new Space(dimnum);
            s.points = points;
            s.edges = edges;
            s.faces = faces;
            return s;
        }
        public override string ToString()
        {
            string res = "";
            res += dimnum+"|";
            res += points.Count+"|";
            foreach (var p in points) res += p + "|";
            res += edges.Count + "|";
            foreach (var e in edges) res += e + "|";
            res += faces.Count + "|";
            foreach (var f in faces) res += f + "|";

            res.Remove(res.Length - 1);
            return res;
        }
        public void Draw(DrawingContext dc, Point center, Transform view, DrawingRules dr, int SelectedPoint=-1, int SelectedEdge=-1)
        {
            List<Point> _2dpoints=new List<Point>();
            foreach(var p in points)
            {
                var newp = view.ApplyTo(p);
                _2dpoints.Add(newp.ConvertTo2D(center));
            }
            for (int i = 0; i < _2dpoints.Count;i++ )
                if (i == SelectedPoint) dc.DrawEllipse(dr.SelPointBrush, null, _2dpoints[i], dr.SelPointWidth, dr.SelPointWidth);
                else dc.DrawEllipse(dr.PointBrush, null, _2dpoints[i], dr.PointWidth, dr.PointWidth);
            for (int i = 0; i < edges.Count; i++)
                if (i == SelectedEdge) dc.DrawLine(dr.SelLinePen, _2dpoints[edges[i].point1], _2dpoints[edges[i].point2]);
                else dc.DrawLine(dr.LinePen, _2dpoints[edges[i].point1], _2dpoints[edges[i].point2]);
            foreach(var f in faces) 
            {
                PathFigure pf=new PathFigure();
                for(int i=1;i<f.points.Count;i++)
                {
                    pf.Segments.Add(new LineSegment(_2dpoints[f.points[i]], true));
                }
                pf.StartPoint=_2dpoints[f.points[0]];
                pf.IsClosed = true;
                PathGeometry g = new PathGeometry(new[]{pf});
                dc.DrawGeometry(dr.FaceBrush, null, g);
            }

            //coordinate lines
            //base
            dc.DrawLine(dr.BaseCoordLinePen, center, new Point(1000+center.X, center.Y));
            dc.DrawLine(dr.BaseCoordLinePen, center, new Point(center.X, center.Y - 1000));
            //orig
            for(int i=0;i<dimnum;i++)
            {
                dc.DrawLine(dr.CoordLinePen, (view.ApplyTo(new DVector(dimnum)).ConvertTo2D(center)), (view.ApplyTo(1000 * DVector.GetOrt(i, dimnum))).ConvertTo2D(center));
            }
        }
    }
}
