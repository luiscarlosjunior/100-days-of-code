using System;

namespace ExemploTesteConsignado
{
    class Financiamento
    {
        private decimal valorCredito;
        private TipoCredito tipoCredito;
        private int quantidadeParcela;
        private DateTime primeiraDataVencimento;
        private string status;

        public decimal ValorCredito 
        {
            get 
            {
                if ((TipoCredito != TipoCredito.CreditoPessoaJuridica
                    || valorCredito >= Constantes.ValorCreditoPessoaJuridica)
                    && valorCredito <= Constantes.ValorMaximoCredito)
                {
                    return valorCredito == 0 ? -1 : valorCredito;
                }
                else
                {
                    return -1;
                }
            }
            set 
            {
                valorCredito = value;
            } 
        }
        public int QuantidadeParcela 
        {
            get
            {
                return quantidadeParcela < Constantes.QuantidadeParcelaMinima 
                    || quantidadeParcela > Constantes.QuantidadeParcelaMaxima ? -1 : quantidadeParcela;
            }
            set
            {
               quantidadeParcela = value;
            }
        }
        public DateTime PrimeiraDataVencimento { get ; set ; }
        public TipoCredito TipoCredito { get ; set ; }
        
        // Define o status do crédito
        public string Status 
        {
            get 
            {
                // Validação se o crédito é aprovado ou não
                if (ValorCredito >= 0 && QuantidadeParcela >= 0 &&
                    validarData() == true)
                {
                    return "Aprovado";
                }
                else
                {
                    return "Reprovado";
                }
            }
            set 
            { }
        }

        public void processarCredito()
        {
            if (Status.Length < 0 || Status.Equals("Reprovado"))
            {
                Console.WriteLine("A sua situação foi: Reprovado");
                return;
            }
            else if (Status.Equals("Aprovado"))
            {
                processarDados();
            }
            else
            {
                Console.WriteLine("A sua situação deu: Reprovado");
            }
        }

        private void processarDados()
        {
            decimal valorTotal;
            decimal valorJuros;
            double porcentagemTotalJuros = pegarTaxa(TipoCredito) * QuantidadeParcela;

            valorTotal = Processar.calcularTotalJuros(porcentagemTotalJuros, ValorCredito);
            valorJuros = Processar.calcularJuros(porcentagemTotalJuros, ValorCredito);

            Console.WriteLine("\n=========================================");
            Console.WriteLine("A sua situação deu: {0}\nValor total com Juros: R$ {1}\nValor dos juros: RS {2}",
                Status.ToString(), valorTotal, valorJuros);
            Console.WriteLine("=========================================");
        }

        /// <summary>
        /// Formata a data para o padrão dia/mes/ano
        /// </summary>
        /// <returns>Retorna true ou false se a data informada atende os requísitos</returns>
        public bool validarData()
        {
            DateTime primeiraDataMin = Convert.ToDateTime(PrimeiraDataVencimento.Date.ToString("dd/MM/yyyy"));

            DateTime primeiraDataMax = Convert.ToDateTime(PrimeiraDataVencimento.Date.ToString("dd/MM/yyyy"));

            if (primeiraDataMin <= DateTime.Now.AddDays(Constantes.MinimoDiasPrimeiroVencimento) && primeiraDataMax >= DateTime.Now.AddDays(Constantes.MaximoDiasPrimeiroVencimento))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public double pegarTaxa(TipoCredito tipoCredito)
        {
            switch (tipoCredito)
            {
                case TipoCredito.CreditoDireto:
                    return 0.02;
                case TipoCredito.CreditoConsignado:
                    return 0.01;
                case TipoCredito.CreditoPessoaJuridica:
                    return 0.05;
                case TipoCredito.CreditoPessoaFisica:
                    return 0.03;
                case TipoCredito.CreditoImobiliario:
                    return 0.0075;
                default:
                    return 0.0;
            }
        }
    }
}
