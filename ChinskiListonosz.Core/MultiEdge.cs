using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core
{
    public class MultiEdge : Edge
    {
        /// <summary>
        /// N is a number of edges in multigraph
        /// </summary>
        public int N { get; set; }

        public MultiEdge(int u, int v, int w, int n = 1) : base(u,v,w)
        {
            N = n;
        }

        public override bool Equals(object obj)
        {
            var other = obj as MultiEdge;
            if (other != null)
            {
                return base.Equals(obj) && this.N == other.N;
            }
            return false;    
        }
    }
}
