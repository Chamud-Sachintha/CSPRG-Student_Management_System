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
    public partial class CoursesManagement : UserControl
    {
        public CoursesManagement()
        {
            InitializeComponent();
        }

        StudentManagementSystemDBAccess db_obj = new StudentManagementSystemDBAccess();

        private void GetCourseCategoryDetails()
        {
            string[] AvailableCourseCategories = db_obj.GetCourseCategoryDetails();

            for (int each_categoty = 0; each_categoty <= AvailableCourseCategories.Length; each_categoty++)
            {
                if (AvailableCourseCategories[each_categoty] == null)
                {
                    break;
                }
                else
                {
                    course_cat_cmb.Items.Add(AvailableCourseCategories[each_categoty]);
                }
            }
        }

        private void GetregisteredCourseDetails()
        {
            SqlCeCommand GetRegisteredCourseDetails = new SqlCeCommand("select * from course_details");
            course_dataGridView1.ReadOnly = true;
            course_dataGridView1.DataSource = db_obj.GetRegisteredCoursedetails(GetRegisteredCourseDetails);
            course_dataGridView1.AllowUserToAddRows = false;
        }

        private void GetRegisteredCoursecategoryDetails()
        {
            SqlCeCommand GetRegistredCourseCategoryDetails = new SqlCeCommand("select * from course_category_details");
            cat_dataGridView2.ReadOnly = true;
            cat_dataGridView2.AllowUserToAddRows = false;
            cat_dataGridView2.DataSource = db_obj.GetRegistredCategoryDetails(GetRegistredCourseCategoryDetails);
        }

        private void CoursesManagement_Load(object sender, EventArgs e)
        {
            GetCourseCategoryDetails();
            GetregisteredCourseDetails();
            GetRegisteredCoursecategoryDetails();
        }

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

        private void addcourse_btn_Click(object sender, EventArgs e)
        {
            if (course_cat_cmb.SelectedItem == null)
            {
                MessageBox.Show("Please Fill Course Category Before Register Course Details.","Empty Feilds Found...");
            }
            else
            {
                string Selectedcategory = course_cat_cmb.SelectedItem.ToString();
                string CourseName = course_name_txt.Text;
                string CourseDecription = course_desc_txt.Text;

                if (ChkFeilds(Selectedcategory) == true && ChkFeilds(CourseName) == true && ChkFeilds(CourseDecription) == true)
                {
                    if (db_obj.RegisterNewCourseDetails(Selectedcategory, CourseName, CourseDecription) == true)
                    {
                        MessageBox.Show("Course Registration Succesfully...", "Course Registration...");
                        GetregisteredCourseDetails();
                    }
                    else
                    {
                        MessageBox.Show("Thereis some error occured while Course Registration...", "Database Or SQL Error...");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter All feilds Before Register Course...", "Empty feilds Found...");
                }
            } 
        }

        private void updatecourse_btn_Click(object sender, EventArgs e)
        {
            int CourseIDNumber = Convert.ToInt32(find_course_txt.Text);
            string UpdatedCourseCategoty = course_cat_cmb.SelectedItem.ToString();
            string UpdatedCourseName = course_name_txt.Text;
            string UpdatedCourseDescription = course_desc_txt.Text;

            if (ChkFeilds(UpdatedCourseName) == true && ChkFeilds(UpdatedCourseDescription) == true)
            {
                if (db_obj.UpdateCourseDetails(UpdatedCourseCategoty, UpdatedCourseName, UpdatedCourseDescription, CourseIDNumber) == true)
                {
                    MessageBox.Show("Course Details Updating Succesfully!...","Course Details Updating...");
                    GetregisteredCourseDetails();
                }
                else
                {
                    MessageBox.Show("There Is Error Occured While Course Details Updating...","Database Or SQL Error...");
                }
            }
            else
            {
                MessageBox.Show("Please Fill All Feilds Before Updating Course Details...","Empty Feilds Found..");
            }
        }

        private void find_course_btn_Click(object sender, EventArgs e)
        {
            int CourseIDNumber = Convert.ToInt32(find_course_txt.Text);
            string[] CourseDetails = db_obj.GetCourseDetails(CourseIDNumber);

            if (CourseDetails[0] != null)
            {
                course_cat_cmb.SelectedItem = CourseDetails[1].ToString();
                course_name_txt.Text = CourseDetails[2].ToString();
                course_desc_txt.Text = CourseDetails[3].ToString();

                course_id_txt.Text = CourseDetails[0].ToString();
            }
            else
            {
                MessageBox.Show("There Is No Course Details For That Course ID Number...","Invalid Course Id Number...");
            }
        }

        private void delcourse_btn_Click(object sender, EventArgs e)
        {
            int CourseIDNumber = Convert.ToInt32(find_course_txt.Text);
            DialogResult DeleteCourseDetails = MessageBox.Show("Are You Sure Want To delete This Course Details From The System ?","Course Deletion Confirmation.",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if (DeleteCourseDetails == DialogResult.OK)
            {
                if (db_obj.DeleteSelectedCourseDetails(CourseIDNumber) == true)
                {
                    MessageBox.Show("Selected Course Details Deletion Successfully!...", "Course Details Deletion.");
                    GetregisteredCourseDetails();
                }
                else
                {
                    MessageBox.Show("There Is Some Error Occured While Course Details deletion...","Database Or SQL Error...");
                }
            }
        }

        private void course_dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            course_cat_cmb.SelectedItem = course_dataGridView1.CurrentRow.Cells[1].Value.ToString();
            course_name_txt.Text = course_dataGridView1.CurrentRow.Cells[2].Value.ToString();
            course_desc_txt.Text = course_dataGridView1.CurrentRow.Cells[3].Value.ToString();

            course_id_txt.Text = course_dataGridView1.CurrentRow.Cells[0].Value.ToString();
            find_course_txt.Text = course_dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void add_cat_btn_Click(object sender, EventArgs e)
        {
            string CourseCategoryName = course_cat_txt.Text;
            string CategoryDescription = cat_desc_txt.Text;

            if (ChkFeilds(CourseCategoryName) == true && ChkFeilds(CategoryDescription) == true)
            {
                if (db_obj.RegisterCourseCategoryDetails(CourseCategoryName, CategoryDescription) == true)
                {
                    MessageBox.Show("Course Category Added Successfully...!","Course Category registration...");
                    GetRegisteredCoursecategoryDetails();
                }
                else
                {
                    MessageBox.Show("There Is Some Error Occured While Registration Course Category details...", "Database Or SQL Error.");
                }
            }
            else
            {
                MessageBox.Show("Please Fill All Neccessary feilds Before Registration.","Empty Feilds Fond...");
            }

        }

        private void find_cat_btn_Click(object sender, EventArgs e)
        {
            string GetCourseIDNumber = find_categoty_txt.Text;

            if (ChkFeilds(GetCourseIDNumber) == true)
            {
                string[] GetSelectedCourseCategoryDetails = db_obj.GetSelectedCourseCategorydetails(GetCourseIDNumber);

                if (GetSelectedCourseCategoryDetails[0] != null)
                {
                    course_cat_txt.Text = GetSelectedCourseCategoryDetails[1].ToString();
                    cat_desc_txt.Text = GetSelectedCourseCategoryDetails[2].ToString();
                    cat_id_txt.Text = GetSelectedCourseCategoryDetails[0].ToString();
                }
                else
                {
                    MessageBox.Show("There Is No Course Category Details For That ID Number.","Invalid Course Category ID Number...");
                }
            }
            else
            {
                MessageBox.Show("Please Fill All feilds Before Register Category details.", "Empty Felds Found...");
            }
        }

        private void update_cat_btn_Click(object sender, EventArgs e)
        {
            int CategoryIDNumber = Convert.ToInt32(find_categoty_txt.Text);
            string UpdatedCategoryName = course_cat_txt.Text;
            string UpdatedCategoryDecription = cat_desc_txt.Text;

            if (ChkFeilds(UpdatedCategoryName) == true && ChkFeilds(UpdatedCategoryDecription) == true)
            {
                if (db_obj.UpdateCategorydetails(CategoryIDNumber,UpdatedCategoryName,UpdatedCategoryDecription) == true)
                {
                    MessageBox.Show("Category details Updating Successfully...","Category details Updating...");
                    GetRegisteredCoursecategoryDetails();
                }
                else
                {
                    MessageBox.Show("There is An Error Occured While Updating Category details...","Database Or SQL Error...");
                }
            }
            else
            {
                MessageBox.Show("Please Fill All Feilds Before Update Category details...","Empty Feilds Found...");
            }
        }

        private void del_cat_btn_Click(object sender, EventArgs e)
        {
            int SelectedCategoryIDNumber = Convert.ToInt32(find_categoty_txt.Text);

            if (ChkFeilds(SelectedCategoryIDNumber.ToString()) == true)
            {
                DialogResult DeleteCategoryDetails = MessageBox.Show("Are You Sure Want To Delete This Category details From The System ? ","Category Details Deletion Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (DeleteCategoryDetails == DialogResult.OK)
                {
                    if (db_obj.DeleteSelectedCategoryDetails(SelectedCategoryIDNumber) == true)
                    {
                        MessageBox.Show("Selected Category details Deletion Successfully...","Category details Deletion...");
                        GetRegisteredCoursecategoryDetails();
                    }
                    else
                    {
                        MessageBox.Show("There Is An Error Occured While Category details Deletion...","database Or SQL Error...");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Enter the ID Number Before Delete Category Details...","Empty Feilds Found...");
            }
        }

        private void cat_dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            course_cat_txt.Text = cat_dataGridView2.CurrentRow.Cells[1].Value.ToString();
            cat_desc_txt.Text = cat_dataGridView2.CurrentRow.Cells[2].Value.ToString();
            cat_id_txt.Text = cat_dataGridView2.CurrentRow.Cells[0].Value.ToString();

            find_categoty_txt.Text = cat_dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
