using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core
{
    public interface IGraph
    {
        List<Edge> Edges { get; }
        List<int> Vertices { get; }
        bool IsConnected();
        List<Tuple<int, int>> Degrees();
        int NumberOfVertices { get; }
        int NumberOfEdges{ get; }
        List<Path> Distances();
        //int ShortestPathFromTo();
    }
}