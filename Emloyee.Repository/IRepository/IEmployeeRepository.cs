using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Model;

namespace Employee.Repository.IRepository
{
   public interface IEmployeeRepository:IDisposable
    {
        List<Model.Employee> Search(DateTime? date);
        List<Model.Employee> GetALLEmployees();
        Employee.Model.Employee GetEmployeeByID(int id);
        void Add(Model.Employee emp);
        void Delete(int id);
        void Update(Model.Employee emp);
    }
}
