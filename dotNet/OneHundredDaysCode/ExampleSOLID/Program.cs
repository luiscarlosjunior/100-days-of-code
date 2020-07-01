using ExampleSOLID.O;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static System.Console;
using System.Runtime.InteropServices;

namespace ExampleSOLID
{

    /// <summary>
    /// This is an example of Single that part SOLID
    /// SRP: Single Responsibility Principle
    /// Esse princípio declara que uma classe deve ser especializada em um único assunto e possuir apenas uma responsabilidade dentro do software, ou seja, a classe deve ter uma única tarefa ou ação para executar.
    /// 
    /// Falta de coesão — uma classe não deve assumir responsabilidades que não são suas;
    /// Alto acoplamento — Mais responsabilidades geram um maior nível de dependências, deixando o sistema engessado e frágil para alterações;
    ///Dificuldades na implementação de testes automatizados — É difícil de “mockar” esse tipo de classe;
    ///Dificuldades para reaproveitar o código;
    /// </summary>
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            var bf = new BetterFilter();
            WriteLine("Gree products (new):");
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                WriteLine($" - { p.Name} is green");
            }


            /*
            var j = new Journal();
            j.AddEntry("I happy today");
            j.AddEntry("I ate a hot dog");
            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"C:\Users\luisc\Documents\GitHub\journal.txt";
            p.SaveToFile(j, filename, true);

            Process.Start(filename);
            */
        }
    }
}
