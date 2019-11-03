using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Clase1_Introduccion.Models;

namespace Clase1_Introduccion.Controllers
{
    public class ShippersAPiController : NorthwindApiController
    {
        
        [HttpGet]
        public IEnumerable<Shipper> Get()
        {
            return this._northwindDBContext.Shippers;
        }

        [HttpGet]
        public Shipper Get(int id)
        {
            return this._northwindDBContext.Shippers.Find(id);
        }
    }
}
