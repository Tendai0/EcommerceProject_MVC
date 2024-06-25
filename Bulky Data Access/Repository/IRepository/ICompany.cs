using Bulky.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky_Data_Access.Repository.IRepository
{
    public interface ICompany:IRepository<Company>
    {
        void Update(Company company);
    }
}
