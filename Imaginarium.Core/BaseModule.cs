using Autofac;
using Imaginarium.Core.Mapping;

namespace Imaginarium.Core
{
    public abstract class BaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var assembly = GetType().Assembly;
            builder.RegisterAssemblyTypes(assembly).AssignableTo<IMapping>().AsImplementedInterfaces().AutoActivate();
        }
    }
}
