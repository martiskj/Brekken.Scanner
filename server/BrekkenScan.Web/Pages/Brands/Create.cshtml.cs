using System.Threading.Tasks;
using BrekkenScan.Domain;
using BrekkenScan.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BrekkenScan.Web.Pages.Brands
{
    public class CreateModel : PageModel
    {
        private readonly IBrandStorage _storage;

        public CreateModel(IBrandStorage storage)
        {
            _storage = storage;
        }

        [BindProperty]
        public BrandCreateModel Brand { get; set; } = new BrandCreateModel();

        public async Task<IActionResult> OnPost()
        {
            await _storage.Add(new Brand
            {
                Barcode = Brand.Barcode,
                Name = Brand.Name
            });

            return RedirectToPage("./List");
        }

        public class BrandCreateModel
        {
            public string Name { get; set; }

            public string Barcode { get; set; }
        }
    }
}