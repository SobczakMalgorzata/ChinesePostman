using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core
{
    public interface IGraph
    {
        bool IsConnected();
        int[] Degrees();
        int NumberOfVertices();
        int NumberOfEdges();
        int[,] Distances();
        //int ShortestPathFromTo();
    }
}