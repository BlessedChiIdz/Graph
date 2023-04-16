using Avalonia.Controls.Shapes;
using Newtonsoft.Json;

namespace Graph.Models
{
    public class CanvasModel
    {
        public string Name { get; set; }
        
        public virtual Line? line { get; set; }

        public virtual Polyline? pLine { get; set; }

        public virtual Rectangle? Rec { get; set; }

        public virtual Ellipse? El { get; set; }

        public virtual Path? P { get; set; }
        

    }
}
