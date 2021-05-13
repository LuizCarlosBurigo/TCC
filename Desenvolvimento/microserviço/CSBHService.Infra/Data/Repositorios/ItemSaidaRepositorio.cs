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

            ItemSaida novaItem = _contexto.Collection.Find(filtro).FirstOrDefault();

            if (novaItem != null)
            {
                await _contexto.Collection.ReplaceOneAsync(filtro, item);
                return item;
            }
            await _contexto.Collection.InsertOneAsync(item);
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
