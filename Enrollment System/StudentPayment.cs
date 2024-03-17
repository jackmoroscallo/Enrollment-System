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
    public partial class StudentPayment : Form
    {

        private readonly ErrorProvider errorProvider = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };

        public StudentPayment()
        {
            InitializeComponent();
        }

        int PaymentID { get; set; }

        private void StudentPayment_Load(object sender, EventArgs e)
        {

            LoadData();
            getSchoolYear();
            getStudentID();

            cbStudentID.Enabled = false;
            tbDescription.ReadOnly = true;
            tbAmount.ReadOnly = true;
            cbPaymentType.Enabled = false;
            cbSchoolYear.Enabled = false; // Use Enabled property instead of ReadOnly
            cbTerm.Enabled = false;  // Use Enabled property instead of ReadOnly
            dtpPaymentDate.Enabled = false;     // Use Enabled property instead of ReadOnly
            cbPaidTo.Enabled = false;     // Use Enabled property instead of ReadOnly
            cbModeOfPayment.Enabled = false; // DateTimePicker doesn't have ReadOnly property, use Enabled instead
            tbDetails.ReadOnly = true;
            cbSchoolYear.DropDownHeight = 150;

        }

        private void btnMainMenu2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void StudentPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Exit the application
                Application.Exit();
            }
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            cbStudentID.Enabled = true;
            tbDescription.ReadOnly = false;
            tbAmount.ReadOnly = false;
            cbPaymentType.Enabled = true;
            cbSchoolYear.Enabled = true; // Use Enabled property instead of ReadOnly
            cbTerm.Enabled = true;  // Use Enabled property instead of ReadOnly
            dtpPaymentDate.Enabled = true;     // Use Enabled property instead of ReadOnly
            cbPaidTo.Enabled = true;     // Use Enabled property instead of ReadOnly
            cbModeOfPayment.Enabled = true; // DateTimePicker doesn't have ReadOnly property, use Enabled instead
            tbDetails.ReadOnly = false;
        }

        private void btnSavePayment_Click(object sender, EventArgs e)
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
            stringBuilder.AppendLine("INSERT INTO [stud].[StudentPayment]");
            stringBuilder.AppendLine("           (");
            stringBuilder.AppendLine("           [StudentID]");
            stringBuilder.AppendLine("           ,[Description]");
            stringBuilder.AppendLine("           ,[Amount]");
            stringBuilder.AppendLine("           ,[PaymentType]");
            stringBuilder.AppendLine("           ,[SchoolYear]");
            stringBuilder.AppendLine("           ,[Term]");
            stringBuilder.AppendLine("           ,[PaymentDate]");
            stringBuilder.AppendLine("           ,[PaidTo]");
            stringBuilder.AppendLine("           ,[ModeOfPayment]");
            stringBuilder.AppendLine("           ,[Details]");
            stringBuilder.AppendLine("           )");
            stringBuilder.AppendLine("     VALUES");
            stringBuilder.AppendLine("           (");
            stringBuilder.AppendLine("           @StudentID");
            stringBuilder.AppendLine("           ,@Description");
            stringBuilder.AppendLine("           ,@Amount");
            stringBuilder.AppendLine("           ,@PaymentType");
            stringBuilder.AppendLine("           ,@SchoolYear");
            stringBuilder.AppendLine("           ,@Term");
            stringBuilder.AppendLine("           ,@PaymentDate");
            stringBuilder.AppendLine("           ,@PaidTo");
            stringBuilder.AppendLine("           ,@ModeOfPayment");
            stringBuilder.AppendLine("           ,@Details");
            stringBuilder.AppendLine("           )");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@StudentID", cbStudentID.Text);
                    command.Parameters.AddWithValue("@Description", tbDescription.Text);
                    command.Parameters.AddWithValue("@Amount", tbAmount.Text);
                    command.Parameters.AddWithValue("@PaymentType", cbPaymentType.Text);
                    command.Parameters.AddWithValue("@SchoolYear", cbSchoolYear.Text);
                    command.Parameters.AddWithValue("@Term", cbTerm.Text);
                    command.Parameters.AddWithValue("@PaymentDate", dtpPaymentDate.Value);
                    command.Parameters.AddWithValue("@PaidTo", cbPaidTo.Text);
                    command.Parameters.AddWithValue("@ModeOfPayment", cbModeOfPayment.Text);
                    command.Parameters.AddWithValue("@Details", tbDetails.Text);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Record Added!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();

            ClearFields();


        }

        private void LoadData()
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SELECT [PaymentID]");
            stringBuilder.AppendLine("      ,[StudentID]");
            stringBuilder.AppendLine("      ,[Description]");
            stringBuilder.AppendLine("      ,[Amount]");
            stringBuilder.AppendLine("      ,[PaymentType]");
            stringBuilder.AppendLine("      ,[SchoolYear]");
            stringBuilder.AppendLine("      ,[Term]");
            stringBuilder.AppendLine("      ,[PaymentDate]");
            stringBuilder.AppendLine("      ,[PaidTo]");
            stringBuilder.AppendLine("      ,[ModeOfPayment]");
            stringBuilder.AppendLine("      ,[Details]");
            stringBuilder.AppendLine("  FROM [IT3232Moroscallo].[stud].[StudentPayment]");

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(stringBuilder.ToString(), connection);

                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                dgPayment.DataSource = dataTable;
                dgPayment.Columns["PaymentID"].Visible = false;

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

        private void ClearFields()
        {
            cbStudentID.Text = "";
            tbDescription.Text = "";
            tbAmount.Text = "";
            cbPaymentType.Text = "";
            cbSchoolYear.Text = ""; // Use Enabled property instead of ReadOnly
            cbTerm.Text = "";  // Use Enabled property instead of ReadOnly
            dtpPaymentDate.Value = DateTime.Now;     // Use Enabled property instead of ReadOnly
            cbPaidTo.Text = "";     // Use Enabled property instead of ReadOnly
            cbModeOfPayment.Text = ""; // DateTimePicker doesn't have ReadOnly property, use Enabled instead
            tbDetails.Text = "";

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

        private void getStudentID()
        {

            string connectionString = GlobalSetting.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Replace "YourTableName" and "YourColumnName" with your actual table and column names
                string query = "SELECT StudentID FROM [stud].[Student]";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Clear existing items in the ComboBox
                        cbStudentID.Items.Clear();

                        while (reader.Read())
                        {
                            // Add each item to the ComboBox
                            cbStudentID.Items.Add(reader["StudentID"].ToString());
                        }
                    }
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("UPDATE [stud].[StudentPayment] SET ");
            stringBuilder.AppendLine("           [StudentID] = @StudentID");
            stringBuilder.AppendLine("           ,[Description] = @Description");
            stringBuilder.AppendLine("           ,[Amount] = @Amount");
            stringBuilder.AppendLine("           ,[PaymentType] = @PaymentType");
            stringBuilder.AppendLine("           ,[SchoolYear] = @SchoolYear");
            stringBuilder.AppendLine("           ,[Term] = @Term");
            stringBuilder.AppendLine("           ,[PaymentDate] = @PaymentDate");
            stringBuilder.AppendLine("           ,[PaidTo] = @PaidTo");
            stringBuilder.AppendLine("           ,[ModeOfPayment] = @ModeOfPayment");
            stringBuilder.AppendLine("           ,[Details] = @Details");
            stringBuilder.AppendLine("WHERE PaymentID = @PaymentID");

            SqlConnection connection = new SqlConnection(connectionString);
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("@StudentID", cbStudentID.Text);
                    command.Parameters.AddWithValue("@Description", tbDescription.Text);
                    command.Parameters.AddWithValue("@Amount", tbAmount.Text);
                    command.Parameters.AddWithValue("@PaymentType", cbPaymentType.Text);
                    command.Parameters.AddWithValue("@SchoolYear", cbSchoolYear.Text);
                    command.Parameters.AddWithValue("@Term", cbTerm.Text);
                    command.Parameters.AddWithValue("@PaymentDate", dtpPaymentDate.Value);
                    command.Parameters.AddWithValue("@PaidTo", cbPaidTo.Text);
                    command.Parameters.AddWithValue("@ModeOfPayment", cbModeOfPayment.Text);
                    command.Parameters.AddWithValue("@Details", tbDetails.Text);;
                    command.Parameters.AddWithValue("@PaymentID", PaymentID);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Record Updated!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();

            ClearFields();

        }

        private void dgPayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dgPayment.Rows[e.RowIndex];
                PaymentID = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());

                cbStudentID.Text = selectedRow.Cells[1].Value.ToString();
                tbDescription.Text = selectedRow.Cells[2].Value.ToString();
                tbAmount.Text = selectedRow.Cells[3].Value.ToString();
                cbPaymentType.Text = selectedRow.Cells[4].Value.ToString();
                cbSchoolYear.Text = selectedRow.Cells[5].Value.ToString();
                cbTerm.Text = selectedRow.Cells[6].Value.ToString();
                dtpPaymentDate.Value = Convert.ToDateTime(selectedRow.Cells[7].Value);
                cbPaidTo.Text = selectedRow.Cells[8].Value.ToString();
                cbModeOfPayment.Text = selectedRow.Cells[9].Value.ToString();
                tbDetails.Text = selectedRow.Cells[10].Value.ToString();
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
                    DataTable schemaTable = connection.GetSchema("Columns", new[] { null, null, "StudentPayment", null });

                    // Constructing the dynamic SQL query
                    command.CommandText = $"SELECT * FROM [stud].[StudentPayment] WHERE ";

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
                    dgPayment.DataSource = searchResults;
                }


            }
        }


        private void DeletePaymentByPaymentID(string paramSubjectID)
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("DELETE FROM [stud].[StudentPayment]  ");
            stringBuilder.AppendLine("WHERE PaymentID = @PaymentID");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@PaymentID", paramSubjectID);
                    command.ExecuteNonQuery();
                }
            }



            LoadData();
        }

        private void DeleteRecord()
        {
            if (dgPayment.SelectedRows.Count > 0)
            {
                int selectedIndex = dgPayment.SelectedRows[0].Index;

                string ID = dgPayment.Rows[selectedIndex].Cells["PaymentID"].Value.ToString();


                DialogResult result = MessageBox.Show($"Do you want to delete?\n\n{ID}", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {

                    DeletePaymentByPaymentID(ID);
                    MessageBox.Show("Record Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
            LoadData();
        }
    }
}
