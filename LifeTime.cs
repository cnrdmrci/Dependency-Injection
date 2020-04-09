using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.LifeTime
{
    public class LifeTime
    {
        public static void Run()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ITransient, TransientOperation>()
                .AddScoped<IScoped, ScopedOperation>()
                .AddSingleton<ISingleton, SingletonOperation>()
                .BuildServiceProvider();

            Console.WriteLine("========== Request 1 ============");
            serviceProvider.GetService<ITransient>().Info();
            serviceProvider.GetService<IScoped>().Info();
            serviceProvider.GetService<ISingleton>().Info();
            Console.WriteLine("========== ========= ============");

            Console.WriteLine("========== Request 2 ============");
            serviceProvider.GetService<ITransient>().Info();
            serviceProvider.GetService<IScoped>().Info();
            serviceProvider.GetService<ISingleton>().Info();
            Console.WriteLine("========== ========= ============");


            using (var scope = serviceProvider.CreateScope())
            {
                Console.WriteLine("========== Request 3 ============");
                scope.ServiceProvider.GetService<IScoped>().Info();
                scope.ServiceProvider.GetService<ITransient>().Info();
                scope.ServiceProvider.GetService<ISingleton>().Info();
                Console.WriteLine("========== ========= ============");

                Console.WriteLine("========== Request 4 ============");
                scope.ServiceProvider.GetService<IScoped>().Info();
                scope.ServiceProvider.GetService<ISingleton>().Info();
                Console.WriteLine("========== ========= ============");
            }

            using (var scope = serviceProvider.CreateScope())
            {
                Console.WriteLine("========== Request 5 ============");
                scope.ServiceProvider.GetService<IScoped>().Info();
                scope.ServiceProvider.GetService<ISingleton>().Info();
                Console.WriteLine("========== ========= ============");
            }


            Console.WriteLine("========== Request 6 ============");
            serviceProvider.GetService<IScoped>().Info();
            Console.WriteLine("========== ========= ============");
        }
    }

    public interface IService
    {
        void Info();
    }

    public interface ISingleton : IService { }
    public interface IScoped : IService { }
    public interface ITransient : IService { }

    public abstract class Operation : ISingleton, IScoped, ITransient
    {
        private Guid _operationId;
        private string _lifeTime;

        public Operation(string lifeTime)
        {
            _operationId = Guid.NewGuid();
            _lifeTime = lifeTime;

            Console.WriteLine($"{_lifeTime} Service Created.");
        }

        public void Info()
        {
            Console.WriteLine($"{_lifeTime}: {_operationId}");
        }
    }

    public class SingletonOperation : Operation
    {
        public SingletonOperation() : base("Singleton") { }
    }
    public class ScopedOperation : Operation
    {
        public ScopedOperation() : base("Scoped") { }
    }
    public class TransientOperation : Operation
    {
        public TransientOperation() : base("Transient") { }
    }
}
