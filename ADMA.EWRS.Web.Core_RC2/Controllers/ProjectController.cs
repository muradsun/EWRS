﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ADMA.EWRS.Web.Core.Controllers
{
    public class ProjectController : BaseWebController
    {
        public ProjectController(IServiceProvider provider)
            : base(provider)
        {
                
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateProjectWizard()
        {
            //return  RedirectToAction("Adnan","MYasin");
            return View();

        }


    }
}
