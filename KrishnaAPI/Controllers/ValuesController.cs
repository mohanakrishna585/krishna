using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KrishnaAPI.Models;
using Newtonsoft.Json;

namespace KrishnaAPI.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // GET api/v
        List<DataClass> list = new List<DataClass>() { new DataClass { Id = 1, ApplicationId = 123, Amount = 230, IsCleared = true, PostingDate = DateTime.Now.AddDays(-1), ClearedDate = DateTime.Now, Summary = "data", Type = "Cash" } };
        public List<DataClass> Get()
        {
            return list;
        }

        // GET api/values/5
        public IEnumerable<DataClass> Get(int id)
        {
            return list.Where(i => i.Id == id);
        }

        // POST api/values
        public List<DataClass> Post([FromUri] DataClass value)
        {
            //INSERTION GOES HERE
            DataClass dc = new DataClass { Id = 4, ApplicationId = 8578, Amount =45, IsCleared = false, PostingDate = DateTime.Now, ClearedDate = value.ClearedDate, Summary = "Testttt", Type = "Cash" };
            list.Add(dc);
            return list;
            //return list.Count();

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]DataClass value)
        {
            list.Where(i => i.Id == id);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            list.RemoveAt(id);
        }



    }
}
