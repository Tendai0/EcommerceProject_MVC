using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky_Data_Access.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICatergoryRepository CatergoryRepository { get; }
        IProductRepository ProductRepository { get; }
        void Save();
    }
}
