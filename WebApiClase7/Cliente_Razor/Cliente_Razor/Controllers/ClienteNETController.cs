using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Cliente_Razor.Controllers
{
    public class ClienteNETController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Models.Persona> amigos = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44320/api/");
                var responseTask = client.GetAsync("PersonaAPI");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Models.Persona>>();
                    readTask.Wait();
                    amigos = readTask.Result;
                }
                else
                {
                    amigos = Enumerable.Empty<Models.Persona>();
                    ModelState.AddModelError(string.Empty, "Error de server.");
                }
            }

            return View(amigos);
        }
    }

}