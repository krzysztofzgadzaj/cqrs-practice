using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using FullCqrsApp.Contracts.Base.Mapping.MappingRegister;

namespace FullCqrsApp.Contracts.Base.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t
                    .GetInterfaces()
                    .Any(i => i == typeof(IMappingRegister)))
                .Where(x => x.ContainsGenericParameters == false);
            
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type) as IMappingRegister;
                instance?.RegisterMapping(this);
            }
        }
    }
}