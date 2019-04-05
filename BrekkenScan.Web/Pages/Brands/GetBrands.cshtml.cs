using BrekkenScan.Business.Business.Brand.Get;
using BrekkenScan.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace BrekkenScan.Web.Pages.Brands
{
    public class GetBrandsModel : PageModel
    {
        private readonly BrandViewService service;

        public GetBrandsModel(BrandViewService service)
        {
            this.service = service;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchCriteria { get; set; }

        public IEnumerable<BrandViewModel> Brands { get; set; }

        public void OnGet()
        {
            Brands = service.GetBrands(new BrandFilter
            {
                NameOrBarcode = SearchCriteria
            });
        }
    }
}