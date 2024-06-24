using Enrollment_System.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
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
        string FormState = "";

        private byte[] imageData;

        private void Student_Load(object sender, EventArgs e)
        {
            DefaultReadOnlyFields();
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

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SELECT [StudentID],[LastName],[FirstName],[MiddleName],[StudentCourse],[YearLevel],[StudentStatus]");
            stringBuilder.AppendLine("      ,[Gender]");
            stringBuilder.AppendLine("      ,[Birthdate]");
            stringBuilder.AppendLine("      ,[Address]");
            stringBuilder.AppendLine("      ,[ContactNumber]");
            stringBuilder.AppendLine("      ,[Email]");
            stringBuilder.AppendLine("  FROM [IT3232Moroscallo].[stud].[Student]");

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(stringBuilder.ToString(), connection);

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

        private void DefaultReadOnlyFields()
        {
            button2.Enabled = false;
            btnModify.Enabled = false;

            tbStudentID.ReadOnly = true;
            cbCourseCode.Enabled = false;
            cbYearLevel.Enabled = false;
            cbStatus.Enabled = false;
            tbLastName.ReadOnly = true;
            tbFirstName.ReadOnly = true;
            tbMiddleName.ReadOnly = true;
            cbGender.Enabled = false;
            dtpBirthDate.Enabled = false;
            tbAddress.ReadOnly = true;
            tbContactNumber.ReadOnly = true;
            tbEmail.ReadOnly = true;
            panel1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (FormState == "Add")
            {
                if (!ValidateAllControls(panel1))
                {
                    MessageBox.Show("Validation failed. Please correct the errors.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    SaveStudent();
                    

                    MessageBox.Show("Record Added!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();

                    ClearFields();
                    DefaultReadOnlyFields();
                }
            }
            else if (FormState == "Update")
            {
                
                    UpdateButton();

                    

                    LoadData();

                    ClearFields();
                    DefaultReadOnlyFields();
                    


            }





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
            SaveStudentImage(tbStudentID.Text);
            ClearFields();


        }

        private void UpdateButton()
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
        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (tbStudentID.Text != "")
            {
                tbStudentID.ReadOnly = false;
                cbCourseCode.Enabled = true;
                cbYearLevel.Enabled = true;
                cbStatus.Enabled = true;
                tbLastName.ReadOnly = false;
                tbFirstName.ReadOnly = false;
                tbMiddleName.ReadOnly = false;
                cbGender.Enabled = true;
                dtpBirthDate.Enabled = true;
                tbAddress.Enabled = true;
                tbContactNumber.Enabled = true;
                tbEmail.Enabled = true;
                panel1.Enabled = true;

                panel1.Enabled = true;
                FormState = "Update";
                button2.Enabled = true;
            }
            else
            {
                MessageBox.Show("No Record Selected");
            }
            

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

                if (tbStudentID.Text != "")
                {
                    btnModify.Enabled = true;
                }
                RetrieveImage(tbStudentID.Text);
                
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
            picBoxStudentImage.Image = null;
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
            tbAddress.Enabled = true;
            tbAddress.ReadOnly = false;
            tbContactNumber.Enabled = true;
            tbContactNumber.ReadOnly = false;
            tbEmail.Enabled = true;
            tbEmail.ReadOnly = false;

            button2.Enabled = true;

            panel1.Enabled = true;

            FormState = "Add";
            ClearFields();
            
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Dispose();
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


                DialogResult result = MessageBox.Show($"Do you want to delete?\n\n{ID}", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    
                    DeleteStudentByIDNumber(ID);
                    MessageBox.Show("Record Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btDelete_Click_1(object sender, EventArgs e)
        {
        
                DeleteRecord();
            LoadData();

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

        private void tbContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Allow only one dot character
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void tbStudentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            // Allow only one dot character
            if (e.KeyChar == '-' && (sender as TextBox).Text.IndexOf('-') > -1)
            {
                e.Handled = true;
            }
        }

        private void cbYearLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Allow only one dot character
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void btnGetPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        picBoxStudentImage.Image = Image.FromFile(openFileDialog.FileName);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            picBoxStudentImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // You can use other image formats
                            imageData = ms.ToArray();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void SaveStudentImage(string idnum)
        {
            if (imageData != null)
            {
                try
                {
                    StringBuilder queryBuilder = new StringBuilder();
                    queryBuilder.Append("INSERT INTO [dbo].[StudentImage] (StudentID, StudentPicture) ");
                    queryBuilder.Append("VALUES (@StudentID, @StudentPicture)");

                    using (SqlConnection connection = new SqlConnection(GlobalSetting.ConnectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(queryBuilder.ToString(), connection);
                        command.Parameters.AddWithValue("@StudentID", idnum);
                        command.Parameters.AddWithValue("@StudentPicture", imageData);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Image saved successfully to the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving image to database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an image to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RetrieveImage(string idNum)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GlobalSetting.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT StudentPicture FROM [dbo].[StudentImage] WHERE StudentID = @StudentID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@StudentID", idNum);
                    byte[] imageData = (byte[])command.ExecuteScalar();

                    if (imageData != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            picBoxStudentImage.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        picBoxStudentImage.Image = null;
                        MessageBox.Show("No image found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving image from database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }

}
