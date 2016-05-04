using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinskiListonosz.Core;

namespace ChinskiListonosz.Core.Tests.TestGraphs.Trees
{
    public partial class ExampleTrees
    {
        public Graph TreeA()
        {
            return new Graph()
            {
                Edges = new List<Edge>()
                {
                    new Edge(0, 1),
                    new Edge(0, 2),
                    new Edge(0, 3),
                    new Edge(0, 4),
                    new Edge(2, 5),
                    new Edge(3, 6),
                    new Edge(4, 7),
                    new Edge(7, 8),
                    new Edge(7, 9),
                    new Edge(7, 10),
                    new Edge(10, 11),
                    new Edge(10, 12),
                    new Edge(10, 13)
                }
            }; 
        }
    }
}
