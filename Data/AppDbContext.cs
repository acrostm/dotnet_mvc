using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LibraryManagement.Models;

namespace LibraryManagement.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Models.Books> Books { get; set; }
        public DbSet<Models.Authors> Authors { get; set; }
        public DbSet<Models.Customers> Customers { get; set; }
        public DbSet<Models.LibraryBranches> LibraryBranches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>()
                .HasOne(b => b.Author)
                .WithMany()
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Books>()
                .HasOne(b => b.LibraryBranch)
                .WithMany()
                .HasForeignKey(b => b.LibraryBranchId);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
