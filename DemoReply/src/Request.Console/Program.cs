using System.Threading.Tasks;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Request.Console
{
    class Program
    {

        static async Task Main(string[] args)
        { 
            IConfiguration config;

            config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

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
                        cfg.UsingRabbitMq(ConfigureBus);
                        
                    });

                    services.AddLogging(cfg => cfg.AddConsole());
                    services.AddHostedService<MassTransitConsoleHostedService>();
                    services.AddHostedService<MessageRequestPublisherService>();

                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConsole();
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));

                })
                .UseConsoleLifetime();

            await builder.RunConsoleAsync();
        }

        static void ConfigureBus(IBusRegistrationContext busRegistrationContext,
            IRabbitMqBusFactoryConfigurator configurator)
        {
            configurator.AutoDelete = true;
            configurator.ReceiveEndpoint("clientPublishTest", e => { });
        }
    }
}
