using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core
{
    public class MultiGraph : GraphBase
    {
        protected Dictionary<Edge,int> edges = new Dictionary<Edge,int>();
        public override List<Edge> Edges
        {
            get
            {
               return edges.SelectMany(edgeN => Enumerable.Repeat(edgeN.Key, edgeN.Value)).ToList();
            }
        }
        
        public MultiGraph(IEnumerable<int> V, IEnumerable<Edge> E)
        {
            if (E.Any(e => !V.Contains(e.U) || !V.Contains(e.V)))
                throw new ArgumentException("Edges can only connect Vertices from V!");
            vertices = new HashSet<int>(V);
            edges = E.GroupBy(e => e).ToDictionary(g => g.Key, g => g.Count());
        }
        public MultiGraph(IEnumerable<Edge> E) : this( E.SelectMany(e => new int[] { e.U, e.V }), E) { }
        public MultiGraph(IGraph G) : this(G.Vertices, G.Edges) { }

        public override int NumberOfEdges { get { return edges.Sum(edgeN => edgeN.Value); } }
        public override int NumberOfVertices { get { return vertices.Count(); } }


        public override IGraph Subgraph(List<int> vertices)
        {
            throw new NotImplementedException();
        }

        public override void RemoveVertice(int v)
        {
            vertices.Remove(v);
            foreach(var edgeN in edges.Where(e => e.Key.IsIncident(v)))
            {
                edges.Remove(edgeN.Key);
            }
        }

        public override void AddEdge(Edge e)
        {
            if (edges.ContainsKey(e))
                edges[e]++;
            else
                edges.Add(e, 1);
        }

        public override void RemoveEdge(Edge e)
        {
            if (edges[e] == 1)
                edges.Remove(e);
            else
                edges[e]--;
        }

        protected override int[] DegreesFromEdges(List<int> vertices)
        {
            var degrees = new int[NumberOfVertices];
            foreach (var edgeN in edges)
            {
                degrees[vertices.IndexOf(edgeN.Key.U)] += edgeN.Value;
                degrees[vertices.IndexOf(edgeN.Key.V)] += edgeN.Value;
            }

            return degrees;
        }
    }
}
