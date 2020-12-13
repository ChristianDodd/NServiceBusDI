using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NServiceBusCore
{
    public interface ITestService
    {
        Task Send();
    }
}
