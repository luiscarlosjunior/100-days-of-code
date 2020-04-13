using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploTesteConsignado
{
    class Processar
    {

        /// <summary>
        /// Essa função calcula o valor final aplicando os juros
        /// </summary>
        /// <param name="taxa">Recebe a taxa a ser aplicada</param>
        /// <returns>Total do cálculo</returns>
        public static decimal calcularTotalJuros(double taxa, decimal valorCredito)
        {
            return valorCredito * (decimal)(taxa + 1);
        }

        /// <summary>
        /// Essa função calcula o valor do juros
        /// </summary>
        /// <param name="taxa">Recebe a taxa a ser aplicada</param>
        /// <param name="valorCredito">Recebe a taxa a ser aplicada</param>
        /// <returns>Total dos juros</returns>
        public static decimal calcularJuros(double taxa, decimal valorCredito)
        {
            return valorCredito * (decimal)(taxa);
        }
    }
}
