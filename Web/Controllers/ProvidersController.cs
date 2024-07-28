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
    public class ProvidersController : ApiController
    {
        // GET: api/Providers
        public List<ProvidersDTO> Get()
        {
            return ProvidersBLL.GetAllProviders();
        }
        [Route("api/Providers/GetByProduct/{name}")]
        // GET: api/Providers/GetByProduct/{name}
        public List<ProvidersDTO> GetByProduct(string name)
        {
            return ProvidersBLL.GetProvidersByProduct(name);
        }

        // POST: api/Providers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Providers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Providers/5
        public void Delete(int id)
        {
        }
    }
}
