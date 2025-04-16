using LinksheetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LinksheetAPI
{
    public class LinksheetDbContext : DbContext
    {
        public LinksheetDbContext(DbContextOptions<LinksheetDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<FAQ>().ToTable("FAQs");
            modelBuilder.Entity<Link>().ToTable("Links")
                .HasOne(l => l.User)
                .WithMany(u => u.Links)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);
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
