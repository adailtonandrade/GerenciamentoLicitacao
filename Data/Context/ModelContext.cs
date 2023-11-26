using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Context
{
    public class ModelContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ModelContext(DbContextOptions<ModelContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ModelContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
