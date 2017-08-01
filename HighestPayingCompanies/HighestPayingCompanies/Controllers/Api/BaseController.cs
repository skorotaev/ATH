using System.Net;
using System.Net.Http;
using System.Web.Http;
using HighestPayingCompanies.Models.Repository;
using Newtonsoft.Json;
using System.Text;

namespace HighestPayingCompanies.Controllers.Api
{
    public class BaseController : ApiController
    {
        protected Repository repo = new Repository();

        protected HttpResponseMessage ToJson(dynamic obj)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            return response;
        }


    }
}