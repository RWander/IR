using System;
using LightInject;

using IR.Core;

namespace IR.CLI
{
    class Program
    {
        private static ServiceContainer Container;
        private static IService Srvc;

        static void Main(string[] args)
        {
            RegisterServices();
            Srvc = Container.GetInstance<IService>();

            Console.WriteLine(Srvc.Authorize());

            DisposeServices();
        }

        private static void RegisterServices()
        {
            Container = new ServiceContainer();
            Container.Register<IService, Service>();
        }

        private static void DisposeServices()
        {
            if (Srvc is IDisposable disp)
            {
                disp.Dispose();
                Srvc = null;
            }

            if (Container != null)
            {
                Container.Dispose();
                Container = null;
            }
        }
    }
}
