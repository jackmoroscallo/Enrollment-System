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
using System.Xml.Linq;

namespace Enrollment_System
{
    public partial class OfferedSubjectList : Form
    {
        public OfferedSubjectList()
        {
            InitializeComponent();
        }

        int Semester = 0;

        private void OfferedSubjectList_Load(object sender, EventArgs e)
        {
            FetchDataAndDisplay();
            getSchoolYear();
            cbSchoolYear.DropDownHeight = 150;
            GetOfferedSubjectList(cbSchoolYear.Text, cbSemester.Text);
        }

        private void LoadData()
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SELECT os.[RecordNumber]");
            stringBuilder.AppendLine("      ,os.[SubjectID]");
            stringBuilder.AppendLine("      ,os.[ClassType]");
            stringBuilder.AppendLine("      ,os.[Capacity]");
            stringBuilder.AppendLine("      ,os.[DateOffered]");
            stringBuilder.AppendLine("      ,os.[SubjectRate]");
            stringBuilder.AppendLine("      ,os.[SchoolYear]");
            stringBuilder.AppendLine("      ,os.[Semester]");
            stringBuilder.AppendLine("      ,os.[CourseCode]");
            stringBuilder.AppendLine("      ,os.[SubjectLevel]");
            stringBuilder.AppendLine("      ,s.[SubjectCode]");
            stringBuilder.AppendLine("      ,s.[SubjectDescription]");
            stringBuilder.AppendLine("      ,s.[Units]");
            stringBuilder.AppendLine("      ,s.[Type]");
            stringBuilder.AppendLine("      ,s.[SubjectHours]");
            stringBuilder.AppendLine("      ,ss.[SubjectTimeStart]");
            stringBuilder.AppendLine("      ,ss.[SubjectTimeEnd]");
            stringBuilder.AppendLine("      ,ss.[SubjectDay]");
            //stringBuilder.AppendLine("      ,ss.[SchedMonday]");
            //stringBuilder.AppendLine("      ,ss.[SchedTuesday]");
            //stringBuilder.AppendLine("      ,ss.[SchedWednesday]");
            //stringBuilder.AppendLine("      ,ss.[SchedThursday]");
            //stringBuilder.AppendLine("      ,ss.[SchedFriday]");
            //stringBuilder.AppendLine("      ,ss.[SchedSaturday]");
            //stringBuilder.AppendLine("      ,ss.[SchedSunday]");
            stringBuilder.AppendLine("      ,r.[RoomName]");
            stringBuilder.AppendLine("      ,ua.[Name]");
            stringBuilder.AppendLine("      ,sec.[SectionName]");
            stringBuilder.AppendLine("      ,ss.[DateAdded]");
            stringBuilder.AppendLine("FROM [IT3232Moroscallo].[sub].[OfferedSubject] os");
            stringBuilder.AppendLine("LEFT JOIN [IT3232Moroscallo].[sub].[Subject] s ON os.[SubjectID] = s.[SubjectID]");
            stringBuilder.AppendLine("LEFT JOIN [IT3232Moroscallo].[sub].[SubjectSchedule] ss ON os.[SubjectID] = ss.[SubjectID] AND os.[CourseCode] = ss.[CourseCode]");
            stringBuilder.AppendLine("LEFT JOIN [IT3232Moroscallo].[dbo].[Room] r ON r.[RoomID] = ss.[RoomID]");
            stringBuilder.AppendLine("LEFT JOIN [IT3232Moroscallo].[stud].[UserAccount] ua ON ua.[UserID] = ss.[InstructorID]");
            stringBuilder.AppendLine("LEFT JOIN [IT3232Moroscallo].[dbo].[Section] sec ON sec.[SectionID] = ss.[SectionID]");

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(stringBuilder.ToString(), connection);

                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                dgOfferedSubjectList.DataSource = dataTable;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
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

