using Employee.Service;
using Employee.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fullstack_Task.Controllers
{
    
    public class EmployeeController : ApiController
    {
        private readonly EmployeeService EmpService;
        private readonly CountryService CountryService;
        private readonly CityService CityService;
        public EmployeeController()
        {
            EmpService = new EmployeeService();
            CountryService = new CountryService();
            CityService = new CityService();
        }
        [HttpGet]
        public List<EmployeeVM> Search(DateTime? date)
        {
            return EmpService.Search(date);
        }
        //GetAll
        [HttpGet]
        public List<EmployeeVM> GetAllEmployees()
        {
            return EmpService.GetAllEmployees();
        }
        //GetEmployee
        [HttpGet]
        public EmployeeVM GetEmployeeById(int id)
        {
            return EmpService.GetEmployeeById(id);
        }
        //Add
        [HttpPost]
        public void AddEmployee(EmployeeVM employeeVM)
        {
           EmpService.Add(employeeVM);
        }
        //Update
        [HttpPost]
        public void UpdateEmployee(EmployeeVM employeeVM)
        {
            EmpService.Update(employeeVM);
        }
        //Delete
        [HttpGet]
        public void DeleteEmployee(int id)
        {
            EmpService.Delete(id);
        }
    }
}