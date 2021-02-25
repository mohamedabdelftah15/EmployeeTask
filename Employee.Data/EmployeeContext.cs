namespace Employee.Data
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
        }

         public virtual DbSet<Employee> Employees { get; set; }
         public virtual DbSet<Country> Countrys { get; set; }
         public virtual DbSet<City> Citys { get; set; }

    }

   
}