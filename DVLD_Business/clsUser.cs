using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update }
        public enMode Mode = enMode.AddNew;


        public int UserID { get; set; }

        public int PersonID { get; set; }

        public clsPerson PersonInfo;

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public clsUser()
        {
            Mode = enMode.AddNew;
            UserID = -1;
            UserName = "";
            Password = "";
            IsActive = true;
        }

        private clsUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            Mode = enMode.Update;

            this.UserID = UserID;
            this.PersonInfo = clsPerson.FindPersonById(PersonID);
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
        }

        private bool _AddUser()
        {
            this.UserID = clsUserData.AddNewUser(PersonID, UserName, Password, IsActive);
            return this.UserID != -1;
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(UserID, UserName, Password, IsActive);
        }

        public static clsUser FindByUserID(int UserID)
        {
            int PersonID = 0;
            string UserName = "";
            string Password = "";
            bool IsActive = false;

            if (clsUserData.FindUserInfoByUserID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }

            return null;
        }

        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = 0;
            string UserName = "";
            string Password = "";
            bool IsActive = false;

            if (clsUserData.FindUserInfoByPersonID(ref UserID, PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }

            return null;
        }

        public static clsUser FindByUserNameAndPassword(string UserName, string Password)
        {
            int UserID = 0;
            int PersonID = 0;
            bool IsActive = false;

            if (clsUserData.FindUserInfoByUserNameAndPassword(ref UserID, ref PersonID, UserName, Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }

            return null;
        }

        public bool Save()
        {
          
            if (Mode == enMode.AddNew)
            {
                if (_AddUser())
                {
                    Mode = enMode.Update;
                    return true;
                }
            }
            else
            {
                return _UpdateUser();
            }

            return false;
        }

        public static DataTable GetAll()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool Delete(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static bool ExistUserByUserID(int UserID)
        {
            return clsUserData.isUserExist(UserID);
        }

        public static bool ExistUserByUserName(string UserName)
        {
            return clsUserData.isUserExist(UserName);
        }

        public static bool isUserExistForPersonID(int PersonID)
        {
            return clsUserData.isUserExistForPersonID(PersonID);
        }
    }
}
