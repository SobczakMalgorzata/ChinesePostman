using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core
{
    public class Graph : GraphBase
    {
        protected HashSet<Edge> edges = new HashSet<Edge>();
        public override List<Edge> Edges { get { return edges.ToList(); } }

        public Graph(IEnumerable<int> V, IEnumerable<Edge> E)
        {
            if (E.Any(e => !V.Contains(e.U) || !V.Contains(e.V)))
                throw new ArgumentException("Edges can only connect Vertices from V!");
            vertices = new HashSet<int>(V);
            edges = new HashSet<Edge>(E);
        }
        public Graph() : this(new HashSet<int>(), new HashSet<Edge>()) { }
        public Graph(IEnumerable<int> V) : this(V, new HashSet<Edge>()) { }
        public Graph(IEnumerable<Edge> E) :
            this(new HashSet<int>(E.SelectMany(e => new int[] { e.U, e.V })).Distinct(), E)
        { }
        /// <summary>
        /// Constructs a complete graph with k vertices with equal edge weights.
        /// </summary>
        /// <param name="k">Number of vertices in complete graph.</param>
        public Graph(int k) : this(Enumerable.Range(0, k))
        {
            for (int u = 0; u < k; u++)
                for (int v = 0; v < k; v++)
                {
                    this.AddEdge(new Edge(u, v));
                }
        }
        public Graph(Graph g) : this(g.Vertices, g.edges.Select(e => e.Clone())) { }
        public Graph Clone()
        {
            return new Graph(this);
        }
        public override IGraph Subgraph(List<int> verticesSubset)
        {
            if (verticesSubset.All(v => vertices.Contains(v)))
                throw new ArgumentException("Some of vertices are not from this graph.");
            var edgesSubset = edges.Where(e => verticesSubset.Contains(e.U) && verticesSubset.Contains(e.V)).ToList();
            return new Graph(verticesSubset, edgesSubset);
        }

        public override void RemoveVertice(int v)
        {
            vertices.Remove(v);
            edges.RemoveWhere(e => e.IsIncident(v));
        }

        public override void AddEdge(Edge e)
        {
            if (vertices.Contains(e.U) && vertices.Contains(e.V))
                Edges.Add(e);
            else
                throw new ArgumentException();
        }
        public override void RemoveEdge(Edge e)
        {
            Edges.Remove(e);
        }
        
        protected override int[] DegreesFromEdges(List<int> vertices)
        {
            var degrees = new int[NumberOfVertices];
            foreach (var edge in Edges)
            {
                degrees[vertices.IndexOf(edge.U)]++;
                degrees[vertices.IndexOf(edge.V)]++;
            }

            return degrees;
        }

        public override int NumberOfVertices
        {
            get
            {
                return this.Vertices.Count;
            }
        }

        public override int NumberOfEdges
        {
            get
            {
                return this.Edges.Count;
            }
        }

        //override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var theOther = obj as Graph;
            return vertices.SetEquals(theOther.vertices) && edges.SetEquals(theOther.edges);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            var hash = 13 + vertices.GetHashCode() + 7 * edges.GetHashCode();
            return hash;
        }
    }
}

