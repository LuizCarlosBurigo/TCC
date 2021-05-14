using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Infra.Data.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

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
                foreach (var telefone in loja.Endereco.Telefones)
                {
                    novaLoja.Endereco.AddTelefone(telefone);
                }
            }
            else
            {
                novaLoja = loja;
            }

            var updateDefenition = Builders<Loja>.Update
                .SetOnInsert(x => x.CodigoEmpresa, novaLoja.CodigoEmpresa)
                .Set(x => x.CodigoFilial, novaLoja.CodigoFilial)
                .Set(x => x.TimeStamp, novaLoja.TimeStamp)
                .Set(x => x.gravacao, novaLoja.gravacao)
                .Set(x => x.Cnpj, novaLoja.Cnpj)
                .Set(x => x.Endereco, novaLoja.Endereco);

            await _contexto.Collection.UpdateOneAsync(filtro, updateDefenition, new UpdateOptions
            {
                IsUpsert = true

            });
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
