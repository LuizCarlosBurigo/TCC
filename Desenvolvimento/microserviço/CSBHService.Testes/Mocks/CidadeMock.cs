using CSBHService.Dominio.ObjetoValor;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CSBHService.Testes.Mocks
{
    public class CidadeMock
    {
        public CidadeMock()
        {
            AddMensagens();
        }

        public IList mensagens { get; private set; }

        public void AddMensagens()
        {
            mensagens = new List<MensagemConsumo>();
            mensagens.Add(new MensagemConsumo(DateTime.Now, "CSBHF002", "W", (new CorpoEntidadeMensagem("000000010SC       Blumenau"))));
        }
    }
}
