using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneHundredDaysCode.Basic
{
    class basic
    {
        // Comparaçao de três valores
        static List<int> compareTriplets(List<int> a, List<int> b)
        {
            List<int> answer = new List<int> { 0, 0 };

            for (int i = 0; i < a.Count(); i++)
            {
                if (a[i] > b[i])
                {
                    answer[0] += 1;
                }
                else if (a[i] < b[i])
                {
                    answer[1] += 1;
                }
            }

            return answer;

        }

        // Calculate and print the sum of the elements in an array, keeping in mind that some of those integers may be quite large.
        static long aVeryBigSum(long[] ar)
        {
            long soma = 0;

            for (int i = 0; i < ar.Length; i++)
            {
                soma += ar[i];
            }

            return soma;
        }

        // Dada uma matriz quadrada, calcule a diferença absoluta entre as somas de suas diagonais.
        public static int diagonalDifference(List<List<int>> arr)
        {
            int somaLeft = 0;
            int somaRight = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                for (int k = 0; k < arr.Count; k++)
                {
                    if (i == k)
                    {
                        somaLeft += arr[i][k];
                    }
                    if ((i + k) == (arr.Count - 1))
                    {
                        somaRight += arr[i][k];
                    }
                }
            }

            return Math.Abs(somaLeft - somaRight);
        }

        // Complete the plusMinus function below.
        static void plusMinus(int[] arr)
        {

            int[] parameters = new int[3];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    parameters[0]++;
                }
                else if (arr[i] < 0)
                {
                    parameters[1]++;
                }
                else
                {
                    parameters[2]++;
                }
            }

            float positive = (float)parameters[0] / arr.Length;
            float negative = (float)parameters[1] / arr.Length;
            float zero = (float)parameters[2] / arr.Length;

            Console.WriteLine(positive.ToString("N4"));
            Console.WriteLine(negative.ToString("N4"));
            Console.WriteLine(zero.ToString("N4"));
        }

        // Complete the staircase function below.
        static void staircase(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new String('#', i + 1).PadLeft(n, ' '));
            }
        }

        // Complete the miniMaxSum function below.
        static void miniMaxSum(int[] arr)
        {
            long[] soma = new long[] { 0, 0 };
            int[] vs = selectionSort(arr);

            for (int i = 0; i < vs.Length - 1; i++)
            {
                soma[0] += vs[i];
            }

            for (int i = 1; i < vs.Length; i++)
            {
                soma[1] += vs[i];
            }

            Console.WriteLine(soma[0] + " " + soma[1]);

        }

        private static int[] selectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                // Find the minimum element in unsorted
                int minIdx = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIdx])
                    {
                        minIdx = j;
                    }
                }
                // Swap the found minimum element with the next
                int temp = arr[minIdx];
                arr[minIdx] = arr[i];
                arr[i] = temp;
            }
            return arr;
        }

        // Complete the birthdayCakeCandles function below.
        static int birthdayCakeCandles(int[] ar)
        {

            int max = ar.Max();
            int cont = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] == max)
                    ++cont;
            }

            return cont;
        }
    }
}
