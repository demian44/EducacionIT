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
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : MyBaseController<Employee, EmployeeRepository>
    {
        public EmployeesController(EmployeeRepository repository): base(repository)
        {
        }
    }

}
