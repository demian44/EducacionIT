using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clase4.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clase4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MyBaseController<TEntity, TRepository> : ControllerBase
         where TEntity : class, IEntity
         where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        public MyBaseController(TRepository repository)
        {
            this.repository = repository;
        }


        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return  await repository.GetAll();
        }

                // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var alumno = await repository.Get(id);
            if(alumno == null)
            {
                return NotFound();
            }
            return alumno;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,TEntity alumno)
        {
            if(id != alumno.ID)
            {
                return BadRequest();
            }
            await repository.Update(alumno);
            return NoContent();
        }

    }
}