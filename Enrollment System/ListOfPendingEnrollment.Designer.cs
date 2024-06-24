namespace Enrollment_System
{
    partial class ListOfPendingEnrollment
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListOfPendingEnrollment));
            this.label3 = new System.Windows.Forms.Label();
            this.cbSemester = new System.Windows.Forms.ComboBox();
            this.btnSelectStudent = new System.Windows.Forms.Button();
            this.dgStudentList = new System.Windows.Forms.DataGridView();
            this.btnSearchFilter = new System.Windows.Forms.Button();
            this.cbSchoolYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgStudentList)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(239, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 28);
            this.label3.TabIndex = 138;
            this.label3.Text = "Select Semester";
            // 
            // cbSemester
            // 
            this.cbSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.cbSemester.FormattingEnabled = true;
            this.cbSemester.Items.AddRange(new object[] {
            "1st Semester",
            "2nd Semester",
            "Summer"});
            this.cbSemester.Location = new System.Drawing.Point(244, 107);
            this.cbSemester.Name = "cbSemester";
            this.cbSemester.Size = new System.Drawing.Size(194, 37);
            this.cbSemester.TabIndex = 137;
            // 
            // btnSelectStudent
            // 
            this.btnSelectStudent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSelectStudent.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSelectStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectStudent.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelectStudent.Location = new System.Drawing.Point(1149, 628);
            this.btnSelectStudent.Name = "btnSelectStudent";
            this.btnSelectStudent.Size = new System.Drawing.Size(190, 62);
            this.btnSelectStudent.TabIndex = 136;
            this.btnSelectStudent.Text = "Select Student";
            this.btnSelectStudent.UseVisualStyleBackColor = false;
            this.btnSelectStudent.Click += new System.EventHandler(this.btnSelectSchedule_Click);
            // 
            // dgStudentList
            // 
            this.dgStudentList.AllowUserToAddRows = false;
            this.dgStudentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStudentList.Location = new System.Drawing.Point(12, 150);
            this.dgStudentList.Name = "dgStudentList";
            this.dgStudentList.ReadOnly = true;
            this.dgStudentList.RowHeadersWidth = 51;
            this.dgStudentList.RowTemplate.Height = 24;
            this.dgStudentList.Size = new System.Drawing.Size(1327, 460);
            this.dgStudentList.TabIndex = 135;
            // 
            // btnSearchFilter
            // 
            this.btnSearchFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSearchFilter.BackColor = System.Drawing.Color.Lime;
            this.btnSearchFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSearchFilter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearchFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearchFilter.Location = new System.Drawing.Point(470, 99);
            this.btnSearchFilter.Name = "btnSearchFilter";
            this.btnSearchFilter.Size = new System.Drawing.Size(151, 45);
            this.btnSearchFilter.TabIndex = 134;
            this.btnSearchFilter.Text = "Filter";
            this.btnSearchFilter.UseVisualStyleBackColor = false;
            this.btnSearchFilter.Click += new System.EventHandler(this.btnSearchFilter_Click);
            // 
            // cbSchoolYear
            // 
            this.cbSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.cbSchoolYear.FormattingEnabled = true;
            this.cbSchoolYear.Items.AddRange(new object[] {
            "BSIT",
            "BSN",
            "BSHM",
            "BSMT"});
            this.cbSchoolYear.Location = new System.Drawing.Point(12, 107);
            this.cbSchoolYear.Name = "cbSchoolYear";
            this.cbSchoolYear.Size = new System.Drawing.Size(194, 37);
            this.cbSchoolYear.TabIndex = 133;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 28);
            this.label2.TabIndex = 132;
            this.label2.Text = "Select School Year";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 38);
            this.label1.TabIndex = 131;
            this.label1.Text = "Pending Enrollments";
            // 
            // ListOfPendingEnrollment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1351, 708);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSemester);
            this.Controls.Add(this.btnSelectStudent);
            this.Controls.Add(this.dgStudentList);
            this.Controls.Add(this.btnSearchFilter);
            this.Controls.Add(this.cbSchoolYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListOfPendingEnrollment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListOfPendingEnrollment";
            this.Load += new System.EventHandler(this.ListOfPendingEnrollment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgStudentList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSemester;
        private System.Windows.Forms.Button btnSelectStudent;
        private System.Windows.Forms.DataGridView dgStudentList;
        private System.Windows.Forms.Button btnSearchFilter;
        private System.Windows.Forms.ComboBox cbSchoolYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}