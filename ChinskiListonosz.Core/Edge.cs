using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core
{
    public class Edge
    {

        public int U { get; set; }
        public int V { get; set; }
        public int W { get; set; }

        public Edge(int u, int v, int w = 1)
        {
            U = u;
            V = v;
            W = w;
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Edge return false.
            Edge otherEdge = obj as Edge;
            return this.Equals(otherEdge);
        }

        public bool Equals(Edge otherEdge)
        {
            // If parameter is null return false:
            if ((object)otherEdge == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (W == otherEdge.W 
                    && ((U == otherEdge.U && V == otherEdge.V) || (U == otherEdge.V && V == otherEdge.U)));
        }
    }
}
