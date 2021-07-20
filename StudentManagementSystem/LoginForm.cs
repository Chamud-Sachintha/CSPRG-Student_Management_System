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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        StudentManagementSystemDBAccess db_obj = new StudentManagementSystemDBAccess();

        private bool ChkFeilds(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string Username = username_txt.Text;
            string Password = password_txt.Text;

            if (ChkFeilds(Username) == true && ChkFeilds(Password) == true)
            {
                string[] admin_details = db_obj.GetAdminDetails(Username, Password);

                if (admin_details[0] != null)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Username Or Password Invalid...");
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Please Enter Username And Password Before Loggin In...");
            }
        }
    }
}
