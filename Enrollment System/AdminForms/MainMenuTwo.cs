using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System.AdminForms
{
    public partial class MainMenuTwo : DevExpress.XtraEditors.XtraForm
    {
        public string userRole { get; set; }
        public string userDetail { get; set; }
        public MainMenuTwo()
        {
            InitializeComponent();
        }

        private void tileItem13_ItemClick(object sender, TileItemEventArgs e)
        {

        }

        private void tileItem6_ItemClick(object sender, TileItemEventArgs e)
        {
            UserManagement userManagement = new UserManagement();
            userManagement.ShowDialog();
        }

        private void tileItem8_ItemClick(object sender, TileItemEventArgs e)
        {
            Student student = new Student();
            student.ShowDialog();
        }

        private void Course_ItemClick(object sender, TileItemEventArgs e)
        {
            Course course = new Course();
            course.ShowDialog();
        }

        private void tileItem9_ItemClick(object sender, TileItemEventArgs e)
        {
            Subject subject = new Subject();
            subject.ShowDialog();
        }

        private void tileItem7_ItemClick(object sender, TileItemEventArgs e)
        {
            Fee fee = new Fee();
            fee.ShowDialog();
        }

        private void tileItem10_ItemClick(object sender, TileItemEventArgs e)
        {
            StudentPayment studentPayment = new StudentPayment();
            studentPayment.userDetail = userDetail;
            studentPayment.ShowDialog();
        }

        private void tileItem11_ItemClick(object sender, TileItemEventArgs e)
        {
            Room room = new Room();
            room.ShowDialog();
        }

        private void tileItem12_ItemClick(object sender, TileItemEventArgs e)
        {
            Section section = new Section();
            section.ShowDialog();
        }
    }
}