
using ConsoleApp1.Messages;
using NServiceBus;
using NServiceBus.Container;
using NServiceBus.Settings;
using StructureMap;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Configure the container and start the bus/register the endpoints
            var container = ConfigureContainer();

            //Grab a service and send command
            var testService = container.GetInstance<ITestService>();

            await testService.Send();
            Console.ReadLine();
        }

        private static IContainer ConfigureContainer()
        {
            //Create the endpoint configuration
            var endpointConfiguration = new EndpointConfiguration("Test");
            var transport = endpointConfiguration.UseTransport<LearningTransport>();

            //Create the container
            var container = Container.For<ConsoleRegistry>();

            //Configure the endpoint to use the structuremap container
            endpointConfiguration.UseContainer<StructureMapBuilder>(
                customizations: customizations =>
                {
                    customizations.ExistingContainer(container);
                });

            //Start the endpoint, and then register with the existing container
            var injectableInstance = NServiceBus.Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();
            container.Inject<IEndpointInstance>(injectableInstance);

            return container;
        }
    }

    public class ConsoleRegistry : Registry
    {
        public ConsoleRegistry()
        {
            For<ITestService>().Use<TestService>();
            For<ITestRepository>().Use<TestRepository>();
        }
    }
}
