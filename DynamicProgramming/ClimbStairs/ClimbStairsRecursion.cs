using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    static class ClimbStairsRecursion
    {
        public static void main()
        {
            long ways = 0;
            long n = 10;
            //List<long> res = new List<long>();
            //FindWays(step: 0, ref ways, n, res);
            //Console.WriteLine(res.Count);
            //Console.WriteLine(ways);
            //long rways = ReturnWays(0, 0, n);
            //Console.WriteLine(rways);

            Dictionary<(long, long), long> res = new Dictionary<(long, long), long>();
            Dictionary<long, long> res1 = new Dictionary<long, long>();
            Dictionary<long, long> res2 = new Dictionary<long, long>();
            long optimizeRes = ReturnWaysMemorization(0, 0, n, res);
            long optimizeRes2 = ReturnWaysMemorization2(0, n, res2);
            Console.WriteLine(optimizeRes);
            long diffways=WaysMemorization(n, n, res1);

        }

        private static void FindWays(long step, ref long ways, long n, List<long> res)
        {
            if (step >= n)
            {
                if (step == n)
                {
                    ways++;
                    res.Add(1);
                }
                return;
            }

            for (long i = 1; i < 3; i++)
            {
                if (step + i <= n)
                {
                    step = step + i;
                    FindWays(step, ref ways, n, res);
                    step = step - i;
                }
            }
        }

        private static long ReturnWays(long step, int i, long n)
        {
            if (step == n)
                return 1;

            if (step > n)
                return 0;

            long step1 = ReturnWays(step + 1, 1, n);
            long step2 = ReturnWays(step + 2, 2, n);
            long totalsteps = step1 + step2;

            return totalsteps;
        }


        private static long ReturnWaysMemorization(long step, long noOfSteps, long n, Dictionary<(long, long), long> res)
        {

            if (step == n)
                return 1;

            if (step > n)
                return 0;
            if (res.ContainsKey((step, noOfSteps)))
            {
                return res[(step, noOfSteps)];
            }

            long step1 = ReturnWaysMemorization(step + 1, 1, n, res);
            long step2 = ReturnWaysMemorization(step + 2, 2, n, res);

            long totalSteps = step1 + step2;
            res[(step, noOfSteps)] = totalSteps;

            return totalSteps;
        }
        private static long ReturnWaysMemorization2(long step, long n, Dictionary<long, long> res2)
        {

            if (step == n)
                return 1;

            if (step > n)
                return 0;
            if (res2.ContainsKey((step)))
            {
                return res2[(step)];
            }

            long step1 = ReturnWaysMemorization2(step + 1, n, res2);
            long step2 = ReturnWaysMemorization2(step + 2, n, res2);

            long totalSteps = step1 + step2;
            res2[step] = totalSteps;

            return totalSteps;
        }

        private static long WaysMemorization(long step, long n, Dictionary<long,long> res1)
        {
            if (step == 0 || step == 1)
                return 1;

            if (step < 0)
                return 0;

            if (res1.ContainsKey(step))
            {
                return res1[step];
            }

            long step1 = WaysMemorization(step - 1, n, res1);
            long step2 = WaysMemorization(step - 2,  n, res1);

            long totalSteps = step1 + step2;
            res1[step] = totalSteps;

            return totalSteps;
        }

        
    }
}
