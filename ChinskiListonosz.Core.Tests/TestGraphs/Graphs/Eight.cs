using ChinskiListonosz.Core.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChinskiListonosz.Core.Tests.TestGraphs.Graphs
{
    public class Eight : GraphTestBase
    {
        static Edge a = new Edge(0, 1, 1);
        static Edge b = new Edge(0, 2, 2);
        static Edge c = new Edge(1, 6, 3);
        static Edge d = new Edge(2, 6, 4);
        static Edge e = new Edge(3, 6, 6);
        static Edge f = new Edge(4, 6, 5);
        static Edge g = new Edge(3, 5, 10);
        static Edge h = new Edge(4, 5, 8);

        public Eight()
        {
            graph = new MultiGraph(new List<Edge>() { a, b, c, d, e, f, g, h });
            this.expectedIsConnected = true;
            this.expectedNEdges = 8;
            this.expectedNVertices = 7;

            this.expectedDegrees = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0,2),
                new Tuple<int, int>(1,2),
                new Tuple<int, int>(2,2),
                new Tuple<int, int>(3,2),
                new Tuple<int, int>(4,2),
                new Tuple<int, int>(5,2),
                new Tuple<int, int>(6,4)
            };

            this.expectedPaths = new List<Path>()
            {
                //From 0
                new Path(new List<Edge> {a}, 0),
                new Path(new List<Edge> {b}, 0),
                new Path(new List<Edge> {a,c,e}, 0),
                new Path(new List<Edge> {a,c,f}, 0),
                new Path(new List<Edge> {a,c,f,h}, 0),
                new Path(new List<Edge> {a,c}, 0),
                //From 1
                new Path(new List<Edge> {a,b}, 1),
                new Path(new List<Edge> {c,e}, 1),
                new Path(new List<Edge> {c,f}, 1),
                new Path(new List<Edge> {c,f,h}, 1),
                new Path(new List<Edge> {c}, 1),
                //From 2
                new Path(new List<Edge> {d,e}, 2),
                new Path(new List<Edge> {d,f}, 2),
                new Path(new List<Edge> {d,f,h}, 2),
                new Path(new List<Edge> {d}, 2),
                //From 3
                new Path(new List<Edge> {e,f}, 3),
                new Path(new List<Edge> {g}, 3),
                new Path(new List<Edge> {e}, 3),
                //From 4
                new Path(new List<Edge> {h}, 4),
                new Path(new List<Edge> {f}, 4),
                //From 5
                new Path(new List<Edge> {h, f}, 5)
            };

            this.expectedTreeEdges = new List<Edge>() { a, b, c, e, f, h };
        }

        [Fact]
        public void CalculatesEulerCycle()
        {
            var result = graph.EulerCycle(5);

            var possibleCycles = new List<Path>()
            {
                new Path(new List<Edge>() { h, f, c, a, b, d, e, g }),
                new Path(new List<Edge>() { h, f, d, b, a, c, e, g }),
                new Path(new List<Edge>() { g, e, c, a, b, d, f, h }),
                new Path(new List<Edge>() { g, e, c, a, b, d, f, h })
            };

            Assert.Contains(result, possibleCycles);


        }
    }
}
