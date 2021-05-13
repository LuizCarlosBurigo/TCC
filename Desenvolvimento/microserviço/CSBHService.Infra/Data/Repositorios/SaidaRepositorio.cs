using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Infra.Data.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CSBHService.Infra.Data.Repositorios
{
    public class SaidaRepositorio : ISaidaRepositorio
    {

        private readonly MongoContext<Saida> _contexto;

        public SaidaRepositorio(IMongoDatabase database) =>
            _contexto = new MongoContext<Saida>(database, "saida_mercadoria");

        public async Task<Saida> InseririOuAtualizar(Saida saida)
        {
            Expression<Func<Saida, bool>> filtro = x =>
                x.CodigoEmpresa == saida.CodigoEmpresa &&
                x.CodigoFilial == saida.CodigoFilial &&
                x.CodigoSaida == saida.CodigoSaida;

            Saida novaSaida = _contexto.Collection.Find(filtro).FirstOrDefault();

            if (novaSaida != null)
            {
                await _contexto.Collection.ReplaceOneAsync(filtro, saida);
                return saida;
            }
            await _contexto.Collection.InsertOneAsync(saida);
            return saida;
        }

        public async Task Excluir(Saida saida)
        {
            Expression<Func<Saida, bool>> filtro = x =>
                x.CodigoEmpresa == saida.CodigoEmpresa &&
                x.CodigoFilial == saida.CodigoFilial &&
                x.CodigoSaida == saida.CodigoSaida;

            await _contexto.Collection.DeleteOneAsync(filtro);
        }
    }
}
