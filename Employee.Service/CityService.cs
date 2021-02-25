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
   public class CityService
    {
        private readonly ICityRepository iCityRepository;
        public CityService()
        {
            iCityRepository = new CityRepository(new EmployeeContext());
        }
        public List<ViewModel.CityVM> GetAllCities()
        {
            var cityVMList = new List<ViewModel.CityVM>();
            var cityList = new List<Model.City>();
           
                    cityList = iCityRepository.GetAllCities();
                    cityVMList = cityList.Select(e => new ViewModel.CityVM { CityId=e.CityId,CityName=e.CityName}).ToList();
           
            return cityVMList;
        }
        public List<ViewModel.CityVM> GetCitiesByCountryId(int? id)
        {
            var cityVMList = new List<ViewModel.CityVM>();
            var cityList = new List<Model.City>();
           
                    cityList = iCityRepository.GetCitiesByCountryId(id);
                    cityVMList = cityList.Select(e => new ViewModel.CityVM { CityId = e.CityId, CityName = e.CityName}).ToList();
           
            return cityVMList;
        }
    }
}
