using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using Module = Autofac.Module;

namespace DependencyInjection.IoC_Container
{
    public class ProgramModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IcecekMakinesi>().AsSelf();
            builder.RegisterType<Kahve>().As<IIcecek>();
        }
    }
}
