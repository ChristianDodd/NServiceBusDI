using NServiceBus;
using NServiceBusCore.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NServiceBusCore
{
    public class TestService : ITestService
    {
        private readonly IEndpointInstance _endpointInstance;
        public TestService(IEndpointInstance endpointInstance)
        {
            _endpointInstance = endpointInstance;
        }

        public async Task Send()
        {
            await _endpointInstance.SendLocal(new TestMEssage { Id = 2 });
        }
    }
}
