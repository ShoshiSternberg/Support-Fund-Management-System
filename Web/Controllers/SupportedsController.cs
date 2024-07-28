using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Dto;
using Bll;
using System.Web.Http.ModelBinding;

namespace Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class SupportedsController : ApiController
    {
        [HttpGet]
        [Route("api/Supporteds/Get")]
       //GET: api/Supporteds/Get
        public List<dynamic> Get()
        {
            var ans=SupportedsBLL.GetAllSupporteds();
            return ans;
        }

        [Route("api/Supporteds/GetSupportedByID/{id}")]
        
        public dynamic GetSupportedByID(int id)
        {
            return SupportedsBLL.GetSupportedByID(id);
        }
        [HttpPost]
        // POST: api/Supporteds
        public bool Post([FromBody]SupportedsDTO supportedToAdd)
        {
            
            //SupportedsDTO newSupp = supportedToAdd[0].ToObject<SupportedsDTO>();
            return SupportedsBLL.InsertSupported(supportedToAdd);
        }

        [HttpPut]
        
        // PUT: api/Supporteds/Put
        public bool Put([FromBody] SupportedsDTO supportedToAdd)
        {
            //SupportedsDTO new1 = (supportedToAdd[1]).ToObject<SupportedsDTO>();
            return SupportedsBLL.UpdateSupported( supportedToAdd);
        }

        // DELETE: api/Supporteds/5
        public void Delete(int id)
        {
        }
    }
}
