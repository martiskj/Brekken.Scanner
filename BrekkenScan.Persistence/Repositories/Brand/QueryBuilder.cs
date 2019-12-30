using BrekkenScan.Domain.Models;
using System.Linq;

namespace BrekkenScan.Persistence.Repositories.Brand.Read
{
    public static class QueryBuilder
    {
        public static IQueryable<Domain.Models.Brand> Filter(this IQueryable<Domain.Models.Brand> brands, BrandFilter filter)
        {
            if (filter.Id != null)
            {
                brands = brands.Where(b => b.Id == filter.Id);
            }

            if (!string.IsNullOrEmpty(filter.NameOrBarcode))
            {
                brands = brands.Where(b =>
                        string.IsNullOrEmpty(filter.NameOrBarcode)
                     || b.Name.Contains(filter.NameOrBarcode)
                     || b.Barcode.Contains(filter.NameOrBarcode));
            }

            return brands;
        }
    }
}
