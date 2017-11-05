using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

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

        public static bool IsMultiple(int multiple, int integer)
        {
            return multiple % integer == 0;
        }

        public static bool IsPrime(int integer)
        {
            for (var i = 2; i <= (int)System.Math.Sqrt(integer); i++)
            {
                if (integer % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static ICollection<int> GetPrimeFactors(int integer)
        {
            var factors = GetFactors(integer).Distinct();
            var primeFactors = factors.Where(IsPrime);
            return primeFactors.Distinct().ToList();
        }

        public static int Lcm(params int[] integers)
        {
            var factorsEachNumber = new List<Dictionary<int, int>>();
            foreach (var @int in integers)
            {
                var primeFactors = ExtractToPrimeFactors(@int);
                var factorTimes = new Dictionary<int, int>();
                foreach (var primeFactor in primeFactors)
                {
                    if (factorTimes.ContainsKey(primeFactor))
                    {
                        factorTimes[primeFactor] += 1;
                    }
                    else
                    {
                        factorTimes.Add(primeFactor, 1);
                    }
                }
                factorsEachNumber.Add(factorTimes);
            }
            var factorTimesAllNumbers = new List<Tuple<int, int>>();
            for (var i = 1; i < factorsEachNumber.Count; i++)
            {
                factorTimesAllNumbers = factorsEachNumber[0].Select(x => new Tuple<int, int>(x.Key, x.Value))
                    .Concat(factorsEachNumber[i].Select(x => new Tuple<int, int>(x.Key, x.Value))).ToList();
            }
            var factorsWithMaxTime = new Dictionary<int, int>();
            foreach (var group in factorTimesAllNumbers.GroupBy(x => x.Item1))
            {
                var choose = group.First();
                foreach (var pair in group)
                {
                    if (pair.Item2 > choose.Item2)
                    {
                        choose = pair;
                    }
                }
                factorsWithMaxTime.Add(choose.Item1, choose.Item2);
            }
            var result = 1;
            foreach (var factorTime in factorsWithMaxTime)
            {
                result *= (int)System.Math.Pow(factorTime.Key, factorTime.Value);
            }
            return result;
        }

        public static ICollection<int> ExtractToPrimeFactors(int integer)
        {
            var primeFactors = GetPrimeFactors(integer).Where(factor => factor != 1);
            var result = new List<int>();
            foreach (var primeFactor in primeFactors.OrderByDescending(f => f))
            {
                while (integer % primeFactor == 0)
                {
                    result.Add(primeFactor);
                    integer /= primeFactor;
                }
            }
            return result;
        }

    }

    
}
