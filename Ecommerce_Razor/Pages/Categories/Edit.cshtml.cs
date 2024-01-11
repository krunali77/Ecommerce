using Ecommerce_Razor.Data;
using Ecommerce_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Ecommerce_Razor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        public readonly AppDbContext _db;

        public Category Category {  get; set; }
        
        public EditModel(AppDbContext db)
        {
            _db = db;
        }
       
        public void OnGet(int id)
        {
            if(id!=0&& id != null)
            {
                Category = _db.categories.Find(id);
            }
            
        }

        public IActionResult OnPost(int id)
        {
             if(ModelState.IsValid)
            {
                _db.categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");

            }
            else
            {
                return Page();
            }

        }
    }
}
