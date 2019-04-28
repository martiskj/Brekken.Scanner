using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrekkenScan.Business.Business.Brand.Get;
using BrekkenScan.Business.Business.Brand.Update;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BrekkenScan.Web.Pages.Brands
{
    public class EditBrandsModel : PageModel
    {
        private readonly BrandReadService getter;
        private readonly BrandUpdateService updater;

        public EditBrandsModel(
            BrandReadService getter,
            BrandUpdateService updater)
        {
            this.getter = getter;
            this.updater = updater;
        }

        [BindProperty]
        public BrandReadModel Brand { get; set; }

        public IActionResult OnGet(int id)
        {
            Brand = getter.GetBrand(id);
            if (Brand == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await updater.Update(Brand.Id, new BrandUpdateModel
            {
                Barcode = Brand.Barcode,
                Name = Brand.Name,
            });

            return Page();
        }
    }
}