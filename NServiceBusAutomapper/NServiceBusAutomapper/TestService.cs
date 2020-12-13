using ConsoleApp1.Messages;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TestService : ITestService
    {
        private readonly IEndpointInstance _instance;

        public TestService(IEndpointInstance instance)
        {
            _instance = instance;
        }

        public async Task Send()
        {
            await _instance.SendLocal(new TestMessage { Id = 3 });
        }
    }
}
