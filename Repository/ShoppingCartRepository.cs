using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vidly.Data;
using vidly.Models;
using vidly.Repository;
using vidly.Repository.IRepository;

namespace vidly.Repository
{
    public class ShoppingCartRepository: Repository<ShoppingCart>, IShoppingCartRepository
    {
        private ApplicationDbContext _db;
        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        

        public void Update(ShoppingCart obj)
        {
            _db.ShoppingCarts.Update(obj);
        }
    }
}