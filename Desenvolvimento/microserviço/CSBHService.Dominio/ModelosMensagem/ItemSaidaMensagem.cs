using CSBHService.Dominio.ObjetoValor;
using System;

namespace CSBHService.Dominio.ModelosMensagem
{
    public class ItemSaidaMensagem : MensagemModeloBase
    {
        public ItemSaidaMensagem(DateTime timeStamp, 
                                 string arquivo, 
                                 string acao, 
                                 CorpoEntidadeMensagem itemSaida) : base(timeStamp, arquivo, acao)
        {
            ItemSaida = itemSaida;
        }

        public CorpoEntidadeMensagem ItemSaida { get; set; }
    }
}
