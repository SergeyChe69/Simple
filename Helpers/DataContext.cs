using DotBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace DotBlog.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DataContext(IConfiguration config)
        {
            Configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("WebDB"));
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}