using Bulky.DataAccess.Data;
using Bulky.Models;
using Bulky.Models.Models;
using Bulky_Data_Access.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky_Data_Access.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IshoppingCartRepository
    {
        private DataContext _context;
        public ShoppingCartRepository(DataContext context):base(context)
        {
            _context = context;
        }
        public void Update(ShoppingCart shoppingCart)
        {
            _context.Update(shoppingCart);
        }
    }
}
