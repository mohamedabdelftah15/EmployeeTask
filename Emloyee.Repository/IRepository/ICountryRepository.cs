using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository.IRepository
{
   public interface ICountryRepository:IDisposable
    {
        List<Employee.Model.Country> GetALLCountries();
    }
}
