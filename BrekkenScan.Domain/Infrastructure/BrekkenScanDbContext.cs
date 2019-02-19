using BrekkenScan.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrekkenScan.Domain.Infrastructure
{
    public class BrekkenScanDbContext : DbContext
    {
        public BrekkenScanDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Consume> Consume { get; set; }
    }
}
