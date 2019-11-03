using System.Web.Http;
using Clase1_Introduccion.Models;

namespace Clase1_Introduccion.Controllers
{
    public abstract class NorthwindApiController : ApiController
    {
        protected NorthwindEntities _northwindDBContext = new NorthwindEntities();

        public NorthwindApiController()
        {
            _northwindDBContext = new NorthwindEntities();
        }
    }
}