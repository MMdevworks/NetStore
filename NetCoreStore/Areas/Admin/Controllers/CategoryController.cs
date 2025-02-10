using Microsoft.AspNetCore.Mvc;
using NetStore.DataAccess.Data;
using NetStore.DataAccess.Repository.IRepository;
using NetStore.Models;


namespace NetCoreStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // get all categories
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
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
            obj.Name = obj.Name.Trim();

            if (!string.IsNullOrWhiteSpace(obj.Name))
            {
                obj.Name = string.Join(" ", obj.Name.Split(' ').Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
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

            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
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
            obj.Name = obj.Name.Trim();

            if (!string.IsNullOrWhiteSpace(obj.Name))
            {
                obj.Name = string.Join(" ", obj.Name.Split(' ').Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
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

            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCategory(int? id)
        {
            Category obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
