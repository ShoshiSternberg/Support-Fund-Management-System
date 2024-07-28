using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Bll;
using Dto;

namespace Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReportsController : ApiController
    {
        // GET: api/Reports
        public List<dynamic> Get()
        {
            return ReportsBLL.GetAllReports();
        }

        // GET: api/Reports/GetByID/{id}
        public dynamic GetByID(int id)
        {
            return ReportsBLL.GetReportByID(id);
        }
        //GET:api/Reports/GetReportsBySupported/{id}
        public List<dynamic> GetReportsBySupported(int id)
        {
            return ReportsBLL.GetAllReportsBySupported(id);
        }

        // POST: api/Reports/Post
        public bool Post([FromBody] List<dynamic> value)
        {
            DateTime d = new DateTime((int)value[1][0], (int)value[1][2], (int)value[1][1]);
            value[0].ReportDate=d;
            ReportsDTO newr = value[0].ToObject<ReportsDTO>();
                      
            return ReportsBLL.InsertReport(newr);
        }

        // PUT: api/Reports/Put
        public bool Put([FromBody] List<dynamic> value)
        {
            DateTime d = new DateTime((int)value[1][0], (int)value[1][2], (int)value[1][1]);
            value[0].ReportDate = d;
            ReportsDTO newr = value[0].ToObject<ReportsDTO>();

            return ReportsBLL.UpdateReport(newr);
        }


        // DELETE: api/Reports/Delete
        public bool Delete(int id)
        {
            return ReportsBLL.RemoveReport(id);
        }
    }
}
