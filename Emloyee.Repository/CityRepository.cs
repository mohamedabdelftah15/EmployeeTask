using Employee.Repository.IRepository;
using Employee.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Model;

namespace Employee.Repository
{
   public class CityRepository:ICityRepository
    {
        private EmployeeContext context;
        public CityRepository(EmployeeContext _context)
        {
            context = _context;
        }
        private bool disposed = false;
        public List<City> GetAllCities()
        {
            return context.Citys.ToList();
        }

        public List<City> GetCitiesByCountryId(int? id)
        {
            if (!id.HasValue)
            {
                return context.Citys.ToList();
            }
            else
            {
                return context.Citys.Where(e => e.Country.CountryId == id).ToList();
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       
    }
}
