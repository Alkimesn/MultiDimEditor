using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MultiDimEditor
{
    class VisualHost : UIElement
    {
        public Visual visual;
        protected override int VisualChildrenCount
        {
            get
            {
                return visual != null ? 1 : 0;
            }
        }
        protected override Visual GetVisualChild(int index)
        {
            return visual;
        }
    }
}
