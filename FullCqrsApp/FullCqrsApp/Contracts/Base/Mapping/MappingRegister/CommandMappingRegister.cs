using AutoMapper;

namespace FullCqrsApp.Contracts.Base.Mapping.MappingRegister
{
    public abstract class CommandMappingRegister<TDestinationType> 
        : IMappingRegister
    {
        public void RegisterMapping(Profile profile) =>
            profile
                .CreateMap(GetType(), typeof(TDestinationType));
    }
}