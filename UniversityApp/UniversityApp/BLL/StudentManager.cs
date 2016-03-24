using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApp.DAL;

namespace UniversityApp.BLL
{
    public class StudentManager
    {
        StudentGateway gateway = new StudentGateway();
        public string Save(Student student)
        {
            // check if regNo already exists
            string message = "";
            bool isRegNoExists = gateway.IsRegNoExists(student.RegNo);

            if (isRegNoExists)
            {
                message = "Reg No already exists!";

            }
            else
            {

                int rowsAffected = gateway.Insert(student);

                if (rowsAffected > 0)
                {
                    message = "Saved successfully";
                }
                else
                {
                    message = "Sorry! Insert failed.";
                }
            }

            return message;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = gateway.GetAllStudents();
            return students;
        }

        public Student GetStudentById(int studentId)
        {
            Student student = gateway.GetStudentById(studentId);
            return student;
        }

        public string Update(Student aStudent)
        {
            bool isUpdated = gateway.Update(aStudent);
            string message = "Update Failed!";
            if (isUpdated)
            {
                message = "Updated Successfully!";
            }

            return message;
        }
    }
}