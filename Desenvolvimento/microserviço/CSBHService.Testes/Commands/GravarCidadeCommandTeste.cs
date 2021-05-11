using System;
using System.Collections.Generic;
using CSBHService.Dominio.Commands;
using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.ObjetoValor;
using CSBHService.Testes.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSBHService.Testes.Commands
{
    [TestClass]
    public class GravarCidadeCommandTeste
    {
        private readonly CidadeMock _cidadeMock;


        public GravarCidadeCommandTeste()
        {
            _cidadeMock = new CidadeMock();
        }

        //Gravar um novo registro da cidade
        [TestMethod]
        public void Testar_GravarCidadeCommand()
        {
            MensagemConsumo mensagem =(MensagemConsumo) _cidadeMock.mensagens[0];
            var comando = new GravarCidadeCommand(mensagem);
            Assert.IsTrue(comando.Validador());
        }
    }
}
