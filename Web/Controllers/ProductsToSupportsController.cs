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
    [EnableCors(headers: "*", methods: "*", origins: "*")]
    public class ProductsToSupportsController : ApiController
    {
        [HttpGet]
        // GET: api/ProductsToSupports
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ProductsToSupports/GetAllProductsBySupport/5
        public List<dynamic> GetAllProductsBySupport(int id)
        {
           List<dynamic> products = new List<dynamic>();
            List<ProductsToSupportsDTO> products2 = ProductsToSupportsBLL.GetProductsToSupportsByID(id);
            for (int i = 0; i < products2.Count; i++)
            {
                dynamic p1 = ProductsBLL.GetProductByID(products2[i].ProdID);
                products.Add(p1);

            }
            List<dynamic> l1 = new List<dynamic>();
            l1.Add(products2);
            l1.Add(products);
            //מחזיר ליסט דינמי שבו 2 איברים:            
            //מערך מוצרים שלמים
            //מערך תרגום מוצרים
            return l1;
        }
        
        // GET: api/ProductsToSupports/GetWhiteProductsBySupport/5
        public List<dynamic> GetWhiteProductsBySupport(int id)
        {
            List<dynamic> products = new List<dynamic>();
            List<ProductsToSupportsDTO> products2 = ProductsToSupportsBLL.GetWhiteProductsToSupportsByID(id);
            for (int i = 0; i < products2.Count; i++)
            {
                dynamic p1 = ProductsBLL.GetProductByID(products2[i].ProdID);
                products.Add(p1);

            }
            List<dynamic> l1 = new List<dynamic>();
            l1.Add(products2);
            l1.Add(products);
            //מחזיר ליסט דינמי שבו 2 איברים:            
            //מערך מוצרים שלמים
            //מערך תרגום מוצרים
            return l1;           

        }
        [HttpPost]
        // POST: api/ProductsToSupports
        public bool Post([FromBody] List<ProductsToSupportsDTO> value)
        {
            return ProductsToSupportsBLL.InsertProductsToSupportsList(value);            
        }

        // PUT: api/ProductsToSupports/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProductsToSupports/5
        public void Delete(int id)
        {
        }
    }
}
