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

        // create category in db, ensure Title Case 
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (!string.IsNullOrWhiteSpace(obj.Name))
            {
                obj.Name = string.Join(" ", obj.Name.Split(' ').Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        // ---- Edit ----

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        // create category in db, ensure Title Case 
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (!string.IsNullOrWhiteSpace(obj.Name))
            {
                obj.Name = string.Join(" ", obj.Name.Split(' ').Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category has been edited successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        // ---- Delete ----
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCategory(int? id)
        {
            Category obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");          
        }
    }
}
