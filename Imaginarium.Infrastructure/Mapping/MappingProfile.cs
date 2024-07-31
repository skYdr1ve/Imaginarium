using AutoMapper;
using Imaginarium.Infrastructure.Mapping.Interfaces;

namespace Imaginarium.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        private IEnumerable<IMapping> _mappings;

        public MappingProfile(IEnumerable<IMapping> mappings)
        {
            if (mappings == null) throw new ArgumentNullException(nameof(mappings));

            _mappings = mappings;

            DisableConstructorMapping();

            DestinationMemberNamingConvention = new ExactMatchNamingConvention();

            foreach (var mapping in _mappings)
            {
                mapping.Configure(this);
            }
        }
    }
}
