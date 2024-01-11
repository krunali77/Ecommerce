using Ecommerce_Razor.Data;
using Ecommerce_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce_Razor.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        public readonly AppDbContext _db;

        public Category Category { get; set; }

        public DeleteModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            if (id != 0 && id != null)
            {
                Category = _db.categories.Find(id);
            }

        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                _db.categories.Remove(Category);
                _db.SaveChanges();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }

        }
    }
}
