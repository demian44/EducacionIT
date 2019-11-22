using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clase4.Data;
using Clase4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clase4.Controllers
{
    [Route("api/students2")]
    [ApiController]
    public class Students2 : MyBaseController<Student, StudentRepository>
    {
        public Students2(StudentRepository repository): base(repository)
        {
        }
    }

}
