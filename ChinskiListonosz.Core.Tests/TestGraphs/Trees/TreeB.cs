using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core.Tests.TestGraphs.Trees
{
    public class TreeB : TreeTestBase
    {
        public TreeB()
        {
            var a = new Edge(0, 1);
            var b = new Edge(0, 2);
            var c = new Edge(0, 3);
            var d = new Edge(0, 4);
            var e = new Edge(0, 5);
            var f = new Edge(1, 6);
            var g = new Edge(2, 7);
            var h = new Edge(3, 8);
            var i = new Edge(4, 9);
            var j = new Edge(4, 10);
            var k = new Edge(5, 11);
            var l = new Edge(5, 12);
            var m = new Edge(5, 13);


            tree = new Graph(new List<Edge>() { a, b, c, d, e, f, g, h, i, j, k, l, m });

            expectedReducedEdges = new List<Edge>() { d, f, g, h, i, j, k, l, m };
        }
    }
}
