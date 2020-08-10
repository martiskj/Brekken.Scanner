using BrekkenScan.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BrekkenScan.Business
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Consume> Consume { get; set; }

        public DbSet<Brand> Brand { get; set; }
    }
}
