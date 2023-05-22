using DemoJQueryDatatable.Models;
using DemoJQueryDatatable.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoJQueryDatatable.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentIO db = new DepartmentIO();

        // GET: Department
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetData()
        {
            var departmentList = db.GetList();
            return Json(new { data = departmentList }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(string name)
        {
            db.AddDepartment(name);           
            return Json(new { success = true, message = "Create a new Department successfully!" });
        }
        
        public ActionResult Edit(string idEdit)
        {
            DEPARTMENT department = db.GetDepartment(idEdit);
            return Json(new { data = department }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(string id, string name)
        {
            db.EditDepartment(id, name);
            return Json(new { success = true, message = "Update the Department successfully!" });
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            db.DeleteDepartment(id);
            return Json(new { success = true, message = "Delete the Department successfully! " + id });
        }
    }
}