using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloMVC2.Models;
using System.Data;

namespace HelloMVC2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SampleDBContext db = new SampleDBContext();
            return View(db.Employees.ToList());
        }


        public ActionResult Details(int id)
        {

            SampleDBContext db = new SampleDBContext();
            Employee employee = db.Employees.Single(x => x.Id == id);
            return View(employee);
        }

        public ActionResult Details1(int id)
        {

            Company company = new Company();
            return View(company);

        }

        public ActionResult Details2(int id)
        {

            SampleDBContext db = new SampleDBContext();
            Employee employee = db.Employees.Single(x => x.Id == id);
            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            SampleDBContext db = new SampleDBContext();
            Employee employee = db.Employees.Single(x => x.Id == id);

            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                SampleDBContext db = new SampleDBContext();
                Employee employeeFromDB = db.Employees.Single(x => x.Id == employee.Id);

                // Populate all the properties except EmailAddrees
                employeeFromDB.FullName = employee.FullName;
                employeeFromDB.Gender = employee.Gender;
                employeeFromDB.Age = employee.Age;
                employeeFromDB.HireDate = employee.HireDate;
                employeeFromDB.Salary = employee.Salary;
                employeeFromDB.PersonalWebSite = employee.PersonalWebSite;

                db.Entry(employeeFromDB).State = System.Data.Entity.EntityState.Modified;
                //db.ObjectStatemanager.ChangeObjectState(employeeFromDB, System.Data.EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = employee.Id });
            }
            return View(employee);
        }
    }
}