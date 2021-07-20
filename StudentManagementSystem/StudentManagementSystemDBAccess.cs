using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;

namespace StudentManagementSystem
{
    class StudentManagementSystemDBAccess
    {
        SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\Sherlock\Documents\StudentManagementSystem.sdf;Password='root123'");
    
        internal string[] GetAdminDetails(string Username,string Password)
        {
 	        if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] AdminDetails = new string[2];
            SqlCeCommand GetAdminDetails = new SqlCeCommand("select * from admin_panel where username='" + Username + "' and password='" + Password + "'",conn);
            SqlCeDataReader SelectedCredentials = GetAdminDetails.ExecuteReader();

            while (SelectedCredentials.Read())
            {
                AdminDetails[0] = SelectedCredentials[0].ToString();
            }

            return AdminDetails;
        }

        internal string[] GetCourseCategoryDetails()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] CourseCategoryDetails = new string[10];
            SqlCeCommand GetCoursecategoryDetails = new SqlCeCommand("select * from course_category_details",conn);
            SqlCeDataReader Categorydetails = GetCoursecategoryDetails.ExecuteReader();

            int x = 0;
            while (Categorydetails.Read())
            {
                CourseCategoryDetails[x] = Categorydetails[1].ToString();
                    x++;
            }

            return CourseCategoryDetails;
        }

        internal string[] GetAvailableCourseDetails(string GetCoursCategory)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] AvailableCourseNames = new string[100];
            SqlCeCommand GetAvailableCourseDetails = new SqlCeCommand("select course_name from course_details where course_category = '" + GetCoursCategory + "'",conn);
            SqlCeDataReader AvailableCourseDetails = GetAvailableCourseDetails.ExecuteReader();

            int x = 0;
            while (AvailableCourseDetails.Read())
            {
                AvailableCourseNames[x] = AvailableCourseDetails[0].ToString();
                x++;
            }

            return AvailableCourseNames;
        }

        internal bool RegisterStudentDetails(string FirstName, string LastName, DateTime BirthDate, string MobileNumber, string EmailAddress, string Gender, string Address, string CourseCategory, string CourseName)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand RegisterNewStudent = new SqlCeCommand("insert into student_details (fname,lname,bdate,phone,email,gender,address,course_cat,course_name) values (@fname,@lname,@bdate,@phone,@email,@gender,@address,@course_cat,@course_name)", conn);
                RegisterNewStudent.Parameters.Add("@fname", FirstName);
                RegisterNewStudent.Parameters.Add("@lname", LastName);
                RegisterNewStudent.Parameters.Add("@bdate", BirthDate);
                RegisterNewStudent.Parameters.Add("@phone", MobileNumber);
                RegisterNewStudent.Parameters.Add("@email", EmailAddress);
                RegisterNewStudent.Parameters.Add("@gender", Gender);
                RegisterNewStudent.Parameters.Add("@address", Address);
                RegisterNewStudent.Parameters.Add("@course_cat", CourseCategory);
                RegisterNewStudent.Parameters.Add("@course_name", CourseName);

                RegisterNewStudent.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal string GetNewStuIDNumber()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string StuIndexNo = "";
            SqlCeCommand GetLastStudentIndexNo = new SqlCeCommand("select max(stu_id) from student_details",conn);
            SqlCeDataReader SelectedIndexNo = GetLastStudentIndexNo.ExecuteReader();

            while (SelectedIndexNo.Read())
            {
                StuIndexNo = SelectedIndexNo[0].ToString();
            }

            return StuIndexNo;
        }

        internal string[] GetStudentdetails(string GetStuIDNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] StudentDetails = new string[100];
            SqlCeCommand GetStudentDetails = new SqlCeCommand("select * from student_details where stu_id = '" + GetStuIDNumber + "'",conn);
            SqlCeDataReader selectedStudentdetails = GetStudentDetails.ExecuteReader();

            int x = 0;
            while (selectedStudentdetails.Read())
            {
                StudentDetails[0] = selectedStudentdetails[0].ToString();
                StudentDetails[1] = selectedStudentdetails[1].ToString();
                StudentDetails[2] = selectedStudentdetails[2].ToString();
                StudentDetails[3] = selectedStudentdetails[3].ToString();
                StudentDetails[4] = selectedStudentdetails[4].ToString();
                StudentDetails[5] = selectedStudentdetails[5].ToString();
                StudentDetails[6] = selectedStudentdetails[6].ToString();
                StudentDetails[7] = selectedStudentdetails[7].ToString();
                StudentDetails[8] = selectedStudentdetails[8].ToString();
                StudentDetails[9] = selectedStudentdetails[9].ToString();
            }

            return StudentDetails;
        }

        internal DataTable ReturnStudentDetailsList(SqlCeCommand GetStudentDetailsList)
        {
            GetStudentDetailsList.Connection = conn;
            SqlCeDataAdapter StudentDetailsAdapter = new SqlCeDataAdapter(GetStudentDetailsList);
            DataTable DetailsList = new DataTable();

            StudentDetailsAdapter.Fill(DetailsList);
            return DetailsList;
        }

        internal bool UpdateStudentDetails(int StudentIDNumber,string FirstName, string LastName, DateTime BirthDate, string MobileNumber, string EmailAddress, string Gender, string Address, string CourseCategory, string CourseName)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand UpdateStudentDetails = new SqlCeCommand("update student_details set fname='" + FirstName + "',lname='" + LastName + "',bdate='" + BirthDate + "',phone='" + MobileNumber + "',email='" + EmailAddress + "',gender='" + Gender + "',address='" + Address + "',course_cat='" + CourseCategory + "',course_name='" + CourseName + "' where stu_id='" + StudentIDNumber + "'", conn);
                UpdateStudentDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        internal bool DeleteSelectedStudentDetails(int StudentIDNumber)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteSelectedStudentDetails = new SqlCeCommand("delete from student_details where stu_id='" + StudentIDNumber + "'", conn);
                DeleteSelectedStudentDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal object ReturnLectureDetailsList(SqlCeCommand GetStudentDetailsList)
        {
            GetStudentDetailsList.Connection = conn;
            SqlCeDataAdapter StudentDetailsAdapter = new SqlCeDataAdapter(GetStudentDetailsList);
            DataTable DetailsList = new DataTable();

            StudentDetailsAdapter.Fill(DetailsList);
            return DetailsList;
        }

        internal string GetNewLecIDNumber()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string LecIndexNo = "";
            SqlCeCommand GetLastLecturerIndexNo = new SqlCeCommand("select max(lec_id) from lecturer_details", conn);
            SqlCeDataReader SelectedIndexNo = GetLastLecturerIndexNo.ExecuteReader();

            while (SelectedIndexNo.Read())
            {
                LecIndexNo = SelectedIndexNo[0].ToString();
            }

            return LecIndexNo;
        }

        internal bool RegisterLecturerDetails(string FirstName, string LastName, DateTime BirthDate, string MobileNumber, string EmailAddress, string Gender, string Address, string CourseCategory, string CourseName)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand RegisterNewStudent = new SqlCeCommand("insert into lecturer_details (fname,lname,bdate,phone,email,gender,address,course_cat,course_name) values (@fname,@lname,@bdate,@phone,@email,@gender,@address,@course_cat,@course_name)", conn);
                RegisterNewStudent.Parameters.Add("@fname", FirstName);
                RegisterNewStudent.Parameters.Add("@lname", LastName);
                RegisterNewStudent.Parameters.Add("@bdate", BirthDate);
                RegisterNewStudent.Parameters.Add("@phone", MobileNumber);
                RegisterNewStudent.Parameters.Add("@email", EmailAddress);
                RegisterNewStudent.Parameters.Add("@gender", Gender);
                RegisterNewStudent.Parameters.Add("@address", Address);
                RegisterNewStudent.Parameters.Add("@course_cat", CourseCategory);
                RegisterNewStudent.Parameters.Add("@course_name", CourseName);

                RegisterNewStudent.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal bool UpdateLecturerDetails(int LecturerIDNumber, string FirstName, string LastName, DateTime BirthDate, string MobileNumber, string EmailAddress, string Gender, string Address, string CourseCategory, string CourseName)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand UpdateLecturerDetails = new SqlCeCommand("update lecturer_details set fname='" + FirstName + "',lname='" + LastName + "',bdate='" + BirthDate + "',phone='" + MobileNumber + "',email='" + EmailAddress + "',gender='" + Gender + "',address='" + Address + "',course_cat='" + CourseCategory + "',course_name='" + CourseName + "' where lec_id='" + LecturerIDNumber + "'", conn);
                UpdateLecturerDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool DeleteSelectedLecturerDetails(int LectureIDNumber)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteSelectedLecturerDetails = new SqlCeCommand("delete from lecturer_details where stu_id='" + LectureIDNumber + "'", conn);
                DeleteSelectedLecturerDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal string[] GetLecturerdetails(string GetLecIDNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] LecturerDetails = new string[100];
            SqlCeCommand GetLecturerDetails = new SqlCeCommand("select * from lecturer_details where lec_id = '" + GetLecIDNumber + "'", conn);
            SqlCeDataReader selectedLecturerdetails = GetLecturerDetails.ExecuteReader();

            int x = 0;
            while (selectedLecturerdetails.Read())
            {
                LecturerDetails[0] = selectedLecturerdetails[0].ToString();
                LecturerDetails[1] = selectedLecturerdetails[1].ToString();
                LecturerDetails[2] = selectedLecturerdetails[2].ToString();
                LecturerDetails[3] = selectedLecturerdetails[3].ToString();
                LecturerDetails[4] = selectedLecturerdetails[4].ToString();
                LecturerDetails[5] = selectedLecturerdetails[5].ToString();
                LecturerDetails[6] = selectedLecturerdetails[6].ToString();
                LecturerDetails[7] = selectedLecturerdetails[7].ToString();
                LecturerDetails[8] = selectedLecturerdetails[8].ToString();
                LecturerDetails[9] = selectedLecturerdetails[9].ToString();
            }

            return LecturerDetails;
        }

        internal bool RegisterNewCourseDetails(string Selectedcategory, string CourseName, string CourseDecription)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand RegisterCourseDetails = new SqlCeCommand("insert into course_details (course_category,course_name,description) values (@course_cat,@course_name,@course_desc)", conn);
                RegisterCourseDetails.Parameters.Add("@course_cat", Selectedcategory);
                RegisterCourseDetails.Parameters.Add("@course_name", CourseName);
                RegisterCourseDetails.Parameters.Add("@course_desc", CourseDecription);

                RegisterCourseDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal DataTable GetRegisteredCoursedetails(SqlCeCommand GetRegisteredCourseDetails)
        {
            GetRegisteredCourseDetails.Connection = conn;
            DataTable RegisteredCourses = new DataTable();
            SqlCeDataAdapter SelectedCourseDetails = new SqlCeDataAdapter(GetRegisteredCourseDetails);
            SelectedCourseDetails.Fill(RegisteredCourses);

            return RegisteredCourses;
        }

        internal bool UpdateCourseDetails(string UpdatedCourseCategoty, string UpdatedCourseName, string UpdatedCourseDescription, int CourseIDNumber)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand UpdateSelectedCourseDetails = new SqlCeCommand("update course_details set course_category='" + UpdatedCourseCategoty + "',course_name='" + UpdatedCourseName + "',description='" + UpdatedCourseDescription + "' where course_id='" + CourseIDNumber + "'", conn);
                UpdateSelectedCourseDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal string[] GetCourseDetails(int CourseIDNumber)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] CourseDetails = new string[100];
            SqlCeCommand GetSelectedCourseDetails = new SqlCeCommand("select * from course_details where course_id='" + CourseIDNumber + "'",conn);
            SqlCeDataReader SelectedCourseDetails = GetSelectedCourseDetails.ExecuteReader();

            while (SelectedCourseDetails.Read())
            {
                CourseDetails[0] = SelectedCourseDetails[0].ToString();
                CourseDetails[1] = SelectedCourseDetails[1].ToString();
                CourseDetails[2] = SelectedCourseDetails[2].ToString();
                CourseDetails[3] = SelectedCourseDetails[3].ToString();
            }

            return CourseDetails;
        }

        internal bool DeleteSelectedCourseDetails(int CourseIDNumber)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteSelectedCourseDetails = new SqlCeCommand("delete from course_details where course_id='" + CourseIDNumber + "'", conn);
                DeleteSelectedCourseDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool RegisterCourseCategoryDetails(string CourseCategoryName, string CategoryDescription)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            try
            {
                SqlCeCommand RegisterNewCourseCategoryDetails = new SqlCeCommand("insert into course_category_details (name,decription) values (@name,@description)", conn);
                RegisterNewCourseCategoryDetails.Parameters.Add("@name", CourseCategoryName);
                RegisterNewCourseCategoryDetails.Parameters.Add("@description", CategoryDescription);

                RegisterNewCourseCategoryDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal string[] GetSelectedCourseCategorydetails(string GetCourseIDNumber)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] CourseCategoruDetails = new string[100];
            SqlCeCommand GetSelectedCourseCategoryDetails = new SqlCeCommand("select * from course_category_details where category_id = '" + GetCourseIDNumber + "'",conn);
            SqlCeDataReader CategoryDetails = GetSelectedCourseCategoryDetails.ExecuteReader();

            while (CategoryDetails.Read())
            {
                CourseCategoruDetails[0] = CategoryDetails[0].ToString();
                CourseCategoruDetails[1] = CategoryDetails[1].ToString();
                CourseCategoruDetails[2] = CategoryDetails[2].ToString();
            }

            return CourseCategoruDetails;
        }

        internal object GetRegistredCategoryDetails(SqlCeCommand GetRegistredCourseCategoryDetails)
        {
            GetRegistredCourseCategoryDetails.Connection = conn;

            DataTable CategoryDetailsTable = new DataTable();
            SqlCeDataAdapter categoryDetails = new SqlCeDataAdapter(GetRegistredCourseCategoryDetails);
            categoryDetails.Fill(CategoryDetailsTable);

            return CategoryDetailsTable;
        }

        internal bool UpdateCategorydetails(int CategoryIDNumber,string Updatedcategoryname,string UpdatedCategoryDescription)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand UpdateSelectedCategorydetails = new SqlCeCommand("update course_category_details set name='" + Updatedcategoryname + "' ,decription='" + UpdatedCategoryDescription + "' where category_id='" + CategoryIDNumber + "'", conn);
                UpdateSelectedCategorydetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool DeleteSelectedCategoryDetails(int SelectedCategoryIDNumber)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteSelectedCategoryDetails = new SqlCeCommand("delete from course_category_details where category_id='" + SelectedCategoryIDNumber + "'", conn);
                DeleteSelectedCategoryDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
