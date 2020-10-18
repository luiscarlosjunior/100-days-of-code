using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("Eu acordei hoje");
            j.AddEntry("Eu tomei café da manhã");
            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"c:\";
            p.SaveToFile(j, filename, true);
            Process.Start(filename);
        }
    }
}
