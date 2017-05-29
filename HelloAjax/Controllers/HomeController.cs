﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloAjax.Models;

namespace HelloAjax.Controllers
{
    public class HomeController : Controller
    {
        SampleDBContext db = new SampleDBContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult All()
        {
            List<Student> model = db.Students.ToList();
            return PartialView("_Student", model);
        }

        public PartialViewResult Top3()
        {
            List<Student> model = db.Students.OrderByDescending(x => x.TotalMarks).Take(3).ToList();
            return PartialView("_Student", model);
        }

        public PartialViewResult Bottom3()
        {
            List<Student> model = db.Students.OrderBy(x => x.TotalMarks).Take(3).ToList();
            return PartialView("_Student", model);
        }


    }
}