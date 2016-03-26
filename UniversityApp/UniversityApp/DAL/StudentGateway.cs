using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UniversityApp.DAL
{
    public class StudentGateway
    {
        string connectionString = @"Server=.\SQLEXPRESS;Database=University_DB;Integrated Security=true;";

        public bool IsRegNoExists(string regNo)
        {
            bool isRegNoExists = false;
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Students WHERE RegNo = '" + regNo + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isRegNoExists = true;
            }

            return isRegNoExists;

        }

        public int Insert(Student aStudent)
        {
            string query = "INSERT INTO Students VALUES('" + aStudent.RegNo + "', '" + aStudent.Name + "', '" + aStudent.Email + "', '" + aStudent.DepartmentId + "')";

            SqlConnection aConnection = new SqlConnection(connectionString);
            //aConnection.ConnectionString = connectionString;
            aConnection.Open();

            SqlCommand aCommand = new SqlCommand();
            aCommand.CommandText = query;
            aCommand.Connection = aConnection;

            int rowsAffected = aCommand.ExecuteNonQuery();
            aConnection.Close();

            return rowsAffected;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Students";

            SqlCommand command = new SqlCommand(query,connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string regNo = reader["RegNo"].ToString();
                string name = reader["Name"].ToString();
                string email = reader["Email"].ToString();
                int department = Convert.ToInt32(reader["DepartmentId"].ToString());

                Student student = new Student(id,name,regNo,email,department);
                students.Add(student);
            }

            connection.Close();
            return students;
        }

        internal bool Delete(Student aStudent)
        {
            int rowsEffected = 0;
            string deleteStudentQuery = "";

            if (IsRegNoExists(aStudent.RegNo) == false)
            {
                return false;
            }
            else if (IsRegNoExists(aStudent.RegNo) == true)
            {
                deleteStudentQuery = "DELETE FROM Students WHERE Id = '" + aStudent.Id + "'";
            }

            SqlConnection dBConnection = new SqlConnection(connectionString);

            dBConnection.Open();
            SqlCommand command = new SqlCommand(deleteStudentQuery, dBConnection);
            rowsEffected = command.ExecuteNonQuery();
            dBConnection.Close();

            return rowsEffected > 0;
        }

        public Student GetStudentById(int studentId)
        {
            Student student = null;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Students WHERE Id='"+studentId+"'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string regNo = reader["RegNo"].ToString();
                string name = reader["Name"].ToString();
                string email = reader["Email"].ToString();
                int department = Convert.ToInt32(reader["DepartmentId"].ToString());

                student = new Student(id, name, regNo, email, department);
               
            }
            
            connection.Close();
            return student;
        }

        public bool Update(Student aStudent)
        {
            string query = "UPDATE Students SET RegNo= '" + aStudent.RegNo + "', Name='" + aStudent.Name + "',Email= '" + aStudent.Email + "',  DepartmentId='" + aStudent.DepartmentId + "' WHERE Id='"+aStudent.Id+"'";

            SqlConnection aConnection = new SqlConnection(connectionString);
            //aConnection.ConnectionString = connectionString;
            aConnection.Open();

            SqlCommand aCommand = new SqlCommand();
            aCommand.CommandText = query;
            aCommand.Connection = aConnection;

            int rowsAffected = aCommand.ExecuteNonQuery();
            aConnection.Close();

            return rowsAffected>0;
        }
    }
}