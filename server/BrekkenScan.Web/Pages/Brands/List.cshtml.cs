using BrekkenScan.Domain;
using BrekkenScan.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrekkenScan.Web.Pages.Brands
{
    public class BrandListingModel : PageModel
    {
        private readonly IBrandStorage _storage;

        public BrandListingModel(IBrandStorage storage)
        {
            _storage = storage;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchCriteria { get; set; }

        public IEnumerable<Brand> Brands { get; set; }

        public async Task OnGet()
        {
            Brands = await _storage.Get(new BrandFilter
            {
                NameOrBarcode = SearchCriteria,
            });
        }
    }
}