using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            // Os tipos de valores são tratados como objetos
            // Executando operações boxing e unboxing
            int i = 123;
            object o = i;   // Boxing
            int j = (int)o; // Unboking

        }
    }
}
