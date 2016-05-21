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
            foreach (var x in collectionA)
                Assert.Contains(x, collectionB);

            foreach (var y in collectionB)
                Assert.Contains(y, collectionA);
        }
    }
}
