using DVLD.Class_Global;
using DVLD.Properties;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmAddUpdatePerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNewPerson = 0, UpdatePersonInfo };
        public enum enGendor { Male = 0, Female = 1 };
     
        public enMode Mode { get; set; }
        private int _PersonID { get; set; }
        public clsPerson _Person { get; set; }
        public frmAddUpdatePerson()
        {
            InitializeComponent();
            Mode = enMode.AddNewPerson;

        }
        public frmAddUpdatePerson(int PersonId)
        {
            InitializeComponent();
            Mode = enMode.UpdatePersonInfo;
            _PersonID = PersonId;
            lblPersonID .Text = PersonId.ToString();
        }
        private void FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();
            foreach (DataRow Row in dtCountries.Rows)
            {
                cbCountry.Items.Add(Row["CountryName"]);
            }
        }
        private void FillControlsWithData()
        {
           lblPersonID .Text = _PersonID.ToString();
           txtFirstName.Text = _Person.FirstName;
           txtSecondName.Text = _Person.SecondName;
           txtThirdName.Text = _Person.ThirdName;
           txtLastName.Text= _Person.LastName;
           txtNationalNo .Text = _Person.NationalNo;
           txtAddress .Text = _Person.Address;
           txtEmail .Text = _Person.Email;
           txtPhone .Text = _Person.Phone;
           dtpDateOfBirth.Value = _Person.DateOfBirth;
           cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInfo.CountryName);

            if (rbMale.Checked)
            {
                rbMale.Checked = true;
            }
            else rbFemale.Checked = true;


            if (_Person.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
                llRemoveImage.Visible = true;
            }
            else
            {
                pbPersonImage.Image = (_Person.Gendor == (short)enGendor.Male ? Resources.Male_512 : Resources.Female_512);
                llRemoveImage.Visible = false;
            }

        }
        private bool GetObjectData(int PersonId)
        {
            _Person = clsPerson.FindPersonById(PersonId);
            return _Person != null;

        }
        private void BuildObject()
        {
            _Person = new clsPerson();
        }
        private void ResetDefaultValues()
        {
            FillCountriesInComboBox();
            llRemoveImage.Visible = false;

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";

            cbCountry.SelectedIndex = cbCountry.FindString("Jordan");
            pbPersonImage.Image = Resources.Male_512;
            rbMale.Checked = true;
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            }
        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
           
            ResetDefaultValues();
            switch (Mode)
            {
                case enMode.AddNewPerson:
                    {
                        lblTitle.Text = "Add New Person";
                        BuildObject();
                        break;
                    }
                case enMode.UpdatePersonInfo:
                    {
                        lblTitle.Text = "Update Person Info";

                        if (GetObjectData(_PersonID))
                        { 
                            FillControlsWithData();
                        }
                        else
                        {
                            MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        break;
                    }
            }
        }
        private void LoadDataFromControlsToObject()
        {
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = (string.IsNullOrEmpty(txtThirdName.Text) ? "" : txtThirdName.Text);
            _Person.LastName = txtLastName.Text;
            _Person.Address = txtAddress.Text;
            _Person.Email = (string.IsNullOrEmpty(txtEmail.Text)) ? "" : txtEmail.Text;
            _Person.Phone = txtPhone.Text;
            _Person.Gendor = (rbMale.Checked) ? (short)enGendor.Male : (short)enGendor.Female;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.NationalNo = txtNationalNo.Text;
            _Person.ImagePath = (pbPersonImage.ImageLocation == null) ? "" : pbPersonImage.ImageLocation.ToString();
            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);
            _Person.NationalityCountryId = clsCountry.FindCountyrByName(cbCountry.Text).CountryID;
        }
        private bool _HandlePersonImage()
        {

            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException Iox)
                    {
                        MessageBox.Show(Iox.Message);//.ToString());
                        return false;
                    }
                }
                if (pbPersonImage.ImageLocation != null)
                {
                    string SourceImagePath = pbPersonImage.ImageLocation.ToString();
                    if (clsUtil.CopyImageToTheFolder(ref SourceImagePath))
                    {
                        pbPersonImage.ImageLocation = SourceImagePath;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            } 
                return true;
        
        }
        private bool Save()
        {
            return _Person.Save();
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (sender) as TextBox;
            if (string.IsNullOrEmpty(txt.Text))
            {
                errorProvider1.SetError(txt, string.Format("This Field {0} is required !", txt.Tag));
                return;
                
            }
            else errorProvider1.SetError(txt, null);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if(!_HandlePersonImage())
            {
                return;
            }
            LoadDataFromControlsToObject();

            if (Save())
            {
                MessageBox.Show("This Operation is successfully");
                lblTitle.Text = "Update Person";
                lblPersonID.Text = _Person.PersonId.ToString();
                //    DataBack?.Invoke(this, _Person.PersonId);
                DataBack?.Invoke(this, _Person.PersonId);
            }
            else
                MessageBox.Show("This Operation is faild");


        }
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if(pbPersonImage.ImageLocation!=null)
                return;
            pbPersonImage.Image = Resources.Male_512;
            
        }
        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation != null)
                return;
               pbPersonImage.Image = Resources.Female_512;
        }
        private void llRemoveImage_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.Image = null;
            if (rbMale.Checked)
            {
                pbPersonImage.Image = Resources.Male_512;
            }
            else pbPersonImage.Image = Resources.Female_512;
        }
        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
               pbPersonImage .Load(selectedFilePath);
                llRemoveImage.Visible = true;
                // ...
            }
        }
        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }


            if (txtNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.IsPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number is used for another person!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!clsValidation.ValidateEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }
    }
 }
