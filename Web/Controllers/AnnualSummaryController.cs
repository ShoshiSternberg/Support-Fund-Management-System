using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Bll;
using Dto;

namespace Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AnnualSummaryController : ApiController
    {
        [HttpGet]
        // GET: api/AnnualSummary/Get
        public List<AnnualSummaryDTO> Get()
        {
            return AnnualSummaryBLL.GetAnnualSummaries();
        }
        [Route("api/AnnualSummary/GetByYear/{year}")]
        // GET: api/AnnualSummary/GetByYear/{year}

        public AnnualSummaryDTO GetByYear(int year)
        {
            return AnnualSummaryBLL.GetAnnualSummaryByYear(year);
        }
        [HttpPost]
        // POST: api/AnnualSummary
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AnnualSummary/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AnnualSummary/5
        public void Delete(int id)
        {
        }
    }
}
