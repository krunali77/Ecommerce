using Ecommerce_Razor.Data;
using Ecommerce_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce_Razor.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;
        
        public Category Category { get; set; }

        public CreateModel(AppDbContext db)
        {
            _db = db;

        }


        public void OnGet()
        {
           
        }

        public IActionResult OnPost()
        {
            _db.categories.Add(Category);
            _db.SaveChanges();

            TempData["success"] = "Category created successfully";
            return RedirectToPage("Index");
        }
    }
    }

