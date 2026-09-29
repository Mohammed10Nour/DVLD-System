using DVLD.Class_Global;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD.Login
{
    public partial class frmLogin : Form
    {
        private clsUser _user;
        private short Failed_Trials_Count;
        private bool _FindUser { get; set; }
        public frmLogin()
        {
            InitializeComponent();
        }

  
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
     
        private void _LogErrorToEventLog(string UserName)
        {
            string SourceName = "DVLD Project";
            // Create the event source if it does not exist
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
               
            }
            string LogMessage=  $"[Security Alert]: Multiple failed login attempts detected.\n\n" +
                                $"Target Username: {UserName}\n" +
                                $"Total Failed Attempts: 3\n" +
                                $"Time of Incident: {DateTime.Now}\n" +
                                $"Action Taken: Application terminated automatically.";
            EventLog.WriteEntry(SourceName, LogMessage, EventLogEntryType.Warning);
            Application.Exit();
        }
        private void _CheckTrialsCount(string UserName)
        {



            if (Failed_Trials_Count >= 3)
            {
                MessageBox.Show(
    "Maximum login attempts exceeded (3 failed trials)!\n\n" +
    "Access Denied. The application will now close for security reasons.",
    "Security Alert - Application Terminated",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error

);
                _LogErrorToEventLog(UserName);
            }


            else
            {
                int remainingTrials = 3 - Failed_Trials_Count;
                MessageBox.Show(
        $"Invalid username or password!\n\nYou have ({remainingTrials}) attempts remaining before your account is locked.",
        "Login Failed",
        MessageBoxButtons.OK,
        MessageBoxIcon.Warning
    );

            }
        }
        private void _ClearTextBox()
        {
            txtUserName.Clear();
            txtPassword.Clear();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            string password = clsCryptography.ComputeHash(txtPassword.Text.Trim());
            string username = txtUserName.Text.Trim();
            _user = clsUser.FindByUserNameAndPassword(username,password);
            if (_user != null)
            {
                if (!_user.IsActive)
                {

                    txtUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    clsGlobal.StoreDataInFile(txtUserName.Text.Trim(), txtPassword.Text.Trim(), chkRememberMe.Checked);
                    Failed_Trials_Count = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                clsGlobal.CurrentUser = _user;
                this.Hide();
                Form frm = new frmMain(this);
                frm.ShowDialog();

            }
            else {
                _ClearTextBox();
                Failed_Trials_Count++;
                _CheckTrialsCount(txtUserName.Text.Trim());
                 }
        }
        private void frmLogin_Load_1(object sender, EventArgs e)
        {
            string UserName = ""; string Password = "";
            try
            {
                if (clsGlobal.GetDataFromFile(ref UserName, ref Password))
                {
                    _FindUser = true;
                    txtUserName.Text = UserName;
                    txtPassword.Text = Password;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
