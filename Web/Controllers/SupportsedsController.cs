using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Dto;
using Bll;
namespace Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class SupportsedsController : ApiController
    {
        [HttpGet]
        [Route("api/Supportseds/Get")]
       
        public List<SupportedsDTO> Get()
        {
            return SupportedsBLL.GetAllSupporteds();
        }
        [Route("api/Supporteds/GetSupportedByID/{id}")]
        
        public SupportedsDTO GetSupportedByID(int id)
        {
            return SupportedsBLL.GetSupportedByID(id);
        }
        [HttpPost]
        // POST: api/Supportseds
        public bool Post([FromBody]SupportedsDTO supportedToAdd)
        {
            return SupportedsBLL.InsertSupported(supportedToAdd);
        }

        // PUT: api/Supportseds/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Supportseds/5
        public void Delete(int id)
        {
        }
    }
}
