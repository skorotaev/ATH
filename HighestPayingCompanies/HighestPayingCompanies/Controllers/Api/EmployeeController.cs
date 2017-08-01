using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HighestPayingCompanies.Models;
//using HighestPayingCompanies.Models.Repository;
using System.Web;

namespace HighestPayingCompanies.Controllers.Api
{
    public class EmployeeController : BaseController
    {
        //private Repository repo;

        //public EmployeeController()
        //{
        //    repo = new Repository();
        //}

        // GET api/Employee
        //[HttpGet]
        //public IEnumerable<Employee> Get()
        //{
        //    return repo.GetEmployees();
        //}

        public HttpResponseMessage Get()
        {
            return ToJson(repo.GetEmployees().AsEnumerable());
        }

        // GET api/Employee/5
        //public Employee Get(int id)
        //{
        //    return repo.GetEmployeeByID(id);
        //}
        public HttpResponseMessage Get(int id)
        {
            return ToJson(repo.GetEmployeeByID(id));
        }

        // POST api/Employee
        //[HttpPost]
        //public string Post([FromBody]Employee employee)
        //{
        //    HttpContext.Current.Response.StatusCode = 200;

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            Employee newEmployee = new Employee();
        //            newEmployee.Name = employee.Name;
        //            newEmployee.Salary = employee.Salary;
        //            newEmployee.CompanyId = employee.Company.CompanyId;

        //            repo.InsertEmployee(newEmployee);
        //            repo.Save();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        HttpContext.Current.Response.StatusCode = 400;
        //        return(e.ToString());
        //    }

        //    return "OK";
        //}

        public HttpResponseMessage Post([FromBody]Employee value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.InsertEmployee(value);
                    return ToJson(repo.Save());
                }
            }
            catch (Exception e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.ReasonPhrase = e.Message;
                return (response);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT api/Employee/5
        //[HttpPut]
        //public string Put(int id, [FromBody] Employee employee)
        //{
        //    HttpContext.Current.Response.StatusCode = 200;

            //    try
            //    {
            //        if (ModelState.IsValid)
            //        {
            //            repo.UpdateEmployee(employee);
            //            repo.Save();
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        HttpContext.Current.Response.StatusCode = 400;
            //        return (e.ToString());
            //    }

            //    return "OK";
            //}

        public HttpResponseMessage Put(int id, [FromBody]Employee value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.UpdateEmployee(value);
                    return ToJson(repo.Save());
                }
            }
            catch (Exception e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.ReasonPhrase = e.Message;
                return (response);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/Employee/5
        //[HttpDelete]
        //public string Delete(int id)
        //{
        //    HttpContext.Current.Response.StatusCode = 200;

        //    try
        //    {
        //        Employee employee = repo.GetEmployeeByID(id);
        //        repo.DeleteEmployee(employee.EmployeeId);
        //        repo.Save();
        //    }
        //    catch (Exception e)
        //    {
        //        HttpContext.Current.Response.StatusCode = 400;
        //        return (e.ToString());
        //    }

        //    return "OK";
        //}
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                repo.DeleteEmployee(id);
                return ToJson(repo.Save());
            }
            catch (Exception e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.ReasonPhrase = e.Message;
                return (response);
            }
        }
    }
}