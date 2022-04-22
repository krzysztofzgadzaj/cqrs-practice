using AutoMapper;

namespace FullCqrsApp.Contracts.Base.Mapping.MappingRegister
{
    public interface IMappingRegister
    {
        void RegisterMapping(Profile profile);
    }
}