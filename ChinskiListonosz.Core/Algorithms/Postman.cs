using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core.Algorithms
{
    public static partial class GraphAlgorithms
    {
        public static Path Postman(this IGraph graph, int startPoint)
        {
            var Odds = graph.Degrees().Where(vdeg => vdeg.Item2.IsOdd()).Select(vdeg => vdeg.Item1).ToList();
            var Eprime = new List<Edge>(graph.Edges);

            if(Odds.Count < 2)
            {
                return graph.EulerCycle(startPoint);
            }

            else if (Odds.Count == 2)
            {
                var additionalPath = graph.Distances()
                                    .Where(p => p.Connects(Odds[0], Odds[1]))
                                    .OrderBy(p => p.Length)
                                    .First();

                Eprime.AddRange(additionalPath.Edges);

            }

            else
            {
                var distances = graph.Distances();
                var OddsPaths = distances.Where(p => Odds.Contains(p.Start) && Odds.Contains(p.End));
                var HEdges = OddsPaths.Select(p => new Edge(p.Start, p.End, p.Length));
                var H = new Graph(Odds, HEdges);
                var T = H.Kruskal();
                var Tprime = T.Reduce();

                Eprime.AddRange(Tprime.Edges);
            }
            var Gprime = new MultiGraph(graph.Vertices, Eprime);
            return Gprime.EulerCycle(startPoint);
        }
    }
}
