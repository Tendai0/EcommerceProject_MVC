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
    public class ProductRepository :Repository<Product>, IProductRepository
    {
        private DataContext _context;
        public ProductRepository(DataContext context):base(context)
        {
            _context = context;
        }
        public void Update(Product product)
        {
            _context.Products.Update(product);
        }
    }
}
