using AjaxHelperSecondEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxHelperSecondEx.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDBEntities db = new EmployeeDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.employees.ToList());
        }
        [HttpPost]
        public ActionResult Index(string q)
        {
            if(string.IsNullOrEmpty(q) == false)
            {
                List<employee> emp = db.employees.Where(model => model.name.StartsWith(q)).ToList();
                return PartialView("_SearchData", emp);
            }
            else
            {
                List<employee> emp = db.employees.ToList();
                return PartialView("_SearchData", emp);
            }
        }
    }
}