using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApp.DAL;
using UniversityApp.Model;

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

        public List<StudentView> GetAllStudentsWithDepartment()
        {
            List<StudentView> students = gateway.GetAllStudentsWithDepartment();
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

        internal string Delete(Student aStudent)
        {
            bool isDeleted = gateway.Delete(aStudent);
            string message = "Delete Failed";
            if (isDeleted)
            {
                message = "Record Deleted!";
            }

            return message;
        }

        internal List<StudentView> ShowAllStudents()
        {
            List<StudentView> allStudents = gateway.ShowAllStudents();
            return allStudents;
        }

        internal List<StudentView> ShowAllDepartments()
        {
            List<StudentView> allStudents = gateway.ShowAllDepartments();
            return allStudents;
        }
    }
}