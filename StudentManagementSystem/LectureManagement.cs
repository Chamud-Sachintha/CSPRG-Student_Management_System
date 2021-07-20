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
    public partial class LectureManagement : UserControl
    {
        public LectureManagement()
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

        private void GetLecturerDetailsList()
        {
            SqlCeCommand GetStudentDetailsList = new SqlCeCommand("select * from lecturer_details");
            lec_dataGridView1.ReadOnly = true;
            lec_dataGridView1.DataSource = db_obj.ReturnLectureDetailsList(GetStudentDetailsList);
            lec_dataGridView1.AllowUserToAddRows = false;
        }

        private void LectureManagement_Load(object sender, EventArgs e)
        {
            LoadStudentCategoryDetails();
            GetLecturerDetailsList();

            lec_update_btn.Enabled = false;
            lec_del_btn.Enabled = false;
        }

        private void course_cat_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void lec_reg_btn_Click(object sender, EventArgs e)
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
                    if (db_obj.RegisterLecturerDetails(FirstName, LastName, BirthDate, MobileNumber, EmailAddress, Gender, Address, CourseCategory,
                        CourseName) == true)
                    {
                        GetLecturerDetailsList();
                        MessageBox.Show("Lecturer details Registration Succesfully...!", "New Lecturer Registration...");

                        string LecturerID = db_obj.GetNewLecIDNumber();
                        lec_id_txt.Text = LecturerID;
                    }
                    else
                    {
                        MessageBox.Show("There is An Error Occured While registration...", "Database Or SQL Error...");
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

        private void lec_dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            fname_txt.Text = lec_dataGridView1.CurrentRow.Cells[1].Value.ToString();
            lname_txt.Text = lec_dataGridView1.CurrentRow.Cells[2].Value.ToString();
            bdate_dtpick.Value = Convert.ToDateTime(lec_dataGridView1.CurrentRow.Cells[3].Value);
            phone_txt.Text = lec_dataGridView1.CurrentRow.Cells[4].Value.ToString();
            email_txt.Text = lec_dataGridView1.CurrentRow.Cells[5].Value.ToString();

            MarkAsTrueRadio(lec_dataGridView1.CurrentRow.Cells[6].Value.ToString());

            address_txt.Text = lec_dataGridView1.CurrentRow.Cells[7].Value.ToString();
            course_cat_cmb.SelectedItem = lec_dataGridView1.CurrentRow.Cells[8].Value.ToString();
            course_name_cmb.SelectedItem = lec_dataGridView1.CurrentRow.Cells[9].Value.ToString();

            lec_id_txt.Text = lec_dataGridView1.CurrentRow.Cells[0].Value.ToString();

            lec_update_btn.Enabled = true;
            lec_del_btn.Enabled = true;

            lec_reg_btn.Enabled = false;
        }

        private void lec_find_btn_Click(object sender, EventArgs e)
        {
            string GetStuIDNumber = find_lec_txt.Text;

            if (Chkfeilds(GetStuIDNumber) == true)
            {
                string[] student_details = db_obj.GetLecturerdetails(GetStuIDNumber);

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

                    lec_id_txt.Text = student_details[0].ToString();

                    lec_reg_btn.Enabled = false;
                    lec_update_btn.Enabled = true;
                    lec_del_btn.Enabled = true;
                }
                else
                {
                    MessageBox.Show("There Is No Student Details For That Student ID Number...", "Invalid Student ID Number...");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Student ID Number Before Search Student details...", "Empty Student ID Number...");
            }
        }

        private void lec_update_btn_Click(object sender, EventArgs e)
        {
            int LecturerIDNumber = Convert.ToInt32(lec_id_txt.Text);
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
                    if (db_obj.UpdateLecturerDetails(LecturerIDNumber, FirstName, LastName, BirthDate, MobileNumber, EmailAddress, Gender, Address, CourseCategory,
                        CourseName) == true)
                    {
                        GetLecturerDetailsList();
                        MessageBox.Show("Lecturer details Updating Succesfully...!", "New Lecturer Updating...");

                        string StudentID = db_obj.GetNewLecIDNumber();
                        lec_id_txt.Text = StudentID;
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

        private void lec_del_btn_Click(object sender, EventArgs e)
        {
            int LectureIDNumber = Convert.ToInt32(lec_id_txt.Text);

            DialogResult DeleteStudentDetails = MessageBox.Show("Are You Sure Want To Delete This Lecturer From The System ? ", "Lecturer Details Deletion...", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DeleteStudentDetails == DialogResult.OK)
            {
                if (db_obj.DeleteSelectedLecturerDetails(LectureIDNumber) == true)
                {
                    MessageBox.Show("Lecture Details Deletion Succesfully...!", "Lecture Details Deletion...");
                    GetLecturerDetailsList();
                }
                else
                {
                    MessageBox.Show("There Is Some Error Occured While Student Deletion...", "Database Or SQL Error...");
                }
            }
        }

        private void ResetAllFeilds()
        {
            lec_reg_btn.Enabled = true;
            lec_update_btn.Enabled = false;
            lec_del_btn.Enabled = false;

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
            lec_id_txt.Text = "";
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            ResetAllFeilds();
        }
    }
}
