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
    [EnableCors(headers:"*",methods:"*",origins:"*")]
    public class ProductsController : ApiController
    {
        [HttpGet]
        // GET: api/Products
        public List<dynamic> GetAllProducts()
        {
            List<dynamic> l=ProductsBLL.GetAllProducts();
            return l;
        }

        [Route("api/Products/GetProductByID/{ID}")]
        public dynamic GetProductByID(int ID)
        {
            return ProductsBLL.GetProductByID(ID);
        }

        [Route("api/Products/GetAllProductsByReason/{reason}")]
        
        public List<dynamic> GetAllProductsByReason(int reason)
        {
            List<dynamic> l;
            if (reason == 0)
                l = ProductsBLL.GetAllProducts();
            else
                l =ProductsBLL.GetAllProductByReason(reason);
            return l;
        }

        [Route("api/Products/GetPrice/{prod}/{shop}")]
        public double GetPrice(string prod,int shop)
        {
            return (ProductsBLL.GetProductsByName(prod, shop)[0]).PricePerUnit;
        }
        [HttpPost]
        // POST: api/Products
        public bool Post([FromBody]List<dynamic> value)
        {
            ProductsDTO prodNew = value[1].ToObject<ProductsDTO>();
            List<int> reason =value[0].ToObject<List<int>>();
            return ProductsBLL.InsertProduct(reason,prodNew);
        }

        // PUT: api/Products/5
        public bool Put( [FromBody] List<dynamic> value)
        {
            ProductsDTO prodNew = value[1].ToObject<ProductsDTO>();
            List<int> reason = value[0].ToObject<List<int>>();
            return ProductsBLL.UpdateProduct(reason, prodNew);
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
