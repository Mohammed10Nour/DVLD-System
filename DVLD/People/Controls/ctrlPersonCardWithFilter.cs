using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DVLD_Business;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {


        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID);
            }
        }


        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }

            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Enabled = _ShowAddPerson;
            }
        }


        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }


       private int _PersonID=-1;

        public int PersonID
        {

            get { return ctrlPersonCard1.PersonID; }

        }
        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonCard1.SelecedPersonInfo; }
        }

        private string _NationalNo;
        public string NationalNo
        {
            set { _NationalNo = value; }
            get { return _NationalNo; }

        }
        private void _LoadDataFromObjectToControls(int PersonID)
        {
            ctrlPersonCard1.GetPersonDataByPersonID(PersonID);
        }
        private void _LoadDataFromObjectToControls(string NationalNo)
        {
            ctrlPersonCard1.GetPersonDataByNationalNO(NationalNo);
        }
        private void _FindPersonInfo()
        {
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    {
                        _PersonID = int.Parse(txtFilterValue.Text.Trim());                     
                        _LoadDataFromObjectToControls(_PersonID);
                        break;
                    }

                case "National No":
                    {
                        NationalNo = txtFilterValue.Text.Trim();                     
                        _LoadDataFromObjectToControls(NationalNo);
                        break;
                    }
                default: break;
            }
            if (OnPersonSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnPersonSelected(ctrlPersonCard1.PersonID);


        }
        public void LoadPersonInfo(int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            FilterEnabled = false;
            txtFilterValue.Text = PersonID.ToString();
            _FindPersonInfo();
        }
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
           
        }
     
        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            //txtFilterValue.Focus();
            cbFilterBy.SelectedIndex = 0;
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
                return;

                    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                 }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ctrlPersonCard1.DefaultControls();
               txtFilterValue.Clear();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            
            if (!this.ValidateChildren())
            {
                return;
            }

            _FindPersonInfo();
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            cbFilterBy.Enabled = true;
            txtFilterValue.Enabled = true;
            txtFilterValue.Clear();
            ctrlPersonCard1.DefaultControls();
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.DataBack += _LoadNewData;
            frm.ShowDialog();

        }
        private void _LoadNewData(object sender, int PersonID)
        {

            cbFilterBy.SelectedIndex = 1;
            ctrlPersonCard1.GetPersonDataByPersonID(PersonID);
            cbFilterBy.Enabled = false;
            txtFilterValue.Text = PersonID.ToString();
            txtFilterValue.Enabled = false;
            _FilterEnabled = false;
            btnAddNewPerson.Enabled = false;
            btnFind.Enabled = false;
        }
        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {

                errorProvider1.SetError(txtFilterValue, null);
            }
        }
    }
}