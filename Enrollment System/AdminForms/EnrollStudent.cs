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

namespace Enrollment_System.AdminForms
{
    public partial class EnrollStudent : Form
    {
        private DataTable selectedSubjectsTable;

        string SchoolYear {  get; set; }
        int Semester {  get; set; }

        public EnrollStudent()
        {
            InitializeComponent();
            selectedSubjectsTable = new DataTable("SelectedSubjects");
            selectedSubjectsTable.Columns.Add("RecordNumber", typeof(int));
            selectedSubjectsTable.Columns.Add("SubjectID", typeof(string));
            selectedSubjectsTable.Columns.Add("SubjectCode", typeof(string));
            selectedSubjectsTable.Columns.Add("SubjectDescription", typeof(string));
            selectedSubjectsTable.Columns.Add("Units", typeof(string));
            selectedSubjectsTable.Columns.Add("Type", typeof(string));
            selectedSubjectsTable.Columns.Add("SubjectHours", typeof(string));

            dataGridViewSelectedSubjects.DataSource = selectedSubjectsTable;

        }

        private void EnrollStudent_Load(object sender, EventArgs e)
        {
            GetCurrentSchoolYearAndSemester();
            LoadData(tbCourse.Text, SchoolYear, Semester);
            string TermDesc = "";

            if (Semester == 1)
            {
                TermDesc = "1st Semester";
            }
            else if (Semester == 2)
            {
                TermDesc = "2nd Semester";
            }
            else if (Semester == 3)
            {
                TermDesc = "Summer";
            }


            this.Text = "Enroll Student for S.Y. " + SchoolYear + " " +  TermDesc ;
           
        }

        private void GetCurrentSchoolYearAndSemester()
        {
            try
            {
                string connectionString = GlobalSetting.ConnectionString;

                // Construct your SQL query dynamically using StringBuilder
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("SELECT [SchoolYear]");
                stringBuilder.Append("      ,[Term] ");
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
                          SchoolYear= reader.GetString(0);
                          Semester = reader.GetInt32(1);
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

        private void LoadData(string pCourseCode, string pSchoolYear, int pSemester)
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
            stringBuilder.AppendLine("WHERE os.CourseCode = @CourseCode AND os.SchoolYear = @SchoolYear AND os.Semester = @Semester");

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection);
                command.Parameters.AddWithValue("@CourseCode", pCourseCode);
                command.Parameters.AddWithValue("@SchoolYear", pSchoolYear);
                command.Parameters.AddWithValue("@Semester", pSemester);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                dgOfferedSub.DataSource = dataTable;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (dgOfferedSub.CurrentRow != null)
            {
                DataRow selectedRow = ((DataRowView)dgOfferedSub.CurrentRow.DataBoundItem).Row;
                int subjectID = selectedRow.Field<int>("RecordNumber");

                DataRow duplicateRow = selectedSubjectsTable.AsEnumerable().FirstOrDefault(r => r.Field<int>("RecordNumber") == subjectID);

                if (duplicateRow == null)
                {
                    selectedSubjectsTable.ImportRow(selectedRow);
                }
                else
                {
                    MessageBox.Show("This subject is already selected.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridViewSelectedSubjects.CurrentRow != null)
            {
                DataRow selectedRow = ((DataRowView)dataGridViewSelectedSubjects.CurrentRow.DataBoundItem).Row;
                DataRow rowToDelete = selectedSubjectsTable.AsEnumerable().FirstOrDefault(r => r.ItemArray.SequenceEqual(selectedRow.ItemArray));
                if (rowToDelete != null)
                {
                    selectedSubjectsTable.Rows.Remove(rowToDelete);
                }
            }

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            SaveStudentSubject();
            SaveStudentEnrollment();

            this.Close();
        }

        private void SaveStudentSubject()
        {

            if (selectedSubjectsTable.Rows.Count > 0)
            {
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("INSERT INTO [stud].[StudentSubject] (StudentID, SubjectID, SubjectStatus, SchoolYear, Semester) ");
                queryBuilder.Append("VALUES (@StudentID, @SubjectID, @SubjectStatus, @SchoolYear, @Semester)");

                using (SqlConnection conn = new SqlConnection(GlobalSetting.ConnectionString))
                {
                    conn.Open();
                    foreach (DataRow row in selectedSubjectsTable.Rows)
                    {
                        int subjectID = Convert.ToInt32(row["SubjectID"].ToString());

       

                        using (SqlCommand cmd = new SqlCommand(queryBuilder.ToString(), conn))
                        {
                            cmd.Parameters.AddWithValue("@StudentID", tbIDNumber.Text);
                            cmd.Parameters.AddWithValue("@SubjectID", subjectID);
                            cmd.Parameters.AddWithValue("@SubjectStatus", "Pending");
                            cmd.Parameters.AddWithValue("@SchoolYear", SchoolYear);
                            cmd.Parameters.AddWithValue("@Semester", Semester);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Selected subjects saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No subjects selected to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveStudentEnrollment()
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append("INSERT INTO [dbo].[Enrollment] (StudentID, CourseCode, YearLevel, SchoolYear, Term, EnrollmentStatus) ");
            queryBuilder.Append("VALUES (@StudentID, @CourseCode, @YearLevel, @SchoolYear, @Term, @EnrollmentStatus)");


            using (SqlConnection conn = new SqlConnection(GlobalSetting.ConnectionString))
                {
                    conn.Open();

      
                        using (SqlCommand cmd = new SqlCommand(queryBuilder.ToString(), conn))
                        {
                            cmd.Parameters.AddWithValue("@StudentID", tbIDNumber.Text);
                            cmd.Parameters.AddWithValue("@CourseCode", tbCourse.Text);
                            cmd.Parameters.AddWithValue("@YearLevel", tbYearLevel.Text);
                            cmd.Parameters.AddWithValue("@SchoolYear", SchoolYear);
                            cmd.Parameters.AddWithValue("@Term", Semester);
                            cmd.Parameters.AddWithValue("@EnrollmentStatus", "Pending-Registrar");
                            cmd.ExecuteNonQuery();
                        }
                 }
              
         
        }
    }
}
