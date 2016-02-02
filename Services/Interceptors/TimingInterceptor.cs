using LightInject.Interception;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interceptors
{
    public class TimingInterceptor : IInterceptor
    {
        public object Invoke(IInvocationInfo invocationInfo)
        {
            var timer = Stopwatch.StartNew();
            try
            {
                // Perform logic before invoking the target method
                var returnValue = invocationInfo.Proceed();
                // Perform logic after invoking the target method
                timer.Stop();
                LogTime(invocationInfo, timer.ElapsedMilliseconds);
                return returnValue;
            }
            catch (Exception)
            {
                timer.Stop();
                LogTime(invocationInfo, timer.ElapsedMilliseconds);
                throw;
            }
        }

        private void LogTime(IInvocationInfo invocationInfo, long time)
        {
            var method = invocationInfo.Method;
            var target = invocationInfo.Proxy.Target;
            //You could discover these and determine what to do with it.
            var parameters = invocationInfo.Arguments;
            //Add a logger and log this data so we know what is taking so long.
        }
    }
}
