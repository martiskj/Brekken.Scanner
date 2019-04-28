using BrekkenScan.Domain;
using System.Collections.Generic;
using System.Linq;

namespace BrekkenScan.Business.Business.Brand.Get
{
    public class BrandReadService
    {
        private readonly ApplicationDbContext database;

        public BrandReadService(ApplicationDbContext database)
        {
            this.database = database;
        }
        public IEnumerable<BrandReadModel> GetBrands(BrandFilter filter)
        {
            return database.Brand
                .Filter(filter)
                .Select(b => new BrandReadModel
                {
                    Id = b.Id,
                    Barcode = b.Barcode,
                    Name = b.Name,
                })
                .ToList();
        }

        public BrandReadModel GetBrand(int id)
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
