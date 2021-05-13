using CSBHService.Dominio.Commands;
using CSBHService.Dominio.Interfaces.Commands;
using CSBHService.Dominio.Interfaces.Repositorio;
using CSBHService.Infra.Data.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace CSBHService.Infra.InversaoDeControle
{
    public static class ServiceDependency
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICidadeRepositorio, CidadeRepositorio>();
            services.AddScoped<IEntradaRepositorio, EntradaRepositorio>();
            services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
            services.AddScoped<IItemEntradaRepositorio, ItemEntradaRepositorio>();
            services.AddScoped<IItemSaidaRepositorio, ItemSaidaRepositorio>();
            services.AddScoped<ILojaRepositorio, LojaRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<ISaidaRepositorio, SaidaRepositorio>();
            services.AddScoped<ITransportadoraRepositorio, TransportadoraRepositorio>();
            services.AddScoped<ICommandResult, CommandResult>();
        }
    }
}
