
namespace CSBHService.Dominio.Entidades
{
    public class ItemSaida : EntidadeLojaBase
    {
        public ItemSaida(int codigoEmpresa, 
                         int codigoFilial, 
                         int sequencia, 
                         int codigoSaida, 
                         int codigoProduto) : base(codigoEmpresa, codigoFilial)
        {
            Sequencia = sequencia;
            CodigoSaida = codigoSaida;
            CodigoProduto = codigoProduto;
        }

        public int Sequencia { get; private set; }
        public int CodigoSaida { get; private set; }
        public int CodigoProduto { get; private set; }
        public int CodigoLote { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
    }
}
