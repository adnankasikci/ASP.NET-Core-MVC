
using AppSpace.Models;
using Microsoft.EntityFrameworkCore;

namespace AppSpace.Db
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Author> Author { get; set; }
        public DbSet<Blogs> Blogs { get; set; }

    }


}