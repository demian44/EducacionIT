﻿using Clase4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase4.Models
{
    public class Student: IEntity
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name{ get; set; }
        public string Email { get; set; }
    }
}
