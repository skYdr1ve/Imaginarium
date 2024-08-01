using Autofac;

namespace Imaginarium.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterGeneric(typeof(Repository<>)).AsImplementedInterfaces();
        }
    }
}
