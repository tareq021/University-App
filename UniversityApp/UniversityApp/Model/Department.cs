using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityApp.Model
{
    public class Department
    {
        public Department(int id, string name)
        {
            this.Name = name;
            this.Id = id;

        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}