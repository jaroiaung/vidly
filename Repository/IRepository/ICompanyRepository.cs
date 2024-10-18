using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vidly.Models;

namespace vidly.Repository.IRepository
{
   public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company obj);
    }
}