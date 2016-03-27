using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityApp.Model
{
    public class StudentView
    {
        public StudentView(int id, string name, string regNo, string email, int department, string departmentName)
        {
            Id = id;
            Name = name;
            RegNo = regNo;
            Email = email;
            DepartmentId = department;
            DepartmentName = departmentName;
        }        

        public string DepartmentName { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegNo { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
    }
}