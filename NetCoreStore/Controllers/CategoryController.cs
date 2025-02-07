using Microsoft.AspNetCore.Mvc;
using NetCoreStore.Data;
using NetCoreStore.Models;

namespace NetCoreStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db= db;
        }

        // get all categories
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            // pass it to view
            return View(objCategoryList);
        }

        // show create category view
        public IActionResult Create()
        {
            return View();
        }

        // create category in db
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
