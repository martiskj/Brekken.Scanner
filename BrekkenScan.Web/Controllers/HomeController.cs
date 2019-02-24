using BrekkenScan.Business.Business.Consume.Commands;
using BrekkenScan.Business.Business.Consume.Queries;
using BrekkenScan.Web.Models.Consume;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ConsumeModel = BrekkenScan.Business.Business.Consume.Commands.ConsumeModel;

namespace BrekkenScan.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index([FromServices] ConsumeViewService service)
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
            [FromServices] ConsumeRegisterService service)
        {
            await service.Register(new ConsumeModel
            {
                Barcode = consume.Barcode,
            });
            return Redirect("/");
        }
    }
}
