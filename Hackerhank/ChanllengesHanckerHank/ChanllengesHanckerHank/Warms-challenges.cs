using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

        public static long RepeatStringCountAs(string s, long n)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();


            //* First Code
            if (s.Length == 1 && s.Equals("a"))
            {
                return n;
            }

            long ocorrencia = s.Where(a => a == 'a').Count();
            long repetir = n / s.Length;
            long remainingLength = n % s.Length;
            string lastStr = s.Substring(0, (int)remainingLength);
            long lastOcorrencia = lastStr.Where(a => a == 'a').Count();
            sw.Stop();



            return (ocorrencia * repetir) + lastOcorrencia;
            /*
            int start = 0, count = a.Length -1;

            (O(n))
            while ((size++) < n)
            {
                if (a[start] == 'a')
                {
                    ++contar_A;
                }
                if (start == count)
                {
                    start = 0;
                    continue;
                }
                ++start;
            }
            */
            /*
             * Second Code (O(n^2)
            for (long i = 0; i < n; i += a.Length)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    if (a[j] == 'a')
                    {
                        ++contar_A;
                    }
                    if ((++size) == n)
                    {
                        goto Terminou;
                    }
                }
            }
            */
            //Terminou:

            

            //d = Repeat(s, n);

            //int b = d.ToString().Count(x => x == 'a');
            //Console.WriteLine(contar_A);
            
            //Console.WriteLine(sw.Elapsed.TotalSeconds);
            //Console.WriteLine(d);
            //Console.WriteLine(int.MaxValue);
            //Console.WriteLine(long.MaxValue);
        }
    }
}
