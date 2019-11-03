using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Clase1_Introduccion.Models;

namespace Clase1_Introduccion.Controllers
{
    public class ProductsController : NorthwindApiController
    {
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _northwindDBContext.Products;
        }

        [HttpGet]
        public Product Get(int id)
        {
            return _northwindDBContext.Products.Find(id);
        }
    }
}
