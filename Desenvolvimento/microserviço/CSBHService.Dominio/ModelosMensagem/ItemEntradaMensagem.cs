using CSBHService.Dominio.ObjetoValor;
using System;

namespace CSBHService.Dominio.ModelosMensagem
{
    public class ItemEntradaMensagem : MensagemModeloBase
    {
        public ItemEntradaMensagem(DateTime timeStamp, 
                                   string arquivo, 
                                   string acao, 
                                   CorpoEntidadeMensagem itemEntrada) : base(timeStamp, arquivo, acao)
        {
            ItemEntrada = itemEntrada;
        }

        public CorpoEntidadeMensagem ItemEntrada { get; set; }
    }
}
