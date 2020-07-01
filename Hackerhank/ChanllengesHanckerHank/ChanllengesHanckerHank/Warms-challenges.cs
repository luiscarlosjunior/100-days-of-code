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

        public static int coutingValleys(string s)
        {
            // A soma faz o controle se estamos no nível do mar
            int soma = 0;
            // Variável level nos informa qual nível estamos
            int level = 0;

            char[] c = s.ToCharArray();

            foreach (var item in c)
            {
                if (item == 'U')
                    if (++soma == 0)
                        ++level;
                    else --soma;
            }
            return level;
        }

        // Verificar se é par sem usar mod
        public static bool isEven(int n)
        {
            int aux = (n / 2);

            if ((aux*2) == n)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static int jumpingClouds(int[] c)
        {
            // Pego o tamanho
            int size = c.Length - 1;
            // Defino o passo
            int jump = 1;

            for (int index = 2; index < size; jump++, index += 2)
                if (c[index] == 1) index--;

            return jump;
        }
    }
}
