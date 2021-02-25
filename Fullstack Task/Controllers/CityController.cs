using Employee.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fullstack_Task.Controllers
{
    public class CityController : ApiController
    {
        private readonly Employee.Service.CityService CityService = new Employee.Service.CityService();
        public List<CityVM> GetAllCities()
        {
            return CityService.GetAllCities();
        }
        public List<CityVM> GetCitiesByCountryId(int? id)
        {
            return CityService.GetCitiesByCountryId(id);
        }
    }
}
