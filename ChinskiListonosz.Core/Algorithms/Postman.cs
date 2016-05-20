using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core.Algorithms
{
    public static partial class GraphAlgorithms
    {
        public static Path Postman(IGraph graph, int StartPoint)
        {
            throw new NotImplementedException();
            var Odds = graph.Degrees().Where(vdeg => vdeg.Item2 % 2 == 1).Select(vdeg => vdeg.Item1).ToList();
            if(Odds.Count < 2)
            {

            }
            else if (Odds.Count == 2)
            {

            }
            else
            {
                var distances = graph.Distances();
                var OddsPaths = distances.Where(p => Odds.Contains(p.Start) && Odds.Contains(p.End));
                var HEdges = OddsPaths.Select(p => new Edge(p.Start, p.End, p.Length));
                var H = new Graph(Odds, HEdges);
                var T = H.Kruskal();
                var Tprime = T.Reduce();
                var GprimeEdges = new List<Edge>(graph.Edges);
                GprimeEdges.AddRange(Tprime.Edges);
                //var Gprime = new MultiGraph(graph.Vertices, GprimeEdges);

            }

        }
    }
}
