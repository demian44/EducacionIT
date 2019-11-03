using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Clase1_Introduccion.Models;

namespace Clase1_Introduccion.Controllers
{
    public class ProductsUIController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();
        private string url = "http://localhost:53116/api/";

        // GET: ProductsUI
        public ActionResult Index()
        {
            IEnumerable<Product> products = new List<Product>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var response = client.GetAsync("Products");
                response.Wait();

                if (response.Result.IsSuccessStatusCode)
                {
                    products = response.Result.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error de server.");
                }
            }

            return View(products);
        }
    }
}