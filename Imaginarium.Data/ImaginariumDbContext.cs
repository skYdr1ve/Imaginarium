using Microsoft.EntityFrameworkCore;

namespace Imaginarium.Data
{
    public class ImaginariumDbContext : DbContext
    {
        public ImaginariumDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ImaginariumDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> IsAvailable()
        {
            return await Database.CanConnectAsync();
        }
    }
}
