using Employee.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Fullstack_Task.Controllers
{
    public class CountryController : ApiController
    {
        private readonly Employee.Service.CountryService CountryService = new Employee.Service.CountryService();
        // GET: Country
        [OutputCache(Duration = 0, NoStore = true)]
        public List<CountryVM> GetAllCountry()
        {
            return CountryService.GetAllCountries();
        }
    }
}