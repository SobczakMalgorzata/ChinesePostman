using ChinskiListonosz.Core.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChinskiListonosz.Core.Tests.TestGraphs.Graphs
{
    public abstract class ConnectedGraphTestBase : GraphTestBase
    {
        [Fact]
        public void KruskalGivesMinimalTree()
        {
            var tree = graph.Kruskal();
            var edges = tree.Edges;

            edges.AssertSetlikeEqual(expectedTreeEdges);
        }

        [Fact]
        public void Postman()
        {
            var eulerCycle = graph.Postman(2);
            Assert.Equal(expectedEulerCycle, eulerCycle);
        }
    }
}
