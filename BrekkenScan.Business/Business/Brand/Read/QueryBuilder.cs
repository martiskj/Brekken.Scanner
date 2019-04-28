using BrekkenScan.Business.Business.Brand.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrekkenScan.Business.Business.Brand.Get
{
    public static class QueryBuilder
    {
        public static IQueryable<Domain.Brand> Filter(this IQueryable<Domain.Brand> brands, BrandFilter filter)
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
