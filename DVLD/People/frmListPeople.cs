using DVLD.User;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmListPeople : Form
    {

        private static DataTable _dtAllData= clsPerson.GetAllPeople();
        private DataTable _dtPeople= _dtAllData.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName", "DateOfBirth", "GendorCaption", "Address", "Phone", "Email");      
       private void _InitializationControls()
            {
            _dtAllData = clsPerson.GetAllPeople();

            _dtPeople = _dtAllData.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            dgvPeople.DataSource = _dtPeople;

            if (dgvPeople.Rows.Count > 0)
            {
                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 70;

                dgvPeople.Columns[1].HeaderText = "National No";
                dgvPeople.Columns[1].Width = 80;


                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 120;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[3].Width = 140;


                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[4].Width = 120;

                dgvPeople.Columns[5].HeaderText = "Last Name";
                dgvPeople.Columns[5].Width = 120;

                dgvPeople.Columns[6].HeaderText = "Date Of Birth";
                dgvPeople.Columns[6].Width = 140;

                dgvPeople.Columns[7].HeaderText = "Address";
                dgvPeople.Columns[7].Width = 160;


                dgvPeople.Columns[8].HeaderText = "Phone";
                dgvPeople.Columns[8].Width = 120;

                dgvPeople.Columns[9].HeaderText = "Email";
                dgvPeople.Columns[9].Width = 120;

                dgvPeople.Columns[10].HeaderText = "Country";
                dgvPeople.Columns[10].Width = 120;
            }
            cbFilterBy.Text = "None";
            txtFilterValue.Select();
            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
        }
       private void _FilterData()
        {
            string FilterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }
            if (string.IsNullOrEmpty(txtFilterValue.Text)|| FilterColumn == "None" )
            {
                _dtPeople.DefaultView.RowFilter = "";
            }
            else 
            {
                if (FilterColumn != "PersonID")
                {
                    _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
                }
                else _dtPeople.DefaultView.RowFilter = string.Format("[{0}] ={1}", FilterColumn, txtFilterValue.Text.Trim());


            }
            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
        }
        public frmListPeople()
            {
                InitializeComponent();
            }
       private void txtFilterValue_TextChanged(object sender, EventArgs e)
            {
            _FilterData();
            }
       private void frmListPeople_Load(object sender, EventArgs e)
            {
            _InitializationControls();
             }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
        txtFilterValue.Visible = (cbFilterBy.Text != "None");

        }
        private void txtFilterValue_TextChanged_1(object sender, EventArgs e)
        {
            _FilterData();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID")
            {
                e.Handled = (!Char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            frmListPeople_Load(null, null);
        }
        private void ShowDetails_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListPeople_Load(null, null);
        }
        private void AddNewPerson_Click(object sender, EventArgs e)
        {
            btnAddPerson.PerformClick();
            frmListPeople_Load(null, null);
        }
        private void EditPersonInfo_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListPeople_Load(null, null);

        }
        private void DeletePerson_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsPerson.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 //   frmListPeople_Load(null,null)
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            frmListPeople_Load(null, null);
        }
        private void dgvPeople_DoubleClick(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value );//frmShowPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListPeople_Load(null, null);
        }
    }
 
}
