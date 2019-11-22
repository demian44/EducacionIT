using Clase4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase4.Models
{
    public class Employee: IEntity
    {
        public int ID { get; set; }
        public string Surname { get; set; }
    }
}
