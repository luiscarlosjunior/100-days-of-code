using System;
using System.Collections.Generic;

namespace ChanllengesHanckerHank
{
    class Warms_challenges
    {
        /// <summary>
        /// 
        /// </summary>
        /// <link>
        /// https://www.hackerrank.com/challenges/sock-merchant/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=warmup
        /// <param name="ar"></param>
        /// <returns></returns>
        public static int sockMerchant(int[] ar)
        {
            // int[] ar = new int[] { 10, 10, 5, 6, 3, 4, 2, 3, 3, 3 };
            HashSet<int> vs = new HashSet<int>();
            int pares = 0;

            foreach (var item in ar)
            {
                if (vs.Contains(item))
                {
                    ++pares;
                    vs.Remove(item);
                }
                else
                {
                    vs.Add(item);
                }
            }
            return pares;
        }
    }
}
