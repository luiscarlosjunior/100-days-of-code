using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ChanllengesHanckerHank
{
    class Program
    {
        /*
         https://www.hackerrank.com/challenges/sock-merchant/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=warmup
             */
        static void Main(string[] args)
        {

            int n = Convert.ToInt32(Console.ReadLine());

            string s = Console.ReadLine();

            int result = coutingValleys(n, s);

            Console.WriteLine(result);
        }

       

        private void VerificarPar()
        {
            int n = 0;
            bool resposta = false;

            Console.WriteLine("Escreva um digito: ");
            n = Convert.ToInt32(Console.ReadLine());

            resposta = Warms_challenges.isEven(n);

            Console.WriteLine($"O número {n} é par? \nR: {resposta}");
        }

        private void CountSocks ()
        {
            int[] ar = new int[] { 10, 10, 5, 6, 3, 4, 2, 3, 3, 3 };
            Warms_challenges.sockMerchant(ar);
        }
    }
}
