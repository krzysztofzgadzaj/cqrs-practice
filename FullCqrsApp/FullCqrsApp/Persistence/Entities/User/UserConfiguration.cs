using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullCqrsApp.Persistence.Entities.User
{
    public class UserConfiguration :
        IEntityTypeConfiguration<User>
    {
        private const string TableName = "Users";
        
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable(TableName, WriteContext.DatabaseName)
                .HasKey(x => x.Id);
            
            builder
                .Property(x => x.Id)
                .IsRequired();

            builder
                .Property(x => x.Name)
                .IsRequired();
            
            builder
                .Property(x => x.Surname)
                .IsRequired();
        }
    }
}