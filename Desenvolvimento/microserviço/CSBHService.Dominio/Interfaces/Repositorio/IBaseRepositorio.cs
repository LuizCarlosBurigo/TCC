using CSBHService.Dominio.Entidades;
using System.Threading.Tasks;

namespace CSBHService.Dominio.Interfaces.Repositorio
{
    public interface IBaseRepository<TEntity> 
        where TEntity : Entidade
    {
        Task<TEntity> InseririOuAtualizar(TEntity entidade);

        Task Excluir(TEntity entidade);
    }
}
