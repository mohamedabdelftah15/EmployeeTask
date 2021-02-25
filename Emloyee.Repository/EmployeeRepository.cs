using Employee.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Model;
using Employee.Data;

namespace Employee.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private EmployeeContext context;
        private bool disposed = false;
        public EmployeeRepository(EmployeeContext _context)
        {
            this.context = _context;
        }
        public List<Model.Employee> Search(DateTime? date)
        {
            if (date.HasValue)
            {
                return context.Employees.Where(e => e.Birthdate.Value == date.Value).ToList();
            }
            else
            {
                return context.Employees.ToList();
            }
        }
        public List<Model.Employee> GetALLEmployees()
        {
            return context.Employees.ToList();
        }

        public Model.Employee GetEmployeeByID(int id)
        {
            return context.Employees.FirstOrDefault(e => e.EId == id);
        }

        public void Add(Employee.Model.Employee emp)
        {
                context.Employees.Add(emp);
                context.SaveChanges();
        }
        public void Update(Employee.Model.Employee emp)
        {
                var _emp = context.Employees.FirstOrDefault(e => e.EId == emp.EId);
                _emp.EmployeeName = emp.EmployeeName;
                _emp.Gender = emp.Gender;
                _emp.Birthdate = emp.Birthdate;
                _emp.CountryId = emp.CountryId;
                _emp.CityId = emp.CityId;
                context.SaveChanges();
        }
        public void Delete(int id)
        {
                var emp = context.Employees.FirstOrDefault(e => e.EId == id);
                context.Employees.Remove(emp);
                context.SaveChanges();
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
