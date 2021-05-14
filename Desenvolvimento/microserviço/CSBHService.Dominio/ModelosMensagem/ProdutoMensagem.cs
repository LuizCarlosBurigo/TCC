using CSBHService.Dominio.ObjetoValor;
using System;

namespace CSBHService.Dominio.ModelosMensagem
{
    public class ProdutoMensagem : MensagemModeloBase
    {
        public ProdutoMensagem(DateTime timeStamp, 
                              string arquivo, 
                              string acao, 
                              CorpoEntidadeMensagem produto) : base(timeStamp, arquivo, acao)
        {
            Produto = produto;
        }

        public CorpoEntidadeMensagem Produto { get; set; }
    }
}
