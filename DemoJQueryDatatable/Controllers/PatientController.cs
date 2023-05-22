using DemoJQueryDatatable.Models;
using DemoJQueryDatatable.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoJQueryDatatable.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        PatientIO db = new PatientIO();
        public ActionResult Index()
        {
            List<PATIENT> pList = db.GetList();
            return View(pList);
        }
    }
}