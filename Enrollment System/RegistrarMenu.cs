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
    public partial class RegistrarMenu : Form
    {
        public RegistrarMenu()
        {
            InitializeComponent();
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
         
            Student student = new Student();
            student.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
         
            Course course = new Course();
            course.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
          
            Subject subject = new Subject();
            subject.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RegsitrarMenu_Load(object sender, EventArgs e)
        {
            CenterPanel();
        }

        private void CenterPanel()
        {
            // Calculate the position to center the panel within the form
            int x = (ClientSize.Width - panel1.Width) / 2;
            int y = (ClientSize.Height - panel1.Height) / 2;

            // Set the panel's location
            panel1.Location = new System.Drawing.Point(x, y);
        }

        private void RegistrarMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Exit the application
                Application.Exit();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ListOfPendingEnrollment listOfPendingEnrollment = new ListOfPendingEnrollment();
            listOfPendingEnrollment.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
