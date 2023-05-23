using DemoJQueryDatatable.Models;
using DemoJQueryDatatable.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            name = name.Trim();
            string patternName = @"^[\p{L}\p{N}\s]*$";
            if (String.IsNullOrEmpty(name))
            {
                return Json(new { success = false, message = "Department name cannot null!" });
            }
            else
            {
                Match valid = Regex.Match(name, patternName, RegexOptions.IgnoreCase);
                if (!valid.Success)
                {
                    return Json(new { success = false, message = "Department name is wrong format!" });
                }
                else
                {
                    if (name.Length > 256)
                    {
                        return Json(new { success = false, message = "Department name cannot be more than 256 charaters!" });
                    }
                    db.AddDepartment(name);
                    return Json(new { success = true, message = "Create a new Department successfully!" });
                }
            }  
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
            return Json(new { success = true, message = "Delete the Department successfully! " });
        }
    }
}