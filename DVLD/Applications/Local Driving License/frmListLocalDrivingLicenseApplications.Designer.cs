namespace DVLD.Applications.Local_Driving_License
{
    partial class frmListLocalDrivingLicenseApplications
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowApplicationDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.EditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.CancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.ScheduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDrivingLicenseFirstTime = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLocalDrivingLicenseApplications = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddNewApplication = new System.Windows.Forms.Button();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.cmsApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(111, 288);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(210, 33);
            this.cbFilterBy.TabIndex = 138;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged_1);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(328, 288);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(256, 30);
            this.txtFilterValue.TabIndex = 137;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged_1);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 136;
            this.label1.Text = "Filter By:";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(305, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(305, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(305, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(305, 6);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(305, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(305, 6);
            // 
            // cmsApplications
            // 
            this.cmsApplications.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowApplicationDetails,
            this.toolStripSeparator2,
            this.EditApplication,
            this.DeleteApplication,
            this.toolStripSeparator5,
            this.CancelApplication,
            this.toolStripSeparator1,
            this.ScheduleTests,
            this.toolStripSeparator3,
            this.issueDrivingLicenseFirstTime,
            this.toolStripSeparator4,
            this.showLicense,
            this.toolStripSeparator6,
            this.showPersonLicenseHistory});
            this.cmsApplications.Name = "contextMenuStrip1";
            this.cmsApplications.Size = new System.Drawing.Size(309, 372);
            this.cmsApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApplications_Opening);
            // 
            // ShowApplicationDetails
            // 
            this.ShowApplicationDetails.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.ShowApplicationDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowApplicationDetails.Name = "ShowApplicationDetails";
            this.ShowApplicationDetails.Size = new System.Drawing.Size(308, 38);
            this.ShowApplicationDetails.Text = "&Show Application Details";
            this.ShowApplicationDetails.Click += new System.EventHandler(this.ShowApplicationDetails_Click);
            // 
            // EditApplication
            // 
            this.EditApplication.Image = global::DVLD.Properties.Resources.edit_32;
            this.EditApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditApplication.Name = "EditApplication";
            this.EditApplication.Size = new System.Drawing.Size(308, 38);
            this.EditApplication.Text = "&Edit Application";
            this.EditApplication.Click += new System.EventHandler(this.EditApplication_Click);
            // 
            // DeleteApplication
            // 
            this.DeleteApplication.Image = global::DVLD.Properties.Resources.Delete_32_2;
            this.DeleteApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DeleteApplication.Name = "DeleteApplication";
            this.DeleteApplication.Size = new System.Drawing.Size(308, 38);
            this.DeleteApplication.Text = "&Delete Application";
            this.DeleteApplication.Click += new System.EventHandler(this.DeleteApplication_Click);
            // 
            // CancelApplication
            // 
            this.CancelApplication.Image = global::DVLD.Properties.Resources.Delete_32;
            this.CancelApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CancelApplication.Name = "CancelApplication";
            this.CancelApplication.Size = new System.Drawing.Size(308, 38);
            this.CancelApplication.Text = "&Cancel Application";
            this.CancelApplication.Click += new System.EventHandler(this.CancelApplication_Click);
            // 
            // ScheduleTests
            // 
            this.ScheduleTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisionTest,
            this.scheduleWrittenTest,
            this.scheduleStreetTest});
            this.ScheduleTests.Image = global::DVLD.Properties.Resources.Schedule_Test_32;
            this.ScheduleTests.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ScheduleTests.Name = "ScheduleTests";
            this.ScheduleTests.Size = new System.Drawing.Size(308, 38);
            this.ScheduleTests.Text = "Sechdule &Tests";
            // 
            // scheduleVisionTest
            // 
            this.scheduleVisionTest.Image = global::DVLD.Properties.Resources.Vision_Test_32;
            this.scheduleVisionTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleVisionTest.Name = "scheduleVisionTest";
            this.scheduleVisionTest.Size = new System.Drawing.Size(247, 38);
            this.scheduleVisionTest.Text = "Schedule Vision Test";
            this.scheduleVisionTest.Click += new System.EventHandler(this.scheduleVisionTest_Click);
            // 
            // scheduleWrittenTest
            // 
            this.scheduleWrittenTest.Image = global::DVLD.Properties.Resources.Written_Test_32;
            this.scheduleWrittenTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleWrittenTest.Name = "scheduleWrittenTest";
            this.scheduleWrittenTest.Size = new System.Drawing.Size(247, 38);
            this.scheduleWrittenTest.Text = "Schedule Written Test";
            this.scheduleWrittenTest.Click += new System.EventHandler(this.scheduleWrittenTest_Click_1);
            // 
            // scheduleStreetTest
            // 
            this.scheduleStreetTest.Image = global::DVLD.Properties.Resources.Street_Test_32;
            this.scheduleStreetTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleStreetTest.Name = "scheduleStreetTest";
            this.scheduleStreetTest.Size = new System.Drawing.Size(247, 38);
            this.scheduleStreetTest.Text = "Schedule Street Test";
            this.scheduleStreetTest.Click += new System.EventHandler(this.scheduleStreetTest_Click_1);
            // 
            // issueDrivingLicenseFirstTime
            // 
            this.issueDrivingLicenseFirstTime.Image = global::DVLD.Properties.Resources.IssueDrivingLicense_32;
            this.issueDrivingLicenseFirstTime.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.issueDrivingLicenseFirstTime.Name = "issueDrivingLicenseFirstTime";
            this.issueDrivingLicenseFirstTime.Size = new System.Drawing.Size(308, 38);
            this.issueDrivingLicenseFirstTime.Text = "&Issue Driving License (First Time)";
            this.issueDrivingLicenseFirstTime.Click += new System.EventHandler(this.issueDrivingLicenseFirstTime_Click);
            // 
            // showLicense
            // 
            this.showLicense.Image = global::DVLD.Properties.Resources.License_View_32;
            this.showLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicense.Name = "showLicense";
            this.showLicense.Size = new System.Drawing.Size(308, 38);
            this.showLicense.Text = "Show &License";
            this.showLicense.Click += new System.EventHandler(this.showLicense_Click);
            // 
            // showPersonLicenseHistory
            // 
            this.showPersonLicenseHistory.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicenseHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonLicenseHistory.Name = "showPersonLicenseHistory";
            this.showPersonLicenseHistory.Size = new System.Drawing.Size(308, 38);
            this.showPersonLicenseHistory.Text = "Show Person License History";
            this.showPersonLicenseHistory.Click += new System.EventHandler(this.showPersonLicenseHistory_Click);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Location = new System.Drawing.Point(124, 693);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(36, 25);
            this.lblRecordsCount.TabIndex = 134;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 693);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 133;
            this.label2.Text = "# Records:";
            // 
            // dgvLocalDrivingLicenseApplications
            // 
            this.dgvLocalDrivingLicenseApplications.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToResizeRows = false;
            this.dgvLocalDrivingLicenseApplications.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalDrivingLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicenseApplications.ContextMenuStrip = this.cmsApplications;
            this.dgvLocalDrivingLicenseApplications.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLocalDrivingLicenseApplications.Location = new System.Drawing.Point(27, 337);
            this.dgvLocalDrivingLicenseApplications.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLocalDrivingLicenseApplications.MultiSelect = false;
            this.dgvLocalDrivingLicenseApplications.Name = "dgvLocalDrivingLicenseApplications";
            this.dgvLocalDrivingLicenseApplications.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalDrivingLicenseApplications.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalDrivingLicenseApplications.RowHeadersWidth = 51;
            this.dgvLocalDrivingLicenseApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalDrivingLicenseApplications.Size = new System.Drawing.Size(1405, 351);
            this.dgvLocalDrivingLicenseApplications.TabIndex = 132;
            this.dgvLocalDrivingLicenseApplications.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(414, 208);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(568, 39);
            this.lblTitle.TabIndex = 135;
            this.lblTitle.Text = "Local Driving License Applications";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Local_32;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(772, 81);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 141;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddNewApplication
            // 
            this.btnAddNewApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewApplication.Image = global::DVLD.Properties.Resources.New_Application_64;
            this.btnAddNewApplication.Location = new System.Drawing.Point(1361, 271);
            this.btnAddNewApplication.Name = "btnAddNewApplication";
            this.btnAddNewApplication.Size = new System.Drawing.Size(71, 58);
            this.btnAddNewApplication.TabIndex = 140;
            this.btnAddNewApplication.UseVisualStyleBackColor = true;
            this.btnAddNewApplication.Click += new System.EventHandler(this.btnAddNewApplication_Click);
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(596, 14);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(206, 169);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 139;
            this.pbPersonImage.TabStop = false;
            // 
            // frmListLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 727);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAddNewApplication);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvLocalDrivingLicenseApplications);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmListLocalDrivingLicenseApplications";
            this.Text = "List Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmListLocalDrivingLicenseApplications_Load);
            this.cmsApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAddNewApplication;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem showLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTime;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTest;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem ScheduleTests;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisionTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CancelApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem DeleteApplication;
        private System.Windows.Forms.ToolStripMenuItem EditApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ShowApplicationDetails;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicenseApplications;
        private System.Windows.Forms.Label lblTitle;
    }
}