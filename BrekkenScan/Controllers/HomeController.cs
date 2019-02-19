using BrekkenScan.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BrekkenScan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var m = new IndexModel
            {
                IKveld = 67,
                Totalt = 945,
                PPHPT = 1.23m,
            };
            return View(m);
        }
    }
}
