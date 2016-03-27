using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityApp
{
    public class Student
    {
        public Student(int id, string name, string regNo, string email, int department)
        {
            this.Id = id;
            this.Name = name;
            this.RegNo = regNo;
            this.Email = email;
            this.DepartmentId = department;
        }

        public Student()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string RegNo { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
    }
}