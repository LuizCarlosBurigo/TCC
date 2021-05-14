

using CSBHService.Dominio.Interfaces.Consumidor;
using CSBHService.Infra.Consumidores;
using GreenPipes;
using MassTransit;
using MassTransit.MultiBus;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CSBHService.Infra.InversaoDeControle
{
    public static class MassTransitDependecy
    {
        public static void AddConsumidor(this IServiceCollection services)
        {
            services.AddMassTransit<ISecondBus>(x =>
            {
                x.AddConsumer<CidadeConsumidor>();
                x.AddConsumer<LojaConsumidor>();
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.UseHealthCheck(provider);
                    cfg.Host(new Uri("rabbitmq://localhost"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ReceiveEndpoint("CSBH_COORPORATIVO_CIDADE", ep =>
                    {
                        ep.PrefetchCount = 10;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<CidadeConsumidor>(provider);
                    });

                    cfg.ReceiveEndpoint("CSBH_COORPORATIVO_LOJA", ep =>
                    {
                        ep.PrefetchCount = 10;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<LojaConsumidor>(provider);
                    });

                }));
            });
            services.AddMassTransitHostedService();
        }
    }
}
