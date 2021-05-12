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
    }
}
