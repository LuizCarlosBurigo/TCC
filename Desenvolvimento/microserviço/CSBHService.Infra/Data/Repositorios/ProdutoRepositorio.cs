using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Infra.Data.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CSBHService.Infra.Data.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {

        private readonly MongoContext<Produto> _contexto;

        public ProdutoRepositorio(IMongoDatabase database) =>
            _contexto = new MongoContext<Produto>(database, "mercadoria");

        public async Task<Produto> InseririOuAtualizar(Produto produto)
        {
            Expression<Func<Produto, bool>> filtro = x =>
                x.CodigoEmpresa == produto.CodigoEmpresa &&
                x.CodigoFilial == produto.CodigoFilial &&
                x.CodigoEntrada == produto.CodigoEntrada &&
                x.CodigoProduto == produto.CodigoProduto &&
                x.Sequencia == produto.Sequencia;

            var updateDefenition = Builders<Produto>.Update
                .SetOnInsert(x => x.CodigoEmpresa, produto.CodigoEmpresa)
                .Set(x => x.CodigoFilial, produto.CodigoFilial)
                .Set(x => x.CodigoEntrada, produto.CodigoEntrada)
                .Set(x => x.CodigoProduto, produto.CodigoProduto)
                .Set(x => x.Sequencia, produto.Sequencia)
                .Set(x => x.Lote, produto.Lote)
                .Set(x => x.Quantidade, produto.Quantidade)
                .Set(x => x.Valor, produto.Valor);

            await _contexto.Collection.UpdateOneAsync(filtro, updateDefenition, new UpdateOptions
            {
                IsUpsert = true

            });
            return produto;
        }

        public async Task Excluir(Produto produto)
        {
            Expression<Func<Produto, bool>> filtro = x =>
                x.CodigoEmpresa == produto.CodigoEmpresa &&
                x.CodigoFilial == produto.CodigoFilial &&
                x.CodigoEntrada == produto.CodigoEntrada &&
                x.CodigoProduto == produto.CodigoProduto &&
                x.Sequencia == produto.Sequencia;

            await _contexto.Collection.DeleteOneAsync(filtro);
        }
    }
}
