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
    public partial class OfferedSubject : Form
    {
        public OfferedSubject()
        {
            InitializeComponent();
        }

        int SubID { get; set; }
        int RoomID { get; set; }
        int InstructorID { get; set; }
        int SectionID { get; set; }

        private void LoadData()
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SELECT [SubjectID]");
            stringBuilder.AppendLine("      ,[CourseCode]");
            stringBuilder.AppendLine("      ,[SubjectCode]");
            stringBuilder.AppendLine("      ,[SubjectDescription]");
            stringBuilder.AppendLine("      ,[Units]");
            stringBuilder.AppendLine("      ,[Type]");
            stringBuilder.AppendLine("      ,[SubjectHours]");
            stringBuilder.AppendLine("  FROM [IT3232Moroscallo].[sub].[Subject]");

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(stringBuilder.ToString(), connection);

                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                dgSubject.DataSource = dataTable;
                dgSubject.Columns["SubjectID"].Visible = false;
                dgSubject.Columns["Units"].Visible = false;
                dgSubject.Columns["SubjectHours"].Visible = false;

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

        private void OfferedSubject_Load(object sender, EventArgs e)
        {
            getSchoolYear();
            getCourses();

            SubID = 0;

            FetchDataAndDisplay();
            cbSchoolYear.DropDownHeight = 150;
            PopulateComboBox();
            PopulateSectionComboBox();
            PopulateInstructorComboBox();
        }

        private void dgSubject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dgSubject.Rows[e.RowIndex];

                SubID = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                
                tbCourseCode.Text = selectedRow.Cells[1].Value.ToString();
                tbCourseCode2.Text = selectedRow.Cells[1].Value.ToString();
                tbSubjectCode.Text = selectedRow.Cells[2].Value.ToString();
                tbSubjectDesc.Text = selectedRow.Cells[3].Value.ToString();
                tbUnits.Text = selectedRow.Cells[4].Value.ToString();
                tbType.Text = selectedRow.Cells[5].Value.ToString();
                tbSubjectHours.Text = selectedRow.Cells[6].Value.ToString();
            }
            catch
            {

            }
        }

        private void FetchDataAndDisplay()
        {
            //try
            //{
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
            //}
            //catch (Exception ex)
            //{
            //    // Handle exceptions
            //    MessageBox.Show("Error: " + ex.Message);
            //}
        }

        private void getCourses()
        {

            string connectionString = GlobalSetting.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Replace "YourTableName" and "YourColumnName" with your actual table and column names
                string query = "SELECT CourseCode FROM [dbo].[Course]";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Clear existing items in the ComboBox
                        cbCourseCode.Items.Clear();

                        while (reader.Read())
                        {
                            // Add each item to the ComboBox
                            cbCourseCode.Items.Add(reader["CourseCode"].ToString());
                        }
                    }
                }
            }
        }

        

        private void btnSelectSubject_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSaveSection_Click(object sender, EventArgs e)
        {
            string searchKeyword = cbCourseCode.Text;

            using (SqlConnection connection = new SqlConnection(GlobalSetting.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    // Get column names
                    DataTable schemaTable = connection.GetSchema("Columns", new[] { null, null, "Subject", null });

                    // Constructing the dynamic SQL query
                    command.CommandText = $"SELECT * FROM [sub].[Subject] WHERE ";

                    foreach (DataRow row in schemaTable.Rows)
                    {
                        string columnName = (string)row["COLUMN_NAME"];

                        // Append each column to the WHERE clause
                        command.CommandText += $"{columnName} LIKE @{columnName} OR ";

                        // Add parameter for the current column
                        command.Parameters.AddWithValue($"@{columnName}", $"%{searchKeyword}%");
                    }

                    // Remove the last 'OR' from the WHERE clause
                    command.CommandText = command.CommandText.TrimEnd(' ', 'O', 'R');

                    // Create a DataTable to store the search results
                    DataTable searchResults = new DataTable();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // Fill the DataTable with the search results
                        adapter.Fill(searchResults);
                    }

                    // Bind the DataTable to the DataGridView
                    dgSubject.DataSource = searchResults;
                }


            }

            

        }

        private void SchedDays()
        {
            string Days = "";
            string[] dayAbbreviations = { "M", " T", " W", " TH", " F", " SAT", " SUN" };

            System.Windows.Forms.CheckBox[] checkboxes = { cbMonday, cbTue, cbWed, cbThur, cbFri, cbSat, cbSun };

            for (int i = 0; i < checkboxes.Length; i++)
            {
                if (checkboxes[i].Checked)
                {
                    Days += dayAbbreviations[i];
                }
            }

            tbDay.Text = Days;


        }

        private void cbMonday_CheckedChanged(object sender, EventArgs e)
        {
            SchedDays();
        }

        private void cbTue_CheckedChanged(object sender, EventArgs e)
        {
            SchedDays();
        }

        private void cbWed_CheckedChanged(object sender, EventArgs e)
        {
            SchedDays();
        }

        private void cbThur_CheckedChanged(object sender, EventArgs e)
        {
            SchedDays();
        }

        private void cbFri_CheckedChanged(object sender, EventArgs e)
        {
            SchedDays();
        }

        private void cbSat_CheckedChanged(object sender, EventArgs e)
        {
            SchedDays();
        }

        private void cbSun_CheckedChanged(object sender, EventArgs e)
        {
            SchedDays();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            SaveOfferedSubject();
            SaveSubjectSchedule();

        }

        private void cbInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetInstructorID(cbInstructor.Text);
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

        private void SaveOfferedSubject()
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("INSERT INTO [sub].[OfferedSubject]");
            stringBuilder.AppendLine("           (");
            stringBuilder.AppendLine("           [SubjectID]");
            stringBuilder.AppendLine("           ,[ClassType]");
            stringBuilder.AppendLine("           ,[Capacity]");
            stringBuilder.AppendLine("           ,[DateOffered]");
            stringBuilder.AppendLine("           ,[SubjectRate]");
            stringBuilder.AppendLine("           ,[SchoolYear]");
            stringBuilder.AppendLine("           ,[Semester]");
            stringBuilder.AppendLine("           ,[CourseCode]");
            stringBuilder.AppendLine("           ,[SubjectLevel]");
            stringBuilder.AppendLine("           )");
            stringBuilder.AppendLine("     VALUES");
            stringBuilder.AppendLine("           (");
            stringBuilder.AppendLine("           @SubjectID");
            stringBuilder.AppendLine("           ,@ClassType");
            stringBuilder.AppendLine("           ,@Capacity");
            stringBuilder.AppendLine("           ,@DateOffered");
            stringBuilder.AppendLine("           ,@SubjectRate");
            stringBuilder.AppendLine("           ,@SchoolYear");
            stringBuilder.AppendLine("           ,@Semester");
            stringBuilder.AppendLine("           ,@CourseCode");
            stringBuilder.AppendLine("           ,@SubjectLevel");
            stringBuilder.AppendLine("           )");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@SubjectID", SubID);
                    command.Parameters.AddWithValue("@ClassType", cbClassType.Text);
                    command.Parameters.AddWithValue("@Capacity", cbCapacity.Text);
                    command.Parameters.AddWithValue("@DateOffered", DateTime.Now);
                    command.Parameters.AddWithValue("@SubjectRate", tbSubjectRate.Text);
                    command.Parameters.AddWithValue("@SchoolYear", cbSchoolYear.Text);
                    command.Parameters.AddWithValue("@CourseCode", tbCourseCode2.Text);
                    command.Parameters.AddWithValue("@SubjectLevel", cbSubjectLevel.Text);



                    if (cbSemester.Text == "1st Semester")
                    {
                        command.Parameters.AddWithValue("@Semester", 0);
                    }
                    else if (cbSemester.Text == "2nd Semester")
                    {
                        command.Parameters.AddWithValue("@Semester", 1);
                    }
                    else if (cbSemester.Text == "Summer")
                    {
                        command.Parameters.AddWithValue("@Semester", 2);
                    }


                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Subject Offered!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void PopulateComboBox()
        {
            using (SqlConnection connection = new SqlConnection(GlobalSetting.ConnectionString))
            {
                string query = "SELECT RoomName FROM [dbo].[Room]";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            cbRoom.Items.Add(reader["RoomName"].ToString());
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }


     
        private void PopulateSectionComboBox()
        {
            using (SqlConnection connection = new SqlConnection(GlobalSetting.ConnectionString))
            {
                string query = "SELECT SectionName FROM [dbo].[Section]";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            cbSection.Items.Add(reader["SectionName"].ToString());
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }



   

        private void PopulateInstructorComboBox()
        {
            using (SqlConnection connection = new SqlConnection(GlobalSetting.ConnectionString))
            {
                string query = "SELECT Name FROM [stud].[UserAccount] WHERE UserType = 'Instructor'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            cbInstructor.Items.Add(reader["Name"].ToString());
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }


      

        private void SaveSubjectSchedule()
        {


            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("INSERT INTO [sub].[SubjectSchedule]");
            stringBuilder.AppendLine("           (");
            stringBuilder.AppendLine("           [SubjectID]");
            stringBuilder.AppendLine("           ,[SubjectTimeStart]");
            stringBuilder.AppendLine("           ,[SubjectTimeEnd]");
            stringBuilder.AppendLine("           ,[SubjectDay]");
            stringBuilder.AppendLine("           ,[SchedMonday]");
            stringBuilder.AppendLine("           ,[SchedTuesday]");
            stringBuilder.AppendLine("           ,[SchedWednesday]");
            stringBuilder.AppendLine("           ,[SchedThursday]");
            stringBuilder.AppendLine("           ,[SchedFriday]");
            stringBuilder.AppendLine("           ,[SchedSaturday]");
            stringBuilder.AppendLine("           ,[SchedSunday]");
            stringBuilder.AppendLine("           ,[RoomID]");
            stringBuilder.AppendLine("           ,[InstructorID]");
            stringBuilder.AppendLine("           ,[CourseCode]");
            stringBuilder.AppendLine("           ,[SubjectLevel]");
            stringBuilder.AppendLine("           ,[SectionID]");
            stringBuilder.AppendLine("           ,[DateAdded]");
            stringBuilder.AppendLine("           ,[SchoolYear]");
            stringBuilder.AppendLine("           ,[Semester]");
            stringBuilder.AppendLine("           )");
            stringBuilder.AppendLine("     VALUES");
            stringBuilder.AppendLine("           (");
            stringBuilder.AppendLine("           @SubjectID");
            stringBuilder.AppendLine("           ,@SubjectTimeStart");
            stringBuilder.AppendLine("           ,@SubjectTimeEnd");
            stringBuilder.AppendLine("           ,@SubjectDay");
            stringBuilder.AppendLine("           ,@SchedMonday");
            stringBuilder.AppendLine("           ,@SchedTuesday");
            stringBuilder.AppendLine("           ,@SchedWednesday");
            stringBuilder.AppendLine("           ,@SchedThursday");
            stringBuilder.AppendLine("           ,@SchedFriday");
            stringBuilder.AppendLine("           ,@SchedSaturday");
            stringBuilder.AppendLine("           ,@SchedSunday");
            stringBuilder.AppendLine("           ,@RoomID");
            stringBuilder.AppendLine("           ,@InstructorID");
            stringBuilder.AppendLine("           ,@CourseCode");
            stringBuilder.AppendLine("           ,@SubjectLevel");
            stringBuilder.AppendLine("           ,@SectionID");
            stringBuilder.AppendLine("           ,@DateAdded");
            stringBuilder.AppendLine("           ,@SchoolYear");
            stringBuilder.AppendLine("           ,@Semester");
            stringBuilder.AppendLine("           )");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@SubjectID", SubID);
                    command.Parameters.AddWithValue("@SubjectTimeStart", dtpTimeStart.Value);
                    command.Parameters.AddWithValue("@SubjectTimeEnd", dtpTimeEnd.Value);
                    command.Parameters.AddWithValue("@SubjectDay", tbDay.Text);
                    command.Parameters.AddWithValue("@RoomID", RoomID);
                    command.Parameters.AddWithValue("@InstructorID", InstructorID);
                    command.Parameters.AddWithValue("@CourseCode", tbCourseCode2.Text);
                    command.Parameters.AddWithValue("@SubjectLevel", cbSubjectLevel.Text);
                    command.Parameters.AddWithValue("@SectionID", SectionID);
                    command.Parameters.AddWithValue("@DateAdded", DateTime.Now);
                    command.Parameters.AddWithValue("@SchoolYear", cbSchoolYear.Text);
                    

                    if (cbMonday.Checked == true)
                    {
                        command.Parameters.AddWithValue("@SchedMonday", 1);
                    }
                    else if (cbMonday.Checked == false)
                    {
                        command.Parameters.AddWithValue("@SchedMonday", 0);
                    }
                 
                    if (cbTue.Checked == true)
                    {
                        command.Parameters.AddWithValue("@SchedTuesday", 1);
                    }
                    else if (cbTue.Checked == false)
                    {
                        command.Parameters.AddWithValue("@SchedTuesday", 0);
                    }
                   
                    if (cbWed.Checked == true)
                    {
                        command.Parameters.AddWithValue("@SchedWednesday", 1);
                    }
                    else if (cbWed.Checked == false)
                    {
                        command.Parameters.AddWithValue("@SchedWednesday", 0);
                    }
                    
                    if (cbThur.Checked == true)
                    {
                        command.Parameters.AddWithValue("@SchedThursday", 1);
                    }
                    else if (cbThur.Checked == false)
                    {
                        command.Parameters.AddWithValue("@SchedThursday", 0);
                    }
                    
                    if (cbFri.Checked == true)
                    {
                        command.Parameters.AddWithValue("@SchedFriday", 1);
                    }
                    else if (cbFri.Checked == false)
                    {
                        command.Parameters.AddWithValue("@SchedFriday", 0);
                    }
                    
                    if (cbSat.Checked == true)
                    {
                        command.Parameters.AddWithValue("@SchedSaturday", 1);
                    }
                    else if (cbSat.Checked == false)
                    {
                        command.Parameters.AddWithValue("@SchedSaturday", 0);
                    }
                    
                    if (cbSun.Checked == true)
                    {
                        command.Parameters.AddWithValue("@SchedSunday", 1);
                    }
                    else if (cbSun.Checked == false)
                    {
                        command.Parameters.AddWithValue("@SchedSunday", 0);
                    }

                    if (cbSemester.Text == "1st Semester")
                    {
                        command.Parameters.AddWithValue("@Semester", 0);
                    }
                    else if (cbSemester.Text == "2nd Semester")
                    {
                        command.Parameters.AddWithValue("@Semester", 1);
                    }
                    else if (cbSemester.Text == "Summer")
                    {
                        command.Parameters.AddWithValue("@Semester", 2);
                    }


                    command.ExecuteNonQuery();
                }

                
            }

        }

        public void ClearFields()
        {
            dtpTimeStart.Value = DateTime.Now;
            dtpTimeEnd.Value = DateTime.Now;
            cbCourseCode.Text = "";


        }

        private string GetRoomID(string roomName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GlobalSetting.ConnectionString))
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("SELECT RoomID, Capacity FROM [dbo].[Room] WHERE RoomName=@RoomName; ");

                    SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection);

                    command.Parameters.AddWithValue("@RoomName", roomName);
                    connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        RoomID = Convert.ToInt32(reader["RoomID"].ToString());
                        cbCapacity.Text = reader["Capacity"].ToString();

                    }
                }

            }
        }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:" + ex.Message);
            }

            return roomName;
        }

        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRoomID(cbRoom.Text); 
        }

        private string GetInstructorID(string instructorName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GlobalSetting.ConnectionString))
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("SELECT UserID FROM [stud].[UserAccount] WHERE UserType='Instructor' AND Name=@Name; ");

                    SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection);

                    command.Parameters.AddWithValue("@Name", instructorName);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            InstructorID = Convert.ToInt32(reader["UserID"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:" + ex.Message);
            }

            return instructorName;
        }

        private string GetSectionID(string section)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GlobalSetting.ConnectionString))
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("SELECT SectionID FROM [dbo].[Section] WHERE SectionName=@SectionName; ");

                    SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection);

                    command.Parameters.AddWithValue("@SectionName", section);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            SectionID = Convert.ToInt32(reader["SectionID"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:" + ex.Message);
            }

            return section;
        }

        private void cbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSectionID(cbSection.Text);
        }

        

      
    }
}
