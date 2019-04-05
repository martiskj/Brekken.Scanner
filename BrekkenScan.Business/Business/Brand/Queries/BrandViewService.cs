using BrekkenScan.Domain;
using System.Collections.Generic;
using System.Linq;

namespace BrekkenScan.Business.Business.Brand.Queries
{
    public class BrandViewService
    {
        private readonly ApplicationDbContext db;

        public BrandViewService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<BrandModel> GetBrands(string filter)
        {
            return db.Brand
                .Where(b => string.IsNullOrEmpty(filter) || b.Name.Contains(filter) || b.Barcode.Contains(filter))
                .Select(b => new BrandModel
                {
                    Barcode = b.Barcode,
                    Name = b.Name,
                })
                .ToList();
        }
    }
}
