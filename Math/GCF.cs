using System.Collections.Generic;
using System.Linq;

namespace Math
{
    public static class Math
    {
        public static int Gcf(params int[] integers)
        {
            if (integers.Length == 1)
            {
                return integers[0];
            }
            var gfc = 1;
            var min = integers.Min();
            if (integers.All(integer => integer % min == 0))
            {
                return min;
            }
            var factors = GetFactors(min);
            factors = factors.OrderByDescending(value => value).ToList();
            foreach (var factor in factors)
            {
                if (integers.All(integer => integer % factor == 0))
                {
                    return factor;
                }
            }
            return gfc;
        }

        public static ICollection<int> GetFactors(int integer)
        {
            var factors = new List<int>();
            factors.AddRange(new []{ 1, integer });
            for (var i = 2; i < integer / 2; i++)
            {
                if (integer % i == 0)
                {
                    factors.AddRange(new []{i, integer / i});
                }
            }
            return factors;
        }

        public static int EuclidGcf(params int[] integers)
        {
            if (integers.Length == 1)
            {
                return integers[0];
            }
            var @int1 = integers.Min();
            var @int2 = integers.Max();
            do
            {
                var gfc = int1 > int2 ? int1 - int2 : int2 - int1;
                if (gfc == 1 || gfc == int1 || gfc == int2)
                {
                    return gfc;
                }
                var unused = int1 > int2 ? int1 = gfc : int2 = gfc;
            } while (true);
        }
    }

    
}
