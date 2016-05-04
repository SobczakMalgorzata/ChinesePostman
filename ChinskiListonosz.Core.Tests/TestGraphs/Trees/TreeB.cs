using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core.Tests.TestGraphs.Trees
{
    public partial class ExampleTrees
    {
        public Graph TreeB()
        {
            return new Graph(
                new List<Edge>()
                {
                    new Edge(0, 1),
                    new Edge(0, 2),
                    new Edge(0, 3),
                    new Edge(0, 4),
                    new Edge(0, 5),
                    new Edge(1, 6),
                    new Edge(2, 7),
                    new Edge(3, 8),
                    new Edge(4, 9),
                    new Edge(4, 10),
                    new Edge(5, 11),
                    new Edge(5, 12),
                    new Edge(5, 13)
                }
            );
        }
    }
}
