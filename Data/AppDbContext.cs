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

        public DbSet<Models.Book> Book { get; set; }
        public DbSet<Models.Author> Author { get; set; }
        public DbSet<Models.LibraryBranch> LibraryBranch { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
