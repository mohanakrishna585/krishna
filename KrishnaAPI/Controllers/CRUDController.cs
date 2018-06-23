using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KrishnaAPI.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        string Baseurl = "http://localhost:53564/";
        public async Task<ActionResult> Index()
        {
            List<Models.DataClass> EmpInfo = new List<Models.DataClass>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Values");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<Models.DataClass>>(EmpResponse);

                }
            }
            return View(EmpInfo);
        }
        public async Task<ActionResult> Delete(int id)
        {
            List<Models.DataClass> EmpInfo = new List<Models.DataClass>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage Res = await client.DeleteAsync("api/Values");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<Models.DataClass>>(EmpResponse);

                }
            }
            return View(EmpInfo);
        }
        public async Task<ActionResult> CreateItem(FormCollection cls)
        {
            IList<Models.DataClass> postData = new List<Models.DataClass> { new Models.DataClass { Id = 2, ApplicationId = 123, Type = "hi", Amount = 34, Summary = "test" } };
            List<Models.DataClass> EmpInfo = new List<Models.DataClass>();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                HttpResponseMessage Res = await client.PostAsync("api/Values", postData, new JsonMediaTypeFormatter());
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                EmpInfo = JsonConvert.DeserializeObject<List<Models.DataClass>>(EmpResponse);

            }

            return View(EmpInfo);
        }
        public async Task<ActionResult> UpdateItem(FormCollection cls)
        {
            IList<Models.DataClass> postData = new List<Models.DataClass> { new Models.DataClass { Id = 2, ApplicationId = 123, Type = "hi", Amount = 34, Summary = "test" } };
            List<Models.DataClass> EmpInfo = new List<Models.DataClass>();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                HttpResponseMessage Res = await client.PutAsync("api/Values", postData, new JsonMediaTypeFormatter());
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                EmpInfo = JsonConvert.DeserializeObject<List<Models.DataClass>>(EmpResponse);

            }

            return View(EmpInfo);
        }
    }
}