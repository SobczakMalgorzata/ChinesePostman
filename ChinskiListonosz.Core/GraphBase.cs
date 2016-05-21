using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core
{
    public abstract class GraphBase : IGraph
    {
        protected HashSet<int> vertices = new HashSet<int>();
        public List<int> Vertices { get { return vertices.ToList(); } }
        public abstract List<Edge> Edges { get; }

        public bool IsConnected
        {
            get
            {
                var v = Vertices.First();
                var reachable = new List<int>();
                var newReachable = new List<int>() { v };
                while (newReachable.Count > 0)
                {
                    reachable = reachable.Union(newReachable).ToList();
                    newReachable = newReachable.SelectMany(u => ConnectedTo(u)).ToList();
                    newReachable = newReachable.Except(reachable).ToList();
                }
                if (Vertices.All(vertex => reachable.Contains(vertex)))
                    return true;
                return false;
            }
        }

        private List<int> ConnectedTo(int u)
        {
            return Edges.Where(e => e.IsIncident(u)).Select(e => e.OtherEndTo(u)).ToList();
        }

        public abstract int NumberOfEdges { get; }
        public abstract int NumberOfVertices { get; }
        
        public List<Tuple<int, int>> Degrees()
        {
            var result = new List<Tuple<int, int>>();
            var verts = Vertices;
            var degrees = DegreesFromEdges(verts);
            
            for (int i = 0; i < NumberOfVertices; i++)
            {
                result.Add(new Tuple<int, int>(verts[i], degrees[i]));
            }
            return result;
        }

        protected abstract int[] DegreesFromEdges(List<int> vertices);

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

        protected List<Path> Dijkstra(int startVertex)
        {
            int[] dist = new int[NumberOfVertices];
            int?[] prev = new int?[NumberOfVertices];
            var unvisited = this.Vertices;

            for (int i = 0; i < NumberOfVertices; i++)
                dist[i] = int.MaxValue;
            dist[startVertex] = 0;

            var v = startVertex;

            while (unvisited.Count > 0)
            {
                var edgeList = this.Edges
                    .Distinct()
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

        protected List<Path> RecreatePaths(int startVertex, int?[] prev)
        {
            var paths = new List<Path>();
            foreach (var ver in this.Vertices)
            {
                if (ver != startVertex)
                {
                    Path p = new Path(ver);
                    var a = ver;
                    var b = prev[ver];

                    while (a != startVertex && b != null)
                    {
                        p.AddToStart(this.Edges.Single(e => e.IsIncident(a) && e.IsIncident((int)b)));
                        a = (int)b;
                        b = prev[a];
                    }
                    if (a == startVertex)
                        paths.Add(p);
                }
            }
            return paths;
        }

        public abstract IGraph Subgraph(List<int> vertices);

        public void AddVertice(int v)
        {
            vertices.Add(v);
        }
        public abstract void RemoveVertice(int v);
        public abstract void AddEdge(Edge e);
        public abstract void RemoveEdge(Edge e);
    }
}
