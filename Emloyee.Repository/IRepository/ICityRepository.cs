using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository.IRepository
{
    public interface ICityRepository:IDisposable
    {
        List<Employee.Model.City> GetAllCities();
        List<Employee.Model.City> GetCitiesByCountryId(int? id);
    }
}
