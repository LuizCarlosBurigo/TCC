using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Infra.Data.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CSBHService.Infra.Data.Repositorios
{
    public class TransportadoraRepositorio : ITransportadoraRepositorio
    {

        private readonly MongoContext<Transportadora> _contexto;

        public TransportadoraRepositorio(IMongoDatabase database) =>
            _contexto = new MongoContext<Transportadora>(database, "transportadora");

        public async Task<Transportadora> InseririOuAtualizar(Transportadora transportadora)
        {
            Expression<Func<Transportadora, bool>> filtro = x =>
                x.CodigoTransportadora == transportadora.CodigoTransportadora &&
                x.Endereco.CodigoCidade == transportadora.Endereco.CodigoCidade;

            Transportadora novaTransportadora = _contexto.Collection.Find(filtro).FirstOrDefault();

            if (novaTransportadora != null)
            {
                await _contexto.Collection.ReplaceOneAsync(filtro, transportadora);
                return transportadora;
            }
            await _contexto.Collection.InsertOneAsync(transportadora);
            return transportadora;
        }
        public async Task Excluir(Transportadora transportadora)
        {
            Expression<Func<Transportadora, bool>> filtro = x =>
                x.CodigoTransportadora == transportadora.CodigoTransportadora &&
                x.Endereco.CodigoCidade == transportadora.Endereco.CodigoCidade;

            await _contexto.Collection.DeleteOneAsync(filtro);
        }

    }
}
