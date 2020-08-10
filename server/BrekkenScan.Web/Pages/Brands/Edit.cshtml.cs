using System.Threading.Tasks;
using BrekkenScan.Domain;
using BrekkenScan.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BrekkenScan.Web.Pages.Brands
{
    public class EditBrandsModel : PageModel
    {
        private readonly IBrandStorage _storage;

        public EditBrandsModel(IBrandStorage storage)
        {
            _storage = storage;
        }

        [BindProperty]
        public Brand Brand { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Brand = await _storage.Get(id);
            if (Brand == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await _storage.Update(Brand);
            return Page();
        }
    }
}