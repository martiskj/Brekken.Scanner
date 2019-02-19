using BrekkenScan.Application.Consume;
using BrekkenScan.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BrekkenScan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index([FromServices] GetConsumeService service)
        {
            var consume = service.GetConsume();
            return View(new IndexModel
            {
                Tonight = consume.Tonight,
                Total = consume.Total,
                PPHPT = 1.23m,
            });
        }
    }
}
