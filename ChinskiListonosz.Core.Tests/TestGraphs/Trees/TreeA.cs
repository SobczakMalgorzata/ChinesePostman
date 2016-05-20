using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinskiListonosz.Core;

namespace ChinskiListonosz.Core.Tests.TestGraphs.Trees
{
    public class TreeA : TreeTestBase
    {
        public TreeA()
        {
            var a = new Edge(0, 1);
            var b = new Edge(0, 2);
            var c = new Edge(0, 3);
            var d = new Edge(0, 4);
            var e = new Edge(2, 5);
            var f = new Edge(3, 6);
            var g = new Edge(4, 7);
            var h = new Edge(7, 8);
            var i = new Edge(7, 9);
            var j = new Edge(7, 10);
            var k = new Edge(10, 11);
            var l = new Edge(10, 12);
            var m = new Edge(10, 13);


            tree = new Graph
            (
                new List<Edge>() { a, b, c, d, e, f, g, h, i, j, k, l, m }
            );
            expectedReducedEdges = new List<Edge>() { a, e, f, g, h, i, k, l, m };
        }
    }
}
