using CSBHService.Dominio.ObjetoValor;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CSBHService.Testes.Mocks
{
    public class EntradaMock
    {
        public EntradaMock()
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
                                                                                                      + "20200711"
                                                                                                      + "20200711"
                                                                                                      + "0000000013,10"
                                                                                                      + "0000000022,10"
                                                                                                      + "123456789"
                                                                                                      + "123"
                                                                                                      ))));
        }
    }
}
