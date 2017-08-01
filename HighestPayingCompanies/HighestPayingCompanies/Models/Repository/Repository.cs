using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HighestPayingCompanies.Models.Repository
{
    public class Repository : IDisposable
    {
        private EFDbContext context = new EFDbContext();

        /// Implementation of CRUD-operations for Company
        ///
        public IEnumerable<Company> GetCompanies()
        {
            return context.Companies.ToList();
        }

        public Company GetCompanyByID(int companyID)
        {
            return context.Companies.Find(companyID);
        }

        public void InsertCompany(Company company)
        {
            context.Companies
                .Add(company);
        }

        public void DeleteCompany(int companyID)
        {
            Company company= context.Companies.Find(companyID);
            context.Companies
                .Remove(company);
        }

        public void UpdateCompany(Company company)
        {
            context.Entry(company).State = EntityState.Modified;
        }
        //////


        /// Implementation of CRUD-operations for Employee
        /// 
        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }

        public Employee GetEmployeeByID(int employeeID)
        {
            return context.Employees.Find(employeeID);
        }

        public void InsertEmployee(Employee employee)
        {
            context.Employees
                .Add(employee);
        }

        public void DeleteEmployee(int employeeID)
        {
            Employee employee = context.Employees.Find(employeeID);
            context.Employees
                .Remove(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            context.Entry(employee).State = EntityState.Modified;
        }
        //////

        public int Save()
        {
            return context.SaveChanges();
        }

        public IEnumerable<Company> GetTopPayingCompanies(int count = 5)
        {
            return context.Companies
                .OrderBy(c => c.Name)
                .Take(count);
        }

        public IEnumerable<Employee> GetTopPaidEmployees(int count = 5)
        {
            return context.Employees
                .Include(e => e.Company)
                .OrderByDescending(e => e.Salary)
                .Take(count);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}