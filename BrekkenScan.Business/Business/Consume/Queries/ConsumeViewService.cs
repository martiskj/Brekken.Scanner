using System.Linq;
using System.Threading.Tasks;
using BrekkenScan.Domain;
using Microsoft.EntityFrameworkCore;

namespace BrekkenScan.Business.Business.Consume.Queries
{
    public class ConsumeViewService
    {
        private readonly ApplicationDbContext _db;

        public ConsumeViewService(ApplicationDbContext db) => _db = db;

        public async Task<ConsumeModel> GetConsume() => new ConsumeModel
        {
            Total = await _db.Consume.CountAsync(),
            Tonight = _db.Consume
                .Where(c => c.TimeStamp > System.DateTime.Now.AddHours(-13))
                .ToList()
                .Select(c => GetBrand(c) ?? "Ukjent")
        };

        private string GetBrand(Domain.Entities.Consume consume)
            => _db.Brand.FirstOrDefault(brand => brand.Barcode == consume.Barcode)?.Name;
    }
}