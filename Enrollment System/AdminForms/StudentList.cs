using Enrollment_System.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System.AdminForms
{
    public partial class StudentList : Form
    {
        public StudentList()
        {
            InitializeComponent();
        }

        private void StudentList_Load(object sender, EventArgs e)
        {
            GetStudentList(cbCourseCode.Text, cbYearLevel.Text);
        }

       

        private void StudentList_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void GetStudentList(string pStudentCourse, string pYearLevel)
        {

            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SELECT [StudentID],([LastName] + ', ' + [FirstName] + ' ' + LEFT([MiddleName], 1) + '.') AS Name,[StudentCourse],[YearLevel],[StudentStatus]");
            stringBuilder.AppendLine("      ,[Gender]");
            stringBuilder.AppendLine("      ,[Birthdate]");
            stringBuilder.AppendLine("      ,[Address]");
            stringBuilder.AppendLine("      ,[ContactNumber]");
            stringBuilder.AppendLine("      ,[Email]");
            stringBuilder.AppendLine("  FROM [IT3232Moroscallo].[stud].[Student]");
            stringBuilder.AppendLine("WHERE StudentCourse = @StudentCourse AND YearLevel = @YearLevel ");

            // Create a DataTable to hold the search results
            DataTable dataTable = new DataTable();

            // Create a SqlConnection and a SqlCommand
            using (SqlConnection connection = new SqlConnection(GlobalSetting.ConnectionString))
            {
                // Open the connection
                connection.Open();

                // Create a SqlCommand with the dynamic query
                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    // Add parameters to the SqlCommand
                    command.Parameters.AddWithValue("@StudentCourse", pStudentCourse);


                    command.Parameters.AddWithValue("@YearLevel", pYearLevel);

                    // Create a SqlDataAdapter to fill the DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // Fill the DataTable with the results
                        adapter.Fill(dataTable);
                    }
                }
            }

            // Bind the DataTable to the DataGridView
            dgStudentList.DataSource = dataTable;
        }

        private void btnSearchFilter_Click(object sender, EventArgs e)
        {
            GetStudentList(cbCourseCode.Text, cbYearLevel.Text);
        }

        private void btnSelectSchedule_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgStudentList.SelectedRows.Count > 0)
                {

                    DataGridViewRow selectedRow = dgStudentList.SelectedRows[0];

                    EnrollStudent enrollStudent = new EnrollStudent();
                    enrollStudent.tbIDNumber.Text = selectedRow.Cells[0].Value.ToString();
                    enrollStudent.tbName.Text = selectedRow.Cells[1].Value.ToString();
                    enrollStudent.tbCourse.Text = selectedRow.Cells[2].Value.ToString();
                    enrollStudent.tbYearLevel.Text = selectedRow.Cells[3].Value.ToString();
                    enrollStudent.ShowDialog();


                }

            }
            catch
            {
            }
        }
    }
}
