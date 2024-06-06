using Bulky.DataAccess.Data;
using Bulky.Models;
using Bulky_Data_Access.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky_Data_Access.Repository
{
    public class CatergoryRepository : Repository<Category>, ICatergoryRepository
    {
        private DataContext _context;
        public CatergoryRepository(DataContext context):base(context)
        {
            _context = context;
        }
        public void Update(Category category)
        {
            _context.Update(category);
        }
    }
}
