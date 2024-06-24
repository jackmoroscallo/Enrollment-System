namespace Enrollment_System.AdminForms
{
    partial class StudentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentList));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchFilter = new System.Windows.Forms.Button();
            this.cbCourseCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgStudentList = new System.Windows.Forms.DataGridView();
            this.btnSelectSchedule = new System.Windows.Forms.Button();
            this.cbYearLevel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgStudentList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "List of Students";
            // 
            // btnSearchFilter
            // 
            this.btnSearchFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSearchFilter.BackColor = System.Drawing.Color.Lime;
            this.btnSearchFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSearchFilter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearchFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearchFilter.Location = new System.Drawing.Point(470, 89);
            this.btnSearchFilter.Name = "btnSearchFilter";
            this.btnSearchFilter.Size = new System.Drawing.Size(151, 45);
            this.btnSearchFilter.TabIndex = 126;
            this.btnSearchFilter.Text = "Filter";
            this.btnSearchFilter.UseVisualStyleBackColor = false;
            this.btnSearchFilter.Click += new System.EventHandler(this.btnSearchFilter_Click);
            // 
            // cbCourseCode
            // 
            this.cbCourseCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.cbCourseCode.FormattingEnabled = true;
            this.cbCourseCode.Items.AddRange(new object[] {
            "BSIT",
            "BSN",
            "BSHM",
            "BSMT"});
            this.cbCourseCode.Location = new System.Drawing.Point(12, 97);
            this.cbCourseCode.Name = "cbCourseCode";
            this.cbCourseCode.Size = new System.Drawing.Size(194, 37);
            this.cbCourseCode.TabIndex = 125;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 28);
            this.label2.TabIndex = 124;
            this.label2.Text = "Select Course";
            // 
            // dgStudentList
            // 
            this.dgStudentList.AllowUserToAddRows = false;
            this.dgStudentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStudentList.Location = new System.Drawing.Point(12, 140);
            this.dgStudentList.Name = "dgStudentList";
            this.dgStudentList.ReadOnly = true;
            this.dgStudentList.RowHeadersWidth = 51;
            this.dgStudentList.RowTemplate.Height = 24;
            this.dgStudentList.Size = new System.Drawing.Size(1327, 460);
            this.dgStudentList.TabIndex = 127;
            // 
            // btnSelectSchedule
            // 
            this.btnSelectSchedule.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSelectSchedule.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSelectSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectSchedule.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelectSchedule.Location = new System.Drawing.Point(1149, 618);
            this.btnSelectSchedule.Name = "btnSelectSchedule";
            this.btnSelectSchedule.Size = new System.Drawing.Size(190, 62);
            this.btnSelectSchedule.TabIndex = 128;
            this.btnSelectSchedule.Text = "Select Student";
            this.btnSelectSchedule.UseVisualStyleBackColor = false;
            this.btnSelectSchedule.Click += new System.EventHandler(this.btnSelectSchedule_Click);
            // 
            // cbYearLevel
            // 
            this.cbYearLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.cbYearLevel.FormattingEnabled = true;
            this.cbYearLevel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbYearLevel.Location = new System.Drawing.Point(244, 97);
            this.cbYearLevel.Name = "cbYearLevel";
            this.cbYearLevel.Size = new System.Drawing.Size(194, 37);
            this.cbYearLevel.TabIndex = 129;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(239, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 28);
            this.label3.TabIndex = 130;
            this.label3.Text = "Select Year Level";
            // 
            // StudentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1351, 708);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbYearLevel);
            this.Controls.Add(this.btnSelectSchedule);
            this.Controls.Add(this.dgStudentList);
            this.Controls.Add(this.btnSearchFilter);
            this.Controls.Add(this.cbCourseCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentList_FormClosing);
            this.Load += new System.EventHandler(this.StudentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgStudentList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchFilter;
        private System.Windows.Forms.ComboBox cbCourseCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgStudentList;
        private System.Windows.Forms.Button btnSelectSchedule;
        private System.Windows.Forms.ComboBox cbYearLevel;
        private System.Windows.Forms.Label label3;
    }
}