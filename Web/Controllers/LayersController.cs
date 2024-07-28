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
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class LayersController : ApiController
    {
        // GET: api/Layers
        public List<LayersDTO> Get()
        {
            return LayersBLL.GetAllLayers();
        }

        // GET: api/Layers/5
        public LayersDTO Get(int id)
        {
            return LayersBLL.GetLayerByID(id);
        }

        // POST: api/Layers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Layers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Layers/5
        public void Delete(int id)
        {
        }
    }
}
