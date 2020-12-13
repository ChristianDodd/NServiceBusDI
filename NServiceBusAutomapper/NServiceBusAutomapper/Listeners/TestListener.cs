using ConsoleApp1.Messages;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Listeners
{
    public class TestListener : IHandleMessages<TestMessage>
    {
        private readonly ITestRepository _testRepository;
        public TestListener(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public Task Handle(TestMessage message, IMessageHandlerContext context)
        {
            throw new NotImplementedException();
        }
    }
}
