using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Web;
using ugh.Models;
using System.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ugh.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public ArrayList Get()
        {
            ValuesVal vv = new ValuesVal();
            return vv.allValues();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Values Get(int id)
        {
            ValuesVal vv = new ValuesVal();
            Values values = vv.getValues(id);
           

            return values;
        }

        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Values value)
           
        {
            ValuesVal vv = new ValuesVal();
            int id;
            id = vv.allPeople(value);
            value.id = id;
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);




            return response;



        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody]Values value)
        {
            ValuesVal vv = new ValuesVal();
            bool recordExistence = false;
            recordExistence = vv.updateVal(id,value);
            HttpResponseMessage response;
            if (recordExistence)
            {
                response = new HttpResponseMessage(HttpStatusCode.NoContent);

            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.NotFound);

            }
            return response;

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete (int id)
        {
            ValuesVal vv = new ValuesVal();
            bool recordExistence = false;
            recordExistence = vv.deleteVal(id);
            HttpResponseMessage response;

            if (recordExistence)
            {
                response =  new HttpResponseMessage(HttpStatusCode.NoContent);

            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.NotFound);

            }
            return response;
        }
    }
}
