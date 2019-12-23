using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BrekkenScan.Domain;
using BrekkenScan.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BrekkenScan.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConsumeStorage _storage;

        public IndexModel(IConsumeStorage storage)
        {
            _storage = storage;
        }

        public int Total { get; set; }

        public IEnumerable<string> Tonight { get; set; }

        public decimal PPHPT { get; set; }

        [BindProperty]
        [RegularExpression("^[0-9 ]+$")]
        public string Barcode { get; set; }

        public async Task OnGet()
        {
            var consume = await _storage.Get(new ConsumeFilter());

            Tonight = consume.Tonight;
            Total = consume.Total;
            PPHPT = 0;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _storage.Add(new Consume
                {
                    Barcode = Barcode,
                });
            }

            return Redirect("/");
        }
    }
}