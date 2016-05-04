using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core.Tests.TestGraphs.Graphs
{
    public class NotConnected : GraphTestBase
    {
        public NotConnected()
        {
            graph = new Graph
            (
                new List<Edge>()
                {
                    new Edge(0, 4),
                    new Edge(1, 2),
                    new Edge(2, 3)
                }
            );
            this.expectedIsConnected = true;
            this.expectedNEdges = 3;
            this.expectedNVertices = 5;
            this.expectedDegrees = new List<Tuple<int, int>> {
                new Tuple<int, int>(0,1),
                new Tuple<int, int>(1,1),
                new Tuple<int, int>(2,2),
                new Tuple<int, int>(3,1),
                new Tuple<int, int>(4,1)
            };
            this.expectedPaths = new List<Path>() { };
        }
    }
}
