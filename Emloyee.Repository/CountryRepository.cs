using Employee.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Repository.IRepository;
using Employee.Model;

namespace Employee.Repository
{
    public class CountryRepository:ICountryRepository
    {
        private EmployeeContext context;
        public CountryRepository(EmployeeContext _context)
        {
            context = _context;
        }
        private bool disposed = false;
        public List<Country> GetALLCountries()
        {
            return context.Countrys.Include("Cities").ToList();
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
