﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aeg.CarService.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        // GET: Panel
        public ActionResult Index()
        {
            return View();
        }
    }
}