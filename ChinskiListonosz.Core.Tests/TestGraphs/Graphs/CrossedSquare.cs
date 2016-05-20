using ChinskiListonosz.Core.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChinskiListonosz.Core.Tests.TestGraphs.Graphs
{
    public class CroseedSquare : GraphTestBase
    {
        public CroseedSquare()
        {
            var a = new Edge(0, 1, 1);
            var b = new Edge(0, 2, 5);
            var f = new Edge(0, 3, 10);

            var e = new Edge(1, 2, 7);
            var c = new Edge(1, 3, 3);

            var d = new Edge(2, 3, 8);
            

            graph =
            new Graph(
                new List<Edge>() { a, b, c, d, e, f }
            );

            this.expectedIsConnected = true;
            this.expectedNEdges = 6;
            this.expectedNVertices = 4;


            this.expectedDegrees = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0,3),
                new Tuple<int, int>(1,3),
                new Tuple<int, int>(2,3),
                new Tuple<int, int>(3,3)
            };

            this.expectedPaths = new List<Path>()
            {
                //From 0
                new Path(new List<Edge> {a}, 0),
                new Path(new List<Edge> {b}, 0),
                new Path(new List<Edge> {a,c}, 0),
                //From 1
                new Path(new List<Edge> {a,b}, 1),
                new Path(new List<Edge> {c}, 1),
                //From 2
                new Path(new List<Edge> {d}, 2)
            };

            this.expectedTreeEdges = new List<Edge>() { a, b, c };
            this.expectedEdgesToDuplicate = new List<Edge> { a, d };
        }


    }
}
