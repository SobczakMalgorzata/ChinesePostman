using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core.Tests.TestGraphs.Graphs
{
    public partial class ExampleGraphs
    {
        public Graph Envelope()
        {
            return new Graph()
            {
                Edges = new List<Edge>()
                {
                    new Edge(0, 1),
                    new Edge(0, 4),
                    new Edge(1, 2),
                    new Edge(1, 3),
                    new Edge(2, 3),
                    new Edge(3, 4)
                }
            };
        }
    }
}
