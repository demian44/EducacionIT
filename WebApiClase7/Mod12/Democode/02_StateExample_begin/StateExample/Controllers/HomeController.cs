﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StateExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int? overallVisitsNumber = HttpContext.Session.GetInt32("Overall");
            int? controllerVisitsNumber = HttpContext.Session.GetInt32("Home");
            int? AnotherControllerVisitsNumber = HttpContext.Session.GetInt32("Another");

            if (overallVisitsNumber == null)
            {
                overallVisitsNumber = 1;
            }
            else
            {
                overallVisitsNumber++;
            }

            if (controllerVisitsNumber == null)
            {
                controllerVisitsNumber = 1;
            }
            else
            {
                controllerVisitsNumber++;
            }

            if (AnotherControllerVisitsNumber == null)
            {
                AnotherControllerVisitsNumber = 0;
            }

 /*->*/     HttpContext.Session.SetInt32("Overall", overallVisitsNumber.Value);
            HttpContext.Session.SetInt32("Home", controllerVisitsNumber.Value);
            HttpContext.Session.SetInt32("Another", AnotherControllerVisitsNumber.Value);

            return View();
        }
    }
}