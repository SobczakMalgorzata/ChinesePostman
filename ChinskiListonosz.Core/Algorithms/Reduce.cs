using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core.Algorithms
{
    public static partial class Al
    {
        public static IGraph Reduce(this IGraph tree)
        {
            var stays = new Dictionary<Edge, bool>();
            foreach (var edge in tree.Edges)
                stays.Add(edge, true);

            var dists = tree.Distances();

            var evenV = tree.Degrees()
                        .Where(vDeg => vDeg.Item2.IsEven())
                        .Select(tup => tup.Item1)
                        .ToList();

            for (int i = 0; i < evenV.Count(); i+=2)
            {
                var p = dists.Single(path => path.Connects(evenV[i], evenV[i + 1]));
                foreach (var edge in p.Edges)
                {
                    stays[edge] = !stays[edge];
                }
            }

            var selectedEdges = stays
                                .Where(keyValue => keyValue.Value)
                                .Select(keyValue => keyValue.Key)
                                .ToList();

            return new Graph(tree.Vertices, selectedEdges);
        }

        private static bool IsEven(this int x)
        {
            return x % 2 == 0;
        }
        private static bool IsOdd(this int x)
        {
            return x % 2 == 1;
        }
    }
}
