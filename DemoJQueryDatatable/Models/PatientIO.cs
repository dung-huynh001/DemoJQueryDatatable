using DemoJQueryDatatable.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoJQueryDatatable.Models
{
    public class PatientIO
    {
        private DBContext _context = new DBContext();

        public List<PATIENT> GetList()
        {
            List<PATIENT> allPatientList = _context.PATIENTs.ToList();
            List<PATIENT> activePatientList = new List<PATIENT>();
            foreach (PATIENT p in allPatientList)
            {
                if (p.DELETEDFLAG == true) continue;
                activePatientList.Add(p);
            }
            return activePatientList;
        }
    }
}