using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinskiListonosz.Core
{
    public static class IntExtensions
    {
        public static bool IsEven(this int x)
        {
            return x % 2 == 0;
        }
        public static bool IsOdd(this int x)
        {
            return x % 2 == 1;
        }
    }
}
