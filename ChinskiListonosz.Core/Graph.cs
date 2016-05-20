using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core
{
    public class Graph : IGraph
    {
        protected HashSet<int> vertices = new HashSet<int>();
        public List<int> Vertices { get { return vertices.ToList(); } }
        protected HashSet<Edge> edges = new HashSet<Edge>();
        public List<Edge> Edges { get { return edges.ToList(); } }

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
        public IGraph Subgraph(List<int> verticesSubset)
        {
            if (verticesSubset.All(v => vertices.Contains(v)))
                throw new ArgumentException("Some of vertices are not from this graph.");
            var edgesSubset = edges.Where(e => verticesSubset.Contains(e.U) && verticesSubset.Contains(e.V)).ToList();
            return new Graph(verticesSubset, edgesSubset);
        }

        public void AddVertice(int v)
        {
            vertices.Add(v);
        }
        public void RemoveVertice(int v)
        {
            vertices.Remove(v);
            edges.RemoveWhere(e => e.IsIncident(v));
        }

        public void AddEdge(Edge e)
        {
            if (vertices.Contains(e.U) && vertices.Contains(e.V))
                Edges.Add(e);
            else
                throw new ArgumentException();
        }
        public void RemoveEdge(Edge e)
        {
            Edges.Remove(e);
        }

        public bool IsConnected
        {
            get
            {
                var v = vertices.First();
                var reachable = new List<int>();
                var newReachable = new List<int>() { v };
                while (newReachable.Count > 0)
                {
                    reachable = reachable.Union(newReachable).ToList();
                    newReachable = newReachable.SelectMany(u => ConnectedTo(u)).ToList();
                    newReachable = newReachable.Except(reachable).ToList();
                }
                if (vertices.All(vertex => reachable.Contains(vertex)))
                    return true;
                return false;
            }
        }

        private List<int> ConnectedTo(int u)
        {
            return Edges.Where(e => e.IsIncident(u)).Select(e => e.OtherEndTo(u)).ToList();
        }

        public List<Tuple<int, int>> Degrees()
        {
            var result = new List<Tuple<int, int>>();
            var verts = Vertices;
            var degrees = new int[NumberOfVertices];
            foreach (var edge in Edges)
            {
                degrees[verts.IndexOf(edge.U)]++;
                degrees[verts.IndexOf(edge.V)]++;
            }
            for (int i = 0; i < NumberOfVertices; i++)
            {
                result.Add(new Tuple<int, int>(verts[i], degrees[i]));
            }
            return result;

        }

        public int NumberOfVertices
        {
            get
            {
                return this.Vertices.Count;
            }
        }

        public int NumberOfEdges
        {
            get
            {
                return this.Edges.Count;
            }
        }

        public List<Path> Distances()
        {
            List<Path> allDist;
            allDist = new List<Path>();
            foreach (var startVertex in Vertices)
            {
                allDist.AddRange(Dijkstra(startVertex));

            }
            return allDist.Distinct().ToList();
        }

        private List<Path> Dijkstra(int startVertex)
        {
            int[] dist = new int[NumberOfVertices];
            int[] prev = new int[NumberOfVertices];
            var unvisited = this.Vertices;

            for (int i = 0; i < NumberOfVertices; i++)
                dist[i] = int.MaxValue;
            dist[startVertex] = 0;

            var v = startVertex;

            while (unvisited.Count > 0)
            {
                var edgeList = this.Edges
                    .Where(e => e.IsIncident(v))
                    .Where(e => unvisited.Contains(e.OtherEndTo(v)))
                    .OrderBy(e => e.W)
                    .ToList();

                foreach (var e in edgeList)
                {
                    var u = e.OtherEndTo(v);
                    if (dist[v] + e.W < dist[u])
                    {
                        dist[u] = dist[v] + e.W;
                        prev[u] = v;
                    }
                }

                unvisited.Remove(v);
                v = unvisited.OrderBy(ver => dist[ver]).FirstOrDefault();
            }

            return RecreatePaths(startVertex, prev);
        }

        private List<Path> RecreatePaths(int startVertex, int[] prev)
        {
            var paths = new List<Path>();
            foreach (var ver in this.Vertices)
            {
                if (ver != startVertex)
                {
                    Path p = new Path(ver);
                    var a = ver;
                    var b = prev[ver];
                    while (a != startVertex)
                    {
                        p.AddToStart(this.Edges.Single(e => e.IsIncident(a) && e.IsIncident(b)));
                        a = b;
                        b = prev[a];
                    }
                    paths.Add(p);
                }
            }
            return paths;
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

