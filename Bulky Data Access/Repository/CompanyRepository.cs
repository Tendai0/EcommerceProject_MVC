using Bulky.DataAccess.Data;
using Bulky.Models;
using Bulky.Models.Models;
using Bulky_Data_Access.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky_Data_Access.Repository
{
    public class CompanyRepository:Repository<Company>,ICompany
    {
        public readonly DataContext _context;
        public CompanyRepository(DataContext context):base(context)
        {
            _context = context; 
        }
        public void Update(Company company)
        {
            _context.Update(company);
        }


    }
}
