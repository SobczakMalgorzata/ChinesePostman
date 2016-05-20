using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core
{
    public abstract class GraphBase : IGraph
    {
        public abstract List<Edge> Edges { get; }
        public abstract List<int> Vertices { get; }

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
            throw new NotImplementedException();
        }

        public abstract IGraph Subgraph(List<int> vertices);

        public abstract void AddVertice(int v);
        public abstract void RemoveVertice(int v);
        public abstract void AddEdge(Edge e);
        public abstract void RemoveEdge(Edge e);
    }
}
