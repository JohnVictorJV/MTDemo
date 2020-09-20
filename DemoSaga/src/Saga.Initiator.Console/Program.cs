using System.Threading.Tasks;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Saga.Initiator.Console
{
    
    class Program
    {

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
                        // cfg.AddConsumersFromNamespaceContaining<EventAConsumer>();
                        cfg.SetKebabCaseEndpointNameFormatter();
                        cfg.UsingRabbitMq(ConfigureBus);
                        
                    });

                    services.AddHostedService<MassTransitHostedService>();
                    services.AddHostedService<SagaInitiatorService>();

                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                })
                .UseConsoleLifetime();
             
           
            await builder.RunConsoleAsync();
           
        }

        static void ConfigureBus(IBusRegistrationContext busRegistrationContext, IRabbitMqBusFactoryConfigurator configurator)
        {
           //configurator.ConfigureEndpoints(busRegistrationContext);
           configurator.AutoDelete = true;
           
           configurator.ReceiveEndpoint("clientSagaInitiatorTest1", e =>
           {
              
           });
        }
    }
}

    
 