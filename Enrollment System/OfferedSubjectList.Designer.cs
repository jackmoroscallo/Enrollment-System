namespace Enrollment_System
{
    partial class OfferedSubjectList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfferedSubjectList));
            this.label2 = new System.Windows.Forms.Label();
            this.btnMainMenu2 = new System.Windows.Forms.Button();
            this.dgOfferedSubjectList = new System.Windows.Forms.DataGridView();
            this.btnSelect = new System.Windows.Forms.Button();
            this.cbSchoolYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSemester = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnViewSubjectOffered = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgOfferedSubjectList)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(725, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(327, 45);
            this.label2.TabIndex = 126;
            this.label2.Text = "Offered Subject List";
            // 
            // btnMainMenu2
            // 
            this.btnMainMenu2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnMainMenu2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMainMenu2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMainMenu2.Location = new System.Drawing.Point(12, 12);
            this.btnMainMenu2.Name = "btnMainMenu2";
            this.btnMainMenu2.Size = new System.Drawing.Size(147, 61);
            this.btnMainMenu2.TabIndex = 125;
            this.btnMainMenu2.Text = "Main Menu";
            this.btnMainMenu2.UseVisualStyleBackColor = false;
            this.btnMainMenu2.Click += new System.EventHandler(this.btnMainMenu2_Click);
            // 
            // dgOfferedSubjectList
            // 
            this.dgOfferedSubjectList.AllowUserToAddRows = false;
            this.dgOfferedSubjectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOfferedSubjectList.Location = new System.Drawing.Point(12, 89);
            this.dgOfferedSubjectList.Name = "dgOfferedSubjectList";
            this.dgOfferedSubjectList.RowHeadersWidth = 51;
            this.dgOfferedSubjectList.RowTemplate.Height = 24;
            this.dgOfferedSubjectList.Size = new System.Drawing.Size(1366, 872);
            this.dgOfferedSubjectList.TabIndex = 127;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSelect.BackColor = System.Drawing.Color.Lime;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSelect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelect.Location = new System.Drawing.Point(1410, 235);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(151, 55);
            this.btnSelect.TabIndex = 130;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSaveSection_Click);
            // 
            // cbSchoolYear
            // 
            this.cbSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.cbSchoolYear.FormattingEnabled = true;
            this.cbSchoolYear.Location = new System.Drawing.Point(1410, 137);
            this.cbSchoolYear.Name = "cbSchoolYear";
            this.cbSchoolYear.Size = new System.Drawing.Size(161, 37);
            this.cbSchoolYear.TabIndex = 129;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(1403, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 38);
            this.label1.TabIndex = 128;
            this.label1.Text = "School Year";
            // 
            // cbSemester
            // 
            this.cbSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.cbSemester.FormattingEnabled = true;
            this.cbSemester.Items.AddRange(new object[] {
            "1st Semester",
            "2nd Semester",
            "Summer"});
            this.cbSemester.Location = new System.Drawing.Point(1597, 137);
            this.cbSemester.Name = "cbSemester";
            this.cbSemester.Size = new System.Drawing.Size(210, 37);
            this.cbSemester.TabIndex = 132;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(1590, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 38);
            this.label3.TabIndex = 131;
            this.label3.Text = "Semester";
            // 
            // btnViewSubjectOffered
            // 
            this.btnViewSubjectOffered.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnViewSubjectOffered.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnViewSubjectOffered.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnViewSubjectOffered.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnViewSubjectOffered.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnViewSubjectOffered.Location = new System.Drawing.Point(1597, 235);
            this.btnViewSubjectOffered.Name = "btnViewSubjectOffered";
            this.btnViewSubjectOffered.Size = new System.Drawing.Size(151, 55);
            this.btnViewSubjectOffered.TabIndex = 133;
            this.btnViewSubjectOffered.Text = "View Subject";
            this.btnViewSubjectOffered.UseVisualStyleBackColor = false;
            this.btnViewSubjectOffered.Click += new System.EventHandler(this.btnViewSubjectOffered_Click);
            // 
            // OfferedSubjectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1770, 973);
            this.Controls.Add(this.btnViewSubjectOffered);
            this.Controls.Add(this.cbSemester);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.cbSchoolYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgOfferedSubjectList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMainMenu2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OfferedSubjectList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Offered Subject List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OfferedSubjectList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgOfferedSubjectList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMainMenu2;
        private System.Windows.Forms.DataGridView dgOfferedSubjectList;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ComboBox cbSchoolYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSemester;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnViewSubjectOffered;
    }
}