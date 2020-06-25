using System;
using System.Collections.Generic;
using System.Text;

namespace ParallelProcessing
{
    public class Work
    {
        public void Count()
        {
            Console.WriteLine("Thread 1 Start");

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Thread 1 End");

        }

        public void Alphabets()
        {
            Console.WriteLine("Thread 2 Start");
            for (char i = 'A'; i < 'Z'; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Thread 2 End");
        }

    }
}
