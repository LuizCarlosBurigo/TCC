using CSBHService.Dominio.Interfaces.Consumidor;
using CSBHService.Dominio.ObjetoValor;
using System;

namespace CSBHService.Dominio.ModelosMensagem
{
    public class CidadeMensagem : MensagemModeloBase
    {
        public CidadeMensagem(DateTime timeStamp, 
                              string arquivo, 
                              string acao, 
                              CorpoEntidadeMensagem cidade) : base(timeStamp, arquivo, acao)
        {
            Cidade = cidade;
        }

        public CorpoEntidadeMensagem Cidade { get; set; }
    }
}
