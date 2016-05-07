using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core
{
    public interface IGraph
    {
        /// <summary>
        /// Returns a list of edges from the graph.
        /// </summary>
        List<Edge> Edges { get; }
        /// <summary>
        /// Returns an unordered list of vertices from the graph.
        /// </summary>
        List<int> Vertices { get; }
        /// <summary>
        /// Checks if the graph is connected.
        /// </summary>
        /// <returns></returns>
        bool IsConnected { get; }
        /// <summary>
        /// Creates a list of degrees of vertices.
        /// </summary>
        /// <returns>List of pairs (vertex number, vertex degree).</returns>
        List<Tuple<int, int>> Degrees();
        /// <summary>
        /// Returns number of vertices in graph.
        /// </summary>
        int NumberOfVertices { get; }
        /// <summary>
        /// Returns number of edges in graph.
        /// </summary>
        int NumberOfEdges{ get; }
        /// <summary>
        /// Calculates shortest paths between all vertices in graph.
        /// </summary>
        /// <returns>List of Paths connecting different vertices.</returns>
        List<Path> Distances();
    }
}