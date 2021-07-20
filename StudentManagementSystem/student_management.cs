using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace StudentManagementSystem
{
    public partial class student_management : UserControl
    {
        public student_management()
        {
            InitializeComponent();
        }

        StudentManagementSystemDBAccess db_obj = new StudentManagementSystemDBAccess();

        private string ChkRadioFeilds(RadioButton male, RadioButton Female)
        {
            if (male.Checked == true)
            {
                return male.Name;
            }
            if (Female.Checked == true)
            {
                return Female.Name;
            }
            else
            {
                return null;
            }
        }

        private bool Chkfeilds(string value)
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

        private void MarkAsTrueRadio(string p)
        {
            if (p == "Male")
            {
                Male.Checked = true;
            }
            else
            {
                Female.Checked = true;
            }
        }

        private void stu_reg_btn_Click(object sender, EventArgs e)
        {
            string FirstName = fname_txt.Text;
            string LastName = lname_txt.Text;
            DateTime BirthDate = Convert.ToDateTime(bdate_dtpick.Value);
            string MobileNumber = phone_txt.Text;
            string EmailAddress = email_txt.Text;
            string Address = address_txt.Text;
            string CourseCategory = course_cat_cmb.Text;
            string CourseName = course_name_cmb.Text;

            if (Chkfeilds(FirstName) == true && Chkfeilds(LastName) == true && Chkfeilds(MobileNumber) == true && Chkfeilds(EmailAddress) == true
                && Chkfeilds(Address) == true)
            {
                string Gender = ChkRadioFeilds(Male, Female);

                if (BirthDate < System.DateTime.Now.AddYears(-10) && !(string.IsNullOrEmpty(Gender)))
                {
                    if (db_obj.RegisterStudentDetails(FirstName, LastName, BirthDate, MobileNumber, EmailAddress, Gender, Address, CourseCategory,
                        CourseName) == true)
                    {
                        GetStudentDetailsList();
                        MessageBox.Show("Student details Registration Succesfully...!", "New Student Registration...");

                        string StudentID = db_obj.GetNewStuIDNumber();
                        stu_id_txt.Text = StudentID;
                    }
                    else
                    {
                        MessageBox.Show("There is An Error Occured While registration...","Database Or SQL Error...");
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill All feilds Correctly With Correct Values...","Empty or Mismatch feilds...");
                }
            }
            else
            {
                MessageBox.Show("Please Fill All feilds Correctly With Correct Values...", "Empty or Mismatch feilds...");
            }
        }

        private void LoadStudentCategoryDetails()
        {
            string[] CoursCategoryDetails = db_obj.GetCourseCategoryDetails();

            for (int each_categoty = 0; each_categoty <= CoursCategoryDetails.Length; each_categoty++)
            {
                if (CoursCategoryDetails[each_categoty] == null)
                {
                    break;
                }
                else
                {
                    course_cat_cmb.Items.Add(CoursCategoryDetails[each_categoty]);
                }
            }
        }

        private void GetStudentDetailsList()
        {
            SqlCeCommand GetStudentDetailsList = new SqlCeCommand("select * from student_details");
            stu_dataGridView1.ReadOnly = true;
            stu_dataGridView1.DataSource = db_obj.ReturnStudentDetailsList(GetStudentDetailsList);
            stu_dataGridView1.AllowUserToAddRows = false;
        }

        private void student_management_Load(object sender, EventArgs e)
        {
            LoadStudentCategoryDetails();
            GetStudentDetailsList();

            stu_update_btn.Enabled = false;
            stu_del_btn.Enabled = false;
        }

        private void course_cat_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            course_name_cmb.Items.Clear();
            string GetCoursCategory = course_cat_cmb.Text;
            string[] AvailableCourses = db_obj.GetAvailableCourseDetails(GetCoursCategory);

            for (int each_course_name = 0; each_course_name <= AvailableCourses.Length; each_course_name++)
            {
                if (AvailableCourses[each_course_name] == null)
                {
                    break;
                }
                else
                {
                    course_name_cmb.Items.Add(AvailableCourses[each_course_name]);
                }
            }
        }

        private void find_stu_btn_Click(object sender, EventArgs e)
        {
            string GetStuIDNumber = find_stu_txt.Text;

            if (Chkfeilds(GetStuIDNumber) == true)
            {
                string[] student_details = db_obj.GetStudentdetails(GetStuIDNumber);

                if (student_details[0] != null)
                {
                    fname_txt.Text = student_details[1].ToString();
                    lname_txt.Text = student_details[2].ToString();
                    bdate_dtpick.Value = Convert.ToDateTime(student_details[3]);
                    phone_txt.Text = student_details[4].ToString();
                    email_txt.Text = student_details[5].ToString();

                    MarkAsTrueRadio(student_details[6]);

                    address_txt.Text = student_details[7].ToString();
                    course_cat_cmb.SelectedItem = student_details[8];
                    course_name_cmb.SelectedItem = student_details[9];

                    stu_id_txt.Text = student_details[0].ToString();

                    stu_reg_btn.Enabled = false;
                    stu_update_btn.Enabled = true;
                    stu_del_btn.Enabled = true;
                }
                else
                {
                    MessageBox.Show("There Is No Student Details For That Student ID Number...","Invalid Student ID Number...");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Student ID Number Before Search Student details...","Empty Student ID Number...");
            }
        }

        private void stu_dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            fname_txt.Text = stu_dataGridView1.CurrentRow.Cells[1].Value.ToString();
            lname_txt.Text = stu_dataGridView1.CurrentRow.Cells[2].Value.ToString();
            bdate_dtpick.Value = Convert.ToDateTime(stu_dataGridView1.CurrentRow.Cells[3].Value);
            phone_txt.Text = stu_dataGridView1.CurrentRow.Cells[4].Value.ToString();
            email_txt.Text = stu_dataGridView1.CurrentRow.Cells[5].Value.ToString();

            MarkAsTrueRadio(stu_dataGridView1.CurrentRow.Cells[6].Value.ToString());

            address_txt.Text = stu_dataGridView1.CurrentRow.Cells[7].Value.ToString();
            course_cat_cmb.SelectedItem = stu_dataGridView1.CurrentRow.Cells[8].Value.ToString();
            course_name_cmb.SelectedItem = stu_dataGridView1.CurrentRow.Cells[9].Value.ToString();

            stu_id_txt.Text = stu_dataGridView1.CurrentRow.Cells[0].Value.ToString();

            stu_update_btn.Enabled = true;
            stu_del_btn.Enabled = true;

            stu_reg_btn.Enabled = false;
        }

        private void stu_update_btn_Click(object sender, EventArgs e)
        {
            int StudentIDNumber = Convert.ToInt32(stu_id_txt.Text);
            string FirstName = fname_txt.Text;
            string LastName = lname_txt.Text;
            DateTime BirthDate = Convert.ToDateTime(bdate_dtpick.Value);
            string MobileNumber = phone_txt.Text;
            string EmailAddress = email_txt.Text;
            string Address = address_txt.Text;
            string CourseCategory = course_cat_cmb.Text;
            string CourseName = course_name_cmb.Text;

            if (Chkfeilds(FirstName) == true && Chkfeilds(LastName) == true && Chkfeilds(MobileNumber) == true && Chkfeilds(EmailAddress) == true
                && Chkfeilds(Address) == true)
            {
                string Gender = ChkRadioFeilds(Male, Female);

                if (BirthDate < System.DateTime.Now.AddYears(-10) && !(string.IsNullOrEmpty(Gender)))
                {
                    if (db_obj.UpdateStudentDetails(StudentIDNumber,FirstName, LastName, BirthDate, MobileNumber, EmailAddress, Gender, Address, CourseCategory,
                        CourseName) == true)
                    {
                        GetStudentDetailsList();
                        MessageBox.Show("Student details Updating Succesfully...!", "New Student Updating...");

                        string StudentID = db_obj.GetNewStuIDNumber();
                        stu_id_txt.Text = StudentID;
                    }
                    else
                    {
                        MessageBox.Show("There is An Error Occured While Updating...", "Database Or SQL Error...");
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill All feilds Correctly With Correct Values...", "Empty or Mismatch feilds...");
                }
            }
            else
            {
                MessageBox.Show("Please Fill All feilds Correctly With Correct Values...", "Empty or Mismatch feilds...");
            }
        }

        private void stu_del_btn_Click(object sender, EventArgs e)
        {
            int StudentIDNumber = Convert.ToInt32(stu_id_txt.Text);

            DialogResult DeleteStudentDetails = MessageBox.Show("Are You Sure Want To Delete This Student From The System ? ","Student Details Deletion...",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (DeleteStudentDetails == DialogResult.OK)
            {
                if (db_obj.DeleteSelectedStudentDetails(StudentIDNumber) == true)
                {
                    MessageBox.Show("Student Details Deletion Succesfully...!","Student Details Deletion...");
                    GetStudentDetailsList();
                }
                else
                {
                    MessageBox.Show("There Is Some Error Occured While Student Deletion...","Database Or SQL Error...");
                }
            }
        }

        private void ResetAllFeilds()
        {
            stu_reg_btn.Enabled = true;
            stu_update_btn.Enabled = false;
            stu_del_btn.Enabled = false;

            fname_txt.Text = "";
            lname_txt.Text = "";
            bdate_dtpick.Value = System.DateTime.Now;
            phone_txt.Text = "";
            email_txt.Text = "";
            Male.Checked = false;
            Female.Checked = false;
            address_txt.Text = "";
            course_cat_cmb.SelectedItem = null;
            course_name_cmb.SelectedItem = null;
            stu_id_txt.Text = "";
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            ResetAllFeilds();
        }
        
    }
}
