using Avalonia.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Models
{
    public class CanvasModel
    {
        public string? Name { get; set; }
        public Line? line { get; set; }
        public Polyline? pLine { get; set; }
        public Rectangle? Rec { get; set; }
        public Ellipse? El { get; set; }
        public Path? P { get; set; }
    }
}
