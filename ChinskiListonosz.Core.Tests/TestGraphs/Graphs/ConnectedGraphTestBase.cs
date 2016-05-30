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
        protected List<Path> expectedEulerCycles;

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
            var startingPoint = 2;
            var eulerCycle = graph.Postman(startingPoint);

            Assert.Equal(eulerCycle.Start, startingPoint);
            Assert.Equal(eulerCycle.End, startingPoint);

            foreach (var edge in eulerCycle.Edges)
            {
                Assert.Contains(edge, graph.Edges);
            }

            for(int i =0; i< eulerCycle.Edges.Count(); i++)
            {
                Assert.True(eulerCycle.Edges.ElementAt(i).IsIncident(eulerCycle.Edges.ElementAt(i % eulerCycle.Edges.Count)));
            }

            eulerCycle.Edges.Distinct().AssertSetlikeEqual(graph.Edges);
        }
    }
}
 