using ChinskiListonosz.Core.Algorithms;
using System;
using System.Collections.Generic;
using Xunit;

namespace ChinskiListonosz.Core.Tests.TestGraphs.Graphs
{
    public abstract class GraphTestBase
    {
        protected IGraph graph;
        protected int expectedNEdges;
        protected int expectedNVertices;
        protected bool expectedIsConnected;
        protected List<Tuple<int, int>> expectedDegrees;
        protected List<Path> expectedPaths;
        protected List<Edge> expectedTreeEdges;
        protected Path expectedEulerCycle;

        [Fact]
        public void IsConnectedTest()
        {
            Assert.Equal(expectedIsConnected, graph.IsConnected);
        }

        [Fact]
        public void DegreesTest()
        {
            var result = graph.Degrees();
            result.AssertSetlikeEqual(expectedDegrees);
        }

        [Fact]
        public void NumberOfEdgesTest()
        {
            Assert.Equal(expectedNEdges, graph.NumberOfEdges);
        }

        [Fact]
        public void NumberOfVerticesTest()
        {
            Assert.Equal(expectedNVertices, graph.NumberOfVertices);
        }

        [Fact]
        public void DistancesTableTest()
        {
            var result = graph.Distances();
            result.AssertSetlikeEqual(expectedPaths);
        }

        [Fact]
        public void KruskalGivesTree()
        {
            if (graph.IsConnected)
            {
                var tree = graph.Kruskal();
                Assert.True(tree.IsConnected);
                Assert.Equal(expectedNVertices - 1, tree.NumberOfEdges);
                Assert.Equal(expectedNVertices, tree.NumberOfVertices);
            }
            else
                Assert.Throws<ArgumentException>(() => graph.Kruskal());
        }

        
    }
}