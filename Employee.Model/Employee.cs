using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Model
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EId { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime?  Birthdate { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
    }
}
