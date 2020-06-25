using System;
using System.Threading;

namespace ParallelProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Work w = new Work();
            Console.WriteLine("Main Thread Start");

            ThreadStart s1 = w.Count;
            ThreadStart s2 = w.Alphabets;
            Thread thread1 = new Thread(s1);
            Thread thread2 = new Thread(s2);
            thread1.Start();
            thread2.Start();

            Console.WriteLine("Main Thread Ends");
            Console.ReadKey();
        }
    }
}
