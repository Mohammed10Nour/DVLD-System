using DVLD.Class_Global;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class frmAddUpdateUser : Form
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private int _UserID = -1;

        private clsUser _User;
    
        private void _GetObjectData()
        {

            _User = clsUser.FindByUserID(_UserID);

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }
            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _UserID.ToString();
            txtUserName.Text = _User.UserName.ToString();
            txtPassword.Text = _User.Password.ToString();
            txtConfirmPassword.Text = _User.Password.ToString();
            chkIsActive.Checked = (_User.IsActive) ? true : false;

            tpLoginInfo.Enabled = true;
            btnSave.Enabled = true;
            
        }
        private void _BuildObject()
        {

            _User = new clsUser();
            tpLoginInfo.Enabled = false;
            btnSave.Enabled = false;
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkIsActive.Checked = true;
        }
        private void _ReferechData()
        {
            lblTitle.Text = "Update _User";
            lblUserID.Text = _User.UserID.ToString();

        }
        private void _LoadDataFromControlsToObjectUser()
        {

            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = clsCryptography.ComputeHash(txtPassword.Text.Trim());
            _User.IsActive = (chkIsActive.Checked) ? true : false;
        }
        private void _SaveData()
        {

            if (_User.Save())
            {
                MessageBox.Show("The user information has been saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ReferechData();

            }
            else MessageBox.Show("Failed to save user information. Please try again.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    
     
        public frmAddUpdateUser()
        {

            InitializeComponent();
            _Mode = enMode.AddNew;
         
        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
          
        }  
        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        lblTitle.Text = "Add New User";
                        this.Text = "Add New User";
                        _BuildObject();
                        break;
                    }
                case enMode.Update:
                    {
                        lblTitle.Text = "Update User";
                        this.Text = "Update User";
                        _GetObjectData();
                       
                         break;
                    }
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            { return; }
            _LoadDataFromControlsToObjectUser();
            _SaveData();

        }
        private void btnPersonInfoNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                return;
            }

         
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {

                if (clsUser.isUserExistForPersonID(ctrlPersonCardWithFilter1.PersonID ))
                {

                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }

                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                }
            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
             

            }

        }
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
            if (_Mode == enMode.AddNew)
            {

                if (clsUser.ExistUserByUserName(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                }
               ;
            }
            else
            {
                //incase update make sure not to use anothers user name
                if (_User.UserName != txtUserName.Text.Trim())
                {
                    if (clsUser.ExistUserByUserName(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    }

                }
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
            ;
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
            ;
        }
    }
    }



      