        private void GetOfferedSubjectList(string pSchoolYear, string pSemester )
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            stringBuilder.AppendLine("SELECT os.[RecordNumber]");
            stringBuilder.AppendLine("      ,os.[SubjectID]");
            stringBuilder.AppendLine("      ,os.[ClassType]");
            stringBuilder.AppendLine("      ,os.[Capacity]");
            stringBuilder.AppendLine("      ,os.[DateOffered]");
            stringBuilder.AppendLine("      ,os.[SubjectRate]");
            stringBuilder.AppendLine("      ,os.[SchoolYear]");
            stringBuilder.AppendLine("      ,os.[Semester]");
            stringBuilder.AppendLine("      ,os.[CourseCode]");
            stringBuilder.AppendLine("      ,os.[SubjectLevel]");
            stringBuilder.AppendLine("      ,s.[SubjectCode]");
            stringBuilder.AppendLine("      ,s.[SubjectDescription]");
            stringBuilder.AppendLine("      ,s.[Units]");
            stringBuilder.AppendLine("      ,s.[Type]");
            stringBuilder.AppendLine("      ,s.[SubjectHours]");
            stringBuilder.AppendLine("      ,FORMAT(ss.[SubjectTimeStart], 'hh:mm tt') AS SubjectTimeStart");
            stringBuilder.AppendLine("      ,FORMAT(ss.[SubjectTimeEnd], 'hh:mm tt') AS SubjectTimeEnd");
            stringBuilder.AppendLine("      ,ss.[SubjectDay]");
            stringBuilder.AppendLine("      ,r.[RoomName]");
            stringBuilder.AppendLine("      ,ua.[Name]");
            stringBuilder.AppendLine("      ,sec.[SectionName]");
            stringBuilder.AppendLine("      ,ss.[DateAdded]");
            stringBuilder.AppendLine("FROM [IT3232Moroscallo].[sub].[OfferedSubject] os");
            stringBuilder.AppendLine("LEFT JOIN [IT3232Moroscallo].[sub].[Subject] s ON os.[SubjectID] = s.[SubjectID]");
            stringBuilder.AppendLine("LEFT JOIN [IT3232Moroscallo].[sub].[SubjectSchedule] ss ON os.[SubjectID] = ss.[SubjectID] AND os.[CourseCode] = ss.[CourseCode]");
            stringBuilder.AppendLine("LEFT JOIN [IT3232Moroscallo].[dbo].[Room] r ON r.[RoomID] = ss.[RoomID]");
            stringBuilder.AppendLine("LEFT JOIN [IT3232Moroscallo].[stud].[UserAccount] ua ON ua.[UserID] = ss.[InstructorID]");
            stringBuilder.AppendLine("LEFT JOIN [IT3232Moroscallo].[dbo].[Section] sec ON sec.[SectionID] = ss.[SectionID]");
            stringBuilder.AppendLine("WHERE os.SchoolYear = @SchoolYear AND os.Semester = @Semester ");

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

                    command.Parameters.AddWithValue("@Semester", Semester);

                    // Create a SqlDataAdapter to fill the DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // Fill the DataTable with the results
                        adapter.Fill(dataTable);
                    }
                }
            }

            // Bind the DataTable to the DataGridView
            dgOfferedSubjectList.DataSource = dataTable;
        }

        private void btnSaveSection_Click(object sender, EventArgs e)
        {
            GetOfferedSubjectList(cbSchoolYear.Text, cbSemester.Text);
        }

        private void btnMainMenu2_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void btnViewSubjectOffered_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgOfferedSubjectList.SelectedRows.Count > 0)
                {

                    DataGridViewRow selectedRow = dgOfferedSubjectList.SelectedRows[0];

                    ViewOfferedSubjectList vOSubjectList = new ViewOfferedSubjectList();
                    vOSubjectList.RecordNumber = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                    vOSubjectList.ShowDialog();
                    

                }

            }
            catch
            {
            }
           
        }
    }
}
