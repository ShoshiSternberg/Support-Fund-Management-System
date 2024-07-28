using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dto;
using Bll;
using System.Web.Http.Cors;
namespace Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ResponsiblesController : ApiController
    {
        [HttpGet]
        // GET: api/Responsibles/GetAllResponsibles
        public List<ResponsiblesDTO> GetAllResponsibles()
        {
            return ResponsiblesBLL.GetAllResponsibles();
        }
        [Route("api/Responsibles/GetResponsibleByID/{id}")]
        public ResponsiblesDTO GetResponsibleByID(int id)
        {
            return ResponsiblesBLL.GetResponsibleByID(id);
        }
        [Route("api/Responsibles/GetResponsibleByNamePassword/{name}/{password}")]
        public ResponsiblesDTO GetResponsibleByNamePassword(string name,string password)
        {            
            return ResponsiblesBLL.GetResponsibleByNameAndPassword(name,password);
        }
        public List<string> GetNamesOfparticipants()
        {
            return ResponsiblesBLL.GetNamesOfparticipants();
        }
        [HttpPost]  
        // POST: api/Responsibles
        public bool Post([FromBody] ResponsiblesDTO value)
        {
            return ResponsiblesBLL.InsertResponsible(value);
        }

        // PUT: api/Responsibles/5
        public bool Put( [FromBody] ResponsiblesDTO value)
        {
            return ResponsiblesBLL.UpdateResponsible(value);
        }

        // DELETE: api/Responsibles/5
        public void Delete(int id)
        {
        }
    }
}
