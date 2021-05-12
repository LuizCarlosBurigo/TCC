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
        private readonly ItemSaidaMock _itemSaidaMock;
        private readonly TransportadoraMock _transportadoraMock;
        private readonly FornecedorMock _fornecedorMock;
        private readonly EntradaMock _entradaMock;


        public CommandsTeste()
        {
            _cidadeMock = new CidadeMock();
            _lojaMock = new LojaMock();
            _saidaMock = new SaidaMock();
            _itemSaidaMock = new ItemSaidaMock();
            _transportadoraMock = new TransportadoraMock();
            _fornecedorMock = new FornecedorMock();
            _entradaMock = new EntradaMock();
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

        //Executar GravarItemSaidaCommand
        [TestMethod]
        public void Testar_GravarItemSaidaCommand()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_itemSaidaMock.mensagens[0];
            var comando = new GravarItemSaidaCommand(mensagem);
            Assert.IsTrue(comando.Validador());
        }

        //Executar GravarTransportadoraCommand
        [TestMethod]
        public void Testar_GravarTransportadoraCommand()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_transportadoraMock.mensagens[0];
            var comando = new GravarTransportadoraCommand(mensagem);
            Assert.IsTrue(comando.Validador());
        }

        //Executar GravarFornecedorCommand
        [TestMethod]
        public void Testar_GravarFornecedorCommand()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_fornecedorMock.mensagens[0];
            var comando = new GravarFornecedorCommand(mensagem);
            Assert.IsTrue(comando.Validador());
        }

        //Executar GravarEntradaCommand
        [TestMethod]
        public void Testar_GravarEntradaCommand()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_entradaMock.mensagens[0];
            var comando = new GravarEntradaCommand(mensagem);
            Assert.IsTrue(comando.Validador());
        }
    }
}
