using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30dayshackerhank
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            double d;
            string s;

            i = Convert.ToInt32(Console.ReadLine());
            d = Convert.ToDouble(Console.ReadLine());
            s = Console.ReadLine();

            Console.WriteLine(i + d);
            Console.WriteLine("{0:F1}", d + d);
            Console.WriteLine("HackerHank " + s);

        }



    }
}
