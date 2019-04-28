using BrekkenScan.Domain;
using System.Threading.Tasks;

namespace BrekkenScan.Business.Business.Brand.Update
{
    public class BrandUpdateService
    {
        private readonly ApplicationDbContext database;

        public BrandUpdateService(ApplicationDbContext database)
        {
            this.database = database;
        }

        public async Task Update(int id, BrandUpdateModel update)
        {
            var brand = await database.Brand.FindAsync(id);
            if (brand != null)
            {
                brand.Name = update.Name;
                brand.Barcode = update.Barcode;
            }

            await database.SaveChangesAsync();
        }
    }
}
