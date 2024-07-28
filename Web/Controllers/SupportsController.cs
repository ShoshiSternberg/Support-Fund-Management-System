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
    [EnableCors(headers: "*", methods: "*", origins: "*")]
    public class SupportsController : ApiController
    {
        [HttpGet]
        // GET: api/Supports/Get
        public List<dynamic> Get()
        {
            return SupportsBLL.GetAllSupports();
        }

        // GET: api/Supports/GetSupportById/5
        public dynamic GetSupportById(int id)
        {
            return SupportsBLL.GetSupportByID(id);
        }
        //GET:api/Supports/GetSupportsBySupported/{id}
        public List<dynamic> GetSupportsBySupported(int id)
        {
            return SupportsBLL.GetAllSupportsBySupported(id);
        }
        //הפונקציה מקבלת ליסט דינמי שמכיל אובייקט תמיכה ומערך של פרטי מוצרים לתרגום
        //מחזיר במקום הראשון את קוד התמיכה ובמקום השני מערך של קודי המוצרים 
        // POST: api/Supports
        [HttpPost]
        public List<dynamic> Post([FromBody]List<dynamic> value)
        {
            SupportsDTO supp = value[0].ToObject<SupportsDTO>() ;
            List<prod>prods = value[1].ToObject<List<prod>>();
            DateTime d = new DateTime((int)value[2][0], (int)value[2][1], (int)value[2][2]);
            supp.SupportDate = d;
            int[] res = new int[prods.Count];
            for (int i = 0; i < prods.Count; i++)
            {
                res[i] = prods[i].GetProductCodeByDetails();
            }
            List<dynamic> l1 = new List<dynamic>();
            l1.Add(res);
            l1.Add(SupportsBLL.InsertSupport(supp));
            return l1;
        }

        // PUT: api/Supports/Put/{5}
        [HttpPut]        
        public List<dynamic> Put([FromBody] List<dynamic> value)
        {
            int id =(int) value[0];
            SupportsDTO supp = value[1].ToObject<SupportsDTO>();
            List<prod> prods = value[2].ToObject<List<prod>>();
            DateTime d = new DateTime((int)value[3][0], (int)value[3][1], (int)value[3][2]);
            supp.SupportDate = d;
            //מחיקת המוצרים המקוריים
            ProductsToSupportsBLL.RemoveProuctsToSupportBySupportID(id);    

            int[] res = new int[prods.Count];
            //תרגום המוצרים
            for (int i = 0; i < prods.Count; i++)
            {
                res[i] = prods[i].GetProductCodeByDetails();
            }
            List<dynamic> l1 = new List<dynamic>();
            l1.Add(res);//קודי המוצרים
            l1.Add(SupportsBLL.UpdateSupport(id,supp));//תוצאת העדכון של פרטי התמיכה
            return l1;

        }

        // DELETE: api/Supports/5
        public void Delete(int id)
        {
        }
    }
}
