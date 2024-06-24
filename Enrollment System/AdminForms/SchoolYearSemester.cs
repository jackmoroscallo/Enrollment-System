using Enrollment_System.Modules;
using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Enrollment_System
{
    public partial class SchoolYearSemester : Form
    {
        public SchoolYearSemester()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            UpdateSchoolYearSemester();
        }

        private void UpdateSchoolYearSemester()
        {
            

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("UPDATE [dbo].[DefaultSchoolYearTerm] SET ");
            stringBuilder.AppendLine("           [SchoolYear] = @SchoolYear");
            stringBuilder.AppendLine("           ,[Term] = @Term");
            

            SqlConnection connection = new SqlConnection(GlobalSetting.ConnectionString);
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("@SchoolYear", cbSchoolYear.Text);
                
                    
                    if (cbSemester.Text == "1st Semester")
                    {
                        command.Parameters.AddWithValue("@Term", 1);
                    }
                    else if (cbSemester.Text == "2nd Semester")
                    {
                        command.Parameters.AddWithValue("@Term", 2);
                    }
                    else if (cbSemester.Text == "Summer")
                    {
                        command.Parameters.AddWithValue("@Term", 3);
                    }

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Record Updated!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();



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

        private void SchoolYearSemester_Load(object sender, EventArgs e)
        {
            FetchDataAndDisplay();
            getSchoolYear();

            cbSchoolYear.DropDownHeight = 150;
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

        private void SchoolYearSemester_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Exit the application
                this.Dispose();
            }
        }

    }
}
