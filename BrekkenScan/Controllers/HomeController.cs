using BrekkenScan.Application.Consume;
using BrekkenScan.Business.Business.Consume.Commands;
using BrekkenScan.Web.Models.Consume;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ConsumeModel = BrekkenScan.Business.Business.Consume.Commands.ConsumeModel;

namespace BrekkenScan.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index([FromServices] ViewConsumeService service)
        {
            var consume = await service.GetConsume();
            return View(new ConsumeViewModel
            {
                Tonight = consume.Tonight,
                Total = consume.Total,
                PPHPT = 1.23m,
            });
        }

        public async Task<ActionResult> RegisterConsume(
            ConsumeEditModel consume,
            [FromServices] RegisterConsumeService service)
        {
            await service.RegisterConsume(new ConsumeModel
            {
                Barcode = consume.Barcode,
            });
            return Redirect("Index");
        }
    }
}
