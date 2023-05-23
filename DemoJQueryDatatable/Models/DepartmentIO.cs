using DemoJQueryDatatable.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoJQueryDatatable.Models
{
    public class DepartmentIO
    {
        private DBContext _context = new DBContext();

        public class Department
        {
            public int departmentID { get; set; }
            public string departmentName { get; set; }
            public string createdBy { get; set; }
            public string createdDate { get; set; }
            public string updatedBy { get; set; }
            public string updatedDate { get; set; }
            public bool deletedFlag { get; set; }
        }
        public List<Department> GetList()
        {
            List<DEPARTMENT> allDepartmentList = _context.DEPARTMENTs.ToList();
            List<Department> activeDepartmentList = new List<Department>();
            foreach(DEPARTMENT item in allDepartmentList)
            {
                if (item.DELETEDFLAG == true) continue;
                Department department = new Department();
                department.departmentID = item.DEPARTMENTID;
                department.departmentName = item.DEPARTMENTNAME;
                department.createdBy = item.CREATEDBY;
                department.createdDate = item.CREATEDDATE.ToString();
                department.updatedBy = item.UPDATEDBY;
                department.updatedDate = item.UPDATEDDATE.ToString();
                department.deletedFlag = item.DELETEDFLAG;
                activeDepartmentList.Add(department);
            }
            return activeDepartmentList;
        }
        public void AddDepartment(string departmentName)
        {
            DEPARTMENT newDepartment = new DEPARTMENT();
            newDepartment.DEPARTMENTNAME = departmentName;
            newDepartment.CREATEDBY = "Admin";
            newDepartment.CREATEDDATE = DateTime.Now;
            newDepartment.UPDATEDBY = "Admin";
            newDepartment.UPDATEDDATE = DateTime.Now;
            newDepartment.DELETEDFLAG = false;
            _context.DEPARTMENTs.Add(newDepartment);
            _context.SaveChanges();
        }

        public DEPARTMENT GetDepartment(string id)
        {
            int departmentID = Int32.Parse(id);
            return _context.DEPARTMENTs.Where(c => c.DEPARTMENTID.Equals(departmentID)).FirstOrDefault();      
        }

        // Edit
        public void EditDepartment(string id, string name)
        {
            DEPARTMENT department = GetDepartment(id.ToString());
            department.DEPARTMENTNAME = name;
            department.CREATEDDATE = DateTime.Now;
            department.UPDATEDDATE = DateTime.Now;
            _context.SaveChanges();
        }

        public void DeleteDepartment(string id)
        {
            DEPARTMENT department = GetDepartment(id.ToString());
            department.DELETEDFLAG = true;
            _context.SaveChanges();
        }

    }
}