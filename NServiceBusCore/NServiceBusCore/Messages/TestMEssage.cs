using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace NServiceBusCore.Messages
{
    public class TestMEssage : ICommand
    {
        public int Id { get;set; }
    }
}
