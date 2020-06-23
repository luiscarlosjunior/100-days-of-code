using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

    }


    class Program
    {

        static void Main(string[] args)
        {
            
            /*
            var j = new Journal();
            j.AddEntry("Uma bela noticia");
            j.AddEntry("Eu detectei um inseto");
            */

        }
    }
}
