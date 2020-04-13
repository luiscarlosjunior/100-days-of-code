using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploTesteConsignado
{
    class Program
    {
        static void Main(string[] args)
        {
            testesAutomaticos();
            //processarDadosEntrada();
            Console.ReadKey();
        }

        private static void testesAutomaticos()
        {
            testarAutomaticoValido();
            testarAutomaticoInvalido();
        }

        static void testarAutomaticoValido()
        {
            Financiamento fn = new Financiamento();

            // Entrada dos dados
            Console.WriteLine("========Bem-vindo ao simulador de empréstimo========\n " +
                "Entradas de teste\n");

            try
            {
                Console.WriteLine("Valor informado para crédito: R$ 15.000,00");
                fn.ValorCredito = 15000;

                Console.WriteLine("O tipo de crédito informado foi o Crédito Pessoa Fisica");
                fn.TipoCredito = TipoCredito.CreditoPessoaFisica; 

                Console.WriteLine("Foi utilizado uma quantidade de 10 parcelas, apra exemplo");
                fn.QuantidadeParcela = 10;

                Console.WriteLine("A data utilizada foi: " + DateTime.Now.AddDays(Constantes.MinimoDiasPrimeiroVencimento));
                fn.PrimeiraDataVencimento = DateTime.Now.AddDays(Constantes.MinimoDiasPrimeiroVencimento);

                Console.WriteLine("\n-----------------------------------------");

                Console.WriteLine("Processando a situação");
                fn.processarCredito();

            }
            catch (Exception)
            {
                Console.WriteLine("Houve algum erro, provavelmente erro de entrada, comece novamente!");
            }
        }

        static void testarAutomaticoInvalido()
        {
            Financiamento fn = new Financiamento();

            // Entrada dos dados
            Console.WriteLine("========Bem-vindo ao simulador de empréstimo========\n " +
                "Entradas de teste\n");

            try
            {
                Console.WriteLine("Valor informado para crédito: R$ 10.000,00");
                fn.ValorCredito = 10000;

                Console.WriteLine("O tipo de crédito informado foi o Crédito Pessoa Juridica");
                fn.TipoCredito = TipoCredito.CreditoPessoaJuridica;

                Console.WriteLine("Foi utilizado uma quantidade de 10 parcelas, apra exemplo");
                fn.QuantidadeParcela = 10;

                Console.WriteLine("A data utilizada foi: " + DateTime.Now.AddDays(Constantes.MinimoDiasPrimeiroVencimento));
                fn.PrimeiraDataVencimento = DateTime.Now.AddDays(Constantes.MinimoDiasPrimeiroVencimento);

                Console.WriteLine("\n-----------------------------------------");

                Console.WriteLine("Processando a situação");
                fn.processarCredito();

            }
            catch (Exception)
            {
                Console.WriteLine("Houve algum erro, provavelmente erro de entrada, comece novamente!");
            }
        }

        static void processarDadosEntrada()
        {
            Financiamento fn = new Financiamento();

            // Entrada dos dados
            Console.WriteLine("========Bem-vindo ao simulador de empréstimo========\n " +
                "Por favor, Informe as informações solicitadas abaixo\n");

            try
            {
                Console.WriteLine("Informe o valor do crédito desejado em R$:" +
                    "\n(Para pessoas jurídicas, favor informar um valor mínimo de R$ 15.000,00)");
                fn.ValorCredito = Convert.ToDecimal(Console.ReadLine());

                fn.TipoCredito = mostrarTiposCreditos();

                Console.WriteLine("Informe a quantidade de parcelas entre 5x até 72x");
                fn.QuantidadeParcela = Convert.ToInt32(Console.ReadLine());
                fn.PrimeiraDataVencimento = pegarData();

                Console.WriteLine("\n-----------------------------------------------");
                fn.processarCredito();

            }
            catch (Exception)
            {
                Console.WriteLine("Houve algum erro, provavelmente erro de entrada, comece novamente!");
            }
        }

        private static TipoCredito mostrarTiposCreditos()
        {
            Console.WriteLine("\nInforme o tipo de crédito, escolha entre as opções:\n");
            foreach (var item in Enum.GetValues(typeof(TipoCredito)))
            {
                Console.WriteLine("{0} - {1}", (int)item, ((TipoCredito)item));
            }

            Console.WriteLine("\nInforme o código:\n");

            return (TipoCredito)Convert.ToInt32(Console.ReadLine());
        }

        /// <summary>
        /// Formata a data 
        /// </summary>
        /// <returns>Retorna a data informada na linha de execução</returns>
        private static DateTime pegarData()
        {
            DateTime dtMinData = DateTime.Now.AddDays(Constantes.MinimoDiasPrimeiroVencimento);
            DateTime dtMaxData = DateTime.Now.AddDays(Constantes.MaximoDiasPrimeiroVencimento);

            Console.WriteLine("Informe a primeira data de vencimento.\nEntre com uma data no formato dd/mm/yyyy\nA data de vencimento deverá estar entre o dia de hoje mais " + Constantes.MinimoDiasPrimeiroVencimento + " dias e no máximo hoje e mais " + Constantes.MaximoDiasPrimeiroVencimento + " dias") ;

            Console.WriteLine("A data válida é entre {0} e {0}", dtMinData, dtMaxData);
            string line = Console.ReadLine();

            DateTime dt;
            while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Data inválida, por favor informe uma data com o formato dd/mm/yyyy \nPor exemplo: 01/02/2000");
                line = Console.ReadLine();
            }

            return dt;
        }
    }
}
