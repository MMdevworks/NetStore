using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetStore.DataAccess.Data;
using NetStore.DataAccess.Repository.IRepository;
using NetStore.Models;
using NetStore.Models.ViewModels;


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
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product() 
            };

            return View(productVM);
        }

        // create product in db, ensure Title Case 
        [HttpPost]
        public IActionResult Create(ProductVM pvmobj)
        {
            pvmobj.Product.ProductName = pvmobj.Product.ProductName.Trim();

            if (!string.IsNullOrWhiteSpace(pvmobj.Product.ProductName))
            {
                pvmobj.Product.ProductName = string.Join(" ", pvmobj.Product.ProductName.Split(' ').Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(pvmobj.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                pvmobj.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            return View(pvmobj);
            }
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
