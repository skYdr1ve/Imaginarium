
using Autofac;
using AutoMapper;
using Imaginarium.Infrastructure.Mapping;

namespace Imaginarium.Infrastructure
{
    public class InfrastructureModule : BaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<MappingProfile>().AsSelf();
            builder.Register(c => new MapperConfiguration(cfg =>
            {
                cfg.DestinationMemberNamingConvention = new ExactMatchNamingConvention();

                cfg.AddProfile(c.Resolve<MappingProfile>());
            })).AsSelf().SingleInstance();
        }
    }
}
