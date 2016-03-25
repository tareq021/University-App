using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityApp.BLL;
using UniversityApp.Model;

namespace UniversityApp
{
    public partial class StudentEntryUI : System.Web.UI.Page
    {
        StudentManager manager = new StudentManager();
        DepartmentManager departmentManager = new DepartmentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack==false)
            {
                if (Request.QueryString["id"]!=null)
                {
                    int studentId = Convert.ToInt32(Request.QueryString["id"]);

                    Student student = manager.GetStudentById(studentId);

                    if (student!=null)
                    {
                        nameTextBox.Text = student.Name;
                        emailTextBox.Text = student.Email;
                        regNoTextBox.Text = student.RegNo;
                        departmentDropDown.SelectedValue = student.DepartmentId.ToString();
                        saveButton.Text = "Update";
                    }
                }
                


                List<Department> departments = departmentManager.GetAll();

                departmentDropDown.DataSource = departments;
                departmentDropDown.DataTextField = "Name";
                departmentDropDown.DataValueField = "Id";
                departmentDropDown.DataBind();
            }
            

        }
         
        protected void saveButton_Click(object sender, EventArgs e)
        {
            

            Student aStudent = new Student();
            aStudent.RegNo = regNoTextBox.Text;
            aStudent.Name = nameTextBox.Text;
            aStudent.Email = emailTextBox.Text;
            aStudent.DepartmentId = Convert.ToInt32(departmentDropDown.SelectedValue);
            string message = "";
            if (saveButton.Text!="Update")
            {
                message = manager.Save(aStudent);
            }
            else
            {
                int studentId = Convert.ToInt32(Request.QueryString["id"]);
                aStudent.Id = studentId;

                message = manager.Update(aStudent);
                saveButton.Text = "Save";
            }
           
            messageLabel.Text = message;

        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            List<Student> studentList = manager.GetAllStudents();

            studentGridView.DataSource = studentList;
            studentGridView.DataBind();
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}