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
    public partial class PendingEnrollment : Form
    {
        string SchoolYear { get; set; }
        int Semester { get; set; }

        public PendingEnrollment()
        {
            InitializeComponent();
        }

        private void btnEnrollStudent_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Enroll Student?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                UpdateEnrollmentStatus(tbIDNumber.Text);
            }
           
        }

        private void UpdateEnrollmentStatus(string pStudentID)
        {


            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("UPDATE [dbo].[Enrollment] SET ");
            stringBuilder.AppendLine("           [EnrollmentStatus] = @EnrollmentStatus");
            stringBuilder.AppendLine("WHERE StudentID = @StudentID AND SchoolYear = @SchoolYear AND Term = @Term");


            SqlConnection connection = new SqlConnection(GlobalSetting.ConnectionString);
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("@EnrollmentStatus", "Pending-Accounting");
                    command.Parameters.AddWithValue("@StudentID", pStudentID);
                    command.Parameters.AddWithValue("@SchoolYear", SchoolYear);
                    command.Parameters.AddWithValue("@Term", Semester);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Student Enrollment: Pending Accounting Office", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();



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
                stringBuilder.Append("FROM [dbo].[DefaultSchoolYearTerm]");

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
                            SchoolYear = reader.GetString(0);
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
        private void LoadData(string pStudentID, string pSchoolYear, int pSemester)
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SELECT studsub.[RecordNumber]");
            stringBuilder.AppendLine("        ,studsub.[SubjectID]");
            stringBuilder.AppendLine("        ,os.[ClassType]");
            stringBuilder.AppendLine("		  ,s.[SubjectCode]");
            stringBuilder.AppendLine("        ,s.[SubjectDescription]");
            stringBuilder.AppendLine("        ,s.[Units]");
            stringBuilder.AppendLine("        ,s.[Type]");
            stringBuilder.AppendLine("        ,s.[SubjectHours]");
            stringBuilder.AppendLine("		  ,FORMAT(ss.[SubjectTimeStart], 'hh:mm tt') AS SubjectTimeStart");
            stringBuilder.AppendLine("        ,FORMAT(ss.[SubjectTimeEnd], 'hh:mm tt') AS SubjectTimeEnd");
            stringBuilder.AppendLine("        ,ss.[SubjectDay]");
            stringBuilder.AppendLine("        ,r.[RoomName]");
            stringBuilder.AppendLine("        ,os.[SubjectRate]");
            stringBuilder.AppendLine("        ,os.[SchoolYear]");
            stringBuilder.AppendLine("        ,os.[Semester]");
            stringBuilder.AppendLine("        ,os.[CourseCode]");
            stringBuilder.AppendLine("        ,os.[SubjectLevel]");
            stringBuilder.AppendLine("        ,sec.[SectionName]");
            stringBuilder.AppendLine("		  ,ua.[Name]");
            stringBuilder.AppendLine("        ,ss.[DateAdded]");
            stringBuilder.AppendLine("        ,studsub.[SubjectStatus]");
            stringBuilder.AppendLine("FROM [IT3232Moroscallo].[stud].[StudentSubject] studsub");
            stringBuilder.AppendLine("LEFT JOIN [IT3232Moroscallo].[sub].[OfferedSubject] os ON studsub.[SubjectID] = os.[SubjectID] AND  studsub.SchoolYear = os.SchoolYear AND studsub.Semester = os.Semester ");
            stringBuilder.AppendLine("LEFT JOIN [IT3232Moroscallo].[sub].[Subject] s ON studsub.[SubjectID] = s.[SubjectID]");
            stringBuilder.AppendLine("LEFT JOIN [IT3232Moroscallo].[sub].[SubjectSchedule] ss ON studsub.[SubjectID] = ss.[SubjectID] ");
            stringBuilder.AppendLine("LEFT JOIN [IT3232Moroscallo].[dbo].[Room] r ON r.[RoomID] = ss.[RoomID]");
            stringBuilder.AppendLine("LEFT JOIN [IT3232Moroscallo].[stud].[UserAccount] ua ON ua.[UserID] = ss.[InstructorID]");
            stringBuilder.AppendLine("LEFT JOIN [IT3232Moroscallo].[dbo].[Section] sec ON sec.[SectionID] = ss.[SectionID]");
            stringBuilder.AppendLine("WHERE studsub.StudentID = @StudentID AND studsub.SchoolYear = @SchoolYear AND studsub.Semester = @Semester ");

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection);
                command.Parameters.AddWithValue("@StudentID", pStudentID);
                command.Parameters.AddWithValue("@SchoolYear", pSchoolYear);
                command.Parameters.AddWithValue("@Semester", pSemester);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                dgStudentSubjects.DataSource = dataTable;
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

        private void PendingEnrollment_Load(object sender, EventArgs e)
        {
            GetCurrentSchoolYearAndSemester();
            LoadData(tbIDNumber.Text, SchoolYear, Semester);
        }
    }
}
