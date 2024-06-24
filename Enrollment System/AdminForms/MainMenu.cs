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
    public partial class MainMenu : Form
    {
        public string userRole { get; set; }
        public string userDetail { get; set; }
        public MainMenu()
        {

            InitializeComponent();
 
            CenterPanel();
        }

      

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Student student = new Student();
            student.Show();
        }

        
        private void MainMenu_Load(object sender, EventArgs e)
        {
            //// Get the size of the screen
            //int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            //int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            //// Get the size of the form
            //int formWidth = this.Width;
            //int formHeight = this.Height;

            //// Calculate the position of the form
            //int formX = (screenWidth - formWidth) / 2;
            //int formY = (screenHeight - formHeight) / 2;

            //// Set the position of the form
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(formX, formY);

    
            CenterPanel();

            MessageBox.Show("Welcome Back, " + (userDetail));
        }

        private void CenterPanel()
        {
            // Calculate the position to center the panel within the form
            int x = (ClientSize.Width - panel1.Width) / 2;
            int y = (ClientSize.Height - panel1.Height) / 2;

            // Set the panel's location
            panel1.Location = new System.Drawing.Point(x, y);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Course course = new Course();
            course.Show();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
  
            Subject subject = new Subject();
            subject.ShowDialog();
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            Fee fee = new Fee();
            fee.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            StudentPayment studentPayment = new StudentPayment();
            studentPayment.userDetail = userDetail;
            studentPayment.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            UserManagement userManagement = new UserManagement();
            userManagement.ShowDialog();
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.Show();
        }

        private void schoolYearSemesterControlToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SchoolYearSemester schoolYearSemester = new SchoolYearSemester();
            schoolYearSemester.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Section section = new Section();
            section.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Room room = new Room();
            room.ShowDialog();
        }
    }
}
