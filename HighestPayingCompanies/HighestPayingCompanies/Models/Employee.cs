using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HighestPayingCompanies.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        [Required]
        public decimal Salary { get; set; }

        // Foreign Key
        public int CompanyId { get; set; }
        // Navigation property
        public Company Company { get; set; }
    }
}