using LightInject.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interceptors
{
    public class ExceptionInterceptor : IInterceptor
    {
        public object Invoke(IInvocationInfo invocationInfo)
        {
            try
            {
                // Perform logic before invoking the target method
                var returnValue = invocationInfo.Proceed();
                // Perform logic after invoking the target method
                return returnValue;
            }
            catch (Exception ex)
            {
                LogExceptionInformation(invocationInfo, ex);
                throw;
            }
        }

        private void LogExceptionInformation(IInvocationInfo invocationInfo, Exception ex)
        {
            var method = invocationInfo.Method;
            var target = invocationInfo.Proxy.Target;
            //You could discover these and determine what to do with it.
            var parameters = invocationInfo.Arguments;
            //Add a logger and log this data so we know what is taking so long.
            //because you have the error, you now have all of the data that was passed to 
        }
    }
}
