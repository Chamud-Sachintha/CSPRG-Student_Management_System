using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class MainSystemVeiw : Form
    {
        public MainSystemVeiw()
        {
            InitializeComponent();
        }

        private void MainSystemVeiw_Load(object sender, EventArgs e)
        {
            student_management1.Show();
            student_management1.BringToFront();

            lectureManagement1.Hide();
            coursesManagement1.Hide();
        }

        private void teachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lectureManagement1.Show();
            lectureManagement1.BringToFront();

            student_management1.Hide();
            coursesManagement1.Hide();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            student_management1.Show();
            student_management1.BringToFront();

            lectureManagement1.Hide();
            coursesManagement1.Hide();
        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            coursesManagement1.Show();
            coursesManagement1.BringToFront();

            student_management1.Hide();
            lectureManagement1.Hide();
        }

       
    }
}
