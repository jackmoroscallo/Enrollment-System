using Enrollment_System.AdminForms;
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
    public partial class ViewOfferedSubjectList : Form
    {
        public ViewOfferedSubjectList()
        {
            InitializeComponent();
        }

        public int RecordNumber { get; set; }
        private void ViewOfferedSubjectList_Load(object sender, EventArgs e)
        {
            GetOfferedSubjectDetails(RecordNumber);
        }

        private int GetOfferedSubjectDetails(int pRecordNumber)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GlobalSetting.ConnectionString))
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
                    stringBuilder.AppendLine("WHERE os.RecordNumber = @RecordNumber");



                    SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection);

                    command.Parameters.AddWithValue("@RecordNumber", pRecordNumber);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tbCourseCode.Text = reader["CourseCode"].ToString();
                            tbSubjectDesc.Text = reader["SubjectDescription"].ToString();
                            tbSubjectCode.Text = reader["SubjectCode"].ToString();
                            tbUnits.Text = reader["Units"].ToString();
                            tbSubjectHours.Text = reader["SubjectHours"].ToString();
                            tbType.Text = reader["Type"].ToString();
                            dtpTimeStart.Text = reader["SubjectTimeStart"].ToString();
                            dtpTimeEnd.Text = reader["SubjectTimeEnd"].ToString();
                            tbDay.Text = reader["SubjectDay"].ToString();
                            tbClassType.Text = reader["ClassType"].ToString();
                            dtpTimeEnd.Text = reader["SubjectTimeEnd"].ToString();
                            tbSemester.Text = reader["Semester"].ToString();
                            tbCourseCode2.Text = reader["CourseCode"].ToString();
                            tbRoom.Text = reader["RoomName"].ToString();
                            tbCapacity.Text = reader["Capacity"].ToString();
                            tbInstructor.Text = reader["Name"].ToString();
                            tbSubjectRate.Text = reader["SubjectRate"].ToString();
                            tbSection.Text = reader["SectionName"].ToString();
                            tbSubjectLevel.Text = reader["SubjectLevel"].ToString();
                            tbSchoolYear.Text = reader["SchoolYear"].ToString();

                            if (tbSemester.Text == "1")
                            {
                                command.Parameters.AddWithValue("@Semester", "1st Semester");
                            }
                            else if (tbSemester.Text == "2")
                            {
                                command.Parameters.AddWithValue("@Semester", "2nd Semester");
                            }
                            else if (tbSemester.Text == "3")
                            {
                                command.Parameters.AddWithValue("@Semester", "Summer");
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:" + ex.Message);
            }

            return pRecordNumber;
        }
    }
}
