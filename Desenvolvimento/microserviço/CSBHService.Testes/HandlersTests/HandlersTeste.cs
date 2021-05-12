using CSBHService.Dominio.Commands;
using CSBHService.Dominio.Handlers;
using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.ObjetoValor;
using CSBHService.Testes.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSBHService.Testes.HandlersTests
{
    [TestClass]
    public class HandlersTeste
    {
        private readonly CidadeMock _cidadeMock;
        private readonly LojaMock _lojaMock;
        private readonly SaidaMock _saidaMock;
        private readonly ItemSaidaMock _itemSaidaMock;
        private readonly TransportadoraMock _transportadoraMock;
        private readonly FornecedorMock _fornecedorMock;
        private readonly EntradaMock _entradaMock;
        private readonly ItemEntradaMock _itemEntradaMock;
        private readonly ProdutoMock _produtoMock;
        private readonly ICommand _command;

        public HandlersTeste()
        {
            _cidadeMock = new CidadeMock();
            _lojaMock = new LojaMock();
            _saidaMock = new SaidaMock();
            _itemSaidaMock = new ItemSaidaMock();
            _transportadoraMock = new TransportadoraMock();
            _fornecedorMock = new FornecedorMock();
            _entradaMock = new EntradaMock();
            _itemEntradaMock = new ItemEntradaMock();
            _produtoMock = new ProdutoMock();
        }

        //Executar CidadeHandler
        [TestMethod]
        public void Testar_CidadeHandler()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_cidadeMock.mensagens[0];
            var comando = new GravarCidadeCommand(mensagem);
            var handler = new CidadeHandler();
            var resultado =(CommandResult) handler.Handle(comando);
            Assert.IsTrue(resultado.Sucesso);
        }

        //Executar EntradaHandler
        [TestMethod]
        public void Testar_EntradaHandler()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_entradaMock.mensagens[0];
            var comando = new GravarEntradaCommand(mensagem);
            var handler = new EntradaHandler();
            var resultado = (CommandResult)handler.Handle(comando);
            Assert.IsTrue(resultado.Sucesso);
        }

        //Executar FornecedorHandler
        [TestMethod]
        public void Testar_FornecedorHandler()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_fornecedorMock.mensagens[0];
            var comando = new GravarFornecedorCommand(mensagem);
            var handler = new FornecedorHandler();
            var resultado = (CommandResult)handler.Handle(comando);
            Assert.IsTrue(resultado.Sucesso);
        }

        //Executar ItemEntradaHandler
        [TestMethod]
        public void Testar_ItemEntradaHandler()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_itemEntradaMock.mensagens[0];
            var comando = new GravarItemEntradaCommand(mensagem);
            var handler = new ItemEntradaHandler();
            var resultado = (CommandResult)handler.Handle(comando);
            Assert.IsTrue(resultado.Sucesso);
        }

        //Executar ItemSaidaHandler
        [TestMethod]
        public void Testar_ItemSaidaHandler()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_itemSaidaMock.mensagens[0];
            var comando = new GravarItemSaidaCommand(mensagem);
            var handler = new ItemSaidaHandler();
            var resultado = (CommandResult)handler.Handle(comando);
            Assert.IsTrue(resultado.Sucesso);
        }

        //Executar LojaHandler
        [TestMethod]
        public void Testar_LojaHandler()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_lojaMock.mensagens[0];
            var comando = new GravarLojaCommand(mensagem);
            var handler = new LojaHandler();
            var resultado = (CommandResult)handler.Handle(comando);
            Assert.IsTrue(resultado.Sucesso);
        }

        //Executar ProdutoHandler
        [TestMethod]
        public void Testar_ProdutoHandler()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_produtoMock.mensagens[0];
            var comando = new GravarProdutoCommand(mensagem);
            var handler = new ProdutoHandler();
            var resultado = (CommandResult)handler.Handle(comando);
            Assert.IsTrue(resultado.Sucesso);
        }

        //Executar TransportadoraHandler
        [TestMethod]
        public void Testar_TransportadoraHandler()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_transportadoraMock.mensagens[0];
            var comando = new GravarTransportadoraCommand(mensagem);
            var handler = new TransportadoraHandler();
            var resultado = (CommandResult)handler.Handle(comando);
            Assert.IsTrue(resultado.Sucesso);
        }

        //Executar SaidaHandler
        [TestMethod]
        public void Testar_SaidaHandler()
        {
            MensagemConsumo mensagem = (MensagemConsumo)_saidaMock.mensagens[0];
            var comando = new GravarSaidaCommand(mensagem);
            var handler = new SaidaHandler();
            var resultado = (CommandResult)handler.Handle(comando);
            Assert.IsTrue(resultado.Sucesso);
        }
    }
}
