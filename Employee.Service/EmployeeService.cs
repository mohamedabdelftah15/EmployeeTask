using Employee.Data;
using Employee.Repository;
using Employee.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Service
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository iEmployeeRepository;
        public EmployeeService()
        {
            iEmployeeRepository = new EmployeeRepository(new EmployeeContext());
        }
        public List<ViewModel.EmployeeVM> Search(DateTime? date)
        {
            var eVMList = new List<ViewModel.EmployeeVM>();
            var eList = new List<Model.Employee>();

                eList = iEmployeeRepository.Search(date);
                eVMList = eList.Select(e => new ViewModel.EmployeeVM { EId = e.EId, EmployeeName = e.EmployeeName, Gender = e.Gender, Birthdate = e.Birthdate.Value, CityId = e.CityId, CountryId = e.CountryId, Country = new ViewModel.CountryVM { CountryId = e.Country.CountryId, CountryName = e.Country.CountryName }, City = new ViewModel.CityVM { CityId = e.City.CityId, CityName = e.City.CityName, CountryId = e.City.CountryId } }).ToList();

            return eVMList;
        }
        public List<ViewModel.EmployeeVM> GetAllEmployees()
        {
            var eVMList = new List<ViewModel.EmployeeVM>();
            var eList = new List<Model.Employee>();
            
                    eList = iEmployeeRepository.GetALLEmployees();
                    eVMList = eList.Select(e => new ViewModel.EmployeeVM { EId = e.EId, EmployeeName = e.EmployeeName, Gender = e.Gender, Birthdate = e.Birthdate.Value,CityId=e.CityId,CountryId=e.CountryId,Country=new ViewModel.CountryVM { CountryId=e.Country.CountryId,CountryName=e.Country.CountryName},City=new ViewModel.CityVM { CityId=e.City.CityId ,CityName=e.City.CityName,CountryId=e.City.CountryId} }).ToList();
               
            return eVMList;
        }
        
        public ViewModel.EmployeeVM GetEmployeeById(int id)
        {
            var emp = new Model.Employee();
            var empVM = new ViewModel.EmployeeVM();
           
                    emp = iEmployeeRepository.GetEmployeeByID(id);
                    empVM.EId = emp.EId;
                    empVM.EmployeeName = emp.EmployeeName;
                    empVM.Gender = emp.Gender;
                    empVM.Birthdate = emp.Birthdate.Value;
                    empVM.CountryId = emp.CountryId;
                    empVM.CityId = emp.CityId;
                    empVM.Country = new ViewModel.CountryVM {CountryId=emp.Country.CountryId,CountryName=emp.Country.CountryName };
                    empVM.City = new ViewModel.CityVM { CityId=emp.City.CityId,CityName=emp.City.CityName,CountryId=emp.City.CountryId};
           
            return empVM;
        }
        public void Add(ViewModel.EmployeeVM emp)
        {
                    var _emp = new Model.Employee
                    {
                        EId = emp.EId,
                        EmployeeName = emp.EmployeeName,
                        Gender = emp.Gender,
                        Birthdate = emp.Birthdate.Value,
                        CityId=emp.CityId,
                        CountryId=emp.CountryId
                    }
                    ;

                    iEmployeeRepository.Add(_emp);
        }
        public void Update(ViewModel.EmployeeVM emp)
        {
              var _emp = new Model.Employee
                    {
                        EId = emp.EId,
                        EmployeeName = emp.EmployeeName,
                        Gender = emp.Gender,
                        Birthdate = emp.Birthdate.Value,
                        CountryId=emp.CountryId,
                        CityId=emp.CityId
                    }
                    ;

                    iEmployeeRepository.Update(_emp);
        }

        public void Delete(int id)
        {
            iEmployeeRepository.Delete(id);
        }
    }
}
