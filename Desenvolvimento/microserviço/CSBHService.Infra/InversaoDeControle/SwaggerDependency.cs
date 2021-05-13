using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CSBHService.Infra.InversaoDeControle
{
    public static class SwaggerDependency
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "CSBH_sincronizador_loja",
                        Version = "V1",
                        Description = "Sincronizador de dados"
                    });
            });
        }
    }
}
