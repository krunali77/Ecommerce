using Ecommerce_DataAcess.Data;
using Ecommerce_DataAcess.Repository.IRepository;
using Ecommerce_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_DataAcess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext productRepo;

        public ProductRepository(AppDbContext db): base(db) 
        {
            productRepo = db;
        }

        public void Update(Product product)
        {
           var objFromDb= productRepo.products.FirstOrDefault(product=>product.Id==product.Id);
            if(objFromDb != null)
            {
                objFromDb.Title= product.Title;
                objFromDb.Description= product.Description;
                objFromDb.Brand= product.Brand;
                objFromDb.Color= product.Color;
                objFromDb.ListPrice= product.ListPrice;
                objFromDb.ListPrice10= product.ListPrice10;
                objFromDb.CategoryId= product.CategoryId;

                if(product.ImageUrl!=null)
                {
                    objFromDb.ImageUrl= product.ImageUrl;
                }
            }
        }
    }
}
