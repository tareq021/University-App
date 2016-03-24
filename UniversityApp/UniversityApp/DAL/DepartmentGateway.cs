using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApp.Model;

namespace UniversityApp.DAL
{
    public class DepartmentGateway
    {
        string connectionString = @"Server=.\SQLEXPRESS;Database=University_DB;Integrated Security=true;";
        public List<Department> GetAll()
        {
            List<Department> departments = new List<Department>();
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Departments";

            SqlCommand command = new SqlCommand(query,connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = (int) reader["Id"];
                string name = reader["Name"].ToString();

                Department department = new Department(id,name);

                departments.Add(department);

            }

            return departments;
        }
    }
}