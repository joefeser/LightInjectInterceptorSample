using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ExampleService : IExampleService
    {
        public void BlowsUp(string test, int value)
        {
            throw new NotImplementedException();
        }

        public void WorkingCall(string test, int value)
        {
            Thread.Sleep(value);
        }
    }
}
