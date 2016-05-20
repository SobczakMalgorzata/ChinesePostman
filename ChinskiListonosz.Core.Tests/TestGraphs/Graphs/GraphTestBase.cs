using ChinskiListonosz.Core.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
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
        protected List<Edge> expectedEdgesToDuplicate;

        [Fact]
        public void IsConnectedTest()
        {
            Assert.Equal(expectedIsConnected, graph.IsConnected);
        }

        [Fact]
        public void DegreesTest()
        {
            var result = graph.Degrees();
            foreach (var x in result)
                Assert.Contains(x, expectedDegrees);
            
            foreach (var ed in expectedDegrees)
                Assert.Contains(ed, result);
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
            foreach (var x in result)
                Assert.Contains(x, expectedPaths);

            foreach (var expath in expectedPaths)
                Assert.Contains(expath, result);
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

        [Fact]
        public void KruskalGivesMinimalTree()
        {
            if(graph.IsConnected)
            {
                var tree = graph.Kruskal();
                var edges = tree.Edges;

                foreach (var e in edges)
                    Assert.Contains(e, expectedTreeEdges);

                foreach (var exedge in expectedTreeEdges)
                    Assert.Contains(exedge, edges);
            }
            
        }

        [Fact(Skip = "Hangs tests")]
        public void GetsProperEdgeDoubles()
        {
            
        }

        [Fact(Skip = "Hangs tests")]
        public void Postman()
        {

        }
    }
}