using ChinskiListonosz.Core.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChinskiListonosz.Core.Tests.TestGraphs.Trees
{
    public abstract class TreeTestBase
    {
        protected IGraph tree;
        protected List<Edge> expectedReducedEdges;

        [Fact]
        public void ReturnsExpectedReduced()
        {
            var edges = tree.Reduce().Edges;

            edges.AssertSetlikeEqual(expectedReducedEdges);
        }

        [Fact]
        public void PostmanTest()
        {
            var startingPoint = 4;
            var eulerCycle = tree.Postman(startingPoint);

            Assert.Equal(eulerCycle.Start, startingPoint);
            Assert.Equal(eulerCycle.End, startingPoint);

            foreach (var edge in eulerCycle.Edges)
            {
                Assert.Contains(edge, tree.Edges);
            }

            for (int i = 0; i < eulerCycle.Edges.Count(); i++)
            {
                Assert.True(eulerCycle.Edges.ElementAt(i).IsIncident(eulerCycle.Edges.ElementAt(i % eulerCycle.Edges.Count)));
            }

            eulerCycle.Edges.Distinct().AssertSetlikeEqual(tree.Edges);
        }

        private void EmptyAction()
        {

        }
    }
}
