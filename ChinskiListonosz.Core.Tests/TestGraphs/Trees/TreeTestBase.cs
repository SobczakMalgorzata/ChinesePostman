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
    }
}
