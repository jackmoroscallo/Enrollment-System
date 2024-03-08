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
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace Enrollment_System
{
    public partial class Student : Form
    {

        private readonly ErrorProvider errorProvider = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };

        public Student()
        {
            InitializeComponent();


        }


        private void Student_Load(object sender, EventArgs e)
        {
            LoadData();
            getCourses();

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

            // Read-Only Code
            tbStudentID.ReadOnly = true;
            tbLastName.ReadOnly = true;
            tbFirstName.ReadOnly = true;
            tbMiddleName.ReadOnly = true;
            cbCourseCode.Enabled = false; // Use Enabled property instead of ReadOnly
            cbYearLevel.Enabled = false;  // Use Enabled property instead of ReadOnly
            cbStatus.Enabled = false;     // Use Enabled property instead of ReadOnly
            cbGender.Enabled = false;     // Use Enabled property instead of ReadOnly
            dtpBirthDate.Enabled = false; // DateTimePicker doesn't have ReadOnly property, use Enabled instead
            tbAddress.ReadOnly = true;
            tbContactNumber.ReadOnly = true;
            tbEmail.ReadOnly = true;

        }

        private void LoadData()
        {
            string connectionString = GlobalSetting.ConnectionString;

            string query = "SELECT [StudentID],[LastName],[FirstName],[MiddleName],[StudentCourse],[YearLevel],[StudentStatus]\r\n      ,[Gender]\r\n      ,[Birthdate]\r\n      ,[Address]\r\n      ,[ContactNumber]\r\n      ,[Email]\r\n  FROM [IT3232Moroscallo].[stud].[Student]\r\n";

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;


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

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (!ValidateAllControls(panel1))
            {
                MessageBox.Show("Validation failed. Please correct the errors.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            SaveStudent();



        }

        private void SaveStudent()
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("INSERT INTO [stud].[Student]");
            stringBuilder.AppendLine("           (");
            stringBuilder.AppendLine("           [StudentID]");
            stringBuilder.AppendLine("           ,[LastName]");
            stringBuilder.AppendLine("           ,[FirstName]");
            stringBuilder.AppendLine("           ,[MiddleName]");
            stringBuilder.AppendLine("           ,[StudentCourse]");
            stringBuilder.AppendLine("           ,[YearLevel]");
            stringBuilder.AppendLine("           ,[StudentStatus]");
            stringBuilder.AppendLine("           ,[Gender]");
            stringBuilder.AppendLine("           ,[Birthdate]");
            stringBuilder.AppendLine("           ,[Address]");
            stringBuilder.AppendLine("           ,[ContactNumber]");
            stringBuilder.AppendLine("           ,[Email]");
            stringBuilder.AppendLine("           )");
            stringBuilder.AppendLine("     VALUES");
            stringBuilder.AppendLine("           (");
            stringBuilder.AppendLine("           @StudentID");
            stringBuilder.AppendLine("           ,@LastName");
            stringBuilder.AppendLine("           ,@FirstName");
            stringBuilder.AppendLine("           ,@MiddleName");
            stringBuilder.AppendLine("           ,@StudentCourse");
            stringBuilder.AppendLine("           ,@YearLevel");
            stringBuilder.AppendLine("           ,@StudentStatus");
            stringBuilder.AppendLine("           ,@Gender");
            stringBuilder.AppendLine("           ,@Birthdate");
            stringBuilder.AppendLine("           ,@Address");
            stringBuilder.AppendLine("           ,@ContactNumber");
            stringBuilder.AppendLine("           ,@Email");
            stringBuilder.AppendLine("           )");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@StudentID", tbStudentID.Text);
                    command.Parameters.AddWithValue("@LastName", tbLastName.Text);
                    command.Parameters.AddWithValue("@FirstName", tbFirstName.Text);
                    command.Parameters.AddWithValue("@MiddleName", tbMiddleName.Text);
                    command.Parameters.AddWithValue("@StudentCourse", cbCourseCode.Text);
                    command.Parameters.AddWithValue("@YearLevel", cbYearLevel.Text);
                    command.Parameters.AddWithValue("@StudentStatus", cbStatus.Text);
                    command.Parameters.AddWithValue("@Gender", cbGender.Text);
                    command.Parameters.AddWithValue("@Birthdate", dtpBirthDate.Value);
                    command.Parameters.AddWithValue("@Address", tbAddress.Text);
                    command.Parameters.AddWithValue("@ContactNumber", tbContactNumber.Text);
                    command.Parameters.AddWithValue("@Email", tbEmail.Text);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Record Added!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();

            ClearFields();


        }
        private void btUpdate_Click(object sender, EventArgs e)
        {

            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("UPDATE [stud].[Student] SET ");
            stringBuilder.AppendLine("           [LastName] = @LastName");
            stringBuilder.AppendLine("           ,[FirstName] = @FirstName");
            stringBuilder.AppendLine("           ,[MiddleName] = @MiddleName");
            stringBuilder.AppendLine("           ,[StudentCourse] = @StudentCourse");
            stringBuilder.AppendLine("           ,[YearLevel] = @YearLevel");
            stringBuilder.AppendLine("           ,[StudentStatus] = @StudentStatus");
            stringBuilder.AppendLine("           ,[Gender] = @Gender");
            stringBuilder.AppendLine("           ,[Birthdate] = @Birthdate");
            stringBuilder.AppendLine("           ,[Address] = @Address");
            stringBuilder.AppendLine("           ,[ContactNumber] = @ContactNumber");
            stringBuilder.AppendLine("           ,[Email] = @Email");
            stringBuilder.AppendLine("WHERE StudentID = @StudentID");

            SqlConnection connection = new SqlConnection(connectionString);
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("@LastName", tbLastName.Text);
                    command.Parameters.AddWithValue("@FirstName", tbFirstName.Text);
                    command.Parameters.AddWithValue("@MiddleName", tbMiddleName.Text);
                    command.Parameters.AddWithValue("@StudentCourse", cbCourseCode.Text);
                    command.Parameters.AddWithValue("@YearLevel", cbYearLevel.Text);
                    command.Parameters.AddWithValue("@StudentStatus", cbStatus.Text);
                    command.Parameters.AddWithValue("@Gender", cbGender.Text);
                    command.Parameters.AddWithValue("@Birthdate", dtpBirthDate.Value);
                    command.Parameters.AddWithValue("@Address", tbAddress.Text);
                    command.Parameters.AddWithValue("@ContactNumber", tbContactNumber.Text);
                    command.Parameters.AddWithValue("@Email", tbEmail.Text);
                    command.Parameters.AddWithValue("@StudentID", tbStudentID.Text);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Record Updated!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();

            ClearFields();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                tbStudentID.Text = selectedRow.Cells[0].Value.ToString();
                tbLastName.Text = selectedRow.Cells[1].Value.ToString();
                tbFirstName.Text = selectedRow.Cells[2].Value.ToString();
                tbMiddleName.Text = selectedRow.Cells[3].Value.ToString();
                cbCourseCode.Text = selectedRow.Cells[4].Value.ToString();
                cbYearLevel.Text = selectedRow.Cells[5].Value.ToString();
                cbStatus.Text = selectedRow.Cells[6].Value.ToString();
                cbGender.Text = selectedRow.Cells[7].Value.ToString();
                dtpBirthDate.Value = Convert.ToDateTime(selectedRow.Cells[8].Value);
                tbAddress.Text = selectedRow.Cells[9].Value.ToString();
                tbContactNumber.Text = selectedRow.Cells[10].Value.ToString();
                tbEmail.Text = selectedRow.Cells[11].Value.ToString();

                tbStudentID.ReadOnly = true;
            }
            catch
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            tbStudentID.ReadOnly = false;

            tbStudentID.Text = "";
            tbLastName.Text = "";
            tbFirstName.Text = "";
            tbMiddleName.Text = "";
            cbCourseCode.Text = "";
            cbYearLevel.Text = "";
            cbStatus.Text = "";
            cbGender.Text = "";
            dtpBirthDate.Value = DateTime.Now;
            tbAddress.Text = "";
            tbContactNumber.Text = "";
            tbEmail.Text = "";
        }


        private void Student_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Exit the application
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbStudentID.ReadOnly = false;
            tbLastName.ReadOnly = false;
            tbFirstName.ReadOnly = false;
            tbMiddleName.ReadOnly = false;
            cbCourseCode.Enabled = true; // Use Enabled property instead of ReadOnly
            cbYearLevel.Enabled = true;  // Use Enabled property instead of ReadOnly
            cbStatus.Enabled = true;     // Use Enabled property instead of ReadOnly
            cbGender.Enabled = true;     // Use Enabled property instead of ReadOnly
            dtpBirthDate.Enabled = true; // DateTimePicker doesn't have ReadOnly property, use Enabled instead
            tbAddress.ReadOnly = false;
            tbContactNumber.ReadOnly = false;
            tbEmail.ReadOnly = false;
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

   

        private void DeleteStudentByIDNumber(string paramStudentID)
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("DELETE FROM [stud].[Student]  ");
            stringBuilder.AppendLine("WHERE StudentID = @StudentID");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@StudentID", paramStudentID);
                    command.ExecuteNonQuery();
                }
            }



            LoadData();
        }

        private void DeleteRecord() 
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                string ID = dataGridView1.Rows[selectedIndex].Cells["StudentID"].Value.ToString();
                DeleteStudentByIDNumber(ID);
                MessageBox.Show("Record Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btDelete_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                DeleteRecord();

            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //// Get the search keyword from the TextBox
            //string searchKeyword = tbSearch.Text;

            //// Create a StringBuilder to build the dynamic SQL query
            //StringBuilder queryBuilder = new StringBuilder();

            //// Start building the SELECT query
            //queryBuilder.Append("SELECT * FROM [stud].[Student]");
            //queryBuilder.Append("WHERE ");

            //// Add conditions for searching (replace "ColumnName" with your actual column name)
            //queryBuilder.Append("LastName LIKE @SearchKeyword");

            //// Create a DataTable to hold the search results
            //DataTable dataTable = new DataTable();

            //// Create a SqlConnection and a SqlCommand
            //using (SqlConnection connection = new SqlConnection(GlobalSetting.ConnectionString))
            //{
            //    // Open the connection
            //    connection.Open();

            //    // Create a SqlCommand with the dynamic query
            //    using (SqlCommand command = new SqlCommand(queryBuilder.ToString(), connection))
            //    {
            //        // Add parameters to the SqlCommand
            //        command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");

            //        // Create a SqlDataAdapter to fill the DataTable
            //        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            //        {
            //            // Fill the DataTable with the results
            //            adapter.Fill(dataTable);
            //        }
            //    }
            //}

            //// Bind the DataTable to the DataGridView
            //dataGridView1.DataSource = dataTable;



            string searchKeyword = tbSearch.Text;

            using (SqlConnection connection = new SqlConnection(GlobalSetting.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    // Get column names
                    DataTable schemaTable = connection.GetSchema("Columns", new[] { null, null, "Student", null });

                    // Constructing the dynamic SQL query
                    command.CommandText = $"SELECT * FROM [stud].[Student] WHERE ";

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
                    dataGridView1.DataSource = searchResults;
                }


            }
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
