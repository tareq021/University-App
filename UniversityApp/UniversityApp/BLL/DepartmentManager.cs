using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityApp.DAL;
using UniversityApp.Model;

namespace UniversityApp.BLL
{
    public class DepartmentManager
    {
        public List<Department> GetAll()
        {
            DepartmentGateway gateway = new DepartmentGateway();
            List<Department> departments = gateway.GetAll();
            return departments;
        }
    }
}