using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace DependencyInjection.IoC_Container
{
    public class IoC_Container
    {
        public static void Run()
        {
            IContainer container = getAutofacConfigFromPrograModule();

            using (var scope = container.BeginLifetimeScope())
            {
                var icecekMakinesi = scope.Resolve<IcecekMakinesi>();
                //IcecekMakinesi icecekMakinesi = new IcecekMakinesi(container.Resolve<IIcecek>());
                icecekMakinesi.Olustur();
            }

        }

        public static IContainer getAutofacConfigFromPrograModule()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ProgramModule>();
            IContainer container = builder.Build();
            return container;
        }

        public static IContainer getAutofacConfigContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<IcecekMakinesi>().AsSelf();
            builder.RegisterType<Kahve>().As<IIcecek>();
            IContainer container = builder.Build();

            return container;
        }
    }

    public interface IIcecek
    {
        void Hazirla();
    }
    public class Kahve : IIcecek
    {
        public void Hazirla()
        {
            Console.WriteLine("Kahve hazırlanıyor.");
        }
    }
    public class IcecekMakinesi
    {
        IIcecek _icecek;
        public IcecekMakinesi(IIcecek icecek)
        {
            _icecek = icecek;
        }
        public void Olustur()
        {
            _icecek.Hazirla();
        }
    }
}
