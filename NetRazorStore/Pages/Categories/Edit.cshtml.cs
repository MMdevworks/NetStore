using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetRazorStore.Models;
using NetRazorStore.Data;

namespace NetRazorStore.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if(id!=null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }
         
        public IActionResult OnPost()
        {
            if (!string.IsNullOrWhiteSpace(Category.Name))
            {
                Category.Name = string.Join(" ", Category.Name.Split(' ').Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category has been edited";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
