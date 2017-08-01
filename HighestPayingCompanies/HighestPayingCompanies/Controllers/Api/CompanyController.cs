using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HighestPayingCompanies.Models;

namespace HighestPayingCompanies.Controllers.Api
{
    public class CompanyController : BaseController
    {
        // GET api/Company
        public HttpResponseMessage Get()
        {
            return ToJson(repo.GetCompanies().AsEnumerable());
        }

        // GET api/Company/5
        public HttpResponseMessage Get(int id)
        {
            return ToJson(repo.GetCompanyByID(id));
        }

        // POST api/Company
        public HttpResponseMessage Post([FromBody]Company value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.InsertCompany(value);
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

        // PUT api/Company/5
        public HttpResponseMessage Put(int id, [FromBody]Company value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.UpdateCompany(value);
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

        // DELETE api/Company/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                repo.DeleteCompany(id);
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