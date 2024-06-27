using Enrollment_System.AdminForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenuTwo());
            //string ConnectionString = "Data Source=(localdb)\\Local;Initial Catalog=IT3232Moroscallo;User ID=test;Password=test";

            //using (SqlConnection connection = new SqlConnection(ConnectionString)) 
            //{
            //    connection.Open();

            //    string query = "SELECT * FROM [IT3232Moroscallo].[dbo].[Student_Basic_Info]";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        SqlDataReader reader = command.ExecuteReader();

            //        while (reader.Read()) 
            //        {
            //            string columnName = reader["StudentName"].ToString();
            //            //Console.WriteLine(columnName);
            //            MessageBox.Show(columnName);
            //        }
            //        reader.Close();
            //    }
            //    connection.Close();
            //}
        }
    }
}
