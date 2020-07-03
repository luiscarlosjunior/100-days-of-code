using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace WorkXml
{
    public class Despacho 
    { 
        
    }

     class Processo
    {
        public string Numero { get; set; }
        public string Despacho { get; set; }
        public string Titular { get; set; }
        public string Procurador { get; set; }
        public string Apostila { get; set; }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            ProcurarDados();
            /*
            var filename = "RM2580.xml";
            var caminho = @"C:\Users\luisc\Desktop\teste.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var purchaseOrderFilepath = Path.Combine(currentDirectory, filename);

            var xml = XElement.Load(purchaseOrderFilepath);

            string nome = "Larissa Marques da Fonseca";

            var query = from s in xml.Elements("processo")
                        where (string)s.Element("procurador") == nome.Trim()
                        select s;

            if (!File.Exists(caminho))
            {
                File.Create(caminho).Close();
            }

            List<string> linhas = File.ReadAllLines(caminho).ToList();


            using (var escrever =  new StreamWriter(caminho))
            {
                for (int i = 0; i < linhas.Count(); i++)
                {
                    escrever.WriteLine(linhas[i].ToString());
                }

                foreach (var item in query)
                {
                    escrever.WriteLine(item.ToString());
                }
            }*/

            /*
            var query = from s in xml.Elements("processo")
                        where (string)s.Element("procurador") == nome.Trim()
                        select s;
                        
                        */
                        /*
            foreach (var item in query)
            {
                Console.WriteLine("{0}", (string)item.Element("despachos").Element("despacho").Attribute("codigo"));
                Console.WriteLine("{0}", (string)item.Element("titulares"));
                Console.WriteLine("{0}", (string)item.Element("marca"));
                Console.WriteLine("{0}", (string)item.Element("procurador"));
            }
            */
            /*
            var query2 = from s in xml.Elements("processo")
                        select s;

            List<string> Procuradores = new List<string>();

            string texto = "";

            if (query.Count() <= 0)
            {
                Console.WriteLine(query.Count());
            }
            else
            {
                foreach (var item in query2)
                {
                    texto = (string)item.Element("procurador");
                    if (texto == null)
                    {
                        continue;
                    }

                    texto.Trim();

                    if (!Procuradores.Contains(texto))
                    {
                        Procuradores.Add((string)item.Element("procurador"));
                        Console.WriteLine("Procurador: {0}", (string)item.Element("processo"));
                    }
                }
                Procuradores.Sort();
                foreach (var item in Procuradores)
                {
                    Console.WriteLine("Procurador: {0}", item.ToString());
                }
            }*/

        }

        private static void ProcurarDados()
        {
            var filename = "RM2580.xml";
            var caminho = @"C:\Users\luisc\Desktop\teste.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var purchaseOrderFilepath = Path.Combine(currentDirectory, filename);

            var xml = XElement.Load(purchaseOrderFilepath);
            var p = new Processo();

            //string nome = "Larissa Marques da Fonseca";

            var query = from s in xml.Elements("processo")
                        where (string)s.Attribute("numero").Value == "918748887"
                        select new Processo {
                            Numero = (string)s.Attribute("numero").Value,
                            Despacho = (string)s.Element("despacho").Attribute("codigo").Value,
                            Titular = (string)s.Element("titular").Attribute("nome-razao-social").Value,
                            Procurador = (string)s.Element("procurador").Value
                        };


            foreach (var item in query)
            {
                Console.WriteLine(item.Procurador); 
            }

            if (!File.Exists(caminho))
            {
                File.Create(caminho).Close();
            }

            List<string> linhas = File.ReadAllLines(caminho).ToList();


            using (var escrever = new StreamWriter(caminho))
            {
                for (int i = 0; i < linhas.Count(); i++)
                {
                    escrever.WriteLine(linhas[i].ToString());
                }

                foreach (var item in query)
                {
                    escrever.WriteLine(item.ToString());
                }
            }

            /*
            var query = from s in xml.Elements("processo")
                        where (string)s.Element("procurador") == nome.Trim()
                        select s;
                        */
            foreach (var item in query)
            {/*
                Console.WriteLine("{0}", (string)item.Element("despachos").Element("despacho").Attribute("codigo"));
                Console.WriteLine("{0}", (string)item.Element("titulares"));
                Console.WriteLine("{0}", (string)item.Element("marca"));
                Console.WriteLine("{0}", (string)item.Element("procurador"));*/
            }
        }

        private void BuscarDadosXML()
        {
            var filename = "RM2580.xml";
            var caminho = @"C:\Users\luisc\Desktop\teste.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var purchaseOrderFilepath = Path.Combine(currentDirectory, filename);

            var xml = XElement.Load(purchaseOrderFilepath);

            string nome = "Larissa Marques da Fonseca";

            var query = from s in xml.Elements("processo")
                        where (string)s.Element("procurador") == nome.Trim()
                        select s;

            if (!File.Exists(caminho))
            {
                File.Create(caminho).Close();
            }

            List<string> linhas = File.ReadAllLines(caminho).ToList();


            using (var escrever = new StreamWriter(caminho))
            {
                for (int i = 0; i < linhas.Count(); i++)
                {
                    escrever.WriteLine(linhas[i].ToString());
                }

                foreach (var item in query)
                {
                    escrever.WriteLine(item.ToString());
                }
            }

            foreach (var item in query)
            {
                Console.WriteLine("{0}", (string)item.Element("despachos").Element("despacho").Attribute("codigo"));
                Console.WriteLine("{0}", (string)item.Element("titulares"));
                Console.WriteLine("{0}", (string)item.Element("marca"));
                Console.WriteLine("{0}", (string)item.Element("procurador"));
            }
        }
    }
}
