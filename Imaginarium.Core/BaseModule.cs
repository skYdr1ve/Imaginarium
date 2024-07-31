using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imaginarium.Core
{
    internal class BaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var assembly = GetType().Assembly;
            builder.RegisterAssemblyTypes(assembly).AssignableTo<IMapping>().AsImplementedInterfaces().AutoActivate();
        }
    }
}
