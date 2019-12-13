﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using IdentityExample.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityExample.Controllers
{
    public class StudentController : Controller
    {
        private StudentContext _studentContext;

        public StudentController(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        [Authorize]
        public async Task<IActionResult> IndexAsync()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult CourseDetails()
        {
            return View(_studentContext.Courses.ToList());
        }
    }
}