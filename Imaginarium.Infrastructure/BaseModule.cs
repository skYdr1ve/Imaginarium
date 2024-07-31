using Autofac;
using Imaginarium.Infrastructure.Mapping.Interfaces;

namespace Imaginarium.Infrastructure
{
    public class BaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var assembly = GetType().Assembly;
            builder.RegisterAssemblyTypes(assembly).AssignableTo<IMapping>().AsImplementedInterfaces().AutoActivate();
        }
    }
}
