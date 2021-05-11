
namespace CSBHService.Dominio.Entidades
{
    public class Produto : EntidadeLojaBase
    {
        public Produto(int codigoEmpresa, 
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
        public int Lote { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
