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
    public class TypesOfExpensesAndIncomeController : ApiController
    {
        [HttpGet]
        // GET: api/TypesOfExpensesAndIncome/Get
        public List<TypesOfExpensesAndIncomeDTO> Get()
        {
            return TypesOfExpensesAndIncomeBLL.GetAllTypesOfExpensesAndIncome();
        }

        // GET: api/TypesOfExpensesAndIncome/Get/5
        public TypesOfExpensesAndIncomeDTO Get(int id)
        {
            return TypesOfExpensesAndIncomeBLL.GetTypesOfExpensesAndIncomeByID(id);
        }
        [HttpPost]
        // POST: api/TypesOfExpensesAndIncome
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TypesOfExpensesAndIncome/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TypesOfExpensesAndIncome/5
        public void Delete(int id)
        {
        }
    }
}
