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
    }
}