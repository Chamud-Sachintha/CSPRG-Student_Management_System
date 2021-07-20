namespace StudentManagementSystem
{
    partial class CoursesManagement
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.delcourse_btn = new System.Windows.Forms.Button();
            this.updatecourse_btn = new System.Windows.Forms.Button();
            this.addcourse_btn = new System.Windows.Forms.Button();
            this.course_cat_cmb = new System.Windows.Forms.ComboBox();
            this.course_desc_txt = new System.Windows.Forms.TextBox();
            this.course_id_txt = new System.Windows.Forms.TextBox();
            this.course_name_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.del_cat_btn = new System.Windows.Forms.Button();
            this.update_cat_btn = new System.Windows.Forms.Button();
            this.add_cat_btn = new System.Windows.Forms.Button();
            this.cat_desc_txt = new System.Windows.Forms.TextBox();
            this.cat_id_txt = new System.Windows.Forms.TextBox();
            this.course_cat_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.course_dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.find_course_txt = new System.Windows.Forms.TextBox();
            this.find_course_btn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.find_categoty_txt = new System.Windows.Forms.TextBox();
            this.cat_dataGridView2 = new System.Windows.Forms.DataGridView();
            this.find_cat_btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.course_dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cat_dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.delcourse_btn);
            this.groupBox1.Controls.Add(this.updatecourse_btn);
            this.groupBox1.Controls.Add(this.addcourse_btn);
            this.groupBox1.Controls.Add(this.course_cat_cmb);
            this.groupBox1.Controls.Add(this.course_desc_txt);
            this.groupBox1.Controls.Add(this.course_id_txt);
            this.groupBox1.Controls.Add(this.course_name_txt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 370);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Details";
            // 
            // delcourse_btn
            // 
            this.delcourse_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delcourse_btn.Location = new System.Drawing.Point(428, 316);
            this.delcourse_btn.Name = "delcourse_btn";
            this.delcourse_btn.Size = new System.Drawing.Size(154, 45);
            this.delcourse_btn.TabIndex = 3;
            this.delcourse_btn.Text = "Delete Course";
            this.delcourse_btn.UseVisualStyleBackColor = true;
            this.delcourse_btn.Click += new System.EventHandler(this.delcourse_btn_Click);
            // 
            // updatecourse_btn
            // 
            this.updatecourse_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatecourse_btn.Location = new System.Drawing.Point(242, 316);
            this.updatecourse_btn.Name = "updatecourse_btn";
            this.updatecourse_btn.Size = new System.Drawing.Size(154, 45);
            this.updatecourse_btn.TabIndex = 3;
            this.updatecourse_btn.Text = "Update Course";
            this.updatecourse_btn.UseVisualStyleBackColor = true;
            this.updatecourse_btn.Click += new System.EventHandler(this.updatecourse_btn_Click);
            // 
            // addcourse_btn
            // 
            this.addcourse_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addcourse_btn.Location = new System.Drawing.Point(45, 316);
            this.addcourse_btn.Name = "addcourse_btn";
            this.addcourse_btn.Size = new System.Drawing.Size(154, 45);
            this.addcourse_btn.TabIndex = 3;
            this.addcourse_btn.Text = "Add Course";
            this.addcourse_btn.UseVisualStyleBackColor = true;
            this.addcourse_btn.Click += new System.EventHandler(this.addcourse_btn_Click);
            // 
            // course_cat_cmb
            // 
            this.course_cat_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.course_cat_cmb.FormattingEnabled = true;
            this.course_cat_cmb.Location = new System.Drawing.Point(118, 44);
            this.course_cat_cmb.Name = "course_cat_cmb";
            this.course_cat_cmb.Size = new System.Drawing.Size(184, 32);
            this.course_cat_cmb.TabIndex = 2;
            // 
            // course_desc_txt
            // 
            this.course_desc_txt.Location = new System.Drawing.Point(118, 113);
            this.course_desc_txt.Multiline = true;
            this.course_desc_txt.Name = "course_desc_txt";
            this.course_desc_txt.Size = new System.Drawing.Size(491, 107);
            this.course_desc_txt.TabIndex = 1;
            // 
            // course_id_txt
            // 
            this.course_id_txt.Location = new System.Drawing.Point(180, 260);
            this.course_id_txt.Name = "course_id_txt";
            this.course_id_txt.Size = new System.Drawing.Size(216, 29);
            this.course_id_txt.TabIndex = 1;
            // 
            // course_name_txt
            // 
            this.course_name_txt.Location = new System.Drawing.Point(393, 47);
            this.course_name_txt.Name = "course_name_txt";
            this.course_name_txt.Size = new System.Drawing.Size(216, 29);
            this.course_name_txt.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Course ID Number :- ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Description :- ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(319, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name :- ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category :- ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.del_cat_btn);
            this.groupBox2.Controls.Add(this.update_cat_btn);
            this.groupBox2.Controls.Add(this.add_cat_btn);
            this.groupBox2.Controls.Add(this.cat_desc_txt);
            this.groupBox2.Controls.Add(this.cat_id_txt);
            this.groupBox2.Controls.Add(this.course_cat_txt);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(711, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 370);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Category Details";
            // 
            // del_cat_btn
            // 
            this.del_cat_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.del_cat_btn.Location = new System.Drawing.Point(425, 316);
            this.del_cat_btn.Name = "del_cat_btn";
            this.del_cat_btn.Size = new System.Drawing.Size(154, 45);
            this.del_cat_btn.TabIndex = 3;
            this.del_cat_btn.Text = "Delete Category";
            this.del_cat_btn.UseVisualStyleBackColor = true;
            this.del_cat_btn.Click += new System.EventHandler(this.del_cat_btn_Click);
            // 
            // update_cat_btn
            // 
            this.update_cat_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_cat_btn.Location = new System.Drawing.Point(239, 316);
            this.update_cat_btn.Name = "update_cat_btn";
            this.update_cat_btn.Size = new System.Drawing.Size(154, 45);
            this.update_cat_btn.TabIndex = 3;
            this.update_cat_btn.Text = "Update Caregory";
            this.update_cat_btn.UseVisualStyleBackColor = true;
            this.update_cat_btn.Click += new System.EventHandler(this.update_cat_btn_Click);
            // 
            // add_cat_btn
            // 
            this.add_cat_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_cat_btn.Location = new System.Drawing.Point(42, 316);
            this.add_cat_btn.Name = "add_cat_btn";
            this.add_cat_btn.Size = new System.Drawing.Size(154, 45);
            this.add_cat_btn.TabIndex = 3;
            this.add_cat_btn.Text = "Add Category";
            this.add_cat_btn.UseVisualStyleBackColor = true;
            this.add_cat_btn.Click += new System.EventHandler(this.add_cat_btn_Click);
            // 
            // cat_desc_txt
            // 
            this.cat_desc_txt.Location = new System.Drawing.Point(106, 113);
            this.cat_desc_txt.Multiline = true;
            this.cat_desc_txt.Name = "cat_desc_txt";
            this.cat_desc_txt.Size = new System.Drawing.Size(491, 107);
            this.cat_desc_txt.TabIndex = 1;
            // 
            // cat_id_txt
            // 
            this.cat_id_txt.Location = new System.Drawing.Point(217, 260);
            this.cat_id_txt.Name = "cat_id_txt";
            this.cat_id_txt.Size = new System.Drawing.Size(216, 29);
            this.cat_id_txt.TabIndex = 1;
            // 
            // course_cat_txt
            // 
            this.course_cat_txt.Location = new System.Drawing.Point(106, 50);
            this.course_cat_txt.Name = "course_cat_txt";
            this.course_cat_txt.Size = new System.Drawing.Size(216, 29);
            this.course_cat_txt.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Course Category Number :- ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Description :- ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Name :- ";
            // 
            // course_dataGridView1
            // 
            this.course_dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.course_dataGridView1.Location = new System.Drawing.Point(0, 435);
            this.course_dataGridView1.Name = "course_dataGridView1";
            this.course_dataGridView1.RowHeadersWidth = 230;
            this.course_dataGridView1.Size = new System.Drawing.Size(633, 245);
            this.course_dataGridView1.TabIndex = 1;
            this.course_dataGridView1.DoubleClick += new System.EventHandler(this.course_dataGridView1_DoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 398);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Course ID Number :- ";
            // 
            // find_course_txt
            // 
            this.find_course_txt.Location = new System.Drawing.Point(183, 398);
            this.find_course_txt.Name = "find_course_txt";
            this.find_course_txt.Size = new System.Drawing.Size(133, 20);
            this.find_course_txt.TabIndex = 1;
            // 
            // find_course_btn
            // 
            this.find_course_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find_course_btn.Location = new System.Drawing.Point(331, 389);
            this.find_course_btn.Name = "find_course_btn";
            this.find_course_btn.Size = new System.Drawing.Size(115, 29);
            this.find_course_btn.TabIndex = 3;
            this.find_course_btn.Text = "Find Course";
            this.find_course_btn.UseVisualStyleBackColor = true;
            this.find_course_btn.Click += new System.EventHandler(this.find_course_btn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(715, 398);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Category ID Number :- ";
            // 
            // find_categoty_txt
            // 
            this.find_categoty_txt.Location = new System.Drawing.Point(894, 398);
            this.find_categoty_txt.Name = "find_categoty_txt";
            this.find_categoty_txt.Size = new System.Drawing.Size(133, 20);
            this.find_categoty_txt.TabIndex = 1;
            // 
            // cat_dataGridView2
            // 
            this.cat_dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cat_dataGridView2.Location = new System.Drawing.Point(711, 435);
            this.cat_dataGridView2.Name = "cat_dataGridView2";
            this.cat_dataGridView2.RowHeadersWidth = 330;
            this.cat_dataGridView2.Size = new System.Drawing.Size(633, 245);
            this.cat_dataGridView2.TabIndex = 1;
            this.cat_dataGridView2.DoubleClick += new System.EventHandler(this.cat_dataGridView2_DoubleClick);
            // 
            // find_cat_btn
            // 
            this.find_cat_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find_cat_btn.Location = new System.Drawing.Point(1042, 389);
            this.find_cat_btn.Name = "find_cat_btn";
            this.find_cat_btn.Size = new System.Drawing.Size(115, 29);
            this.find_cat_btn.TabIndex = 3;
            this.find_cat_btn.Text = "Find Course";
            this.find_cat_btn.UseVisualStyleBackColor = true;
            this.find_cat_btn.Click += new System.EventHandler(this.find_cat_btn_Click);
            // 
            // CoursesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.find_cat_btn);
            this.Controls.Add(this.find_course_btn);
            this.Controls.Add(this.cat_dataGridView2);
            this.Controls.Add(this.course_dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.find_categoty_txt);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.find_course_txt);
            this.Controls.Add(this.label9);
            this.Name = "CoursesManagement";
            this.Size = new System.Drawing.Size(1366, 680);
            this.Load += new System.EventHandler(this.CoursesManagement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.course_dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cat_dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button delcourse_btn;
        private System.Windows.Forms.Button updatecourse_btn;
        private System.Windows.Forms.Button addcourse_btn;
        private System.Windows.Forms.ComboBox course_cat_cmb;
        private System.Windows.Forms.TextBox course_desc_txt;
        private System.Windows.Forms.TextBox course_id_txt;
        private System.Windows.Forms.TextBox course_name_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button del_cat_btn;
        private System.Windows.Forms.Button update_cat_btn;
        private System.Windows.Forms.Button add_cat_btn;
        private System.Windows.Forms.TextBox cat_desc_txt;
        private System.Windows.Forms.TextBox cat_id_txt;
        private System.Windows.Forms.TextBox course_cat_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView course_dataGridView1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox find_course_txt;
        private System.Windows.Forms.Button find_course_btn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox find_categoty_txt;
        private System.Windows.Forms.DataGridView cat_dataGridView2;
        private System.Windows.Forms.Button find_cat_btn;
    }
}
