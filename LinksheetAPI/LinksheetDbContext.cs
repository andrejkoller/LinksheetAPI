using LinksheetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LinksheetAPI
{
    public class LinksheetDbContext : DbContext
    {
        public LinksheetDbContext(DbContextOptions<LinksheetDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<FAQ> FAQs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<FAQ>().ToTable("FAQs");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
