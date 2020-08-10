using BrekkenScan.Business;
using BrekkenScan.Domain;
using BrekkenScan.Domain.Models;
using BrekkenScan.Persistence.Repositories.Brand.Read;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrekkenScan.Persistence.Repositories.Brand
{
    class BrandStorage : IBrandStorage
    {
        private readonly ApplicationDbContext _database;

        public BrandStorage(ApplicationDbContext database)
        {
            _database = database;
        }

        public async Task Add(Domain.Models.Brand brand)
        {
            await _database.Brand.AddAsync(brand);
            await _database.SaveChangesAsync();
        }

        public async Task<Domain.Models.Brand> Get(int id)
        {
            return (await Get(new BrandFilter { Id = id })).SingleOrDefault();
        }

        public async Task<IEnumerable<Domain.Models.Brand>> Get(BrandFilter filter)
        {
            return await _database.Brand.Filter(filter).ToListAsync();
        }

        public async Task Update(Domain.Models.Brand brand)
        {
            var entry = await _database.Brand.FindAsync(brand.Id);
            if (entry != null)
            {
                entry.Name = brand.Name;
                entry.Barcode = brand.Barcode;
            }

            await _database.SaveChangesAsync();
        }
    }
}
