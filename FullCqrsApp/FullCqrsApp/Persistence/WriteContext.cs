using System.Reflection;
using FullCqrsApp.Persistence.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace FullCqrsApp.Persistence
{
    public class WriteContext : DbContext
    {
        public const string DatabaseName = "WriteSchema";
        
        public WriteContext(DbContextOptions<WriteContext> options) 
            : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}