using System.Linq;
using System.Threading.Tasks;
using BrekkenScan.Domain;
using Microsoft.EntityFrameworkCore;

namespace BrekkenScan.Business.Business.Consume.Get
{
    public class ConsumeReadService
    {
        private readonly ApplicationDbContext database;

        public ConsumeReadService(ApplicationDbContext database) => this.database = database;

        public async Task<ConsumeReadModel> GetConsume() => new ConsumeReadModel
        {
            Total = await database.Consume.CountAsync(),
            Tonight = database.Consume
                .Where(c => c.TimeStamp > System.DateTime.Now.AddHours(-13))
                .ToList()
                .Select(c => GetBrand(c) ?? "Ukjent")
        };

        private string GetBrand(Domain.Consume consume)
            => database.Brand.FirstOrDefault(brand => brand.Barcode == consume.Barcode)?.Name;
    }
}