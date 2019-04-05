using BrekkenScan.Domain;
using System.Collections.Generic;
using System.Linq;

namespace BrekkenScan.Business.Business.Brand.Get
{
    public class BrandViewService
    {
        private readonly ApplicationDbContext db;

        public BrandViewService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<BrandViewModel> GetBrands(BrandFilter filter)
        {
            return db.Brand.Filter(filter)
                .Select(b => new BrandViewModel
                {
                    Id = b.Id,
                    Barcode = b.Barcode,
                    Name = b.Name,
                })
                .ToList();
        }

        public BrandViewModel GetBrand(int id)
        {
            return GetBrands(new BrandFilter
            {
                Id = id
            }).SingleOrDefault();
        }
    }

    public class BrandFilter
    {
        public int? Id { get; set; }

        public string NameOrBarcode { get; set; }
    }
}
