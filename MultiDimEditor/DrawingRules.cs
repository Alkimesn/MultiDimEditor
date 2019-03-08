using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MultiDimEditor
{
    enum DrawMode { Normal, CrossSection, Perspective}
    class DrawingRules
    {
        public double PointWidth { get; set; }
        public double LineWidth { get; set; }
        public double SelPointWidth { get; set; }
        public double SelLineWidth { get; set; }
        public Brush PointBrush { get; set; }
        public Brush SelPointBrush { get; set; }
        public Pen LinePen { get; set; }
        public Pen SelLinePen { get; set; }
        public Pen CoordLinePen { get; set; }
        public Pen BaseCoordLinePen { get; set; }
        public Brush FaceBrush { get; set; }
        public DrawMode DrawMode { get; set; }
        public bool DrawCoordLines { get; set; }
        public DrawingRules()
        {
            PointWidth = 3;
            LineWidth = 1;
            SelPointWidth = 4;
            SelLineWidth = 2;
            PointBrush = Brushes.Black;
            LinePen = new Pen(Brushes.Black, LineWidth);
            SelPointBrush = Brushes.Purple;
            SelLinePen = new Pen(Brushes.Purple, SelLineWidth);
            CoordLinePen = new Pen(Brushes.Red, LineWidth);
            BaseCoordLinePen = new Pen(Brushes.Blue, LineWidth);
            FaceBrush = new SolidColorBrush(Color.FromArgb(50, 64, 64, 64));
            DrawMode = DrawMode.Normal;
            DrawCoordLines = true;
        }
        public static List<Color> AllColors = new List<Color>() { Colors.Black, Colors.Red, Colors.Green, Colors.Blue, Colors.Cyan, Colors.Magenta, Colors.Yellow };
    }
}
