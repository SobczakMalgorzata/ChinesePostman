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
			this(new HashSet<int>(E.SelectMany(e => new int[] { e.U, e.V })), E) { }
		/// <summary>
		/// Constructs a complete graph with k vertices with equal edge weights.
		/// </summary>
		/// <param name="k">Number of vertices in complete graph.</param>
		public Graph(int k) : this(Enumerable.Range(0,k))
		{
			for (int u = 0; u < k; u++)
			for (int v = 0; v < k; v++)
			{
				this.AddEdge(new Edge(u, v));
			}
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
			if (!vertices.Contains(e.U) || !vertices.Contains(e.V))
				throw new ArgumentException();
			Edges.Add(e);
		}
		public void RemoveEdge(Edge e)
		{
			Edges.Remove(e);
		}

		public bool IsConnected()
		{
			var paths = this.Distances();
			for (int u = 0; u < NumberOfVertices; u++)
			for (int v = u+1; v < NumberOfVertices; v++)
			{
				if (paths.Where(path => path.Connects(u,v)).Count() == 0)
				{
					return false;
				}
			}
			return true;
		}

		public List<Tuple<int,int>> Degrees()
		{
			var result = new List<Tuple<int, int>>();
			var verts = Vertices;
			var degrees = new int[NumberOfVertices];
			foreach (var edge in Edges)
			{
				degrees[verts.IndexOf(edge.U)]++;
				degrees[verts.IndexOf(edge.V)]++;                
			}
			for (int i = 0; i<NumberOfVertices; i++)
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
			throw new NotImplementedException();

		}
	}
}
