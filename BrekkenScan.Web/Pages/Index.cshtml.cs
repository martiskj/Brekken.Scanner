using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BrekkenScan.Business.Business.Consume.Create;
using BrekkenScan.Business.Business.Consume.Get;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BrekkenScan.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ConsumeReadService reader;
        private readonly ConsumeCreateService register;

        public IndexModel(ConsumeReadService reader, ConsumeCreateService register)
        {
            this.reader = reader;
            this.register = register;
        }

        public int Total { get; set; }

        public IEnumerable<string> Tonight { get; set; }

        public decimal PPHPT { get; set; }

        [BindProperty]
        [RegularExpression("^[0-9 ]+$")]
        public string Barcode { get; set; }

        public async Task OnGet()
        {
            var consume = await reader.GetConsume();

            Tonight = consume.Tonight;
            Total = consume.Total;
            PPHPT = 0;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await register.Register(new ConsumeCreateModel
                {
                    Barcode = this.Barcode,
                });
            }

            return Redirect("/");
        }
    }
}