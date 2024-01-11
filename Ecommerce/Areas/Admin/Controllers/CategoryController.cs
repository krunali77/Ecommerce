using Ecommerce_DataAcess.Data;
using Ecommerce_DataAcess.Repository;
using Ecommerce_DataAcess.Repository.IRepository;
using Ecommerce_Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly IUnitOfWork categoryRepo;
        public CategoryController(IUnitOfWork db)
        {
            categoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = categoryRepo.Category.GetAll().ToList();
            return View(objCategoryList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            categoryRepo.Category.add(obj);
            categoryRepo.Save();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            Category? data = categoryRepo.Category.Get(e => e.Id == id);
            if (data == null)
            {
                return NotFound(nameof(data));
            }
            return View(data);

        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                categoryRepo.Category.Update(obj);
                categoryRepo.Save();
            }
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Category? obj = categoryRepo.Category.Get(e => e.Id == id);
            if (obj == null)
            {
                return NotFound(nameof(obj));
            }

            return View(obj);

        }
        [HttpPost]
        public IActionResult Delete(Category obj)
        {
            if (ModelState.IsValid)
            {
                categoryRepo.Category.remove(obj);
                categoryRepo.Save();
            }
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }


    }
}




