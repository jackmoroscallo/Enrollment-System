using Enrollment_System.Modules;
using Microsoft.SqlServer.Server;
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
    public partial class LogIn : Form
    {
        private static string UserType;
        private static string UserDetail;
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Exit the application
                Application.Exit();
            }
        }

        static bool Login(string username, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GlobalSetting.ConnectionString))
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("SELECT PasswordHash, Salt, UserType, Name ");
                    stringBuilder.Append("FROM [IT3232Moroscallo].[stud].[UserAccount] ");
                    stringBuilder.Append("WHERE Username = @Username ");
                    
                    SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection);
                    command.Parameters.AddWithValue("@Username", username);
                    
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string storedPasswordHash = reader["PasswordHash"].ToString();
                        string salt = reader["Salt"].ToString();

                        //hash the entered password with the retrieved sakt
                        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
                        UserType = reader["UserType"].ToString();
                        UserDetail = reader["Name"].ToString();
                        //Compare the hashed passwords
                        if (hashedPassword == storedPasswordHash)
                        {
                            return true; //Login successful
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:" + ex.Message);
            }

            return false; //Login Failed

        }
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (Login(tbUsername.Text, tbPassword.Text))
            {
               
                if (UserType == "Administrator")
                {
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.userRole = UserType;
                    mainMenu.userDetail = UserDetail;
                    mainMenu.Show();
                }

                else if (UserType == "Registrar Personnel")
                {
                    RegistrarMenu registrarMenu = new RegistrarMenu();
                    
                    registrarMenu.Show();
                }
                else if (UserType == "Accounting Personnel")
                {
                    AccountingMenu accountingMenu = new AccountingMenu();

                    accountingMenu.Show();
                }
                else if (UserType == "Coordinator")
                {
                    CoordinatorMenu coordinatorMenu = new CoordinatorMenu();

                    coordinatorMenu.Show();
                }

                this.Hide();
              
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!");
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}