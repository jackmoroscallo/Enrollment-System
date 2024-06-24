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
    public partial class AccountingMenu : Form
    {
        public AccountingMenu()
        {
            InitializeComponent();
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.Show();
        }

        private void AccountingMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Exit the application
                Application.Exit();
            }
        }

        private void AccountingMenu_Load(object sender, EventArgs e)
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Fee fee = new Fee();
            fee.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            StudentPayment studentPayment = new StudentPayment();
            studentPayment.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AccountingPendingEnrollment accountingPendingEnrollment = new AccountingPendingEnrollment();
            accountingPendingEnrollment.ShowDialog();
        }
    }
}
