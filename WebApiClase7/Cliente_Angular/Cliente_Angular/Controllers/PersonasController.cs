using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cliente_Angular.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cliente_Angular.Controllers
{
    public class PersonasController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<Persona> Getamigos()
        {
            IEnumerable<Persona> amigos = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44320/api/");
                var responseTask = client.GetAsync("PersonaAPI");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Persona>>();
                    readTask.Wait();
                    amigos = readTask.Result;
                }
                else
                {
                    amigos = Enumerable.Empty<Persona>();
                    ModelState.AddModelError(string.Empty, "Error de server.");
                }
            }
            return amigos;
        }

    }
}