using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core
{
    public class MultiGraph : IGraph
    {
        protected HashSet<int> vertices = new HashSet<int>();
        public List<int> Vertices { get { return vertices.ToList(); } }
        protected Dictionary<Edge,int> edges = new Dictionary<Edge,int>();
        public List<Edge> Edges { get { return edges.Keys.ToList(); } }

        public MultiGraph()
        {
            throw new NotImplementedException();
        }
        
        public bool IsConnected
        {
            get { throw new NotImplementedException(); }
        }

        public int NumberOfEdges
        {
            get { return edges.Count(); }
        }

        public int NumberOfVertices
        {
            get
            {
                return vertices.Count();
            }
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

        public List<Path> Distances()
        {
            throw new NotImplementedException();
        }

        public IGraph Subgraph(List<int> vertices)
        {
            throw new NotImplementedException();
        }

        public void AddVertice(int v)
        {
            throw new NotImplementedException();
        }

        public void RemoveVertice(int v)
        {
            throw new NotImplementedException();
        }

        public void AddEdge(Edge e)
        {
            throw new NotImplementedException();
        }

        public void RemoveEdge(Edge e)
        {
            throw new NotImplementedException();
        }
    }
}
