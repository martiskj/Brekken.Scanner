using BrekkenScan.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrekkenScan.Domain
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
