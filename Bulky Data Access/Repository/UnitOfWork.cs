using Bulky.DataAccess.Data;
using Bulky.Models;
using Bulky_Data_Access.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky_Data_Access.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;
        public ICatergoryRepository CatergoryRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public ICompany CompanyRepository { get; private set; }
        public IshoppingCartRepository ShoppingCartRepository { get; private set; }
        public IApplicationUserRepository ApplicationUserRepository { get;private set; }
        public UnitOfWork(DataContext context) 
        {
            _context = context;
            ApplicationUserRepository = new ApplicationUserRepository(_context);
            ShoppingCartRepository = new ShoppingCartRepository(_context);
            CatergoryRepository = new CatergoryRepository(_context);
            ProductRepository = new ProductRepository(_context);
            CompanyRepository = new CompanyRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
