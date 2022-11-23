using DotBlog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotBlog.Helpers
{
    public class IdentityContext : IdentityDbContext<IdentityUser>
    {
        protected readonly IConfiguration Configuration;
        public IdentityContext(IConfiguration config)
        {
            Configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("IdentityDB"));
        }
    }
}