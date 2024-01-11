using Ecommerce_DataAcess.Data;
using Ecommerce_DataAcess.Repository.IRepository;
using Ecommerce_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_DataAcess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext categoryRepo;
        public CategoryRepository(AppDbContext db) : base(db)
        {
            categoryRepo = db;
        }

     
        public void Update(Category obj)
        {
            categoryRepo.categories.Update(obj);
        }
    }
}