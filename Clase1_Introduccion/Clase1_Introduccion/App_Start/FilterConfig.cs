﻿using System.Web;
using System.Web.Mvc;

namespace Clase1_Introduccion
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
