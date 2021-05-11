using CSBHService.Dominio.Commands;
using CSBHService.Dominio.ObjetoValor;
using CSBHService.Testes.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSBHService.Testes.CommandsTest
{
    [TestClass]
    public class CommandsTeste
    {
        private readonly CidadeMock _cidadeMock;
        private readonly LojaMock _lojaMock;
        private readonly SaidaMock _saidaMock;


        public CommandsTeste()
        {
            _cidadeMock = new CidadeMock();
            _lojaMock = new LojaMock();
            _saidaMock = new SaidaMock();
        }

        //Executar GravarCidadeCommand
        [TestMethod]
        public void Testar_GravarCidadeCommand()
        {
            MensagemConsumo mensagem = (MensagemConsumo) _cidadeMock.mensagens[0];
            var comando = new GravarCidadeCommand(mensagem);
            Assert.IsTrue(comando.Validador());
        }

        //Executar GravarLojaCommand
        [TestMethod]
        public void Testar_GravarLojaCommand()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_lojaMock.mensagens[0];
            var comando = new GravarLojaCommand(mensagem);
            Assert.IsTrue(comando.Validador());
        }

        //Executar GravarSaidaCommand
        [TestMethod]
        public void Testar_GravarSaidaCommand()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_saidaMock.mensagens[0];
            var comando = new GravarSaidaCommand(mensagem);
            Assert.IsTrue(comando.Validador());
        }
    }
}
