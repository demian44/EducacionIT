using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clase2_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clase2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmigosController : ControllerBase
    {
        private readonly ApplicationDBContext db;

        // aplicamos inyeccion de dependencia para app dbContext
        // en el constructor
        public AmigosController(ApplicationDBContext contexto)
        {
            this.db = contexto;
        }

        /// <summary>
        /// Return All
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Amigo> Get()
        {
            //return db.Amigos;
            var amigos = from amigo in db.Amigos
                         select amigo;

            return amigos;
        }

        /// <summary>
        /// Return All
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetByID(int? id)
        {
            //return db.Amigos;
            var amigos = db.Amigos.Find(id);
            if (amigos is null)
            {
                return NotFound();
            }

            return Ok(amigos);
        }
    }
}