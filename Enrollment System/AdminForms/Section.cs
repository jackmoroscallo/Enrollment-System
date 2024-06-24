using Enrollment_System.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System
{
    public partial class Section : Form
    {
        private readonly ErrorProvider errorProvider = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
        public Section()
        {
            InitializeComponent();
        }

        int SecID { get; set; }

        private void Section_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void Section_Load(object sender, EventArgs e)
        {
            LoadData();
            getCourses();
            tbSectionName.ReadOnly = true;
            cbCourseCode.Enabled = false;
        }

        private void LoadData()
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SELECT [SectionID]");
            stringBuilder.AppendLine("      ,[SectionName]");
            stringBuilder.AppendLine("      ,[CourseCode]");
            stringBuilder.AppendLine("  FROM [IT3232Moroscallo].[dbo].[Section]");

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(stringBuilder.ToString(), connection);

                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                dgSection.DataSource = dataTable;
                dgSection.Columns["SectionID"].Visible = false;

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
            tbSectionName.Text = "";
            cbCourseCode.Text = "";
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

        private void SaveSection()
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("INSERT INTO [dbo].[Section]");
            stringBuilder.AppendLine("           (");
            stringBuilder.AppendLine("           [SectionName]");
            stringBuilder.AppendLine("           ,[CourseCode]");
            stringBuilder.AppendLine("           )");
            stringBuilder.AppendLine("     VALUES");
            stringBuilder.AppendLine("           (");
            stringBuilder.AppendLine("           @SectionName");
            stringBuilder.AppendLine("           ,@CourseCode");
            stringBuilder.AppendLine("           )");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@SectionName", tbSectionName.Text);
                    command.Parameters.AddWithValue("@CourseCode", cbCourseCode.Text);



                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Record Added!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();
            ClearFields();
        }

        private void btnAddSection_Click(object sender, EventArgs e)
        {
            tbSectionName.ReadOnly = false;
            cbCourseCode.Enabled = true;
        }

        private void btnSaveSection_Click(object sender, EventArgs e)
        {
            SaveSection();
            errorProvider.Clear();
            
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateSection();
        }

        private void UpdateSection()
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("UPDATE [dbo].[Section] SET ");
            stringBuilder.AppendLine("           [SectionName] = @SectionName");
            stringBuilder.AppendLine("           ,[CourseCode] = @CourseCode");
            stringBuilder.AppendLine("WHERE SectionID = @SectionID");

            SqlConnection connection = new SqlConnection(connectionString);
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("@SectionName", tbSectionName.Text);
                    command.Parameters.AddWithValue("@CourseCode", cbCourseCode.Text);
                    command.Parameters.AddWithValue("@SectionID", SecID);


                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Record Updated!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();
            ClearFields();
        }

        private void dgSection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dgSection.Rows[e.RowIndex];

                SecID = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                tbSectionName.Text = selectedRow.Cells[1].Value.ToString();
                cbCourseCode.Text = selectedRow.Cells[2].Value.ToString();



            }
            catch
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void DeleteRecord()
        {
            if (dgSection.SelectedRows.Count > 0)
            {
                int selectedIndex = dgSection.SelectedRows[0].Index;

                string ID = dgSection.Rows[selectedIndex].Cells["SectionID"].Value.ToString();


                DialogResult result = MessageBox.Show($"Do you want to delete?\n\n{ID}", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {

                    DeleteSectionByIDNumber(ID);
                    MessageBox.Show("Record Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            ClearFields();
        }

        private void DeleteSectionByIDNumber(string paramSectionID)
        {
            string connectionString = GlobalSetting.ConnectionString;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("DELETE FROM [dbo].[Section]  ");
            stringBuilder.AppendLine("WHERE SectionID = @SectionID");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection))
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@SectionID", paramSectionID);
                    command.ExecuteNonQuery();
                }
            }



            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        private void SearchSection()
        {
            string searchKeyword = tbSearch.Text;

            using (SqlConnection connection = new SqlConnection(GlobalSetting.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    // Get column names
                    DataTable schemaTable = connection.GetSchema("Columns", new[] { null, null, "Section", null });

                    // Check if there are any columns
                    if (schemaTable.Rows.Count == 0)
                    {
                        // Handle scenario where no columns are found
                        MessageBox.Show("No columns found in the table.");
                        return;
                    }

                    // Constructing the dynamic SQL query
                    command.CommandText = "SELECT * FROM [dbo].[Section] WHERE ";

                    foreach (DataRow row in schemaTable.Rows)
                    {
                        string columnName = (string)row["COLUMN_NAME"];

                        // Append each column to the WHERE clause
                        command.CommandText += $"[{columnName}] LIKE @{columnName} OR ";

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
                    dgSection.DataSource = searchResults;
                }
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchSection();
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
