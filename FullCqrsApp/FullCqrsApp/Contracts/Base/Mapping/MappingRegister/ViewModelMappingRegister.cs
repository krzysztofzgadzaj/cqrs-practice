using AutoMapper;

namespace FullCqrsApp.Contracts.Base.Mapping.MappingRegister
{
    public abstract class ViewModelMappingRegister<TSourceType> 
        : IMappingRegister
    {
        public void RegisterMapping(Profile profile) => 
            profile
                .CreateMap(typeof(TSourceType), GetType());
    }
}