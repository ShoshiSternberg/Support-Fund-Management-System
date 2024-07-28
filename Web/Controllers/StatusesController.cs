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

    public class StatusesController : ApiController
    {
        // GET: api/Statuses
        public List<StatusesDTO> Get()
        {
            return StatusesBLL.GetAllStatuses();
        }

        // GET: api/Statuses/5
        public StatusesDTO Get(int id)
        {
            return StatusesBLL.GetStatusByID(id);
        }

        // POST: api/Statuses
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Statuses/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Statuses/5
        public void Delete(int id)
        {
        }
    }
}
