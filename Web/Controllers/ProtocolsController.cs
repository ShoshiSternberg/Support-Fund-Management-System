using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bll;
using Dto;
using System.Web.Http.Cors;
namespace Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProtocolsController : ApiController
    {
        // GET: api/Protocols
        public List<dynamic> Get()
        {
            return ProtocolsBLL.GetAllProtocols();
        }

        // GET: api/GetProtocolByID/5
        public dynamic GetProtocolByID(int id)
        {
            return ProtocolsBLL.GetProtocolByID(id);
        }
        //GET: api/GetProtocolBySupportID/3
        public dynamic GetProtocolBySupportID(int id)
        {
            return ProtocolsBLL.GetProtocolBySupportID(id);
        }
        // POST: api/Protocols
        public bool Post([FromBody]ProtocolsDTO ProtocolToInsert)
        {
            return ProtocolsBLL.InsertProtocol(ProtocolToInsert);
        }
        
        // PUT: api/Protocols/{protoObj}
        public bool Put([FromBody] List<dynamic> protoObj)
        {
            ProtocolsDTO newprotocol = protoObj[1].ToObject<ProtocolsDTO>();
            int id = (int)protoObj[0];
            return ProtocolsBLL.UpdateProtocol(id,newprotocol);    
        }

        // DELETE: api/Protocols/5
        public void Delete(int id)
        {
        }
    }
}
