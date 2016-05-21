using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChinskiListonosz.Core.Tests
{
    public static class TestMethodsExtension
    {
        public static void AssertSetlikeEqual<T>(this IEnumerable<T> collectionA, IEnumerable<T> collectionB)
        {
            var g1 = collectionA.GroupBy(t => t);
            var g2 = collectionB.GroupBy(t => t);

            foreach (var x in g1)
                Assert.Contains(x, g2);

            foreach (var y in g2)
                Assert.Contains(y, g1);


            foreach (var x in collectionA)
                Assert.Contains(x, collectionB);

            foreach (var y in collectionB)
                Assert.Contains(y, collectionA);
        }
        
        [Fact]
        public static void AssertSetLikeEqualTest()
        {
            var l1 = new List<int> { 1, 2, 2, 2, 3, 3, 4, 5, 6 };
            var l2 = new List<int> { 2, 3, 3, 4, 5, 6, 2, 2, 1 };

            l1.AssertSetlikeEqual(l2);
            l2.AssertSetlikeEqual(l1);
        }
    }


}
