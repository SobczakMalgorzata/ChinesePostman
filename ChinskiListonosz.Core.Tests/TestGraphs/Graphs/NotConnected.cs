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
            var a = new Edge(0, 4);
            var b = new Edge(1, 2);
            var c = new Edge(2, 3);

            graph = new Graph
            (
                new List<Edge>() { a, b, c }
            );
            this.expectedIsConnected = false;
            this.expectedNEdges = 3;
            this.expectedNVertices = 5;
            this.expectedDegrees = new List<Tuple<int, int>> {
                new Tuple<int, int>(0,1),
                new Tuple<int, int>(1,1),
                new Tuple<int, int>(2,2),
                new Tuple<int, int>(3,1),
                new Tuple<int, int>(4,1)
            };
            this.expectedPaths = new List<Path>()
            {
                new Path(new List<Edge>() { a }),
                new Path(new List<Edge>() { b }),
                new Path(new List<Edge>() { c }),
                new Path(new List<Edge>() { b, c })
            };
        }
    }
}
