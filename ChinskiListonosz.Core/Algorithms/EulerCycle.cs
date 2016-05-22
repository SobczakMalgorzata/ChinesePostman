using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core.Algorithms
{
    public static partial class GraphAlgorithms
    {
        public static Path EulerCycle(this IGraph graph, int start)
        {
            if (graph.Degrees().Any(tp => tp.Item2.IsOdd()))
                throw new ArgumentException("Graph is not an Euler Graph");

            List<Edge> remainingEdges = graph.Edges;
            Path result = FindCycle(remainingEdges, start);
            while (remainingEdges.Count > 0)
            {
                start = remainingEdges.Select(e => result.VisitedVertices.First(i => e.IsIncident(i))).First();
                result.InsertAtSuitable(FindCycle(remainingEdges, start));
            }
            return result;
        }

        private static Path FindCycle(List<Edge> edges, int start)
        {
            Path result = new Path(start);
            Edge nextEdge;
            int nextV = start;

            while (nextV != start || result.Length == 0)
            {
                nextEdge = edges.Find(e => e.IsIncident(nextV));
                result.AddToEnd(nextEdge);
                nextV = nextEdge.OtherEndTo(nextV);
                edges.Remove(nextEdge);
            }
            return result;
        }
    }
}
