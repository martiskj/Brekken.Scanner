using BrekkenScan.Business;
using BrekkenScan.Domain;
using BrekkenScan.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BrekkenScan.Persistence.Repositories.Consume
{
    public class ConsumeStorage : IConsumeStorage
    {
        private readonly ApplicationDbContext _database;

        public ConsumeStorage(ApplicationDbContext database)
        {
            _database = database;
        }

        public async Task Add(Domain.Models.Consume consume)
        {
            consume.TimeStamp = DateTime.Now;
            await _database.Consume.AddAsync(consume);
            await _database.SaveChangesAsync();
        }

        public async Task<ConsumeReadModel> Get(ConsumeFilter filter)
        {
            return new ConsumeReadModel
            {
                Total = await _database.Consume.CountAsync(),
                Tonight = _database.Consume
                    .Where(c => c.TimeStamp > DateTime.Now.AddHours(-13))
                    .ToList()
                    .Select(c => GetBrand(c) ?? "Ukjent")
            };
        }

        private string GetBrand(Domain.Models.Consume consume)
            => _database.Brand.FirstOrDefault(brand => brand.Barcode == consume.Barcode)?.Name;
    }
}
