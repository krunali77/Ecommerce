using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ecommerce_DataAcess.Data;
using Ecommerce_DataAcess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_DataAcess.Repository
{
    public class Repository<T> : IRepository<T> where T : class

    {
        private readonly AppDbContext _db;

        internal DbSet<T> DbSet;

        public Repository(AppDbContext db)
        {
            _db = db;
            this.DbSet= _db.Set<T>();

            _db.products.Include(u => u.Category);

        }

        public void add(T entity)
        {
            DbSet.Add(entity);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter, string? includeproperties = null)
        {
            IQueryable<T> query = DbSet;
            query= query.Where(filter);
            if (!string.IsNullOrEmpty(includeproperties))
            {
                foreach (var includeprop in includeproperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop);
                }
            }
           
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, string? includeProperties = null)
        {
            IQueryable<T> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }
        public void remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void removeRange(IEnumerable<T> entities)
        {
           DbSet.RemoveRange(entities);
        }
    }
}
