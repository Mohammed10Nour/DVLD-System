using DVLD.Class_Global;
using DVLD_Business;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {
       public enum enMode { AddNew=1,Update=2};
       public enMode Mode =enMode.AddNew;
     
       public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication;
       public int LocalDrivingLicenseApplicationID;

        private int _SelectedPersonID;
        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            Mode = enMode.AddNew;

        }
        public frmAddUpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            Mode = enMode.Update;

        }
        private void _FillComboBoxWithData()
        {
            DataTable _dtLicenseClass = clsLicenseClass.GetAllLicenseClasses();
            foreach (DataRow Rows in _dtLicenseClass.Rows)
            {
                cbLicenseClass.Items.Add(Rows["ClassName"]);
            }
          
        }
        private void _AddNewStatus()
        {
             this.Text = " New ";
            lblTitle.Text = " New Local Driving License Application";
            LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
            lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            tpApplicationInfo.Enabled = false;
            btnSave.Enabled = false;
            cbLicenseClass.SelectedIndex = 2;
        }
        private void _UpdateStatus()
        {
            this.Text = "Update";
            lblTitle.Text = " Update Local Driving License Application";
            btnSave.Enabled = true;
            tpApplicationInfo.Enabled = true;
            LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationsByID(LocalDrivingLicenseApplicationID);
        }
        private void _LoadData()
        {
            ctrlPersonCardWithFilter1.LoadPersonInfo(LocalDrivingLicenseApplication.ApplicantPersonID);
            if (LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }
            lblLocalDrivingLicebseApplicationID.Text = LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblFees.Text = LocalDrivingLicenseApplication.PaidFees.ToString();
            lblApplicationDate.Text = clsFormat.DateToShort(LocalDrivingLicenseApplication.ApplicationDate);
            cbLicenseClass.Text = LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblCreatedByUser.Text = LocalDrivingLicenseApplication.CreatedByUserInfo.UserName;

        }
     
        private void frmAddUpdateLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _FillComboBoxWithData();
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        _AddNewStatus();
                        break;
                    }
                case enMode.Update:
                    {
                        _UpdateStatus();
                        _LoadData();
                        break;
                    }
            }
        }
        private void btnApplicationInfoNext_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;             
                tcApplicationInfo.SelectedTab= tcApplicationInfo.TabPages["tpApplicationInfo"];
                return;

            }
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {

                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];

            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //   ctrlPersonCardWithFilter1.FilterFocus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseClassID = clsLicenseClass.Find(cbLicenseClass.Text).LicenseClassID;
           // ctrlPersonCardWithFilter1.PersonID

            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }


            //check if user already have issued license of the same driving  class.
            if (clsLicenses.IsLicenseExistByPersonID(ctrlPersonCardWithFilter1.PersonID, LicenseClassID))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          
           LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID; ;
           LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
           LocalDrivingLicenseApplication.ApplicationTypeID = 1;
           LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
           LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
           LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblFees.Text);
           LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
           LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;


            if (LocalDrivingLicenseApplication.Save())
            {
                lblLocalDrivingLicebseApplicationID.Text = LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                //change form mode to update.
                Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);




        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;

        }
    
       
    }
}
