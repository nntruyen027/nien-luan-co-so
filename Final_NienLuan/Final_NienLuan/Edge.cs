using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace Final_NienLuan
{
    public class Edge
    {
        public Color Color_Edge;
        public Node Start_Node { get; set; }
        public Node End_Node { get; set; }
        public int Weight { get; set; }

        
    }
}
