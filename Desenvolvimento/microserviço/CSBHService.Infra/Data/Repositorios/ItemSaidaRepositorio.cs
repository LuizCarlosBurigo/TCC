using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Infra.Data.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CSBHService.Infra.Data.Repositorios
{
    public class ItemSaidaRepositorio : IItemSaidaRepositorio
    {
        private readonly MongoContext<ItemSaida> _contexto;

        public ItemSaidaRepositorio(IMongoDatabase database) =>
            _contexto = new MongoContext<ItemSaida>(database, "item_saida_deposito");

        public async Task<ItemSaida> InseririOuAtualizar(ItemSaida item)
        {
            Expression<Func<ItemSaida, bool>> filtro = x =>
                x.CodigoEmpresa == item.CodigoEmpresa &&
                x.CodigoFilial == item.CodigoFilial &&
                x.CodigoSaida == item.CodigoSaida &&
                x.CodigoProduto == item.CodigoProduto &&
                x.Sequencia == item.Sequencia;

            var updateDefenition = Builders<ItemSaida>.Update
                .SetOnInsert(x => x.CodigoEmpresa, item.CodigoEmpresa)
                .Set(x => x.CodigoFilial, item.CodigoFilial)
                .Set(x => x.CodigoSaida, item.CodigoSaida)
                .Set(x => x.CodigoProduto, item.CodigoProduto)
                .Set(x => x.Sequencia, item.Sequencia)
                .Set(x => x.CodigoLote, item.CodigoLote)
                .Set(x => x.Quantidade, item.Quantidade)
                .Set(x => x.Valor, item.Valor);

            await _contexto.Collection.UpdateOneAsync(filtro, updateDefenition, new UpdateOptions
            {
                IsUpsert = true

            });
            return item;
        }

        public async Task Excluir(ItemSaida item)
        {
            Expression<Func<ItemSaida, bool>> filtro = x =>
                x.CodigoEmpresa == item.CodigoEmpresa &&
                x.CodigoFilial == item.CodigoFilial &&
                x.CodigoSaida == item.CodigoSaida &&
                x.CodigoProduto == item.CodigoProduto &&
                x.Sequencia == item.Sequencia;

            await _contexto.Collection.DeleteOneAsync(filtro);
        }
    }
}
