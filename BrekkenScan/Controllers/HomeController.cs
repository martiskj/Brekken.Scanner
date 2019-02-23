using BrekkenScan.Application.Consume;
using BrekkenScan.Business.Business.Consume.Commands;
using BrekkenScan.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BrekkenScan.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index([FromServices] GetConsumeService service)
        {
            var consume = await service.GetConsume();
            return View(new IndexModel
            {
                Tonight = consume.Tonight,
                Total = consume.Total,
                PPHPT = 1.23m,
            });
        }

        public async Task<ActionResult> Create(string barcode, [FromServices] PostConsumeService service)
        {
            await service.PostConsume(barcode);
            return Redirect("Index");
        }
    }
}
