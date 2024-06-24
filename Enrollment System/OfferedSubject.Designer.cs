namespace Enrollment_System
{
    partial class OfferedSubject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfferedSubject));
            this.label2 = new System.Windows.Forms.Label();
            this.cbCourseCode = new System.Windows.Forms.ComboBox();
            this.btnSaveSection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgSubject = new System.Windows.Forms.DataGridView();
            this.SubjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCourseCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSubjectCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbUnits = new System.Windows.Forms.TextBox();
            this.tbSubjectDesc = new System.Windows.Forms.TextBox();
            this.tbSubjectHours = new System.Windows.Forms.TextBox();
            this.tbType = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbCapacity = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cbClassType = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbSubjectRate = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbSemester = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbSchoolYear = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbCourseCode2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbDay = new System.Windows.Forms.TextBox();
            this.cbSun = new System.Windows.Forms.CheckBox();
            this.cbSat = new System.Windows.Forms.CheckBox();
            this.cbFri = new System.Windows.Forms.CheckBox();
            this.cbThur = new System.Windows.Forms.CheckBox();
            this.cbWed = new System.Windows.Forms.CheckBox();
            this.cbTue = new System.Windows.Forms.CheckBox();
            this.cbMonday = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.cbSection = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbSubjectLevel = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbInstructor = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbRoom = new System.Windows.Forms.ComboBox();
            this.dtpTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpTimeStart = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgSubject)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cbCourseCode
            // 
            resources.ApplyResources(this.cbCourseCode, "cbCourseCode");
            this.cbCourseCode.FormattingEnabled = true;
            this.cbCourseCode.Name = "cbCourseCode";
            // 
            // btnSaveSection
            // 
            resources.ApplyResources(this.btnSaveSection, "btnSaveSection");
            this.btnSaveSection.BackColor = System.Drawing.Color.Lime;
            this.btnSaveSection.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSaveSection.Name = "btnSaveSection";
            this.btnSaveSection.UseVisualStyleBackColor = false;
            this.btnSaveSection.Click += new System.EventHandler(this.btnSaveSection_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // dgSubject
            // 
            this.dgSubject.AllowUserToAddRows = false;
            this.dgSubject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSubject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjectID});
            resources.ApplyResources(this.dgSubject, "dgSubject");
            this.dgSubject.Name = "dgSubject";
            this.dgSubject.RowTemplate.Height = 24;
            this.dgSubject.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSubject_CellClick);
            // 
            // SubjectID
            // 
            this.SubjectID.DataPropertyName = "SubjectID";
            resources.ApplyResources(this.SubjectID, "SubjectID");
            this.SubjectID.Name = "SubjectID";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // tbCourseCode
            // 
            resources.ApplyResources(this.tbCourseCode, "tbCourseCode");
            this.tbCourseCode.Name = "tbCourseCode";
            this.tbCourseCode.ReadOnly = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // tbSubjectCode
            // 
            resources.ApplyResources(this.tbSubjectCode, "tbSubjectCode");
            this.tbSubjectCode.Name = "tbSubjectCode";
            this.tbSubjectCode.ReadOnly = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // tbUnits
            // 
            resources.ApplyResources(this.tbUnits, "tbUnits");
            this.tbUnits.Name = "tbUnits";
            this.tbUnits.ReadOnly = true;
            // 
            // tbSubjectDesc
            // 
            resources.ApplyResources(this.tbSubjectDesc, "tbSubjectDesc");
            this.tbSubjectDesc.Name = "tbSubjectDesc";
            this.tbSubjectDesc.ReadOnly = true;
            // 
            // tbSubjectHours
            // 
            resources.ApplyResources(this.tbSubjectHours, "tbSubjectHours");
            this.tbSubjectHours.Name = "tbSubjectHours";
            this.tbSubjectHours.ReadOnly = true;
            // 
            // tbType
            // 
            resources.ApplyResources(this.tbType, "tbType");
            this.tbType.Name = "tbType";
            this.tbType.ReadOnly = true;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage1.Controls.Add(this.cbCapacity);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.cbClassType);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.tbSubjectRate);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.cbSemester);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.cbSchoolYear);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.tbCourseCode2);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.tbDay);
            this.tabPage1.Controls.Add(this.cbSun);
            this.tabPage1.Controls.Add(this.cbSat);
            this.tabPage1.Controls.Add(this.cbFri);
            this.tabPage1.Controls.Add(this.cbThur);
            this.tabPage1.Controls.Add(this.cbWed);
            this.tabPage1.Controls.Add(this.cbTue);
            this.tabPage1.Controls.Add(this.cbMonday);
            this.tabPage1.Controls.Add(this.btnAdd);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.cbSection);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.cbSubjectLevel);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.cbInstructor);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.cbRoom);
            this.tabPage1.Controls.Add(this.dtpTimeEnd);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.dtpTimeStart);
            this.tabPage1.Controls.Add(this.label10);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // cbCapacity
            // 
            resources.ApplyResources(this.cbCapacity, "cbCapacity");
            this.cbCapacity.FormattingEnabled = true;
            this.cbCapacity.Items.AddRange(new object[] {
            resources.GetString("cbCapacity.Items"),
            resources.GetString("cbCapacity.Items1"),
            resources.GetString("cbCapacity.Items2"),
            resources.GetString("cbCapacity.Items3"),
            resources.GetString("cbCapacity.Items4"),
            resources.GetString("cbCapacity.Items5")});
            this.cbCapacity.Name = "cbCapacity";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // cbClassType
            // 
            resources.ApplyResources(this.cbClassType, "cbClassType");
            this.cbClassType.FormattingEnabled = true;
            this.cbClassType.Items.AddRange(new object[] {
            resources.GetString("cbClassType.Items"),
            resources.GetString("cbClassType.Items1")});
            this.cbClassType.Name = "cbClassType";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // tbSubjectRate
            // 
            resources.ApplyResources(this.tbSubjectRate, "tbSubjectRate");
            this.tbSubjectRate.Name = "tbSubjectRate";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // cbSemester
            // 
            resources.ApplyResources(this.cbSemester, "cbSemester");
            this.cbSemester.FormattingEnabled = true;
            this.cbSemester.Items.AddRange(new object[] {
            resources.GetString("cbSemester.Items"),
            resources.GetString("cbSemester.Items1"),
            resources.GetString("cbSemester.Items2")});
            this.cbSemester.Name = "cbSemester";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // cbSchoolYear
            // 
            resources.ApplyResources(this.cbSchoolYear, "cbSchoolYear");
            this.cbSchoolYear.FormattingEnabled = true;
            this.cbSchoolYear.Name = "cbSchoolYear";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // tbCourseCode2
            // 
            resources.ApplyResources(this.tbCourseCode2, "tbCourseCode2");
            this.tbCourseCode2.Name = "tbCourseCode2";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // tbDay
            // 
            resources.ApplyResources(this.tbDay, "tbDay");
            this.tbDay.Name = "tbDay";
            // 
            // cbSun
            // 
            resources.ApplyResources(this.cbSun, "cbSun");
            this.cbSun.Name = "cbSun";
            this.cbSun.UseVisualStyleBackColor = true;
            this.cbSun.CheckedChanged += new System.EventHandler(this.cbSun_CheckedChanged);
            // 
            // cbSat
            // 
            resources.ApplyResources(this.cbSat, "cbSat");
            this.cbSat.Name = "cbSat";
            this.cbSat.UseVisualStyleBackColor = true;
            this.cbSat.CheckedChanged += new System.EventHandler(this.cbSat_CheckedChanged);
            // 
            // cbFri
            // 
            resources.ApplyResources(this.cbFri, "cbFri");
            this.cbFri.Name = "cbFri";
            this.cbFri.UseVisualStyleBackColor = true;
            this.cbFri.CheckedChanged += new System.EventHandler(this.cbFri_CheckedChanged);
            // 
            // cbThur
            // 
            resources.ApplyResources(this.cbThur, "cbThur");
            this.cbThur.Name = "cbThur";
            this.cbThur.UseVisualStyleBackColor = true;
            this.cbThur.CheckedChanged += new System.EventHandler(this.cbThur_CheckedChanged);
            // 
            // cbWed
            // 
            resources.ApplyResources(this.cbWed, "cbWed");
            this.cbWed.Name = "cbWed";
            this.cbWed.UseVisualStyleBackColor = true;
            this.cbWed.CheckedChanged += new System.EventHandler(this.cbWed_CheckedChanged);
            // 
            // cbTue
            // 
            resources.ApplyResources(this.cbTue, "cbTue");
            this.cbTue.Name = "cbTue";
            this.cbTue.UseVisualStyleBackColor = true;
            this.cbTue.CheckedChanged += new System.EventHandler(this.cbTue_CheckedChanged);
            // 
            // cbMonday
            // 
            resources.ApplyResources(this.cbMonday, "cbMonday");
            this.cbMonday.Name = "cbMonday";
            this.cbMonday.UseVisualStyleBackColor = true;
            this.cbMonday.CheckedChanged += new System.EventHandler(this.cbMonday_CheckedChanged);
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.BackColor = System.Drawing.Color.Lime;
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // cbSection
            // 
            resources.ApplyResources(this.cbSection, "cbSection");
            this.cbSection.FormattingEnabled = true;
            this.cbSection.Name = "cbSection";
            this.cbSection.SelectedIndexChanged += new System.EventHandler(this.cbSection_SelectedIndexChanged);
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // cbSubjectLevel
            // 
            resources.ApplyResources(this.cbSubjectLevel, "cbSubjectLevel");
            this.cbSubjectLevel.FormattingEnabled = true;
            this.cbSubjectLevel.Items.AddRange(new object[] {
            resources.GetString("cbSubjectLevel.Items"),
            resources.GetString("cbSubjectLevel.Items1"),
            resources.GetString("cbSubjectLevel.Items2"),
            resources.GetString("cbSubjectLevel.Items3")});
            this.cbSubjectLevel.Name = "cbSubjectLevel";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // cbInstructor
            // 
            resources.ApplyResources(this.cbInstructor, "cbInstructor");
            this.cbInstructor.FormattingEnabled = true;
            this.cbInstructor.Name = "cbInstructor";
            this.cbInstructor.SelectedIndexChanged += new System.EventHandler(this.cbInstructor_SelectedIndexChanged);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // cbRoom
            // 
            resources.ApplyResources(this.cbRoom, "cbRoom");
            this.cbRoom.FormattingEnabled = true;
            this.cbRoom.Name = "cbRoom";
            this.cbRoom.SelectedIndexChanged += new System.EventHandler(this.cbRoom_SelectedIndexChanged);
            // 
            // dtpTimeEnd
            // 
            resources.ApplyResources(this.dtpTimeEnd, "dtpTimeEnd");
            this.dtpTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeEnd.Name = "dtpTimeEnd";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // dtpTimeStart
            // 
            resources.ApplyResources(this.dtpTimeStart, "dtpTimeStart");
            this.dtpTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeStart.Name = "dtpTimeStart";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // OfferedSubject
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tbSubjectHours);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbUnits);
            this.Controls.Add(this.tbSubjectDesc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbSubjectCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbCourseCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgSubject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveSection);
            this.Controls.Add(this.cbCourseCode);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "OfferedSubject";
            this.Load += new System.EventHandler(this.OfferedSubject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSubject)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCourseCode;
        private System.Windows.Forms.Button btnSaveSection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgSubject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCourseCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSubjectCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbUnits;
        private System.Windows.Forms.TextBox tbSubjectDesc;
        private System.Windows.Forms.TextBox tbSubjectHours;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DateTimePicker dtpTimeStart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpTimeEnd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbRoom;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbInstructor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbSubjectLevel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbSection;
        private System.Windows.Forms.TextBox tbDay;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox cbWed;
        private System.Windows.Forms.CheckBox cbTue;
        private System.Windows.Forms.CheckBox cbMonday;
        private System.Windows.Forms.CheckBox cbSun;
        private System.Windows.Forms.CheckBox cbSat;
        private System.Windows.Forms.CheckBox cbFri;
        private System.Windows.Forms.CheckBox cbThur;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbCourseCode2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbSubjectRate;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbSemester;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbSchoolYear;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cbClassType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectID;
        private System.Windows.Forms.ComboBox cbCapacity;
    }
}