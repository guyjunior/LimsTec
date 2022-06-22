using LimsDetec.Models;
using Microsoft.EntityFrameworkCore;

namespace LimsDetec.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Sample> Samples { get; set; }

       

    }
}
