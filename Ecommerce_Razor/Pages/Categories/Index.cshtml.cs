using Ecommerce_Razor.Data;
using Ecommerce_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce_Razor.Pages.Categories
{
    public class IndexModel : PageModel
    {

        private readonly AppDbContext _db;

        public List<Category> CategoryList { get; set; }

        public IndexModel(AppDbContext db)
        {
            _db = db;
            
        }
        public void OnGet()
        {
            CategoryList= _db.categories.ToList();
        }
    }
}
