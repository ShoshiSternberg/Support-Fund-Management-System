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
    public class SupportWayController : ApiController
    {
        [HttpGet]
        // GET: api/SupportWay/Get
        public List<SupportWayDTO> Get()
        {
            return SupportWayBLL.GetAllSupportWays();
        }
        //GET:SupportWay/Get
        public SupportWayDTO Get(int id)
        {
            return SupportWayBLL.GetSupportWayByID(id);
        }
        [Route("api/SupportWay/GetSupportWaysByProdAndProv/{a}/{b}")]
        //GET: api/SupportWay/GetSupportWaysByProdAndProv/{a}/{b}
        public List<SupportWayDTO> GetSupportWaysByProdAndProv(string a,int b)
        {
            return SupportWayBLL.GetSupportWaysByProdAndProv(a,b);
        }


        [HttpPost]
        // POST: api/SupportWay/Post
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SupportWay/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SupportWay/5
        public void Delete(int id)
        {
        }
    }
}
