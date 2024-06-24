using Enrollment_System.AdminForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System
{
    public partial class CoordinatorMenu : Form
    {
        public CoordinatorMenu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            StudentList studentList = new StudentList();
            studentList.ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Dispose();
            LogIn logIn = new LogIn();
            logIn.Show();
        }

        private void CoordinatorMenu_Load(object sender, EventArgs e)
        {

        }

        private void CoordinatorMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
