namespace HighestPayingCompanies.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using HighestPayingCompanies.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<HighestPayingCompanies.Models.Repository.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HighestPayingCompanies.Models.Repository.EFDbContext";
        }

        protected override void Seed(HighestPayingCompanies.Models.Repository.EFDbContext context)
        {
            var companies = new List<Company>
            {
                new Company() { CompanyId = 1, Name = "A.T. Kearney" },
                new Company() { CompanyId = 2, Name = "Strategy&" },
                new Company() { CompanyId = 3, Name = "Juniper Networks" },
                new Company() { CompanyId = 4, Name = "McKinsey & Company" },
                new Company() { CompanyId = 5, Name = "Google" },
                new Company() { CompanyId = 6, Name = "VMware" },
                new Company() { CompanyId = 7, Name = "Amazon" },
                new Company() { CompanyId = 8, Name = "Boston Consulting Group" },
                new Company() { CompanyId = 9, Name = "Guidewire" },
                new Company() { CompanyId = 10, Name = "Cadence Design Systems" },
                new Company() { CompanyId = 11, Name = "Visa" },
                new Company() { CompanyId = 12, Name = "Facebook" },
                new Company() { CompanyId = 13, Name = "Twitter" },
                new Company() { CompanyId = 14, Name = "Box" },
                new Company() { CompanyId = 15, Name = "Walmart eCommerce" },
                new Company() { CompanyId = 16, Name = "SAP" },
                new Company() { CompanyId = 17, Name = "Synopsys" },
                new Company() { CompanyId = 18, Name = "Altera" },
                new Company() { CompanyId = 19, Name = "LinkedIn" },
                new Company() { CompanyId = 20, Name = "Cloudera" },
                new Company() { CompanyId = 21, Name = "Salesforce" },
                new Company() { CompanyId = 22, Name = "Microsoft" },
                new Company() { CompanyId = 23, Name = "F5 Networks" },
                new Company() { CompanyId = 24, Name = "Adobe" },
                new Company() { CompanyId = 25, Name = "Broadcom" }
            };
            companies.ForEach(c => context.Companies.AddOrUpdate(c));
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee() { EmployeeId = 1, Name = "Laura Gorsuch", Salary = 167534, CompanyId = 1 },
                new Employee() { EmployeeId = 2, Name = "Scott Majors", Salary = 160000, CompanyId = 2 },
                new Employee() { EmployeeId = 3, Name = "Armand Brenton", Salary = 157000, CompanyId = 3 },
                new Employee() { EmployeeId = 4, Name = "Wilma Morgan", Salary = 155000, CompanyId = 4 },
                new Employee() { EmployeeId = 5, Name = "Michael Gordon", Salary = 152133, CompanyId = 5 },
                new Employee() { EmployeeId = 6, Name = "William Holden", Salary = 152133, CompanyId = 6 },
                new Employee() { EmployeeId = 7, Name = "Brett Davis", Salary = 150100, CompanyId = 7 },
                new Employee() { EmployeeId = 8, Name = "Cynthia Medford", Salary = 150020, CompanyId = 8 },
                new Employee() { EmployeeId = 9, Name = "Eric Deangelo", Salary = 150020, CompanyId = 9 },
                new Employee() { EmployeeId = 10, Name = "Paul Trapp", Salary = 150010, CompanyId = 10 },
                new Employee() { EmployeeId = 11, Name = "Leo Lawley", Salary = 150000, CompanyId = 11 },
                new Employee() { EmployeeId = 12, Name = "Gene Holmes", Salary = 150000, CompanyId = 12 },
                new Employee() { EmployeeId = 13, Name = "Ollie Romero", Salary = 150000, CompanyId = 13 },
                new Employee() { EmployeeId = 14, Name = "Goldie Grover", Salary = 150000, CompanyId = 14 },
                new Employee() { EmployeeId = 15, Name = "Charles Strong", Salary = 149000, CompanyId = 15 },
                new Employee() { EmployeeId = 16, Name = "Louis Trantham", Salary = 148431, CompanyId = 16 },
                new Employee() { EmployeeId = 17, Name = "Albert Lund", Salary = 148000, CompanyId = 17 },
                new Employee() { EmployeeId = 18, Name = "Jamel Gaston", Salary = 147000, CompanyId = 18 },
                new Employee() { EmployeeId = 19, Name = "Carl Williams", Salary = 145000, CompanyId = 19 },
                new Employee() { EmployeeId = 20, Name = "Linda Garcia", Salary = 145000, CompanyId = 20 },
                new Employee() { EmployeeId = 21, Name = "Lucille Oneal", Salary = 143750, CompanyId = 21 },
                new Employee() { EmployeeId = 22, Name = "Aimee Gutierrez", Salary = 141000, CompanyId = 22 },
                new Employee() { EmployeeId = 23, Name = "Regan Peterson", Salary = 140200, CompanyId = 23 },
                new Employee() { EmployeeId = 24, Name = "Joseph Blue", Salary = 140000, CompanyId = 24 },
                new Employee() { EmployeeId = 25, Name = "Danial Christiansen", Salary = 140000, CompanyId = 25 }
            };
            employees.ForEach(e => context.Employees.AddOrUpdate(e));
            context.SaveChanges();
        }
    }
}
