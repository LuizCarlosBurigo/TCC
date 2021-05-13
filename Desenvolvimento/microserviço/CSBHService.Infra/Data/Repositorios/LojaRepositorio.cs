using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Infra.Data.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CSBHService.Infra.Data.Repositorios
{
    public class LojaRepositorio : ILojaRepositorio
    {

        private readonly MongoContext<Loja> _contexto;

        public LojaRepositorio(IMongoDatabase database) =>
            _contexto = new MongoContext<Loja>(database, "loja");

        public async Task<Loja> InseririOuAtualizar(Loja loja)
        {
            Expression<Func<Loja, bool>> filtro = x =>
                x.CodigoEmpresa == loja.CodigoEmpresa &&
                x.CodigoFilial == loja.CodigoFilial;

            Loja novaLoja = _contexto.Collection.Find(filtro).FirstOrDefault();

            if (novaLoja != null)
            {
                await _contexto.Collection.ReplaceOneAsync(filtro, loja);
                return loja;
            }
            await _contexto.Collection.InsertOneAsync(loja);
            return loja;
        }

        public async Task Excluir(Loja loja)
        {
            Expression<Func<Loja, bool>> filtro = x =>
                x.CodigoEmpresa == loja.CodigoEmpresa &&
                x.CodigoFilial == loja.CodigoFilial;

            await _contexto.Collection.DeleteOneAsync(filtro);
        }
    }
}
