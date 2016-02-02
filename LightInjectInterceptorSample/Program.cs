using LightInject;
using Services.Interceptors;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightInjectInterceptorSample
{
    class Program
    {
        static ServiceContainer container = null;
        static void Main(string[] args)
        {
            InitializeContainer();

            var service = container.GetInstance<IExampleService>();
            try
            {
                service.WorkingCall("test param", 2300);
                service.BlowsUp("test param 99", 22);
            }
            catch (Exception)
            {

            }

            Console.ReadLine();
        }


        //not best practice, just showing how all of the magic happens.

        static void InitializeContainer()
        {
            container = new ServiceContainer();

            container.RegisterAssembly(typeof(Services.Installer).Assembly, () => { return new PerContainerLifetime(); },
                (serviceType, implementingType) => serviceType.Namespace == typeof(Services.Installer).Namespace + ".Interfaces");

            //register the interceptors
            container.Register<ExceptionInterceptor>();
            container.Register<TimingInterceptor>();

            //register by hand
            //container.Register<IConfigurationService, ConfigurationService>();

            //Wire up a Timing and Exception Interceptor
            container.Intercept(sr => sr.ServiceType == typeof(IExampleService), sf => sf.GetInstance<ExceptionInterceptor>());
            container.Intercept(sr => sr.ServiceType == typeof(IExampleService), sf => sf.GetInstance<TimingInterceptor>());

        }

    }
}
