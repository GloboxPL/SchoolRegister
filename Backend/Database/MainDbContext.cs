using Microsoft.EntityFrameworkCore;
using SchoolRegister.Models;

namespace SchoolRegister.Database
{
    public class MainDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

    }
}