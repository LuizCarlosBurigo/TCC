using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBHService.Dominio.Entidades
{
    public class ItemEntrada : EntidadeLojaBase
    {
        public ItemEntrada(int codigoEmpresa, 
                           int codigoFilial, 
                           int codigoEntrada, 
                           int codigoProduto, 
                           int sequencia) : base(codigoEmpresa, codigoFilial)
        {
            CodigoEntrada = codigoEntrada;
            CodigoProduto = codigoProduto;
            Sequencia = sequencia;
        }

        public int CodigoEntrada { get; private set; }
        public int CodigoProduto { get; private set; }
        public int Sequencia { get; private set; }
        public int Lote { get; private set; }
        public int Quantidade { get; private set; }
        public double Frete { get; private set; }
    }
}
