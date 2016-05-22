using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChinskiListonosz.Core.Tests
{
    public class PathTests
    {
        [Fact]
        public void EnumerableConstructor()
        {
            var e1 = new Edge(1, 2);
            var e2 = new Edge(3, 2);
            var e3 = new Edge(3, 4);

            var list = new List<Edge>() { e1, e2, e3 };

            var path = new Path(list);

            Assert.Equal(list, path.Edges.ToList());
        }

        [Fact]
        public void PathLengthIs3()
        {
            var e1 = new Edge(1, 2);
            var e2 = new Edge(3, 2);
            var e3 = new Edge(3, 4);

            var list = new List<Edge>() { e1, e2, e3 };

            var path = new Path(list);
            Assert.Equal(3, path.Length);
        }

        [Fact]
        public void InsertAtBeggining()
        {
            var e1 = new Edge(1, 2);
            var e2 = new Edge(3, 2);
            var e3 = new Edge(3, 4);

            var list = new List<Edge>() { e1, e2, e3 };

            var path = new Path(list);

            var listCycle = new List<Edge>() { e1, e1 };
            var pathCycle = new Path(listCycle);

            var expectedPath = new Path(new List<Edge>() { e1, e1, e1, e2, e3 });
            Assert.Equal(expectedPath, path.InsertAtSuitable(pathCycle));
        }

        [Fact]
        public void InsertAtEnd()
        {
            var e1 = new Edge(1, 2);
            var e2 = new Edge(3, 2);
            var e3 = new Edge(3, 4);
            var list = new List<Edge>() { e1, e2, e3 };
            var path = new Path(list);

            var listCycle = new List<Edge>() { e3, e3 };
            var pathCycle = new Path(listCycle);

            var expectedPath = new Path(new List<Edge>() { e1, e2, e3, e3, e3 });
            Assert.Equal(expectedPath, path.InsertAtSuitable(pathCycle));
        }

        [Fact]
        public void InsertInMiddle()
        {
            var e1 = new Edge(1, 2);
            var e2 = new Edge(3, 2);
            var e3 = new Edge(3, 4);
            var list = new List<Edge>() { e1, e2, e3 };
            var path = new Path(list);

            var listCycle = new List<Edge>() { e2, e2 };
            var pathCycle = new Path(listCycle);

            var expectedPath = new Path(new List<Edge>() { e1, e2, e2, e2, e3 });
            Assert.Equal(expectedPath, path.InsertAtSuitable(pathCycle));
        }
    }
}
