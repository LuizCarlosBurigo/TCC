using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Infra.Data.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CSBHService.Infra.Data.Repositorios
{
    public class EntradaRepositorio : IEntradaRepositorio
    {
        private readonly MongoContext<Entrada> _contexto;

        public EntradaRepositorio(IMongoDatabase database) =>
            _contexto = new MongoContext<Entrada>(database, "entrada_mercadorias");

        public async Task<Entrada> InseririOuAtualizar(Entrada entrada)
        {
            Expression<Func<Entrada, bool>> filtro = x =>
                x.CodigoEmpresa == entrada.CodigoEmpresa &&
                x.CodigoFilial == entrada.CodigoFilial &&
                x.CodigoEntrada == entrada.CodigoEntrada &&
                x.CodigoTransportadora == entrada.CodigoTransportadora;

            Entrada novaEntrada = _contexto.Collection.Find(filtro).FirstOrDefault();
            if (novaEntrada != null)
            {
                await _contexto.Collection.FindOneAndReplaceAsync(filtro, entrada);
                return entrada;
            }
            await _contexto.Collection.InsertOneAsync(entrada);
            return entrada;
        }

        public async Task Excluir(Entrada entrada)
        {
            Expression<Func<Entrada, bool>> filtro = x =>
                x.CodigoEmpresa == entrada.CodigoEmpresa &&
                x.CodigoFilial == entrada.CodigoFilial &&
                x.CodigoEntrada == entrada.CodigoEntrada &&
                x.CodigoTransportadora == entrada.CodigoTransportadora;

            await _contexto.Collection.DeleteOneAsync(filtro);
        }
    }
}
