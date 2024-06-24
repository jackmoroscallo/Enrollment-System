namespace Enrollment_System
{
    partial class PendingEnrollment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PendingEnrollment));
            this.btnEnrollStudent = new System.Windows.Forms.Button();
            this.tbYearLevel = new System.Windows.Forms.TextBox();
            this.tbCourse = new System.Windows.Forms.TextBox();
            this.tbIDNumber = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.dgStudentSubjects = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEnrollmentDate = new System.Windows.Forms.TextBox();
            this.tbEnrollmentStatus = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgStudentSubjects)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnrollStudent
            // 
            this.btnEnrollStudent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEnrollStudent.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEnrollStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnrollStudent.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEnrollStudent.Location = new System.Drawing.Point(979, 603);
            this.btnEnrollStudent.Name = "btnEnrollStudent";
            this.btnEnrollStudent.Size = new System.Drawing.Size(183, 53);
            this.btnEnrollStudent.TabIndex = 139;
            this.btnEnrollStudent.Text = "Enroll Student";
            this.btnEnrollStudent.UseVisualStyleBackColor = false;
            this.btnEnrollStudent.Click += new System.EventHandler(this.btnEnrollStudent_Click);
            // 
            // tbYearLevel
            // 
            this.tbYearLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbYearLevel.Location = new System.Drawing.Point(319, 140);
            this.tbYearLevel.Name = "tbYearLevel";
            this.tbYearLevel.ReadOnly = true;
            this.tbYearLevel.Size = new System.Drawing.Size(248, 34);
            this.tbYearLevel.TabIndex = 138;
            // 
            // tbCourse
            // 
            this.tbCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCourse.Location = new System.Drawing.Point(17, 140);
            this.tbCourse.Name = "tbCourse";
            this.tbCourse.ReadOnly = true;
            this.tbCourse.Size = new System.Drawing.Size(248, 34);
            this.tbCourse.TabIndex = 137;
            // 
            // tbIDNumber
            // 
            this.tbIDNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIDNumber.Location = new System.Drawing.Point(17, 78);
            this.tbIDNumber.Name = "tbIDNumber";
            this.tbIDNumber.ReadOnly = true;
            this.tbIDNumber.Size = new System.Drawing.Size(248, 34);
            this.tbIDNumber.TabIndex = 136;
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(319, 78);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(542, 34);
            this.tbName.TabIndex = 135;
            // 
            // dgStudentSubjects
            // 
            this.dgStudentSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStudentSubjects.Location = new System.Drawing.Point(12, 196);
            this.dgStudentSubjects.Name = "dgStudentSubjects";
            this.dgStudentSubjects.RowHeadersWidth = 51;
            this.dgStudentSubjects.RowTemplate.Height = 24;
            this.dgStudentSubjects.Size = new System.Drawing.Size(1150, 389);
            this.dgStudentSubjects.TabIndex = 133;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 132;
            this.label1.Text = "STUDENT INFO";
            // 
            // tbEnrollmentDate
            // 
            this.tbEnrollmentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEnrollmentDate.Location = new System.Drawing.Point(613, 140);
            this.tbEnrollmentDate.Name = "tbEnrollmentDate";
            this.tbEnrollmentDate.ReadOnly = true;
            this.tbEnrollmentDate.Size = new System.Drawing.Size(248, 34);
            this.tbEnrollmentDate.TabIndex = 140;
            // 
            // tbEnrollmentStatus
            // 
            this.tbEnrollmentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEnrollmentStatus.Location = new System.Drawing.Point(914, 140);
            this.tbEnrollmentStatus.Name = "tbEnrollmentStatus";
            this.tbEnrollmentStatus.ReadOnly = true;
            this.tbEnrollmentStatus.Size = new System.Drawing.Size(248, 34);
            this.tbEnrollmentStatus.TabIndex = 141;
            // 
            // PendingEnrollment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1203, 706);
            this.Controls.Add(this.tbEnrollmentStatus);
            this.Controls.Add(this.tbEnrollmentDate);
            this.Controls.Add(this.btnEnrollStudent);
            this.Controls.Add(this.tbYearLevel);
            this.Controls.Add(this.tbCourse);
            this.Controls.Add(this.tbIDNumber);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.dgStudentSubjects);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PendingEnrollment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PendingEnrollment";
            this.Load += new System.EventHandler(this.PendingEnrollment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgStudentSubjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEnrollStudent;
        public System.Windows.Forms.TextBox tbYearLevel;
        public System.Windows.Forms.TextBox tbCourse;
        public System.Windows.Forms.TextBox tbIDNumber;
        public System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.DataGridView dgStudentSubjects;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbEnrollmentDate;
        public System.Windows.Forms.TextBox tbEnrollmentStatus;
    }
}