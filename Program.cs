using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dependency Injection Types");
            ConstrutorInjection.ConstructorInjection.Run();
            MethodInjection.MethodInjection.Run();
            SetterInjection.SetterInjection.Run();

            Console.WriteLine("IoC Container");
            IoC_Container.IoC_Container.Run();
        }
    }
}
