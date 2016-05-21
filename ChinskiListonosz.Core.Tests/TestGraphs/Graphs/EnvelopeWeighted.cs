using ChinskiListonosz.Core.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChinskiListonosz.Core.Tests.TestGraphs.Graphs
{
    public class EnvelopeWeighted : GraphTestBase
    {
        public EnvelopeWeighted()
        {
            var a = new Edge(0, 1);
            var b = new Edge(0, 4);
            var e = new Edge(1, 2, 2);
            var c = new Edge(1, 3, 10);
            var f = new Edge(2, 3, 4);
            var d = new Edge(3, 4);

            graph =
            new Graph(
                new List<Edge>() { a,b,c,d,e,f }
            );

            this.expectedIsConnected = true;
            this.expectedNEdges = 6;
            this.expectedNVertices = 5;

           
            this.expectedDegrees = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0,2),
                new Tuple<int, int>(1,3),
                new Tuple<int, int>(2,2),
                new Tuple<int, int>(3,3),
                new Tuple<int, int>(4,2)
            };

            this.expectedPaths = new List<Path>()
            {
                //From 0
                new Path(new List<Edge> {a}, 0),
                new Path(new List<Edge> {a,e}, 0),
                new Path(new List<Edge> {b,d}, 0),
                new Path(new List<Edge> {b}, 0),
                //From 1
                new Path(new List<Edge> {e}, 1),
                new Path(new List<Edge> {a,b,d}, 1),
                new Path(new List<Edge> {a,b}, 1),
                //From 2
                new Path(new List<Edge> {f}, 2),
                new Path(new List<Edge> {e,a,b}, 2),
                //From 3
                new Path(new List<Edge> {d}, 3)
            };

            this.expectedTreeEdges = new List<Edge>() { a, b, d, e };
            this.expectedEdgesToDuplicate = new List<Edge>() { a, b, d };
        }

        
    }
}
