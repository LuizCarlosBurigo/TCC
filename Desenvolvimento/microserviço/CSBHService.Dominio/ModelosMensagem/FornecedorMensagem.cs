using CSBHService.Dominio.ObjetoValor;
using System;

namespace CSBHService.Dominio.ModelosMensagem
{
    public class FornecedorMensagem : MensagemModeloBase
    {
        public FornecedorMensagem(DateTime timeStamp, 
                                  string arquivo, 
                                  string acao, 
                                  CorpoEntidadeMensagem fornecedor) : base(timeStamp, arquivo, acao)
        {
            Fornecedor = fornecedor;
        }

        public CorpoEntidadeMensagem Fornecedor { get; set; }
    }
}
