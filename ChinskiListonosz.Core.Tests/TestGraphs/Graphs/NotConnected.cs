using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core.Tests.TestGraphs.Graphs
{
    public partial class ExampleGraphs
    {
        public Graph NotConnected()
        {
            return new Graph()
            {
                Edges = new List<Edge>()
                {
                    new Edge(0, 4),
                    new Edge(1, 2),
                    new Edge(2, 3)
                }
            };
        }
    }
}
