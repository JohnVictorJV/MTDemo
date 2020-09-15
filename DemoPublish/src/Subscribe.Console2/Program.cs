using System.Threading.Tasks;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Subscribe.Console2
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
                        cfg.UsingRabbitMq(ConfigureBus);
                        
                    });

                    services.AddHostedService<MassTransitConsoleHostedService>();
                    services.AddHostedService<ConsoleWriteLineService>();

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
            configurator.AutoDelete = true;
            configurator.ReceiveEndpoint("clientSubsriberTest2", e =>
           {
               e.Consumer<EventAConsumer>();
               e.Consumer<EventBConsumer>();
               e.Consumer<EventCConsumer>();
               e.Consumer<EventDConsumer>();
               e.Consumer<EventEConsumer>();
               e.Consumer<EventFConsumer>();
               e.Consumer<EventGConsumer>();
               e.Consumer<Event1Consumer>();
               e.Consumer<Event2Consumer>();
               e.Consumer<Event3Consumer>();
               e.Consumer<EventG123Consumer>();
           });
        }
    }
}

    
 