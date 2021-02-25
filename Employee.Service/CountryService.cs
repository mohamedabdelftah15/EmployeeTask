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
   public class CountryService
    {
        private readonly ICountryRepository iCountryRepository;
        public CountryService()
        {
            iCountryRepository = new CountryRepository(new EmployeeContext());
        }
            public List<ViewModel.CountryVM> GetAllCountries()
        {
            var countryVMList = new List<ViewModel.CountryVM>();
            var countryList = new List<Model.Country>();
            try
            {
                
                    countryList = iCountryRepository.GetALLCountries();
                    countryVMList = countryList.Select(e => new ViewModel.CountryVM { CountryId = e.CountryId, CountryName = e.CountryName }).ToList();
                
            }
            catch (Exception e)
            {
            }
            return countryVMList;
        }
    }
}
