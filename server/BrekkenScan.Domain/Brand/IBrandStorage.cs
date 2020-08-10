using BrekkenScan.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrekkenScan.Domain
{
    public interface IBrandStorage
    {
        Task Add(Brand brand);

        Task Update(Brand brand);

        Task<IEnumerable<Brand>> Get(BrandFilter filter);
        
        Task<Brand> Get(int id);
    }
}
