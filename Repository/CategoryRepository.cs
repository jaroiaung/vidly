using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vidly.Data;
using vidly.Models;
using vidly.Repository.IRepository;

namespace vidly.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}