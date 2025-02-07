using Microsoft.AspNetCore.Mvc;

namespace NetCoreStore.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
