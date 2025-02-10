using Microsoft.AspNetCore.Mvc;
using NetStore.DataAccess.Data;
using NetStore.DataAccess.Repository.IRepository;
using NetStore.Models;


namespace NetCoreStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // get all products
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            // pass it to view
            return View(objProductList);
        }

        // show create product view
        public IActionResult Create()
        {
            return View();
        }

        // create product in db, ensure Title Case 
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            obj.ProductName = obj.ProductName.Trim();

            if (!string.IsNullOrWhiteSpace(obj.ProductName))
            {
                obj.ProductName = string.Join(" ", obj.ProductName.Split(' ').Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
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

            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        // create product in db, ensure Title Case 
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            obj.ProductName = obj.ProductName.Trim();

            if (!string.IsNullOrWhiteSpace(obj.ProductName))
            {
                obj.ProductName = string.Join(" ", obj.ProductName.Split(' ').Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product has been edited successfully";
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

            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);

            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteProduct(int? id)
        {
            Product obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
