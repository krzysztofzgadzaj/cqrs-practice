using System;

namespace FullCqrsApp.Persistence.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}