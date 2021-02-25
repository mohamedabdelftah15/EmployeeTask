using Employee.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Employee.ViewModel
{
    public class EmployeeVM
    {
        public int EId { get; set; }
        [Display(Name="Employee Name")]
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? Birthdate { get; set; }
        [Display(Name = "Country")]
        public int? CountryId { get; set; }
        [Display(Name = "City")]
        public int? CityId { get; set; }
        public CountryVM Country { get; set; }
        public CityVM City { get; set; }
        public List<SelectListItem> GenderList { get; set; }
        public List<SelectListItem> CountryList { get; set; }
        public List<SelectListItem> CityList { get; set; }
    }
}
