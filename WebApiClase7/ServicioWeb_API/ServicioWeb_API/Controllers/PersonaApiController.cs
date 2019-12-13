using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioWeb_API.Models;

namespace ServicioWeb_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaAPIController : ControllerBase
    {
        private List<Persona> _listaPersonas = new List<Persona>();
        public PersonaAPIController()
        {
            _listaPersonas.Add(new Persona() { ID = 1, Apellido = "Montenegro", Nombre = "Teresita" });
            _listaPersonas.Add(new Persona() { ID = 2, Apellido = "Gallego", Nombre = "Cristina" });
            _listaPersonas.Add(new Persona() { ID = 3, Apellido = "Palacios", Nombre = "Claudia" });
            _listaPersonas.Add(new Persona() { ID = 4, Apellido = "Medina", Nombre = "Ruben" });
            _listaPersonas.Add(new Persona() { ID = 5, Apellido = "Rodriguez", Nombre = "Guillermo" });
            _listaPersonas.Add(new Persona() { ID = 6, Apellido = "Guarnes", Nombre = "Guilllermo" });
            _listaPersonas.Add(new Persona() { ID = 7, Apellido = "Rivero", Nombre = "Laura" });
            _listaPersonas.Add(new Persona() { ID = 8, Apellido = "Moro", Nombre = "Lilia" });
            _listaPersonas.Add(new Persona() { ID = 9, Apellido = "Calabresse", Nombre = "Julio" });
            _listaPersonas.Add(new Persona() { ID = 10, Apellido = "Caballero", Nombre = "Luis" });
            _listaPersonas.Add(new Persona() { ID = 11, Apellido = "Viñuela", Nombre = "Marcelo" });
        }

        [HttpGet]
        public List<Persona> GetAll()
        {
            return _listaPersonas;
        }

        [HttpGet("{id}")]
        public ActionResult<Persona> GetPersonaById(int id)
        {
            var persona = _listaPersonas.FirstOrDefault(p => p.ID == id);
            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }
    }
}