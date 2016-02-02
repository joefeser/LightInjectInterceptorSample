using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IExampleService
    {
        void WorkingCall(string test, int value);

        void BlowsUp(string test, int value);
    }
}
