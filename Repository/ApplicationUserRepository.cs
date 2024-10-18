using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vidly.Data;
using vidly.Models;
using vidly.Repository.IRepository;

namespace vidly.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository {
        private ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(ApplicationUser applicationUser) {
            _db.ApplicationUsers.Update(applicationUser);
        }
    }
}