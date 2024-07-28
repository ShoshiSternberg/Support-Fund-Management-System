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
    public class ReasonsForSupportsController : ApiController
    {
        // GET: api/ReasonsForSupports/Get
        public List< ReasonsForSupportsDTO> Get()
        {
            return ReasonsForSupportsBLL.GetAllReasonsForSupports();
        }

        // GET: api/ReasonsForSupports/Get/5
        public ReasonsForSupportsDTO Get(int id)
        {
            return ReasonsForSupportsBLL.GetReasonForSupportByID(id);
        }

        // POST: api/ReasonsForSupports
        public bool Post([FromBody]ReasonsForSupportsDTO value)
        {
            return ReasonsForSupportsBLL.InsertReasonsForSupports(value);
        }

        // PUT: api/ReasonsForSupports/5
        public bool Put( [FromBody]ReasonsForSupportsDTO value)
        {
            return ReasonsForSupportsBLL.UpdateReasonsForSupports(value);
        }

        // DELETE: api/ReasonsForSupports/5
        public void Delete(int id)
        {
        }
    }
}
