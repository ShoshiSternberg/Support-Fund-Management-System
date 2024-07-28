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
    public class TransactionsOnCofferController : ApiController
    {
        [HttpGet]
        // GET: api/TransactionsOnCoffer/Get
        public List<dynamic> Get()
        {
            return TransactionsOnCofferBLL.GetAllTransactions();
        }

        // GET: api/TransactionsOnCoffer/Get/5
        public dynamic Get(int id)
        {
            return TransactionsOnCofferBLL.GetTransactionByID(id);
        }
        [HttpPost]
        // POST: api/TransactionsOnCoffer/Post
        public bool Post([FromBody]TransactionsOnCofferDTO Object1)
        {
            return TransactionsOnCofferBLL.InsertTransaction(Object1);
        }

        // PUT: api/TransactionsOnCoffer/5
        public bool Put([FromBody] TransactionsOnCofferDTO Object1)
        {
            return TransactionsOnCofferBLL.UpdateTransaction(Object1);
        }

        // DELETE: api/TransactionsOnCoffer/5
        public void Delete(int id)
        {
        }
    }
}
