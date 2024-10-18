using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vidly.Data;
using vidly.Models;
using vidly.Repository.IRepository;

namespace vidly.Repository
{
   public class CompanyRepository : Repository<Company>, ICompanyRepository 
        {
        private ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        

        public void Update(Company obj)
        {
            _db.Companies.Update(obj);
        }
    }
}