using BrekkenScan.Domain;
using System.Threading.Tasks;

namespace BrekkenScan.Business.Business.Brand.Create
{
    public class BrandCreateService
    {
        private readonly ApplicationDbContext database;

        public BrandCreateService(ApplicationDbContext database)
        {
            this.database = database;
        }

        public async Task Create(BrandCreateModel model)
        {
            await database.Brand.AddAsync(new Domain.Brand
            {
                Barcode = model.Barcode,
                Name = model.Name,
            });
            await database.SaveChangesAsync();
        }
    }
}
