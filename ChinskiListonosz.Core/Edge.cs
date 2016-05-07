using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core
{
    public class Edge
    {

        public int U { get; }
        public int V { get; }
        public int W { get; }

        public Edge(int u, int v, int w = 1)
        {
            U = u;
            V = v;
            W = w;
        }

        public Edge(Edge e) : this(e.U, e.V, e.W) { }
        public Edge Clone() { return new Edge(this); }

        public bool IsIncident(int v)
        {
            return (U == v || V == v);
        }

        public int OtherEndTo(int u)
        {
            if (U == u)
                return V;
            return U;
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

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 13;
            hash = hash * 7 + U.GetHashCode();
            hash = V.GetHashCode();
            hash = hash * 7 + W.GetHashCode();
            return hash;
        }
    }
}
