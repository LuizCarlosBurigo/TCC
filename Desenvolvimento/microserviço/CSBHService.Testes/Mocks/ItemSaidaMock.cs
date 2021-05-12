using CSBHService.Dominio.ObjetoValor;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CSBHService.Testes.Mocks
{
    public class ItemSaidaMock
    {
        public ItemSaidaMock()
        {
            AddMensagens();
        }

        public IList mensagens { get; private set; }

        public void AddMensagens()
        {
            mensagens = new List<MensagemConsumo>();
            mensagens.Add(new MensagemConsumo(DateTime.Now, "CSBHF002", "W", (new CorpoEntidadeMensagem("003"
                                                                                                      + "194"
                                                                                                      + "123456789"
                                                                                                      + "123456789"
                                                                                                      + "123456789"
                                                                                                      + "123456789"
                                                                                                      + "123456789"
                                                                                                      + "0000000032,10"))));
        }
    }
}
