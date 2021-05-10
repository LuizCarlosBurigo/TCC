using System;
using System.Collections.Generic;
using System.Linq;

namespace CSBHService.Dominio.Entidades
{
    public class Saida : EntidadeLojaBase
    {
        public Saida(int codigoEmpresa, 
                     int codigoFilial,
                     int codigoSaida, 
                     int codigoTranspotadora) : base(codigoEmpresa, codigoFilial)
        {
            CodigoSaida = codigoSaida;
            CodigoTranspotadora = codigoTranspotadora;
        }

        public int CodigoSaida { get; private set; }
        public int CodigoTranspotadora { get; private set; }
        public double Total { get; private set; }
        public double Frete { get; private set; }
        public double Imposto { get; private set; }
    }
}
