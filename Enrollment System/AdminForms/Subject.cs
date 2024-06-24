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
        private readonly ErrorProvider errorProvider = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
        public Subject()
        {
            InitializeComponent();
        }

        int SubID { get; set; }

        private void btnMainMenu2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            
        }

        private void Subject_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            cbCourseCode.Enabled = true;
            tbSubjectCode.ReadOnly = false;
            tbSubjectDescription.ReadOnly = false;
            tbUnits.ReadOnly = false;
            cbType.Enabled = true;
            tbSubjectHours.ReadOnly = false;
            tbSearch.ReadOnly = false;

            ClearFields();
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
            tbSubjectHours.ReadOnly = true;
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
            stringBuilder.AppendLine("      ,[SubjectHours]");
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
            stringBuilder.AppendLine("           ,[SubjectHours]");
            stringBuilder.AppendLine("           )");
            stringBuilder.AppendLine("     VALUES");
            stringBuilder.AppendLine("           (");
            stringBuilder.AppendLine("           @CourseCode");
            stringBuilder.AppendLine("           ,@SubjectCode");
            stringBuilder.AppendLine("           ,@SubjectDescription");
            stringBuilder.AppendLine("           ,@Units");
            stringBuilder.AppendLine("           ,@Type");
            stringBuilder.AppendLine("           ,@SubjectHours");
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
                    command.Parameters.AddWithValue("@SubjectHours", tbSubjectHours.Text);



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
            stringBuilder.AppendLine("           ,[SubjectHours] = @SubjectHours");
            stringBuilder.AppendLine("WHERE SubjectID = @SubjectID");

            SqlConnection connection = new SqlConnection(connectionString);
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
                    command.Parameters.AddWithValue("@SubjectHours", tbSubjectHours.Text);
                    command.Parameters.AddWithValue("@SubjectID", SubID);


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

        private void DeleteRecord()
        {
            if (dgSubject.SelectedRows.Count > 0)
            {
                int selectedIndex = dgSubject.SelectedRows[0].Index;

                string ID = dgSubject.Rows[selectedIndex].Cells["SubjectID"].Value.ToString();


                DialogResult result = MessageBox.Show($"Do you want to delete?\n\n{ID}", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {

                    DeleteSubjectBySubjectID(ID);
                    MessageBox.Show("Record Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
            LoadData();
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
            tbSubjectHours.Text = "";

        }

        private void dgSubject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dgSubject.Rows[e.RowIndex];

                SubID = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                cbCourseCode.Text = selectedRow.Cells[1].Value.ToString();
                tbSubjectCode.Text = selectedRow.Cells[2].Value.ToString();
                tbSubjectDescription.Text = selectedRow.Cells[3].Value.ToString();
                tbUnits.Text = selectedRow.Cells[4].Value.ToString();
                cbType.Text = selectedRow.Cells[5].Value.ToString();
                tbSubjectHours.Text = selectedRow.Cells[6].Value.ToString();
            }
            catch
            {

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

        private void Subject_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbSubjectRate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbUnits_KeyPress(object sender, KeyPressEventArgs e)
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

        private void offeredSubjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OfferedSubject offeredSubject = new OfferedSubject();
            offeredSubject.ShowDialog();
        }

        private void offeredSubjectListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OfferedSubjectList offeredSubjectList = new OfferedSubjectList();
            offeredSubjectList.ShowDialog();
        }
    }
}
