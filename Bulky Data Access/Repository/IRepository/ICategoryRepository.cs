using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky_Data_Access.Repository.IRepository
{
    public interface ICatergoryRepository:IRepository<Category>
    {
        void Update(Category category);
   
    }
}
