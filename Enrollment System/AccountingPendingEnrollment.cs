using Enrollment_System.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System
{
    public partial class AccountingPendingEnrollment : Form
    {
        public AccountingPendingEnrollment()
        {
            InitializeComponent();
        }

        public int Semester { get; set; }

        private void AccountingPendingEnrollment_Load(object sender, EventArgs e)
        {
            getSchoolYear();
            FetchDataAndDisplay();
        }

        private void getSchoolYear()
        {

            string connectionString = GlobalSetting.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Replace "YourTableName" and "YourColumnName" with your actual table and column names
                string query = "SELECT SchoolYear FROM [dbo].[SchoolYear] ORDER BY SchoolYear DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Clear existing items in the ComboBox
                        cbSchoolYear.Items.Clear();

                        while (reader.Read())
                        {
                            // Add each item to the ComboBox
                            cbSchoolYear.Items.Add(reader["SchoolYear"].ToString());
                        }
                    }
                }
            }
        }

        private void btnSearchFilter_Click(object sender, EventArgs e)
        {
            GetPendingEnrollments(cbSchoolYear.Text, cbSemester.Text);
        }

        private void GetPendingEnrollments(string pSchoolYear, string pSemester)
        {

            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SELECT [EnrollmentID]");
            stringBuilder.AppendLine("      ,e.[StudentID]");
            stringBuilder.AppendLine("	  ,(s.[LastName] + ', ' + s.[FirstName] + ' ' + LEFT(s.[MiddleName], 1) + '.') AS Name");
            stringBuilder.AppendLine("      ,e.[CourseCode]");
            stringBuilder.AppendLine("      ,e.[YearLevel]");
            stringBuilder.AppendLine("      ,e.[SchoolYear]");
            stringBuilder.AppendLine("      ,e.[Term]");
            stringBuilder.AppendLine("      ,e.[EnrollmentDate]");
            stringBuilder.AppendLine("      ,e.[EnrollmentStatus]");
            stringBuilder.AppendLine("  FROM [IT3232Moroscallo].[dbo].[Enrollment] e");
            stringBuilder.AppendLine("  LEFT JOIN [IT3232Moroscallo].[stud].[Student] s");
            stringBuilder.AppendLine("  ON s.[StudentID] = e.[StudentID]");
            stringBuilder.AppendLine("  WHERE e.[SchoolYear] = @SchoolYear AND e.[Term] = @Term AND e.[EnrollmentStatus] = 'Pending-Accounting'");


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
                    command.Parameters.AddWithValue("@SchoolYear", pSchoolYear);

                    if (pSemester == "1st Semester")
                    {
                        Semester = 1;
                    }
                    else if (pSemester == "2nd Semester")
                    {
                        Semester = 2;
                    }
                    else if (pSemester == "Summer")
                    {
                        Semester = 3;
                    }

                    command.Parameters.AddWithValue("@Term", Semester);



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

        private void FetchDataAndDisplay()
        {
            try
            {
                string connectionString = GlobalSetting.ConnectionString;

                // Construct your SQL query dynamically using StringBuilder
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("SELECT [SchoolYear]");
                stringBuilder.Append("      ,CASE WHEN [Term] = 1 THEN '1st Semester'");
                stringBuilder.Append("			WHEN [Term] = 2 THEN '2nd Semester'");
                stringBuilder.Append("			ELSE 'Summer'");
                stringBuilder.Append("			END AS Term ");
                stringBuilder.Append("FROM [IT3232Moroscallo].[dbo].[DefaultSchoolYearTerm]");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                    {
                        connection.Open();
                        // Execute the query
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {

                            // Display the data in the textbox
                            cbSchoolYear.Text = reader.GetString(0);
                            cbSemester.Text = reader.GetString(1);
                        }
                        else
                        {
                            // Handle if no data found
                            MessageBox.Show("No data found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSelectStudent_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgStudentList.SelectedRows.Count > 0)
                {

                    DataGridViewRow selectedRow = dgStudentList.SelectedRows[0];

                    PendingEnrollment pendingEnrollment = new PendingEnrollment();
                    pendingEnrollment.tbIDNumber.Text = selectedRow.Cells[1].Value.ToString();
                    pendingEnrollment.tbName.Text = selectedRow.Cells[2].Value.ToString();
                    pendingEnrollment.tbCourse.Text = selectedRow.Cells[3].Value.ToString();
                    pendingEnrollment.tbYearLevel.Text = selectedRow.Cells[4].Value.ToString();
                    pendingEnrollment.tbEnrollmentDate.Text = selectedRow.Cells[7].Value.ToString();
                    pendingEnrollment.tbEnrollmentStatus.Text = selectedRow.Cells[8].Value.ToString();
                    pendingEnrollment.ShowDialog();


                }

            }
            catch
            {
            }
        }
    }
}
