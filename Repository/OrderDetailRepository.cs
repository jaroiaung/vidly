using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vidly.Data;
using vidly.Models;
using vidly.Repository.IRepository;

namespace vidly.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private ApplicationDbContext _db;
        public OrderDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        

        public void Update(OrderDetail obj)
        {
            _db.OrderDetails.Update(obj);
        }
    }
}