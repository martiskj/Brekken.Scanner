using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrekkenScan.Business.Business.Brand.Create;
using BrekkenScan.Business.Business.Brand.Get;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BrekkenScan.Web.Pages.Brands
{
    public class CreateModel : PageModel
    {
        private readonly BrandCreateService creater;

        public CreateModel(BrandCreateService creater)
        {
            this.creater = creater;
        }

        [BindProperty]
        public BrandCreateModel Brand { get; set; }

        public IActionResult OnGet()
        {
            Brand = new BrandCreateModel();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await creater.Create(Brand);
            return RedirectToPage("./List");
        }
    }
}