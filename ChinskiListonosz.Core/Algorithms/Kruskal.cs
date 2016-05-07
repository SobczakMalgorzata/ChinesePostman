using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core.Algorithms
{
    public static class GraphAlgorithms
    {
        public static Graph Kruskal(this IGraph graph)
        {
            if (!graph.IsConnected)
                throw new ArgumentException("Input graph must be connected!");
            var kruskal = new List<Edge>();
            var forest = new List<List<int>>();
            int uIndex = 0;
            int vIndex = 0;

            var rand = new System.Random();
            var edges = new HashSet<Edge>(graph.Edges.OrderBy(edge => rand.Next()).ToList());

            foreach (var edge in graph.Edges)
            {
                var indexes = FindSubTreesIndexes(forest, edge);
                uIndex = indexes.Key;
                vIndex = indexes.Value;
                if (uIndex == -1 && vIndex == -1)
                {
                    forest.Add(new List<int> { edge.U, edge.V });
                    kruskal.Add(edge);
                }
                else if (uIndex == -1)
                {
                    forest[vIndex].Add(edge.U);
                    kruskal.Add(edge);
                }
                else if (vIndex == -1)
                {
                    forest[uIndex].Add(edge.V);
                    kruskal.Add(edge);
                }
                else if (uIndex != vIndex)
                {
                    forest[uIndex].AddRange(forest[vIndex]);
                    forest.RemoveAt(vIndex);
                    kruskal.Add(edge);
                }
            }
            return new Graph(new HashSet<Edge>(kruskal));
        }

        private static KeyValuePair<int, int> FindSubTreesIndexes(List<List<int>> forest, Edge edge)
        {
            int uIndex = -1;
            int vIndex = -1;
            //uIndex = forest.IndexOf(forest.Where(subTree => subTree.Contains(edge.U));
            //vIndex = forest.IndexOf(forest.Where(subTree => subTree.Contains(edge.V));
            foreach (List<int> subTreeVertices in forest)
            {
                if (subTreeVertices.Contains(edge.U))
                    uIndex = forest.IndexOf(subTreeVertices);

                if (subTreeVertices.Contains(edge.V))
                    vIndex = forest.IndexOf(subTreeVertices);
            }
            return new KeyValuePair<int, int>(uIndex, vIndex);
        }
    }
}
