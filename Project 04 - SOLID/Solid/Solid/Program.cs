using Solid.DIP;
using Solid.DIP.Contracts;
using System;
using Unity;
using DryIoc;
using System.Diagnostics;

namespace Solid
{
    class Program
    {
        static void Main(string[] args)
        {

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var repository = new CustomerRepository();
            var customerService = new CustomerService(repository);
            repository.Save(new Models.Customer(new Guid(),"abraao", "12345678910"));

            stopwatch.Stop();
            var temp = stopwatch.Elapsed;
            Console.WriteLine($"Tempo passado DIP : {stopwatch.Elapsed}");
            stopwatch.Restart();

            #region DIP - Unity
            stopwatch.Start();

            var container = new UnityContainer();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            var repositoryUnity = container.Resolve<ICustomerRepository>();
            repositoryUnity.Save(new Models.Customer(new Guid(), "Unity", "12345678910"));

            stopwatch.Stop();
            var tempUnity = stopwatch.Elapsed;
            Console.WriteLine($"Tempo passado DIP Unity: {stopwatch.Elapsed}");
            stopwatch.Restart();

            #endregion

            #region DIP - DryIoC
            stopwatch.Start();

            Container containerDryIoC = new Container();
            containerDryIoC.Register<ICustomerRepository, CustomerRepository>();
            var repositoryDryIoC = containerDryIoC.Resolve<ICustomerRepository>();
            repositoryUnity.Save(new Models.Customer(new Guid(), "DryIoC", "12345678910"));

            stopwatch.Stop();
            var tempDryIoC = stopwatch.Elapsed;

            Console.WriteLine($"Tempo passado DIP DryIoC: {stopwatch.Elapsed}");
            Console.WriteLine("\n\n\n");
            Console.WriteLine($"Resultado DryIoC-Unity: {tempDryIoC- tempUnity}");
            Console.WriteLine($"Resultado DryIoC-DipRaiz: {tempDryIoC - temp}");
            Console.WriteLine($"Resultado Unity-DipRaiz: {tempUnity - temp}");

            stopwatch.Restart();
            #endregion
        }
    }
}
