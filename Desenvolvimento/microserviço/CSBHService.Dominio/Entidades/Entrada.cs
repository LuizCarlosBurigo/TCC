using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBHService.Dominio.Entidades
{
    public class Entrada : EntidadeLojaBase
    {
        public Entrada(int codigoEmpresa, 
                       int codigoFilial, 
                       int codigoEntrada, 
                       int codigoTransportadora) : base(codigoEmpresa, codigoFilial)
        {
            CodigoEntrada = codigoEntrada;
            CodigoTransportadora = codigoTransportadora;
        }

        public int CodigoEntrada { get; private set; }
        public int CodigoTransportadora { get; private set; }
        public DateTime DataPedido { get; set; }
        public DateTime EntradaPedido { get; set; }
        public double Total { get; set; }
        public double Frete { get; set; }
        public int NumeroNotaFiscal { get; set; }
        public int SerieNotaFiscal { get; set; }

    }
}
