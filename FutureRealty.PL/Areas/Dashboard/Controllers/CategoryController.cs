using Microsoft.AspNetCore.Mvc;

namespace FutureRealty.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
