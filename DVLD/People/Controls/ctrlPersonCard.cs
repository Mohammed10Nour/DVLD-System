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

namespace DVLD.People.Controls
{
        
    public partial class ctrlPersonCard : UserControl
    {
        private frmAddUpdatePerson frmAddUpdatePerson;
        private clsPerson  _Person;
        public clsPerson SelecedPersonInfo
        {
            get { return _Person; }
        }

        private int _PersonID=-1;
        public int PersonID 
        {
            get { return _PersonID; }
            set { _PersonID = value; }

        }
        private void _LoadPersonImage()
        {
            string ImagePath = _Person.ImagePath;
            if (!string.IsNullOrEmpty(ImagePath))
            {
                if(File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_Person.Gendor == 0)
            {
                pbPersonImage .Image = Resources.Male_512;
            }
            else
            {
                pbPersonImage.Image = Resources.Female_512;
            }
        }
        public void DefaultControls()
        {
            this._PersonID = -1;
        //
            lblPersonID.Text = "[????]";
           lblFullName .Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblGendor.Text = "[????]";
            lblEmail.Text = "[????]";
            lblAddress.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblPhone.Text = "[????]";
            lblCountry.Text = "[????]";
            pbPersonImage.Image = Resources.Male_512;

        }
        private void LoadDataFromObjectToControls()
        {

            PersonID = _Person.PersonId;
            lblPersonID .Text = _Person.PersonId.ToString();

            lblFullName .Text = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;

            lblNationalNo.Text = _Person.NationalNo;

            lblGendor.Text = (_Person.Gendor != 0) ? "Female" : "Male";

            lblEmail.Text = (string.IsNullOrEmpty(_Person.Email)) ? "" : _Person.Email;

            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString();
            lblPhone.Text = _Person.Phone;

            lblCountry.Text = _Person.CountryInfo.CountryName.ToString();

            _LoadPersonImage();
        }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }
        public void GetPersonDataByPersonID(int PersonID)
        {
            _PersonID = PersonID;
            _Person = clsPerson.FindPersonById(_PersonID);
            if (_Person != null)
            {
                LoadDataFromObjectToControls();
            }
            else
            {
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DefaultControls();
                return;
            }

        }
        public void GetPersonDataByNationalNO(string NationalNo)
        {
            _Person = clsPerson.FindPersonByNationalNo(NationalNo);
            if (_Person != null)
            {
                LoadDataFromObjectToControls();
            }
            else
            {
                MessageBox.Show("No Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DefaultControls();
                return;
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson = new frmAddUpdatePerson(_Person.PersonId);
            frmAddUpdatePerson.ShowDialog();
            GetPersonDataByPersonID(_Person.PersonId);
        }
    }
}
