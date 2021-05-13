using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Infra.Data.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CSBHService.Infra.Data.Repositorios
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {

        private readonly MongoContext<Fornecedor> _contexto;

        public FornecedorRepositorio(IMongoDatabase database) =>
            _contexto = new MongoContext<Fornecedor>(database, "fornecedor");

        public async Task<Fornecedor> InseririOuAtualizar(Fornecedor fornecedor)
        {
            Expression<Func<Fornecedor, bool>> filtro = x =>
                x.CodigoFornecedor == fornecedor.CodigoFornecedor &&
                x.Endereco.CodigoCidade == fornecedor.Endereco.CodigoCidade;

            Fornecedor novaFornecedor = _contexto.Collection.Find(filtro).FirstOrDefault();

            if (novaFornecedor != null)
            {
                await _contexto.Collection.ReplaceOneAsync(filtro, fornecedor);
                return fornecedor;
            }
            await _contexto.Collection.InsertOneAsync(fornecedor);
            return fornecedor;
        }

        public async Task Excluir(Fornecedor fornecedor)
        {
            Expression<Func<Fornecedor, bool>> filtro = x =>
                x.CodigoFornecedor == fornecedor.CodigoFornecedor &&
                x.Endereco.CodigoCidade == fornecedor.Endereco.CodigoCidade;

            await _contexto.Collection.DeleteOneAsync(filtro);
        }
    }
}
