using BrekkenScan.Domain;
using System.Threading.Tasks;

namespace BrekkenScan.Business.Business.Brand.Update
{
    public class BrandUpdateService
    {
        private readonly ApplicationDbContext db;

        public BrandUpdateService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task Update(int id, BrandUpdateModel update)
        {
            var brand = await db.Brand.FindAsync(id);
            if (brand != null)
            {
                brand.Name = update.Name;
                brand.Barcode = update.Barcode;
            }

            await db.SaveChangesAsync();
        }
    }
}
