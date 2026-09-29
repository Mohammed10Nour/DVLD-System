using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_Business
{
    public class clsPerson
    {
       
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
            
        public int PersonId
            {
            get;
            set;
            }      
        public string NationalNo
            {
            get;
            set;
            }
        public string FirstName
        {
            get;
            set;
            }    
        public string SecondName
            {
            get;
            set;
            }        
        public string ThirdName
            {
            get;set;
            }    
        public string LastName
            {
            get;
            set;
            }       
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + (string.IsNullOrWhiteSpace(ThirdName) ? "" : ThirdName + " " + LastName); }
        }
        public int Gendor
            {
            get;
            set;
            }       
        public string Email
            {
            get;
            set;
            }    
        public string Address
            {
            get;set;
            }
        public string Phone
            {
            get;set;
            }

        private DateTime _DateOfBirth;
        public DateTime DateOfBirth
            {
                get { return _DateOfBirth; }
                set { _DateOfBirth = value; }
            }

        private int _NationalityCountryId;
        public int NationalityCountryId
            {
                get { return _NationalityCountryId; }
                set { _NationalityCountryId = value; }
            }
        public clsCountry CountryInfo;
        private string _ImagePath;
        public string ImagePath
            {
                get { return _ImagePath; }
                set { _ImagePath = value; }
            }  
        public clsPerson()
            {
                Mode = enMode.AddNew;
                this.PersonId = 0;

                this.NationalNo = "";
                this.FirstName = "";
                this.SecondName = "";
                this.ThirdName = "";
                this.LastName = "";
                this.DateOfBirth = DateTime.Now;
                this.Gendor = 0;
                this.Address = "";
                this.Phone = "";
                this.Email = "";
                this.NationalityCountryId = 0;
                this.ImagePath = "";
            }
        private clsPerson(int PersonId, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, int NationalityCountryId, string ImagePath)
            {
                Mode = enMode.Update;
                this.PersonId = PersonId;
                this.NationalNo = NationalNo;
                this.FirstName = FirstName;
                this.SecondName = SecondName;
                this.ThirdName = ThirdName;
                this.LastName = LastName;
                this.Gendor = Gendor;
                this.Email = Email;
                this.Address = Address;
                this.Phone = Phone;
                this.DateOfBirth = DateOfBirth;
                this.NationalityCountryId = NationalityCountryId;
                this.CountryInfo = clsCountry.FindCountyrByCountryID(NationalityCountryId);
                this.ImagePath = ImagePath;
            }
        private bool _AddNewPerson()
            {

                this.PersonId =clsPersonData.AddNewPersonToDataBase(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                    this.LastName, this.DateOfBirth, this.Gendor, this.Address
                    , this.Phone, this.Email, this.NationalityCountryId, this.ImagePath);
                return this.PersonId != -1;
            }
        private bool _UpdatePerson()
            {
                return clsPersonData.UpdatePersonInfoInDataBase(this.PersonId, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                     this.LastName, this.DateOfBirth, this.Gendor, this.Address
                     , this.Phone, this.Email, this.NationalityCountryId, this.ImagePath);
            }
        public static clsPerson FindPersonById(int PersonId)
            {
                string NationalNo = ""; string FirstName = ""; string SecondName = ""; string ThirdName = ""; string LastName = ""; DateTime DateOfBirth = DateTime.Now;
                int Gendor = 0; string Address = ""; string Phone = ""; string Email = ""; int NationalityCountryId = 0; string ImagePath = "";

                if (clsPersonData.FindPersonInDataBaseByID(PersonId, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryId, ref ImagePath))
                {
                    return new clsPerson(PersonId, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryId, ImagePath);
                }
                else
                    return null;

            }
        public static clsPerson FindPersonByNationalNo(string NationalNo)
            {
                int PersonID = 0; string FirstName = ""; string SecondName = ""; string ThirdName = ""; string LastName = ""; DateTime DateOfBirth = DateTime.Now;
                int Gendor = 0; string Address = ""; string Phone = ""; string Email = ""; int NationalityCountryId = 0; string ImagePath = "";

                if (clsPersonData.FindPersonInDataBaseByNationalNo(ref PersonID, NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryId, ref ImagePath))
                {
                    return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryId, ImagePath);
                }
                else
                    return null;

            }
        public bool Save()
            {
                if (Mode == enMode.AddNew)
                {
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                }
                return _UpdatePerson();
            }
        public static DataTable GetAllPeople()
            {
              
               return clsPersonData.GetAllPeopleFromDataBase();
              
            }
        public static bool DeletePerson(int PersonID)
            {
                return clsPersonData.DeletePersonFromDataBase(PersonID);
            }
        public static bool IsPersonExist(int PersonID)
            {
                return clsPersonData.IsPersonExist(PersonID);
            }
        public static bool IsPersonExist(string NationalNO)
            {
                return clsPersonData.IsPersonExist(NationalNO);
            }
       
        }
    }
