using Microsoft.EntityFrameworkCore;

namespace LibraryManagement
{
    public class AppDbContext : DbContext
    {
        public DbSet<Models.Book> Book { get; set; }
        private readonly IConfiguration _configuration;
        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
