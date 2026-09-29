using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Business
{
    public class clsLocalDrivingLicenseApplication:clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enIssueReason
        {
            NewLicense = 1,
            RenewLicense,
            ReplaceLicense,
            ReleaseDetained
        }
        public enIssueReason IssueReason = enIssueReason.NewLicense;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo;

        public string PersonFullName
        {
            get { return base.ApplicantFullName; }
        }

        public int _ApplicationID { get; set; }
        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;
            this.Mode = enMode.AddNew;
        }
        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, int ApplicationTypeID,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID, int LicenseClassID) : base(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClassID = LicenseClassID;
            LicenseClassInfo = clsLicenseClass.Find(this.LicenseClassID);
            this.Mode = enMode.Update;

        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            //call DataAccess Layer 

            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication
                (
                this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            //call DataAccess Layer 

            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication
                (
                this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);

        }
        public bool Save()
        {
            base.Mode =(clsApplication.enMode)Mode;
            if(!base.Save())
            {
                return false;
            }
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLocalDrivingLicenseApplication();

            }

            return false;
        }


        public static clsLocalDrivingLicenseApplication FindLocalDrivingLicenseApplicationsByID(int LocalDrivingLicenseApplicationID)
        {
            
            int ApplicationID = 0;
            int LicenseClassID = 0;

            bool IsFound = true;
            IsFound=clsLocalDrivingLicenseApplicationData.FindLocalDrivingLicenseApplicationByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);
           
             if(IsFound)
            {
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);
                if(Application!=null)
                {
                   
                    return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, Application.ApplicationID, Application.ApplicantPersonID, Application.ApplicationDate, Application.ApplicationTypeID,
                        (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
                }
            }
            return null;
        }    
        
        public static clsLocalDrivingLicenseApplication FindLocalDrivingLicenseApplicationsByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = 0;
            int LicenseClassID = 0;

            bool IsFound = true;
            IsFound = clsLocalDrivingLicenseApplicationData.FindLocalDrivingLicenseApplicationByApplicationID(ref LocalDrivingLicenseApplicationID, ApplicationID, ref LicenseClassID);

            if (IsFound)
            {
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);
                if (Application != null)
                {

                    return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, Application.ApplicationID, Application.ApplicantPersonID, Application.ApplicationDate, Application.ApplicationTypeID,
                       (enApplicationStatus) Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
                }
            }
            return null;

        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }

        public  bool Delete(int LocalDrivingLicenseApplicaitonID)
        {
           
               if( clsLocalDrivingLicenseApplicationData.Delete(LocalDrivingLicenseApplicationID))
                {
                   return base.Delete();
                    
                }
            
            return false;

        }

        public clsTest GetLastTestPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTest.FindLastTestPerPersonAndLicenseClass(this.ApplicantPersonID, this.LicenseClassID, TestTypeID);
        }
        public bool IsThereAnActiveScheduledTest(clsTestType.enTestType TestTypeID)

        {

            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)

        {

            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public byte TotalTrialsPerTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public bool DoesAttendTestType(clsTestType.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public  bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public bool DoesPassTestType(clsTestType.enTestType TestTypeID)
        {
            return DoesPassTestType(this.LocalDrivingLicenseApplicationID, TestTypeID);
        }
        public byte GetPassedTestCount()
        {
            return clsTest.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }
        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }
        public int GetActiveLicenseID()
        {
            //this will get the license id that belongs to this application
            return clsLicenses.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }
        public int GetCategoryDefaultValidityPeriod()
        {
            return clsLocalDrivingLicenseApplicationData.GetCategoryDefaultValidityPeriod(this.LicenseClassID);
        }
        public string GetClassNameByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.GetClassNameByLDLAppIDFromDataBase(LocalDrivingLicenseApplicationID);
        }
        public bool PassedAllTests()
        {
            return clsTest.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }
        public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;

            clsDriver Driver = clsDriver.FindByPersonID(this.ApplicantPersonID);

            if (Driver == null)
            {
                //we check if the driver already there for this person.
                Driver = new clsDriver();

                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;
                if (Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = Driver.DriverID;
            }
            //now we diver is there, so we add new licesnse

            clsLicenses License = new clsLicenses();
            License.ApplicationID = this.ApplicationID;
            License.DriverID = DriverID;
            License.LicenseClass = this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            License.Notes = Notes;
            License.PaidFees = this.LicenseClassInfo.ClassFees;
            License.IsActive = true;
            License.IssueReason = clsLicenses.enIssueReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;

            if (License.Save())
            {
                //now we should set the application status to complete.
                this.SetComplete();

                return License.LicenseID;
            }

            else
                return -1;
        }
    }
}
