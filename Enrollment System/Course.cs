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
    public partial class Course : Form
    {
        private readonly ErrorProvider errorProvider = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
        public Course()
        {
            InitializeComponent();
        }

        int RecNumber { get; set; }

        private void Course_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Exit the application
                Application.Exit();
            }
        }

        private void Course_Load(object sender, EventArgs e)
        {
            LoadData();

            // Get the size of the screen
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Get the size of the form
            int formWidth = this.Width;
            int formHeight = this.Height;

            // Calculate the position of the form
            int formX = (screenWidth - formWidth) / 2;
            int formY = (screenHeight - formHeight) / 2;

            // Set the position of the form
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(formX, formY);

            tbCourseCode.ReadOnly = true;
            tbCourseDescription.ReadOnly = true;
            cbCourseStatus.Enabled = false;
        }

        private void LoadData()
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SELECT [RecordNumber]");
            stringBuilder.AppendLine("      ,[CourseCode]");
            stringBuilder.AppendLine("      ,[CourseDescription]");
            stringBuilder.AppendLine("      ,CASE WHEN [CourseStatus] = 1 THEN 'Active'");
            stringBuilder.AppendLine("			WHEN [CourseStatus] = 0 THEN 'Inactive'");
            stringBuilder.AppendLine("			END AS CourseStatus");
            stringBuilder.AppendLine("  FROM [IT3232Moroscallo].[dbo].[Course]");

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(stringBuilder.ToString(), connection);

                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                dataGridView2.DataSource = dataTable;
                dataGridView2.Columns["RecordNumber"].Visible = false;

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

        private void btnMainMenu2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            tbCourseCode.ReadOnly = false;
            tbCourseDescription.ReadOnly = false;
            cbCourseStatus.Enabled = true;
        }

        private void btnSaveCourse_Click(object sender, EventArgs e)
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("INSERT INTO [dbo].[Course]");
            stringBuilder.AppendLine("           (");
            stringBuilder.AppendLine("           [CourseCode]");
            stringBuilder.AppendLine("           ,[CourseDescription]");
            stringBuilder.AppendLine("           ,[CourseStatus]");
            stringBuilder.AppendLine("           )");
            stringBuilder.AppendLine("     VALUES");
            stringBuilder.AppendLine("           (");
            stringBuilder.AppendLine("           @CourseCode");
            stringBuilder.AppendLine("           ,@CourseDescription");
            stringBuilder.AppendLine("           ,@CourseStatus");
            stringBuilder.AppendLine("           )");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@CourseCode", tbCourseCode.Text);
                    command.Parameters.AddWithValue("@CourseDescription", tbCourseDescription.Text);
                    

                    if (cbCourseStatus.Text == "Active")
                    {
                        command.Parameters.AddWithValue("@CourseStatus", 1);
                    }
                    else if (cbCourseStatus.Text == "Inactive")
                    {
                        command.Parameters.AddWithValue("@CourseStatus", 0);
                    }

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Record Added!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();



        }

        private void btnClearCourse_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {


            tbCourseCode.Text = "";
            tbCourseDescription.Text = "";
            cbCourseStatus.Text = "";

        }

        private void btnUpdateCourse_Click(object sender, EventArgs e)
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("UPDATE [dbo].[Course] SET ");
            stringBuilder.AppendLine("           [CourseCode] = @CourseCode");
            stringBuilder.AppendLine("           ,[CourseDescription] = @CourseDescription");
            stringBuilder.AppendLine("           ,[CourseStatus] = @CourseStatus");
            stringBuilder.AppendLine("WHERE RecordNumber = @RecordNumber");

            SqlConnection connection = new SqlConnection(connectionString);
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("@CourseCode", tbCourseCode.Text);
                    command.Parameters.AddWithValue("@CourseDescription", tbCourseDescription.Text);
                    if (cbCourseStatus.Text == "Active")
                    {
                        command.Parameters.AddWithValue("@CourseStatus", 1);
                    }
                    else if (cbCourseStatus.Text == "Inactive")
                    {
                        command.Parameters.AddWithValue("@CourseStatus", 0);
                    }
                    command.Parameters.AddWithValue("@RecordNumber", RecNumber);

                    command.ExecuteNonQuery();
                }

                
            }

            MessageBox.Show("Record Updated!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();

            ClearFields();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];

                RecNumber = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                tbCourseCode.Text = selectedRow.Cells[1].Value.ToString();
                tbCourseDescription.Text = selectedRow.Cells[2].Value.ToString();
                cbCourseStatus.Text = selectedRow.Cells[3].Value.ToString();



            }
            catch
            {

            }
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
                    DataTable schemaTable = connection.GetSchema("Columns", new[] { null, null, "Course", null });

                    // Constructing the dynamic SQL query
                    command.CommandText = $"SELECT * FROM [dbo].[Course] WHERE ";

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
                    dataGridView2.DataSource = searchResults;
                }


            }
        }

        private void DeleteCourseByRecordNumber(string paramRecordNumber)
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("DELETE FROM [dbo].[Course]  ");
            stringBuilder.AppendLine("WHERE RecordNumber = @RecordNumber");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@RecordNumber", paramRecordNumber);
                    command.ExecuteNonQuery();
                }
            }



            LoadData();
        }


        private void DeleteRecord() 
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView2.SelectedRows[0].Index;

                string ID = dataGridView2.Rows[selectedIndex].Cells["RecordNumber"].Value.ToString();

                DialogResult result = MessageBox.Show($"Do you want to delete?\n\n{ID}", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    DeleteCourseByRecordNumber(ID);
                    MessageBox.Show("Record Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            
                DeleteRecord();
            LoadData();

        }

        private bool ValidateAllControls(Control container)
        {
            return container.Controls.OfType<TextBox>().All(control => ValidateControl(control)) &&
                   container.Controls.OfType<ComboBox>().All(control => ValidateControl(control));
        }

        private bool ValidateControl(Control control)
        {
            if (control is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                DisplayValidationError(textBox, "Field is required.");
                return false;
            }

            if (control is ComboBox comboBox && comboBox.SelectedItem == null)
            {
                DisplayValidationError(comboBox, "Please select an option.");
                return false;
            }

            return true;
        }

        private void DisplayValidationError(Control control, string errorMessage)
        {
            errorProvider.SetError(control, errorMessage);
        }
    }
}
