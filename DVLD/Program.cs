using DVLD.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.User;
using DVLD.Applications;
using DVLD.Applications.Application_Types;
using DVLD.Tests.TestTypes;
using DVLD.Login;
using DVLD.Applications.Local_Driving_License;
using DVLD.Applications.Local_Driving_License;
namespace DVLD
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //  Application.Run(new frmList)
            //  Application.Run(new frmListApplicationTypes());
            //  Application.Run(new frmListPeople());
            //Application.Run(new frmListUsers());
            // Application.Run(new frmFindPerson());
            //Application.Run(new frmListTestTypes());
             Application.Run(new frmLogin());
            //  Application.Run(new frmAddUpdateLocalDrivingLicenseApplication());
            //  Application.Run(new frmLocalDrivingLicenseApplication(36));
       //     Application.Run(new frmAddUpdateLocalDrivingLicenseApplication());
        }
    }
}
