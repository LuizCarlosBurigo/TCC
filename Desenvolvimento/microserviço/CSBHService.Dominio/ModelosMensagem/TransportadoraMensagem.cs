using CSBHService.Dominio.ObjetoValor;
using System;

namespace CSBHService.Dominio.ModelosMensagem
{
    public class TransportadoraMensagem : MensagemModeloBase
    {
        public TransportadoraMensagem(DateTime timeStamp, 
                                      string arquivo, 
                                      string acao, 
                                      CorpoEntidadeMensagem trasportadora) : base(timeStamp, arquivo, acao)
        {
            Trasportadora = trasportadora;
        }

        public CorpoEntidadeMensagem Trasportadora { get; set; }
    }
}
