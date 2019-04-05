using BrekkenScan.Domain;
using System.Threading.Tasks;

namespace BrekkenScan.Business.Business.Brand.Create
{
    public class BrandCreateService
    {
        private readonly ApplicationDbContext db;

        public BrandCreateService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task Create(BrandCreateModel model)
        {
            await db.Brand.AddAsync(new Domain.Entities.Brand
            {
                Barcode = model.Barcode,
                Name = model.Name,
            });
            await db.SaveChangesAsync();
        }
    }
}
