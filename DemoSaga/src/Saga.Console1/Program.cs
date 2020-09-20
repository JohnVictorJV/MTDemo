using System.Threading.Tasks;
using MassTransit;
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Saga.Console1.StateMachines;

namespace Saga.Console1
{
    class Program
    {

        /// <summary>
        /// // https://github.com/MassTransit/Sample-Batch
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task Main(string[] args)
        { 
           var builder = new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", true);
                    config.AddEnvironmentVariables();

                    if (args != null)
                        config.AddCommandLine(args);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(cfg =>
                    {
                        cfg.SetKebabCaseEndpointNameFormatter();
                        cfg.UsingRabbitMq((x, y) =>
                        {
                            // y.ConfigureEndpoints(x);

                            y.ReceiveEndpoint("solicitud-generica-saga", e =>
                            {
                                e.ConfigureSagas(x);
                            });
                        });

                        
                        cfg.AddSagaStateMachine<AllocationStateMachine, AllocationState>(typeof(AllocateStateMachineDefinition))
                            .EntityFrameworkRepository(r =>
                            {
                                r.UseSqlServer();
                                r.ConcurrencyMode = ConcurrencyMode.Pessimistic; // or use Optimistic, which requires RowVersion

                                r.AddDbContext<DbContext, AllocationStateDbContext>((provider, optionsBuilder) =>
                                {
                                    optionsBuilder.UseSqlServer(hostContext.Configuration.GetConnectionString("sample-batch"));
                                });
                            });

                    });

                    services.AddDbContext<AllocationStateDbContext>(x => x.UseSqlServer(hostContext.Configuration.GetConnectionString("sample-batch")));
                    
                    services.AddHostedService<MassTransitHostedService>();

                    // So we don't need to use ef migrations for this sample.
                    // Likely if you are going to deploy to a production environment, you want a better DB deploy strategy.
                    services.AddHostedService<EntityFrameworkDbCreatedHostedService>();

                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConsole();
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));

                })
                .UseConsoleLifetime();

            await builder.RunConsoleAsync();
        }
    }
}
