using Enrollment_System.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System
{
    public partial class Subject : Form
    {
        public Subject()
        {
            InitializeComponent();
        }

        private void btnMainMenu2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void Subject_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Exit the application
                Application.Exit();
            }
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            cbCourseCode.Enabled = true;
            tbSubjectCode.ReadOnly = false;
            tbSubjectDescription.ReadOnly = false;
            tbUnits.ReadOnly = false;
            cbType.Enabled = true;
            tbSubjectRate.ReadOnly = false;
            tbSearch.ReadOnly = false;
        }

        private void Subject_Load(object sender, EventArgs e)
        {
            LoadData();
            getCourses();

            cbCourseCode.Enabled = false;
            tbSubjectCode.ReadOnly = true;
            tbSubjectDescription.ReadOnly = true;
            tbUnits.ReadOnly = true;
            cbType.Enabled = false;
            tbSubjectRate.ReadOnly = true;
            tbSearch.ReadOnly = true;
        }

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
            stringBuilder.AppendLine("      ,[SubjectRate]");
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

        private void btnSaveSubject_Click(object sender, EventArgs e)
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("INSERT INTO [sub].[Subject]");
            stringBuilder.AppendLine("           (");
            stringBuilder.AppendLine("           [CourseCode]");
            stringBuilder.AppendLine("           ,[SubjectCode]");
            stringBuilder.AppendLine("           ,[SubjectDescription]");
            stringBuilder.AppendLine("           ,[Units]");
            stringBuilder.AppendLine("           ,[Type]");
            stringBuilder.AppendLine("           ,[SubjectRate]");
            stringBuilder.AppendLine("           )");
            stringBuilder.AppendLine("     VALUES");
            stringBuilder.AppendLine("           (");
            stringBuilder.AppendLine("           @CourseCode");
            stringBuilder.AppendLine("           ,@SubjectCode");
            stringBuilder.AppendLine("           ,@SubjectDescription");
            stringBuilder.AppendLine("           ,@Units");
            stringBuilder.AppendLine("           ,@Type");
            stringBuilder.AppendLine("           ,@SubjectRate");
            stringBuilder.AppendLine("           )");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@CourseCode", cbCourseCode.Text);
                    command.Parameters.AddWithValue("@SubjectCode", tbSubjectCode.Text);
                    command.Parameters.AddWithValue("@SubjectDescription", tbSubjectDescription.Text);
                    command.Parameters.AddWithValue("@Units", tbUnits.Text);
                    command.Parameters.AddWithValue("@Type", cbType.Text);
                    command.Parameters.AddWithValue("@SubjectRate", tbSubjectRate.Text);



                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Record Added!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("UPDATE [sub].[Subject] SET ");
            stringBuilder.AppendLine("           [CourseCode] = @CourseCode");
            stringBuilder.AppendLine("           ,[SubjectCode] = @SubjectCode");
            stringBuilder.AppendLine("           ,[SubjectDescription] = @SubjectDescription");
            stringBuilder.AppendLine("           ,[Units] = @Units");
            stringBuilder.AppendLine("           ,[Type] = @Type");
            stringBuilder.AppendLine("           ,[SubjectRate] = @SubjectRate");
            stringBuilder.AppendLine("WHERE SubjectID = @SubjectID");

            SqlConnection connection = new SqlConnection(connectionString);
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("@CourseCode", cbCourseCode.Text);
                    command.Parameters.AddWithValue("@FirstName", tbSubjectCode.Text);
                    command.Parameters.AddWithValue("@MiddleName", tbSubjectDescription.Text);
                    command.Parameters.AddWithValue("@StudentCourse", tbUnits.Text);
                    command.Parameters.AddWithValue("@YearLevel", cbType.Text);
                    command.Parameters.AddWithValue("@StudentStatus", tbSubjectRate.Text);
                    

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Record Updated!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();

            ClearFields();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = tbSearch.Text;

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

        private void DeleteSubjectBySubjectID(string paramSubjectID)
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("DELETE FROM [sub].[Subject]  ");
            stringBuilder.AppendLine("WHERE SubjectID = @SubjectID");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@SubjectID", paramSubjectID);
                    command.ExecuteNonQuery();
                }
            }



            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgSubject.SelectedRows.Count > 0)
            {
                int selectedIndex = dgSubject.SelectedRows[0].Index;

                string ID = dgSubject.Rows[selectedIndex].Cells["SubjectID"].Value.ToString();
                DeleteSubjectBySubjectID(ID);
            }

            MessageBox.Show("Record Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {


            cbCourseCode.Text = "";
            tbSubjectCode.Text = "";
            tbSubjectDescription.Text = "";
            tbUnits.Text = "";
            cbType.Text = "";
            tbSubjectRate.Text = "";

        }

        private void dgSubject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dgSubject.Rows[e.RowIndex];

                cbCourseCode.Text = selectedRow.Cells[0].Value.ToString();
                tbSubjectCode.Text = selectedRow.Cells[1].Value.ToString();
                tbSubjectDescription.Text = selectedRow.Cells[2].Value.ToString();
                tbUnits.Text = selectedRow.Cells[3].Value.ToString();
                cbType.Text = selectedRow.Cells[4].Value.ToString();
                tbSubjectRate.Text = selectedRow.Cells[5].Value.ToString();
            }
            catch
            {

            }
        }
    }
}
