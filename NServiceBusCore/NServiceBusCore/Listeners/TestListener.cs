using NServiceBus;
using NServiceBusCore.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NServiceBusCore.Listeners
{
    public class TestListener : IHandleMessages<TestMEssage>
    {
        private readonly ITestDependency _testDependency;
        public TestListener(ITestDependency testDependency)
        {
            _testDependency = testDependency;
        }
        public Task Handle(TestMEssage message, IMessageHandlerContext context)
        {
            throw new NotImplementedException();
        }
    }
}
