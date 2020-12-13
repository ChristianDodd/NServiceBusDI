using Microsoft.Extensions.DependencyInjection;
using NServiceBus;
using NServiceBusCore.Messages;
using System;
using System.Threading.Tasks;

namespace NServiceBusCore
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var services = ConfigureServices();

            var serviceProvider = services.BuildServiceProvider();

            var testService = serviceProvider.GetService<ITestService>();
            await testService.Send();

            Console.ReadLine();
        }

        private static ServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddScoped<ITestService, TestService>();
            services.AddScoped<ITestDependency, TestDependency>();

            ConfigureNServiceBus(services);

            return services;
        }

        private static void ConfigureNServiceBus(IServiceCollection services)
        {
            var endpointConfiguration = new EndpointConfiguration("Test");
            var transport = endpointConfiguration.UseTransport<LearningTransport>();

            //Configure endpoint to use services
            endpointConfiguration.UseContainer<ServicesBuilder>(
                customizations: customizations =>
                {
                    customizations.ExistingServices(services);
                });

            //Start endpoint and register with container
            var endpoint = NServiceBus.Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();
       
            services.AddScoped(typeof(IEndpointInstance), x => endpoint);
        }
    }
}
