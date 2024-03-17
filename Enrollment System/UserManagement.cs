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
    public partial class UserManagement : Form
    {
        private readonly ErrorProvider errorProvider = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
        public UserManagement()
        {
            InitializeComponent();
        }

        int UserID { get; set; }

        private void btnMainMenu2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void UserManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Exit the application
                Application.Exit();
            }
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            LoadData();
            tbUserName.ReadOnly = true;
            tbEmailAddress.ReadOnly = true;
            tbPasswordHash.ReadOnly = true;
            cbUserType.Enabled = false;
            dtpDateAdded.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbUserName.ReadOnly = false;
            tbEmailAddress.ReadOnly = false;
            tbPasswordHash.ReadOnly = false;
            cbUserType.Enabled = true;
            dtpDateAdded.Enabled = true;
        }

        private void LoadData()
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SELECT [UserID]");
            stringBuilder.AppendLine("      ,[Username]");
            stringBuilder.AppendLine("      ,[EmailAddress]");
            stringBuilder.AppendLine("      ,[PasswordHash]");
            stringBuilder.AppendLine("      ,[UserType]");
            stringBuilder.AppendLine("      ,[DateAdded]");
            stringBuilder.AppendLine("  FROM [IT3232Moroscallo].[stud].[UserAccount]");

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(stringBuilder.ToString(), connection);

                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                dgManagement.DataSource = dataTable;


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

        private void btnSave_Click(object sender, EventArgs e)
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
            stringBuilder.AppendLine("INSERT INTO [stud].[UserAccount]");
            stringBuilder.AppendLine("           (");
            stringBuilder.AppendLine("           [Username]");
            stringBuilder.AppendLine("           ,[EmailAddress]");
            stringBuilder.AppendLine("           ,[PasswordHash]");
            stringBuilder.AppendLine("           ,[UserType]");
            stringBuilder.AppendLine("           ,[DateAdded]");
            stringBuilder.AppendLine("           )");
            stringBuilder.AppendLine("     VALUES");
            stringBuilder.AppendLine("           (");
            stringBuilder.AppendLine("           @Username");
            stringBuilder.AppendLine("           ,@EmailAddress");
            stringBuilder.AppendLine("           ,@PasswordHash");
            stringBuilder.AppendLine("           ,@UserType");
            stringBuilder.AppendLine("           ,@DateAdded");
            stringBuilder.AppendLine("           )");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@Username", tbUserName.Text);
                    command.Parameters.AddWithValue("@EmailAddress", tbEmailAddress.Text);
                    command.Parameters.AddWithValue("@PasswordHash", tbPasswordHash.Text);
                    command.Parameters.AddWithValue("@UserType", cbUserType.Text);
                    command.Parameters.AddWithValue("@DateAdded", dtpDateAdded.Value);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Record Added!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();

            ClearFields();


        }

        private void ClearFields()
        {
            tbUserName.Text = "";
            tbEmailAddress.Text = "";
            tbPasswordHash.Text = "";
            cbUserType.Text = "";
            dtpDateAdded.Value = DateTime.Now;
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("UPDATE [stud].[UserAccount] SET ");
            stringBuilder.AppendLine("           [Username] = @Username");
            stringBuilder.AppendLine("           ,[EmailAddress] = @EmailAddress");
            stringBuilder.AppendLine("           ,[PasswordHash] = @PasswordHash");
            stringBuilder.AppendLine("           ,[UserType] = @UserType");
            stringBuilder.AppendLine("           ,[DateAdded] = @DateAdded");
            stringBuilder.AppendLine("WHERE UserID = @UserID");

            SqlConnection connection = new SqlConnection(connectionString);
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("@Username", tbUserName.Text);
                    command.Parameters.AddWithValue("@EmailAddress", tbEmailAddress.Text);
                    command.Parameters.AddWithValue("@PasswordHash", tbPasswordHash.Text);
                    command.Parameters.AddWithValue("@UserType", cbUserType.Text);
                    command.Parameters.AddWithValue("@DateAdded", dtpDateAdded.Value);
                    command.Parameters.AddWithValue("@UserID", UserID);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Record Updated!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();

            ClearFields();
        }

        private void dgManagement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
       
                DataGridViewRow selectedRow = dgManagement.Rows[e.RowIndex];
                UserID = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());

                tbUserName.Text = selectedRow.Cells[1].Value.ToString();
                tbEmailAddress.Text = selectedRow.Cells[2].Value.ToString();
                tbPasswordHash.Text = selectedRow.Cells[3].Value.ToString();
                cbUserType.Text = selectedRow.Cells[4].Value.ToString();
                dtpDateAdded.Value = Convert.ToDateTime(selectedRow.Cells[5].Value);

          
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
                    DataTable schemaTable = connection.GetSchema("Columns", new[] { null, null, "UserAccount", null });

                    // Constructing the dynamic SQL query
                    command.CommandText = $"SELECT * FROM [stud].[UserAccount] WHERE ";

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
                    dgManagement.DataSource = searchResults;
                }


            }
        }

        private void DeleteUserByUserID(string paramStudentID)
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("DELETE FROM [stud].[UserAccount]  ");
            stringBuilder.AppendLine("WHERE UserID = @UserID");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@UserID", paramStudentID);
                    command.ExecuteNonQuery();
                }
            }



            LoadData();
        }

        private void DeleteRecord()
        {
            if (dgManagement.SelectedRows.Count > 0)
            {
                int selectedIndex = dgManagement.SelectedRows[0].Index;

                string ID = dgManagement.Rows[selectedIndex].Cells["UserID"].Value.ToString();


                DialogResult result = MessageBox.Show($"Do you want to delete?\n\n{ID}", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {

                    DeleteUserByUserID(ID);
                    MessageBox.Show("Record Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
            ClearFields();
            LoadData();
        }
    }
}
