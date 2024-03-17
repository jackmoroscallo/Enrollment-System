namespace Enrollment_System
{
    partial class StudentPayment
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
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSavePayment = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgPayment = new System.Windows.Forms.DataGridView();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchoolYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Term = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModeOfPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Details = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMainMenu2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.tbDetails = new System.Windows.Forms.TextBox();
            this.cbPaymentType = new System.Windows.Forms.ComboBox();
            this.cbModeOfPayment = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbPaidTo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.cbTerm = new System.Windows.Forms.ComboBox();
            this.cbSchoolYear = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbStudentID = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgPayment)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddPayment.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPayment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddPayment.Location = new System.Drawing.Point(1171, 711);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(151, 62);
            this.btnAddPayment.TabIndex = 110;
            this.btnAddPayment.Text = "Add Payment";
            this.btnAddPayment.UseVisualStyleBackColor = false;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClear.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClear.Location = new System.Drawing.Point(1766, 712);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(151, 62);
            this.btnClear.TabIndex = 109;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnUpdate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUpdate.Location = new System.Drawing.Point(1572, 712);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(159, 61);
            this.btnUpdate.TabIndex = 108;
            this.btnUpdate.Text = "Update Subject";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSavePayment
            // 
            this.btnSavePayment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSavePayment.BackColor = System.Drawing.Color.Lime;
            this.btnSavePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePayment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSavePayment.Location = new System.Drawing.Point(1363, 712);
            this.btnSavePayment.Name = "btnSavePayment";
            this.btnSavePayment.Size = new System.Drawing.Size(151, 62);
            this.btnSavePayment.TabIndex = 107;
            this.btnSavePayment.Text = "Save Payment";
            this.btnSavePayment.UseVisualStyleBackColor = false;
            this.btnSavePayment.Click += new System.EventHandler(this.btnSavePayment_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 105);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 31);
            this.label15.TabIndex = 95;
            this.label15.Text = "Keyword";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Location = new System.Drawing.Point(999, 139);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(134, 52);
            this.btnDelete.TabIndex = 94;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearch.Location = new System.Drawing.Point(859, 139);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(134, 52);
            this.btnSearch.TabIndex = 93;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(14, 149);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(839, 38);
            this.tbSearch.TabIndex = 92;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(931, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 45);
            this.label2.TabIndex = 91;
            this.label2.Text = "Student Payment";
            // 
            // dgPayment
            // 
            this.dgPayment.AllowUserToAddRows = false;
            this.dgPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.Description,
            this.Amount,
            this.PaymentType,
            this.SchoolYear,
            this.Term,
            this.PaymentDate,
            this.PaidTo,
            this.ModeOfPayment,
            this.Details});
            this.dgPayment.Location = new System.Drawing.Point(14, 200);
            this.dgPayment.Name = "dgPayment";
            this.dgPayment.RowHeadersWidth = 51;
            this.dgPayment.RowTemplate.Height = 24;
            this.dgPayment.Size = new System.Drawing.Size(1119, 745);
            this.dgPayment.TabIndex = 90;
            this.dgPayment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPayment_CellClick);
            // 
            // StudentID
            // 
            this.StudentID.DataPropertyName = "StudentID";
            this.StudentID.HeaderText = "Student ID";
            this.StudentID.MinimumWidth = 6;
            this.StudentID.Name = "StudentID";
            this.StudentID.Width = 130;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.Width = 130;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.MinimumWidth = 6;
            this.Amount.Name = "Amount";
            this.Amount.Width = 130;
            // 
            // PaymentType
            // 
            this.PaymentType.DataPropertyName = "PaymentType";
            this.PaymentType.HeaderText = "Payment Type";
            this.PaymentType.MinimumWidth = 6;
            this.PaymentType.Name = "PaymentType";
            this.PaymentType.Width = 130;
            // 
            // SchoolYear
            // 
            this.SchoolYear.DataPropertyName = "SchoolYear";
            this.SchoolYear.HeaderText = "School Year";
            this.SchoolYear.MinimumWidth = 6;
            this.SchoolYear.Name = "SchoolYear";
            this.SchoolYear.Width = 130;
            // 
            // Term
            // 
            this.Term.DataPropertyName = "Term";
            this.Term.HeaderText = "Term";
            this.Term.MinimumWidth = 6;
            this.Term.Name = "Term";
            this.Term.Width = 130;
            // 
            // PaymentDate
            // 
            this.PaymentDate.DataPropertyName = "PaymentDate";
            this.PaymentDate.HeaderText = "Payment Date";
            this.PaymentDate.MinimumWidth = 6;
            this.PaymentDate.Name = "PaymentDate";
            this.PaymentDate.Width = 136;
            // 
            // PaidTo
            // 
            this.PaidTo.DataPropertyName = "PaidTo";
            this.PaidTo.HeaderText = "Paid To";
            this.PaidTo.MinimumWidth = 6;
            this.PaidTo.Name = "PaidTo";
            this.PaidTo.Width = 125;
            // 
            // ModeOfPayment
            // 
            this.ModeOfPayment.DataPropertyName = "ModeOfPayment";
            this.ModeOfPayment.HeaderText = "Mode of Payment";
            this.ModeOfPayment.MinimumWidth = 6;
            this.ModeOfPayment.Name = "ModeOfPayment";
            this.ModeOfPayment.Width = 125;
            // 
            // Details
            // 
            this.Details.DataPropertyName = "Details";
            this.Details.HeaderText = "Details";
            this.Details.MinimumWidth = 6;
            this.Details.Name = "Details";
            this.Details.Width = 125;
            // 
            // btnMainMenu2
            // 
            this.btnMainMenu2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnMainMenu2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMainMenu2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMainMenu2.Location = new System.Drawing.Point(14, 27);
            this.btnMainMenu2.Name = "btnMainMenu2";
            this.btnMainMenu2.Size = new System.Drawing.Size(147, 61);
            this.btnMainMenu2.TabIndex = 89;
            this.btnMainMenu2.Text = "Main Menu";
            this.btnMainMenu2.UseVisualStyleBackColor = false;
            this.btnMainMenu2.Click += new System.EventHandler(this.btnMainMenu2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbStudentID);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.tbDetails);
            this.panel1.Controls.Add(this.cbPaymentType);
            this.panel1.Controls.Add(this.cbModeOfPayment);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cbPaidTo);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.dtpPaymentDate);
            this.panel1.Controls.Add(this.cbTerm);
            this.panel1.Controls.Add(this.cbSchoolYear);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbAmount);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbDescription);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1150, 149);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 521);
            this.panel1.TabIndex = 111;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(409, 410);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 29);
            this.label11.TabIndex = 141;
            this.label11.Text = "Details";
            // 
            // tbDetails
            // 
            this.tbDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDetails.Location = new System.Drawing.Point(411, 455);
            this.tbDetails.Name = "tbDetails";
            this.tbDetails.Size = new System.Drawing.Size(327, 34);
            this.tbDetails.TabIndex = 140;
            // 
            // cbPaymentType
            // 
            this.cbPaymentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPaymentType.FormattingEnabled = true;
            this.cbPaymentType.Items.AddRange(new object[] {
            "Tuition",
            "Book",
            "Sundries",
            "Others"});
            this.cbPaymentType.Location = new System.Drawing.Point(411, 171);
            this.cbPaymentType.Name = "cbPaymentType";
            this.cbPaymentType.Size = new System.Drawing.Size(327, 34);
            this.cbPaymentType.TabIndex = 139;
            // 
            // cbModeOfPayment
            // 
            this.cbModeOfPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbModeOfPayment.FormattingEnabled = true;
            this.cbModeOfPayment.Items.AddRange(new object[] {
            "Cash",
            "Online",
            "Cheque"});
            this.cbModeOfPayment.Location = new System.Drawing.Point(33, 455);
            this.cbModeOfPayment.Name = "cbModeOfPayment";
            this.cbModeOfPayment.Size = new System.Drawing.Size(327, 34);
            this.cbModeOfPayment.TabIndex = 138;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 410);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(200, 29);
            this.label10.TabIndex = 137;
            this.label10.Text = "Mode of Payment";
            // 
            // cbPaidTo
            // 
            this.cbPaidTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPaidTo.FormattingEnabled = true;
            this.cbPaidTo.Items.AddRange(new object[] {
            "LEC",
            "LAB"});
            this.cbPaidTo.Location = new System.Drawing.Point(411, 356);
            this.cbPaidTo.Name = "cbPaidTo";
            this.cbPaidTo.Size = new System.Drawing.Size(327, 34);
            this.cbPaidTo.TabIndex = 136;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(409, 311);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 29);
            this.label9.TabIndex = 135;
            this.label9.Text = "Paid To";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(34, 310);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 29);
            this.label8.TabIndex = 134;
            this.label8.Text = "Payment Date";
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPaymentDate.Location = new System.Drawing.Point(34, 355);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(326, 34);
            this.dtpPaymentDate.TabIndex = 133;
            // 
            // cbTerm
            // 
            this.cbTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTerm.FormattingEnabled = true;
            this.cbTerm.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbTerm.Location = new System.Drawing.Point(411, 265);
            this.cbTerm.Name = "cbTerm";
            this.cbTerm.Size = new System.Drawing.Size(327, 34);
            this.cbTerm.TabIndex = 132;
            // 
            // cbSchoolYear
            // 
            this.cbSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSchoolYear.FormattingEnabled = true;
            this.cbSchoolYear.Items.AddRange(new object[] {
            "LEC",
            "LAB"});
            this.cbSchoolYear.Location = new System.Drawing.Point(34, 265);
            this.cbSchoolYear.Name = "cbSchoolYear";
            this.cbSchoolYear.Size = new System.Drawing.Size(327, 34);
            this.cbSchoolYear.TabIndex = 131;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(406, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 29);
            this.label7.TabIndex = 130;
            this.label7.Text = "Term";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 29);
            this.label6.TabIndex = 129;
            this.label6.Text = "School Year";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(406, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 29);
            this.label5.TabIndex = 128;
            this.label5.Text = "Payment Type";
            // 
            // tbAmount
            // 
            this.tbAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAmount.Location = new System.Drawing.Point(34, 169);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(327, 34);
            this.tbAmount.TabIndex = 127;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 29);
            this.label4.TabIndex = 126;
            this.label4.Text = "Amount";
            // 
            // tbDescription
            // 
            this.tbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDescription.Location = new System.Drawing.Point(411, 81);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(327, 34);
            this.tbDescription.TabIndex = 124;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(409, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 29);
            this.label3.TabIndex = 123;
            this.label3.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 29);
            this.label1.TabIndex = 122;
            this.label1.Text = "Student ID";
            // 
            // cbStudentID
            // 
            this.cbStudentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStudentID.FormattingEnabled = true;
            this.cbStudentID.Location = new System.Drawing.Point(33, 81);
            this.cbStudentID.Name = "cbStudentID";
            this.cbStudentID.Size = new System.Drawing.Size(327, 34);
            this.cbStudentID.TabIndex = 142;
            // 
            // StudentPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 973);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAddPayment);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSavePayment);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgPayment);
            this.Controls.Add(this.btnMainMenu2);
            this.Name = "StudentPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentPayment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentPayment_FormClosing);
            this.Load += new System.EventHandler(this.StudentPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPayment)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSavePayment;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgPayment;
        private System.Windows.Forms.Button btnMainMenu2;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchoolYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Term;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModeOfPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Details;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbDetails;
        private System.Windows.Forms.ComboBox cbPaymentType;
        private System.Windows.Forms.ComboBox cbModeOfPayment;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbPaidTo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.ComboBox cbTerm;
        private System.Windows.Forms.ComboBox cbSchoolYear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbStudentID;
    }
}